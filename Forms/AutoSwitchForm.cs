using System;
using System.Windows.Forms;
using System.Windows.Input;
using System.Collections.Generic;
using _4RTools.Utils;
using _4RTools.Model;
using System.Linq;
using static _4RTools.Model.AutoSwitch;

namespace _4RTools.Forms
{
    public partial class AutoSwitchForm : Form, IObserver
    {
        private List<BuffContainer> debuffContainers = new List<BuffContainer>();
        class ComboboxValue
        {
            public int Id { get; private set; }
            public string Name { get; private set; }

            public ComboboxValue(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        public AutoSwitchForm(Subject subject)
        {
            InitializeComponent();

            subject.Attach(this);
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.code)
            {
                case MessageCode.PROFILE_CHANGED:
                    this.ITEMin30.Text = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.Exists(x => x.skillId == EffectStatusIDs.CRAZY_UPROAR) ? ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.FirstOrDefault(x => x.skillId == EffectStatusIDs.CRAZY_UPROAR).itemKey.ToString() : Keys.None.ToString();
                    this.SKILLin30.Text = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.Exists(x => x.skillId == EffectStatusIDs.CRAZY_UPROAR) ? ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.FirstOrDefault(x => x.skillId == EffectStatusIDs.CRAZY_UPROAR).skillKey.ToString() : Keys.None.ToString();
                    this.NEXTITEMin30.Text = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.Exists(x => x.skillId == EffectStatusIDs.CRAZY_UPROAR) ? ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.FirstOrDefault(x => x.skillId == EffectStatusIDs.CRAZY_UPROAR).nextItemKey.ToString() : Keys.None.ToString();
                    this.ITEMin319.Text = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.Exists(x => x.skillId == EffectStatusIDs.THURISAZ || x.skillId == EffectStatusIDs.FIGHTINGSPIRIT) ? ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.FirstOrDefault(x => x.skillId == EffectStatusIDs.THURISAZ || x.skillId == EffectStatusIDs.FIGHTINGSPIRIT).itemKey.ToString() : Keys.None.ToString();
                    this.NEXTITEMin319.Text = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.Exists(x => x.skillId == EffectStatusIDs.THURISAZ || x.skillId == EffectStatusIDs.FIGHTINGSPIRIT) ? ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.FirstOrDefault(x => x.skillId == EffectStatusIDs.THURISAZ || x.skillId == EffectStatusIDs.FIGHTINGSPIRIT).nextItemKey.ToString() : Keys.None.ToString();
                    this.ITEMin110.Text = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.Exists(x => x.skillId == EffectStatusIDs.ASSUMPTIO) ? ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.FirstOrDefault(x => x.skillId == EffectStatusIDs.ASSUMPTIO).itemKey.ToString() : Keys.None.ToString();
                    this.SKILLin110.Text = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.Exists(x => x.skillId == EffectStatusIDs.ASSUMPTIO) ? ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.FirstOrDefault(x => x.skillId == EffectStatusIDs.ASSUMPTIO).skillKey.ToString() : Keys.None.ToString();
                    this.NEXTITEMin110.Text = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.Exists(x => x.skillId == EffectStatusIDs.ASSUMPTIO) ? ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.FirstOrDefault(x => x.skillId == EffectStatusIDs.ASSUMPTIO).nextItemKey.ToString() : Keys.None.ToString();

                    break;
                case MessageCode.TURN_OFF:
                    ProfileSingleton.GetCurrent().AutoSwitch.Stop();
                    break;
                case MessageCode.TURN_ON:
                    ProfileSingleton.GetCurrent().AutoSwitch.Start();
                    break;
            }
        }

        private void onTextChange(object sender, EventArgs e)
        {
            try
            {
                TextBox txtBox = (TextBox)sender;
                if (txtBox.Text.ToString() != String.Empty)
                {
                    Key key = (Key)Enum.Parse(typeof(Key), txtBox.Text.ToString());
                    EffectStatusIDs statusID = (EffectStatusIDs)Int16.Parse(txtBox.Name.Split(new[] { "in" }, StringSplitOptions.None)[1]);
                    string type = txtBox.Name.Split(new[] { "in" }, StringSplitOptions.None)[0];

                    AutoSwitchConfig config = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.Find(cfg => cfg.skillId == statusID);
                    if (config != null)
                    {
                        config.skillId = statusID;

                        switch (type)
                        {
                            case item:
                                config.itemKey = key;
                                break;

                            case skill:
                                config.skillKey = key;
                                break;

                            case nextItem:
                                config.nextItemKey = key;
                                break;
                        }

                    }
                    else {

                        ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.Add(new AutoSwitchConfig(statusID, key, type));
                    }

                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutoSwitch);
                }
                this.ActiveControl = null;
            }
            catch { }
        }

    }
}
