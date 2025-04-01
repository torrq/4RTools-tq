﻿using _4RTools.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Input;

namespace _4RTools.Model
{
    public class UserPreferences : IAction
    {
        private readonly string ACTION_NAME = "UserPreferences";
        public string ToggleStateKey { get; set; } = Keys.End.ToString();
        public List<EffectStatusIDs> AutoBuffOrder { get; set; } = new List<EffectStatusIDs>();
        public bool StopBuffsCity { get; set; } = false;
        public bool SoundEnabled { get; set; } = false;
        public string OverweightMode { get; set; } = "overweightOff";
        public Key OverweightKey { get; set; }
        public bool SwitchAmmo { get; set; } = false;
        public Key Ammo1Key { get; set; }
        public Key Ammo2Key { get; set; }

        public UserPreferences()
        {
        }

        public void Start() { }

        public void Stop() { }

        public string GetConfiguration()
        {
            return JsonConvert.SerializeObject(this);
        }

        public string GetActionName()
        {
            return ACTION_NAME;
        }
        public void SetAutoBuffOrder(List<EffectStatusIDs> buffs)
        {
            this.AutoBuffOrder = buffs;
        }
    }
}
