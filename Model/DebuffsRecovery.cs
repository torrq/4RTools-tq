﻿using _4RTools.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
                                this.useStatusRecovery(key);
                            }
                        }
                    }
                }
                Thread.Sleep(this.delay);
                return 0;
            });
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
                Interop.PostMessage(ClientSingleton.GetClient().process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, (Keys)Enum.Parse(typeof(Keys), key.ToString()), 0);
        }
    }
}