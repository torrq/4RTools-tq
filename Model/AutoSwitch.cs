using System;
using System.Threading;
using System.Windows.Input;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using _4RTools.Utils;
using System.Linq;

namespace _4RTools.Model
{

    public class AutoSwitch : Action
    {
        public static string ACTION_NAME_AUTOSWITCH = "AutoSwitch";
        public const string item = "ITEM";
        public const string skill = "SKILL";
        public const string nextItem = "NEXTITEM";

        private _4RThread thread;
        public int delay { get; set; } = 1000;
        public Dictionary<EffectStatusIDs, Key> buffMapping = new Dictionary<EffectStatusIDs, Key>();
        public List<AutoSwitchConfig> autoSwitchMapping = new List<AutoSwitchConfig>();
        public List<AutoSwitchConfig> autoSwitchGenericMapping = new List<AutoSwitchConfig>();
        public List<String> listCities { get; set; }

        public class AutoSwitchConfig
        {
            public EffectStatusIDs skillId { get; set; }
            public Key itemKey { get; set; }
            public Key skillKey { get; set; }
            public Key nextItemKey { get; set; }

            public AutoSwitchConfig (EffectStatusIDs id, Key key, String type = null)
            {
                this.skillId = id;
                if(type != null)
                {
                    switch (type)
                    {
                        case item:
                            this.itemKey = key;
                            break;

                        case skill:
                            this.skillKey = key;
                            break;

                        case nextItem:
                            this.nextItemKey = key;
                            break;
                    }

                }
            }

            //public AutoSwitchConfig (EffectStatusIDs id)
            //{
            //    this.skillId = id;
            //    this.itemKey = 0;
            //    this.skillKey = 0;
            //    this.nextItemKey = 0;
            //}
        }

        public void Start()
        {
            Client roClient = ClientSingleton.GetClient();
            if (roClient != null)
            {
                if (this.thread != null)
                {
                    _4RThread.Stop(this.thread);
                }
                if (this.listCities == null || this.listCities.Count == 0) this.listCities = LocalServerManager.GetListCities();
                this.thread = AutoSwitchThread(roClient);
                _4RThread.Start(this.thread);
            }
        }

        public _4RThread AutoSwitchThread(Client c)
        {
            bool equipVajra = false;
            int contVajra = 0;
            _4RThread autobuffItemThread = new _4RThread(_ =>
                {
                    List<AutoSwitchConfig> skillClone = new List<AutoSwitchConfig>(this.autoSwitchMapping.Where(x => x.itemKey != Key.None));
                    List<AutoSwitchConfig> skillCloneGeneric = new List<AutoSwitchConfig>(this.autoSwitchGenericMapping.Where(x => x.itemKey != Key.None));
                    string currentMap = c.ReadCurrentMap();
                    if (!ProfileSingleton.GetCurrent().UserPreferences.stopBuffsCity || this.listCities.Contains(currentMap) == false)
                    {
                        for (int i = 1; i < Constants.MAX_BUFF_LIST_INDEX_SIZE; i++)
                        {
                            uint currentStatus = c.CurrentBuffStatusCode(i);

                            if (currentStatus == uint.MaxValue) { continue; }

                            EffectStatusIDs status = (EffectStatusIDs)currentStatus;

                            if (autoSwitchMapping.Exists(x => x.skillId == status))
                            {
                                skillClone = skillClone.Where(skill => skill.skillId != status).ToList();
                            }

                            if (autoSwitchGenericMapping.Exists(x => x.skillId == status))
                            {
                                skillCloneGeneric = skillCloneGeneric.Where(skill => skill.skillId != status).ToList();
                            }

                            if (status == EffectStatusIDs.THURISAZ)
                            {
                                if (equipVajra == true)
                                {
                                    equipVajra = false;
                                    this.equipNextItem(autoSwitchMapping.FirstOrDefault(x => x.skillId == EffectStatusIDs.THURISAZ).nextItemKey);
                                }
                            }

                        }

                        skillClone.AddRange(skillCloneGeneric);
                        foreach (var skill in skillClone)
                        {

                            if (skill.skillId == EffectStatusIDs.THURISAZ)
                            {
                                contVajra++;

                                if (contVajra > 50) { contVajra = 0; equipVajra = false; }

                                if (!equipVajra)
                                {
                                    Thread.Sleep(100);
                                    this.useAutobuff(skill.itemKey, skill.skillKey);
                                    equipVajra = true;
                                }

                            }
                            else if (c.ReadCurrentSp() > 8)
                            {
                                this.useAutobuff(skill.itemKey, skill.skillKey);
                                Thread.Sleep(delay);
                                this.equipNextItem(skill.nextItemKey);
                                equipVajra = false;
                                Thread.Sleep(3000);
                            }

                        }
                    }
                    Thread.Sleep(300);
                    return 0;

                });

            return autobuffItemThread;
        }

        public void ClearKeyMapping()
        {
            buffMapping.Clear();
        }

        public void Stop()
        {
            _4RThread.Stop(this.thread);
        }

        public string GetConfiguration()
        {
            return JsonConvert.SerializeObject(this);
        }

        public string GetActionName()
        {
            return ACTION_NAME_AUTOSWITCH;
        }

        private void useAutobuff(Key item, Key skill)
        {
            if ((item != Key.None) && !Keyboard.IsKeyDown(Key.LeftAlt) && !Keyboard.IsKeyDown(Key.RightAlt))
                Interop.PostMessage(ClientSingleton.GetClient().process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, (Keys)Enum.Parse(typeof(Keys), item.ToString()), 0);
            Thread.Sleep(100);
            if ((skill != Key.None) && !Keyboard.IsKeyDown(Key.LeftAlt) && !Keyboard.IsKeyDown(Key.RightAlt))
                Interop.PostMessage(ClientSingleton.GetClient().process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, (Keys)Enum.Parse(typeof(Keys), skill.ToString()), 0);
        }

        private void equipNextItem(Key next)
        {
            if ((next != Key.None) && !Keyboard.IsKeyDown(Key.LeftAlt) && !Keyboard.IsKeyDown(Key.RightAlt))
                Interop.PostMessage(ClientSingleton.GetClient().process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, (Keys)Enum.Parse(typeof(Keys), next.ToString()), 0);
        }
    }
}
