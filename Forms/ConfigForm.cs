using System;
using _4RTools.Model;
using System.Windows.Forms;
using _4RTools.Utils;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using static _4RTools.Model.AutoSwitch;

namespace _4RTools.Forms
{
    public partial class ConfigForm : Form, IObserver
    {
        public ConfigForm(Subject subject)
        {
            InitializeComponent();
            this.textReinKey.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.textReinKey.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.textReinKey.TextChanged += new EventHandler(this.textReinKey_TextChanged);

            this.ammo1textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.ammo1textBox.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.ammo1textBox.TextChanged += new EventHandler(this.textAmmo1_TextChanged);
            this.ammo2textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.ammo2textBox.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.ammo2textBox.TextChanged += new EventHandler(this.textAmmo2_TextChanged);


            var newListBuff = ProfileSingleton.GetCurrent().UserPreferences.autoBuffOrder;
            this.skillsListBox.MouseLeave += new System.EventHandler(this.skillsListBox_MouseLeave);
            this.skillsListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.skillsListBox_MouseDown);
            this.skillsListBox.DragOver += new DragEventHandler(this.skillsListBox_DragOver);
            this.skillsListBox.DragDrop += new DragEventHandler(this.skillsListBox_DragDrop);

            this.switchListBox.MouseLeave += new System.EventHandler(this.switchListBox_MouseLeave);
            this.switchListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.switchListBox_MouseDown);
            this.switchListBox.DragOver += new DragEventHandler(this.switchListBox_DragOver);
            this.switchListBox.DragDrop += new DragEventHandler(this.switchListBox_DragDrop);

            toolTip1.SetToolTip(switchAmmoCheckBox, "Intercala entre as munições");
            toolTip2.SetToolTip(textReinKey, "atalho rédea");
            toolTip3.SetToolTip(ammo1textBox, "atalho ammo 1");
            toolTip4.SetToolTip(ammo2textBox, "atalho ammo 2");
            subject.Attach(this);
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.code)
            {
                case MessageCode.PROFILE_CHANGED:
                case MessageCode.ADDED_NEW_AUTOBUFF_SKILL:
                case MessageCode.ADDED_NEW_AUTOSWITCH_PETS:
                    UpdateUI(subject);
                    break;
                //case MessageCode.ADDED_NEW_AUTOSWITCH_PETS:
                //    UpdateSwitch();
                //    break;
            }
        }

        public void UpdateSwitch()
        {
            try
            {
                var buffsList = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.Where(x => x.itemKey != Key.None && x.skillId != EffectStatusIDs.THURISAZ).Select(x => x.skillId).ToList();
                var newBuffList = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchOrder;
                if (buffsList.Count > ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchOrder.Count)
                {

                    var newBuffs = buffsList.FindAll(item => !newBuffList.Contains(item));
                    foreach (var buff in newBuffs)
                    {
                        newBuffList.Add(buff);
                    }
                    ProfileSingleton.GetCurrent().AutoSwitch.SetAutoSwitchOrder(newBuffList);
                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutoSwitch);
                }
                
                if (ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchOrder.Count > 0)
                {
                    var tessste = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchOrder;
                    ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchOrder.RemoveAll(item => !buffsList.Contains(item));
                    buffsList = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchOrder;
                }

                switchListBox.Items.Clear();

                foreach (var tswitch in buffsList)
                {
                    switchListBox.Items.Add(tswitch.ToDescriptionString());
                }
            }
            catch (Exception ex)
            {
                var teste = ex;
            }
        }

        public void UpdateUI(ISubject subject)
        {
            try
            {
                AutoBuffSkill currentBuffs = (AutoBuffSkill)(subject as Subject).Message.data;

                if (currentBuffs == null)
                {
                    currentBuffs = ProfileSingleton.GetCurrent().AutobuffSkill;
                }

                var buffsList = currentBuffs.buffMapping.Keys.ToList();
                skillsListBox.Items.Clear();

                foreach (var buff in buffsList)
                {
                    skillsListBox.Items.Add(buff.ToDescriptionString());
                }
                UpdateSwitch();

                this.chkStopBuffsOnCity.Checked = ProfileSingleton.GetCurrent().UserPreferences.stopBuffsCity;
                this.chkStopBuffsOnRein.Checked = ProfileSingleton.GetCurrent().UserPreferences.stopBuffsRein;
                this.chkStopHealOnCity.Checked = ProfileSingleton.GetCurrent().UserPreferences.stopHealCity;
                this.chkStopOnAntiBot.Checked = ProfileSingleton.GetCurrent().UserPreferences.stopSpammersBot;
                this.getOffReinCheckBox.Checked = ProfileSingleton.GetCurrent().UserPreferences.getOffRein;
                this.textReinKey.Text = ProfileSingleton.GetCurrent().UserPreferences.getOffReinKey.ToString();
                this.switchAmmoCheckBox.Checked = ProfileSingleton.GetCurrent().UserPreferences.switchAmmo;
                this.ammo1textBox.Text = ProfileSingleton.GetCurrent().UserPreferences.ammo1Key.ToString();
                this.ammo2textBox.Text = ProfileSingleton.GetCurrent().UserPreferences.ammo2Key.ToString();
            }
            catch (Exception ex)
            {
                var teste = ex;
            }
        }

        private void skillsListBox_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                var autoBuffSkill = ProfileSingleton.GetCurrent().AutobuffSkill;
                var newOrderList = new List<EffectStatusIDs>();
                var orderedBuffList = skillsListBox.Items;
                Dictionary<EffectStatusIDs, Key> currentList = new Dictionary<EffectStatusIDs, Key>(autoBuffSkill.buffMapping);
                Dictionary<EffectStatusIDs, Key> newOrderedBuffList = new Dictionary<EffectStatusIDs, Key>();
                if (currentList.Count > 0)
                {

                    foreach (var buff in orderedBuffList)
                    {
                        var buffId = buff.ToString().ToEffectStatusId();
                        newOrderList.Add(buffId);
                        var findBuff = currentList.FirstOrDefault(t => t.Key == buffId);
                        newOrderedBuffList.Add(findBuff.Key, findBuff.Value);
                    }
                    ProfileSingleton.GetCurrent().UserPreferences.SetAutoBuffOrder(newOrderList);
                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);

                    ProfileSingleton.GetCurrent().AutobuffSkill.ClearKeyMapping();
                    ProfileSingleton.GetCurrent().AutobuffSkill.setBuffMapping(newOrderedBuffList);
                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutobuffSkill);

                    newOrderedBuffList.Clear();
                }
            }
            catch { }
        }
        private void skillsListBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.skillsListBox.SelectedItem == null) return;
            this.skillsListBox.DoDragDrop(this.skillsListBox.SelectedItem, DragDropEffects.Move);
        }

        private void skillsListBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void skillsListBox_DragDrop(object sender, DragEventArgs e)
        {
            Point point = skillsListBox.PointToClient(new Point(e.X, e.Y));
            int index = this.skillsListBox.IndexFromPoint(point);
            if (index < 0) index = this.skillsListBox.Items.Count - 1;
            object data = skillsListBox.SelectedItem;
            this.skillsListBox.Items.Remove(data);
            this.skillsListBox.Items.Insert(index, data);
        }

        private void switchListBox_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                var autoSwitchPets = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchOrder;
                var newOrderList = new List<EffectStatusIDs>();
                var orderedBuffList = switchListBox.Items;
                List<EffectStatusIDs> currentList = ProfileSingleton.GetCurrent().AutoSwitch.autoSwitchMapping.Where(x => x.itemKey != Key.None && x.skillId != EffectStatusIDs.THURISAZ).Select(x => x.skillId).ToList();

                List<EffectStatusIDs> newOrderedBuffList = new List<EffectStatusIDs>();
                if (currentList.Count > 0)
                {

                    foreach (var buff in orderedBuffList)
                    {
                        var buffId = buff.ToString().ToEffectStatusId();
                        newOrderList.Add(buffId);
                        var findBuff = currentList.FirstOrDefault(t => t == buffId);
                        newOrderedBuffList.Add(findBuff);
                    }
                    ProfileSingleton.GetCurrent().AutoSwitch.SetAutoSwitchOrder(newOrderList);
                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().AutoSwitch);
                    newOrderedBuffList.Clear();
                }
            }
            catch { }
        }
        private void switchListBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.switchListBox.SelectedItem == null) return;
            this.switchListBox.DoDragDrop(this.switchListBox.SelectedItem, DragDropEffects.Move);
        }

        private void switchListBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void switchListBox_DragDrop(object sender, DragEventArgs e)
        {
            Point point = switchListBox.PointToClient(new Point(e.X, e.Y));
            int index = this.switchListBox.IndexFromPoint(point);
            if (index < 0) index = this.switchListBox.Items.Count - 1;
            object data = switchListBox.SelectedItem;
            this.switchListBox.Items.Remove(data);
            this.switchListBox.Items.Insert(index, data);
        }

        private void chkStopBuffsOnRein_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            ProfileSingleton.GetCurrent().UserPreferences.stopBuffsRein = chk.Checked;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
        }

        private void chkStopBuffsOnCity_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            ProfileSingleton.GetCurrent().UserPreferences.stopBuffsCity = chk.Checked;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
        }
        private void chkStopHealOnCity_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            ProfileSingleton.GetCurrent().UserPreferences.stopHealCity = chk.Checked;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
        }

        private void chkStopOnAntiBot_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            ProfileSingleton.GetCurrent().UserPreferences.stopSpammersBot = chk.Checked;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
        }

        private void getOffReinCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            ProfileSingleton.GetCurrent().UserPreferences.getOffRein = chk.Checked;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
        }

        private void textReinKey_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtBox = (TextBox)sender;
                if (txtBox.Text.ToString() != String.Empty)
                {
                    Key key = (Key)Enum.Parse(typeof(Key), txtBox.Text.ToString());
                    ProfileSingleton.GetCurrent().UserPreferences.getOffReinKey = key;
                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
                }
            }
            catch { }
        }

        private void switchAmmoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            ProfileSingleton.GetCurrent().UserPreferences.switchAmmo = chk.Checked;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
        }

        private void textAmmo1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtBox = (TextBox)sender;
                if (txtBox.Text.ToString() != String.Empty)
                {
                    Key key = (Key)Enum.Parse(typeof(Key), txtBox.Text.ToString());
                    ProfileSingleton.GetCurrent().UserPreferences.ammo1Key = key;
                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
                }
            }
            catch { }
        }

        private void textAmmo2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtBox = (TextBox)sender;
                if (txtBox.Text.ToString() != String.Empty)
                {
                    Key key = (Key)Enum.Parse(typeof(Key), txtBox.Text.ToString());
                    ProfileSingleton.GetCurrent().UserPreferences.ammo2Key = key;
                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
                }
            }
            catch { }
        }

    }
}
