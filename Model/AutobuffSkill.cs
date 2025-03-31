using System;
using System.Threading;
using System.Windows.Input;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using _4RTools.Utils;
using _4RTools.Forms;
using System.Runtime.InteropServices;

namespace _4RTools.Model
{

    public class AutoBuffSkill : Action
    {
        public static string ACTION_NAME_AUTOBUFFSKILL = "AutobuffSkill";
        public string actionName { get; set; }
        private _4RThread thread;
        public int delay { get; set; } = 100;
        public List<String> listCities { get; set; }

        public Dictionary<EffectStatusIDs, Key> buffMapping = new Dictionary<EffectStatusIDs, Key>();

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public AutoBuffSkill(string actionName)
        {
            this.actionName = actionName;
        }

        public void Start()
        {
            Stop();
            Client roClient = ClientSingleton.GetClient();
            if (roClient != null)
            {
                if (this.thread != null)
                {
                    _4RThread.Stop(this.thread);
                }
                if (this.listCities == null || this.listCities.Count == 0) this.listCities = LocalServerManager.GetListCities();
                this.thread = AutoBuffThread(roClient);
                _4RThread.Start(this.thread);
            }
        }

        private string ToSendKeysFormat(Key key)
        {
            switch (key)
            {
                case Key.D0: return "0";
                case Key.D1: return "1";
                case Key.D2: return "2";
                case Key.D3: return "3";
                case Key.D4: return "4";
                case Key.D5: return "5";
                case Key.D6: return "6";
                case Key.D7: return "7";
                case Key.D8: return "8";
                case Key.D9: return "9";
                default: return key.ToString().ToLower();
            }
        }

        public _4RThread AutoBuffThread(Client c)
        {
            _4RThread autobuffItemThread = new _4RThread(_ =>
            {
                bool foundQuag = false;
                bool foundDecreaseAgi = false;
                string currentMap = c.ReadCurrentMap();
                if (!hasBuff(c, EffectStatusIDs.ANTI_BOT) || !ProfileSingleton.GetCurrent().UserPreferences.stopSpammersBot)
                {
                    if (!ProfileSingleton.GetCurrent().UserPreferences.stopBuffsCity || this.listCities.Contains(currentMap) == false)
                    {
                        List<EffectStatusIDs> buffs = new List<EffectStatusIDs>();
                        Dictionary<EffectStatusIDs, Key> bmClone = new Dictionary<EffectStatusIDs, Key>(this.buffMapping);
                        for (int i = 1; i < Constants.MAX_BUFF_LIST_INDEX_SIZE; i++)
                        {
                            uint currentStatus = c.CurrentBuffStatusCode(i);

                            if (currentStatus == uint.MaxValue) { continue; }

                            buffs.Add((EffectStatusIDs)currentStatus);
                            EffectStatusIDs status = (EffectStatusIDs)currentStatus;

                            if (status == EffectStatusIDs.WEIGHT50 && ProfileSingleton.GetCurrent().UserPreferences.overweightMode == "overweight50")
                            {
                                if (!string.IsNullOrEmpty(ProfileSingleton.GetCurrent().UserPreferences.overweightKey.ToString()))
                                {
                                    // Set focus to the RO window
                                    IntPtr handle = ClientSingleton.GetClient().process.MainWindowHandle;
                                    SetForegroundWindow(handle);
                                    // send ALT-# by the only way that seems to work
                                    System.Windows.Forms.SendKeys.SendWait("%" + ToSendKeysFormat(ProfileSingleton.GetCurrent().UserPreferences.overweightKey));
                                    DebugLogger.Info("Overweight 50%, sent macro: Alt + " + ProfileSingleton.GetCurrent().UserPreferences.overweightKey.ToString());
                                }
                                var frmToggleApplication = (ToggleApplicationStateForm)Application.OpenForms["ToggleApplicationStateForm"];
                                frmToggleApplication.toggleStatus();
                                DebugLogger.Info("Overweight 50%, disable now");

                            }

                            if (status == EffectStatusIDs.WEIGHT90 && ProfileSingleton.GetCurrent().UserPreferences.overweightMode == "overweight90")
                            {
                                if (!string.IsNullOrEmpty(ProfileSingleton.GetCurrent().UserPreferences.overweightKey.ToString()))
                                {
                                    // Set focus to the RO window
                                    IntPtr handle = ClientSingleton.GetClient().process.MainWindowHandle;
                                    SetForegroundWindow(handle);
                                    // send ALT-# by the only way that seems to work
                                    System.Windows.Forms.SendKeys.SendWait("%" + ToSendKeysFormat(ProfileSingleton.GetCurrent().UserPreferences.overweightKey));
                                    DebugLogger.Info("Overweight 90%, sent macro: Alt + " + ProfileSingleton.GetCurrent().UserPreferences.overweightKey.ToString());
                                }
                                DebugLogger.Info("Overweight 90%, disable now");
                                var frmToggleApplication = (ToggleApplicationStateForm)Application.OpenForms["ToggleApplicationStateForm"];
                                frmToggleApplication.toggleStatus();
                            }

                            if (status == EffectStatusIDs.OVERTHRUSTMAX)
                            {
                                if (buffMapping.ContainsKey(EffectStatusIDs.OVERTHRUST))
                                {
                                    bmClone.Remove(EffectStatusIDs.OVERTHRUST);
                                }
                            }

                            if (bmClone.ContainsKey(EffectStatusIDs.EDEN))
                            {
                                bmClone.Remove(EffectStatusIDs.EDEN);
                            }

                            if (buffMapping.ContainsKey(status)) //CHECK IF STATUS EXISTS IN STATUS LIST AND DO ACTION
                            {
                                bmClone.Remove(status);
                            }

                            if (status == EffectStatusIDs.QUAGMIRE) foundQuag = true;
                            if (status == EffectStatusIDs.DECREASE_AGI) foundDecreaseAgi = true;
                        }
                        if (!buffs.Contains(EffectStatusIDs.ANTI_BOT) || !ProfileSingleton.GetCurrent().UserPreferences.stopSpammersBot)
                        {
                            if (!buffs.Contains(EffectStatusIDs.RIDDING))
                            {
                                foreach (var item in bmClone)
                                {
                                    if (foundQuag && (item.Key == EffectStatusIDs.CONCENTRATION || item.Key == EffectStatusIDs.INC_AGI || item.Key == EffectStatusIDs.TRUESIGHT || item.Key == EffectStatusIDs.ADRENALINE || item.Key == EffectStatusIDs.SPEARQUICKEN || item.Key == EffectStatusIDs.ONEHANDQUICKEN || item.Key == EffectStatusIDs.WINDWALK || item.Key == EffectStatusIDs.TWOHANDQUICKEN))
                                    {
                                        break;
                                    }
                                    else if (foundDecreaseAgi && (item.Key == EffectStatusIDs.TWOHANDQUICKEN || item.Key == EffectStatusIDs.ADRENALINE || item.Key == EffectStatusIDs.ADRENALINE2 || item.Key == EffectStatusIDs.ONEHANDQUICKEN || item.Key == EffectStatusIDs.SPEARQUICKEN))
                                    {
                                        break;
                                    }
                                    else if (c.ReadCurrentHp() >= Constants.MINIMUM_HP_TO_RECOVER)
                                    {
                                        this.useAutobuff(item.Value);
                                        Thread.Sleep(delay);
                                    }
                                }
                            }
                        }
                        buffs.Clear();
                    }
                }
                Thread.Sleep(300);
                return 0;
            });

            return autobuffItemThread;
        }
        private bool hasBuff(Client c, EffectStatusIDs buff)
        {
            for (int i = 1; i < Constants.MAX_BUFF_LIST_INDEX_SIZE; i++)
            {
                uint currentStatus = c.CurrentBuffStatusCode(i);
                if (currentStatus == (int)buff) { return true; }
            }
            return false;
        }
        public void AddKeyToBuff(EffectStatusIDs status, Key key)
        {
            if (buffMapping.ContainsKey(status))
            {
                buffMapping.Remove(status);
            }

            if (FormUtils.IsValidKey(key))
            {
                buffMapping.Add(status, key);
            }
        }

        public void setBuffMapping(Dictionary<EffectStatusIDs, Key> buffs)
        {
            this.buffMapping = new Dictionary<EffectStatusIDs, Key>(buffs);
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
            return this.actionName;
        }

        private void useAutobuff(Key key)
        {
            if ((key != Key.None) && !Keyboard.IsKeyDown(Key.LeftAlt) && !Keyboard.IsKeyDown(Key.RightAlt))
                Interop.PostMessage(ClientSingleton.GetClient().process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, (Keys)Enum.Parse(typeof(Keys), key.ToString()), 0);
        }
    }
}
