using _4RTools.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Input;

namespace _4RTools.Model
{
    public class UserPreferences : Action
    {
        private string ACTION_NAME = "UserPreferences";
        public string toggleStateKey { get; set; } = Keys.End.ToString();
        public List<EffectStatusIDs> autoBuffOrder { get; set; } = new List<EffectStatusIDs>();

        public bool stopBuffsCity { get; set; } = false;
        public string overweightMode { get; set; } = "overweightOff";
        public Key overweightKey { get; set; }

        public bool switchAmmo { get; set; } = false;
        public Key ammo1Key { get; set; }
        public Key ammo2Key { get; set; }

        public bool stopSpammersBot { get; set; } = false;

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
            this.autoBuffOrder = buffs;
        }
    }
}
