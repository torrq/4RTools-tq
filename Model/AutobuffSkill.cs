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

        private static readonly Dictionary<Key, string> _sendKeysMap = new Dictionary<Key, string>()
         {
             { Key.D0, "0" },
             { Key.D1, "1" },
             { Key.D2, "2" },
             { Key.D3, "3" },
             { Key.D4, "4" },
             { Key.D5, "5" },
             { Key.D6, "6" },
             { Key.D7, "7" },
             { Key.D8, "8" },
             { Key.D9, "9" }
         };

        private string ToSendKeysFormat(Key key)
        {
            if (_sendKeysMap.TryGetValue(key, out string value))
            {
                return value;
            }
            return key.ToString().ToLower();
        }

        public _4RThread AutoBuffThread(Client c)
        {
            _4RThread autobuffItemThread = new _4RThread(_ =>
            {
                bool foundQuag = false;
                bool foundDecreaseAgi = false;
                string currentMap = c.ReadCurrentMap();
                UserPreferences prefs = ProfileSingleton.GetCurrent().UserPreferences;

                    if (!prefs.stopBuffsCity || !this.listCities.Contains(currentMap))
                    {
                        List<EffectStatusIDs> currentBuffs = new List<EffectStatusIDs>();
                        Dictionary<EffectStatusIDs, Key> buffsToApply = new Dictionary<EffectStatusIDs, Key>(this.buffMapping);

                        for (int i = 1; i < Constants.MAX_BUFF_LIST_INDEX_SIZE; i++)
                        {
                            uint currentStatusValue = c.CurrentBuffStatusCode(i);

                            if (currentStatusValue == uint.MaxValue) { continue; }

                            EffectStatusIDs status = (EffectStatusIDs)currentStatusValue;
                            currentBuffs.Add(status);

                            HandleOverweightStatus(c, status);

                            if (status == EffectStatusIDs.OVERTHRUSTMAX && buffsToApply.ContainsKey(EffectStatusIDs.OVERTHRUST))
                            {
                                buffsToApply.Remove(EffectStatusIDs.OVERTHRUST);
                            }

                            if (buffMapping.ContainsKey(status)) //CHECK IF STATUS EXISTS IN STATUS LIST AND DO ACTION
                            {
                                buffsToApply.Remove(status);
                            }

                            if (status == EffectStatusIDs.QUAGMIRE) foundQuag = true;
                            if (status == EffectStatusIDs.DECREASE_AGI) foundDecreaseAgi = true;
                        }

                        if (!currentBuffs.Contains(EffectStatusIDs.RIDDING))
                        {
                            foreach (var buffToApply in buffsToApply)
                            {
                                if (ShouldSkipBuffDueToQuag(foundQuag, buffToApply.Key))
                                {
                                    continue; // Use continue instead of break to check other buffs
                                }

                                if (ShouldSkipBuffDueToDecreaseAgi(foundDecreaseAgi, buffToApply.Key))
                                {
                                    continue; // Use continue instead of break to check other buffs
                                }

                                if (c.ReadCurrentHp() >= Constants.MINIMUM_HP_TO_RECOVER)
                                {
                                    this.useAutobuff(buffToApply.Value);
                                    Thread.Sleep(delay);
                                }
                            }
                        }
                        currentBuffs.Clear();
                    }
                Thread.Sleep(300);
                return 0;
            });

            return autobuffItemThread;
        }
        private void HandleOverweightStatus(Client c, EffectStatusIDs status)
        {
            if (status == EffectStatusIDs.WEIGHT50 && ProfileSingleton.GetCurrent().UserPreferences.overweightMode == "overweight50")
            {
                SendOverweightMacro(c, "50");
                var frmToggleApplication = (ToggleApplicationStateForm)Application.OpenForms["ToggleApplicationStateForm"];
                frmToggleApplication.toggleStatus();
                DebugLogger.Info("Overweight 50%, disable now");
            }
            else if (status == EffectStatusIDs.WEIGHT90 && ProfileSingleton.GetCurrent().UserPreferences.overweightMode == "overweight90")
            {
                SendOverweightMacro(c, "90");
                DebugLogger.Info("Overweight 90%, disable now");
                var frmToggleApplication = (ToggleApplicationStateForm)Application.OpenForms["ToggleApplicationStateForm"];
                frmToggleApplication.toggleStatus();
            }
        }

        private void SendOverweightMacro(Client c, string percentage)
        {
            if (!string.IsNullOrEmpty(ProfileSingleton.GetCurrent().UserPreferences.overweightKey.ToString()))
            {
                // Set focus to the RO window
                IntPtr handle = ClientSingleton.GetClient().process.MainWindowHandle;
                SetForegroundWindow(handle);
                // send ALT-# by the only way that seems to work
                System.Windows.Forms.SendKeys.SendWait("%" + ToSendKeysFormat(ProfileSingleton.GetCurrent().UserPreferences.overweightKey));
                DebugLogger.Info($"Overweight {percentage}%, sent macro: Alt + " + ProfileSingleton.GetCurrent().UserPreferences.overweightKey.ToString());
            }
        }
        private bool ShouldSkipBuffDueToQuag(bool foundQuag, EffectStatusIDs buffKey)
        {
            return foundQuag && (buffKey == EffectStatusIDs.CONCENTRATION || buffKey == EffectStatusIDs.INC_AGI || buffKey == EffectStatusIDs.TRUESIGHT || buffKey == EffectStatusIDs.ADRENALINE || buffKey == EffectStatusIDs.SPEARQUICKEN || buffKey == EffectStatusIDs.ONEHANDQUICKEN || buffKey == EffectStatusIDs.WINDWALK || buffKey == EffectStatusIDs.TWOHANDQUICKEN);
        }

        private bool ShouldSkipBuffDueToDecreaseAgi(bool foundDecreaseAgi, EffectStatusIDs buffKey)
        {
            return foundDecreaseAgi && (buffKey == EffectStatusIDs.TWOHANDQUICKEN || buffKey == EffectStatusIDs.ADRENALINE || buffKey == EffectStatusIDs.ADRENALINE2 || buffKey == EffectStatusIDs.ONEHANDQUICKEN || buffKey == EffectStatusIDs.SPEARQUICKEN);
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
