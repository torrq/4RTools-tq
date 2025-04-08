﻿using System;
using System.ComponentModel;
using _4RTools.Utils;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace _4RTools.Model
{

    public class Autopot : IAction
    {

        public static string ACTION_NAME_AUTOPOT = "Autopot";
        public static string ACTION_NAME_AUTOPOT_YGG = "AutopotYgg";
        public const string FIRSTHP = "firstHP";
        public const string FIRSTSP = "firstSP";
        public Key HPKey { get; set; }
        public int HPPercent { get; set; }
        public Key SPKey { get; set; }
        public int SPPercent { get; set; }

        private int _delay = AppConfig.AutoPotDefaultDelay;
        public int Delay
        {
            get => _delay <= 0 ? AppConfig.AutoPotDefaultDelay : _delay;
            set => _delay = value;
        }

        // this is currently unused, should probably be hooked up someday. uses the above value instead for defaults
        private int _delayYgg = AppConfig.YggDefaultDelay;
        public int DelayYgg
        {
            get => _delayYgg <= 0 ? AppConfig.YggDefaultDelay : _delayYgg;
            set => _delayYgg = value;
        }

        public bool StopWitchFC { get; set; } = false;
        public string FirstHeal { get; set; } = FIRSTHP;

        public string ActionName { get; set; }
        private _4RThread thread;

        public List<String> CityList { get; set; }

        public Autopot() { }
        public Autopot(string actionName)
        {
            this.ActionName = actionName;
        }

        public Autopot(Key hpKey, int hpPercent, int delay, Key spKey, int spPercent, Key tiKey)
        {
            this.Delay = delay;

            // HP
            this.HPKey = hpKey;
            this.HPPercent = hpPercent;

            // SP
            this.SPKey = spKey;
            this.SPPercent = spPercent;

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
                int hpPotCount = 0;
                if (this.CityList == null || this.CityList.Count == 0) this.CityList = LocalServerManager.GetCityList();
                this.thread = new _4RThread(_ => AutopotThreadExecution(roClient, hpPotCount));
                _4RThread.Start(this.thread);
            }
        }

        private int AutopotThreadExecution(Client roClient, int hpPotCount)
        {
            string currentMap = roClient.ReadCurrentMap();
            if (!ProfileSingleton.GetCurrent().UserPreferences.StopBuffsCity || this.CityList.Contains(currentMap) == false)
            {
                bool hasCriticalWound = HasCriticalWound(roClient);
                if (FirstHeal.Equals(FIRSTHP))
                {
                    healHPFirst(roClient, hpPotCount, hasCriticalWound);
                }
                else
                {
                    healSPFirst(roClient, hpPotCount, hasCriticalWound);
                }
            }
            Thread.Sleep(this.Delay);
            return 0;
        }

        private void healSPFirst(Client roClient, int hpPotCount, bool hasCriticalWound)
        {
            if (roClient.IsSpBelow(SPPercent))
            {
                Pot(this.SPKey);
                hpPotCount++;

                if (hpPotCount == 3 && roClient.IsHpBelow(HPPercent))
                {
                    hpPotCount = 0;
                    if (this.ActionName == ACTION_NAME_AUTOPOT_YGG)
                    {
                        Pot(this.HPKey);
                    }
                    else if (this.ActionName == ACTION_NAME_AUTOPOT && ((!this.StopWitchFC && hasCriticalWound) || !hasCriticalWound))
                    {
                        Pot(this.HPKey);
                    }

                }
            }
            // check hp
            if (roClient.IsHpBelow(HPPercent))
            {
                Pot(this.HPKey);
            }
        }

        private void healHPFirst(Client roClient, int hpPotCount, bool hasCriticalWound)
        {
            if (roClient.IsHpBelow(HPPercent))
            {
                if (this.ActionName == ACTION_NAME_AUTOPOT_YGG)
                {
                    Pot(this.HPKey);
                    hpPotCount++;
                }
                else if (this.ActionName == ACTION_NAME_AUTOPOT && ((!this.StopWitchFC && hasCriticalWound) || !hasCriticalWound))
                {
                    Pot(this.HPKey);
                    hpPotCount++;
                }
                if (hpPotCount == 3 && roClient.IsSpBelow(SPPercent))
                {
                    hpPotCount = 0;
                    Pot(this.SPKey);

                }
            }
            // check sp
            if (roClient.IsSpBelow(SPPercent))
            {
                Pot(this.SPKey);
            }
        }

        private void Pot(Key key)
        {
            Keys k = (Keys)Enum.Parse(typeof(Keys), key.ToString());
            if ((k != Keys.None) && !Keyboard.IsKeyDown(Key.LeftAlt) && !Keyboard.IsKeyDown(Key.RightAlt))
            {
                Interop.PostMessage(ClientSingleton.GetClient().Process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, k, 0); // keydown
                Interop.PostMessage(ClientSingleton.GetClient().Process.MainWindowHandle, Constants.WM_KEYUP_MSG_ID, k, 0); // keyup
            }
        }

        public void Stop()
        {
            _4RThread.Stop(this.thread);
        }

        public string GetConfiguration()
        {
            return JsonConvert.SerializeObject(this);
        }

        public string GetActionName() => ActionName ?? ACTION_NAME_AUTOPOT;

        public bool HasCriticalWound(Client c)
        {
            for (int i = 1; i < Constants.MAX_BUFF_LIST_INDEX_SIZE; i++)
            {
                uint currentStatus = c.CurrentBuffStatusCode(i);

                if (currentStatus == uint.MaxValue) { continue; }

                EffectStatusIDs status = (EffectStatusIDs)currentStatus;

                if (status == EffectStatusIDs.CRITICALWOUND)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}
