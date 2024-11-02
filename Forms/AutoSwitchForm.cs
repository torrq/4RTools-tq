using System;
using System.Windows.Forms;
using System.Windows.Input;
using System.Collections.Generic;
using _4RTools.Utils;
using _4RTools.Model;
using System.Linq;
using static _4RTools.Model.AutoSwitch;
using System.Diagnostics;

namespace _4RTools.Forms
{
    public partial class AutoSwitchForm : Form, IObserver
    {
        private List<Buff> allBuffs = new List<Buff>();
        private Subject _subject;
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
            _subject = subject;

            this.allBuffs.AddRange(Buff.GetArcherSkills());
            this.allBuffs.AddRange(Buff.GetSwordmanSkill());
            this.allBuffs.AddRange(Buff.GetMageSkills());
            this.allBuffs.AddRange(Buff.GetMerchantSkills());
            this.allBuffs.AddRange(Buff.GetThiefSkills());
            this.allBuffs.AddRange(Buff.GetAcolyteSkills());
            this.allBuffs.AddRange(Buff.GetTaekwonSkills());
            this.allBuffs.AddRange(Buff.GetNinjaSkills());
            this.allBuffs.AddRange(Buff.GetGunsSkills());

            this.allBuffs.OrderBy(o => o.name).ToList();

            foreach (var skill in this.allBuffs.OrderBy(o => o.name).ToList())
            {
                this.skillCB.Items.Add(skill.name);
            }

            subject.Attach(this);
        }

        private void loadCustomSkills(Subject subject)
        {
            List<Buff> filteredBuffs = new List<Buff>();

            var teste = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchGenericMapping;
            foreach (var skill in ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchGenericMapping)
            {
                if (this.allBuffs.Exists(x => x.effectStatusID == skill.skillId))
                {
                    filteredBuffs.Add(this.allBuffs.FirstOrDefault(x => x.effectStatusID == skill.skillId));
                }
            }

            AutoSwitchContainer skillContainer = new AutoSwitchContainer();
            skillContainer = new AutoSwitchContainer(this.AutoSwitchGP, filteredBuffs);
            new AutoSwitchRenderer(skillContainer, toolTip1, subject, this).doRender();
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.code)
            {
                case MessageCode.PROFILE_CHANGED:
                    this.ITEMin319.Text = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.Exists(x => x.skillId == EffectStatusIDs.THURISAZ) ? ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.FirstOrDefault(x => x.skillId == EffectStatusIDs.THURISAZ).itemKey.ToString() : Keys.None.ToString();
                    this.NEXTITEMin319.Text = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.Exists(x => x.skillId == EffectStatusIDs.THURISAZ) ? ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.FirstOrDefault(x => x.skillId == EffectStatusIDs.THURISAZ).nextItemKey.ToString() : Keys.None.ToString();
                    loadCustomSkills(subject as Subject);
                    break;
                case MessageCode.TURN_OFF:
                    ProfileSingleton.GetCurrent().AutoSwitch.Stop();
                    break;
                case MessageCode.TURN_ON:
                    ProfileSingleton.GetCurrent().AutoSwitch.Start();
                    break;
                case MessageCode.CHANGED_AUTOSWITCH_SKILL:
                    loadCustomSkills(subject as Subject);
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
                    else
                    {

                        ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.Add(new AutoSwitchConfig(statusID, key, type));
                    }

                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutoSwitch);
                }
                this.ActiveControl = null;
            }
            catch { }
        }

        private void btnNewSwitch(object sender, EventArgs e)
        {
            var txtSkill = skillCB.Text;

            var skill = this.allBuffs.FirstOrDefault(x => x.name == txtSkill);
            var _autoSwitchGenericMapping = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchGenericMapping;
            if (!_autoSwitchGenericMapping.Exists(x => x.skillId == skill.effectStatusID)) {
                _autoSwitchGenericMapping.Add(new AutoSwitchConfig(skill.effectStatusID, Key.None));
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutoSwitch);
                _subject.Notify(new Utils.Message(Utils.MessageCode.CHANGED_AUTOSWITCH_SKILL, null));
            }


        }

    }
}
