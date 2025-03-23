using _4RTools.Forms;
using _4RTools.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
namespace _4RTools.Model
{
    public class DebuffsRecovery : Action
    {
        public static string ACTION_NAME_DEBUFF_RECOVERY = "DebuffsRecovery";
        public static string ACTION_NAME_WEIGHT_DEBUFF_RECOVERY = "WeightDebuffsRecovery";

        private _4RThread thread;
        public Dictionary<EffectStatusIDs, Key> buffMapping = new Dictionary<EffectStatusIDs, Key>();
        public int delay { get; set; } = 1;

        private string actionName;

        private Dictionary<uint, DateTime> lastKeyPressTimes = new Dictionary<uint, DateTime>();
        private Dictionary<uint, int> keyPressCount = new Dictionary<uint, int>();
        private const int MAX_KEY_PRESS_COUNT = 2;
        private const int MIN_KEY_PRESS_INTERVAL_MS = 1500;

        private ToggleApplicationStateForm frmToggleApplication = new ToggleApplicationStateForm();

        // Default constructor
        public DebuffsRecovery() : this(ACTION_NAME_DEBUFF_RECOVERY)
        {
        }

        // Constructor with custom action name
        public DebuffsRecovery(string actionName)
        {
            this.actionName = actionName;
        }

        public string GetActionName()
        {
            return this.actionName;
        }

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public _4RThread RestoreStatusThread(Client c)
        {
            Client roClient = ClientSingleton.GetClient();
            _4RThread statusEffectsThread = new _4RThread(_ =>
            {
                if (!hasBuff(roClient, EffectStatusIDs.ANTI_BOT) || !ProfileSingleton.GetCurrent().UserPreferences.stopSpammersBot)
                {
                    for (int i = 0; i <= Constants.MAX_BUFF_LIST_INDEX_SIZE - 1; i++)
                    {
                        uint currentStatus = c.CurrentBuffStatusCode(i);
                        if (currentStatus == uint.MaxValue) { continue; }
                        EffectStatusIDs status = (EffectStatusIDs)currentStatus;
                        if (buffMapping.ContainsKey((EffectStatusIDs)currentStatus)) //IF FOR REMOVE STATUS - CHECK IF STATUS EXISTS IN STATUS LIST AND DO ACTION
                        {
                            //IF CONTAINS CURRENT STATUS ON DICT
                            Key key = buffMapping[(EffectStatusIDs)currentStatus];
                            if (Enum.IsDefined(typeof(EffectStatusIDs), currentStatus))
                            {
                                if (ProfileSingleton.GetCurrent().UserPreferences.overweightMode == "50" &&
    (currentStatus == (uint)EffectStatusIDs.WEIGHT90) && key != Key.None)
                                {
                                    DebugLogger.Info("We are at 90% weight with autostop checkbox enabled, key=" + key.ToString());
                                    /*
                                    var frmToggleApplication = (ToggleApplicationStateForm)Application.OpenForms["ToggleApplicationStateForm"];
                                    frmToggleApplication.toggleStatus();
     
                                    if (shouldSendKey)
                                    {

                                        // Set focus to the RO window
                                        IntPtr handle = ClientSingleton.GetClient().process.MainWindowHandle;
                                        SetForegroundWindow(handle);
                                        // send ALT-# by the only way that seems to work
                                        System.Windows.Forms.SendKeys.SendWait("%" + ToSendKeysFormat(key));
                                    }
                                    */
                                }
                                else if (ProfileSingleton.GetCurrent().UserPreferences.overweightMode == "90" &&
    (currentStatus == (uint)EffectStatusIDs.WEIGHT50) && key != Key.None)
                                {
                                    DebugLogger.Info("We are at 50% weight with autostop checkbox enabled, key=" + key.ToString());
                                }
                                else
                                {
                                    this.useStatusRecovery(key);
                                }
                            }
                        }
                    }
                }
                Thread.Sleep(this.delay);
                return 0;
            })
            {

            };
            return statusEffectsThread;
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

        public string GetConfiguration()
        {
            return JsonConvert.SerializeObject(this);
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
                this.thread = RestoreStatusThread(roClient);
                _4RThread.Start(this.thread);
            }
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

        public void Stop()
        {
            _4RThread.Stop(this.thread);
        }

        private void useStatusRecovery(Key key)
        {
            if ((key != Key.None) && !Keyboard.IsKeyDown(Key.LeftAlt) && !Keyboard.IsKeyDown(Key.RightAlt))
            {
                Interop.PostMessage(ClientSingleton.GetClient().process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, (Keys)Enum.Parse(typeof(Keys), key.ToString()), 0);
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

    }
}