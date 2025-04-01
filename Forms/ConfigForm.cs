using System;
using _4RTools.Model;
using System.Windows.Forms;
using _4RTools.Utils;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;

namespace _4RTools.Forms
{
    public partial class ConfigForm : Form, IObserver
    {
        public ConfigForm(Subject subject)
        {
            InitializeComponent();

            this.ammo1textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.ammo1textBox.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.ammo1textBox.TextChanged += new EventHandler(this.textAmmo1_TextChanged);
            this.ammo2textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.ammo2textBox.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.ammo2textBox.TextChanged += new EventHandler(this.textAmmo2_TextChanged);
            this.overweightKey.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.overweightKey.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.overweightKey.TextChanged += new EventHandler(this.overweightKey_TextChanged);

            var newListBuff = ProfileSingleton.GetCurrent().UserPreferences.AutoBuffOrder;
            this.skillsListBox.MouseLeave += new System.EventHandler(this.skillsListBox_MouseLeave);
            this.skillsListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.skillsListBox_MouseDown);
            this.skillsListBox.DragOver += new DragEventHandler(this.skillsListBox_DragOver);
            this.skillsListBox.DragDrop += new DragEventHandler(this.skillsListBox_DragDrop);

            toolTip1.SetToolTip(switchAmmoCheckBox, "Switch between ammunition");
            toolTip3.SetToolTip(ammo1textBox, "ammo 1 shortcut");
            toolTip4.SetToolTip(ammo2textBox, "ammo 2 shortcut");
            toolTip5.SetToolTip(overweightKey, "Alt-# macro to send when overweight");

            subject.Attach(this);
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.Code)
            {
                case MessageCode.PROFILE_CHANGED:
                case MessageCode.ADDED_NEW_AUTOBUFF_SKILL:
                case MessageCode.ADDED_NEW_AUTOSWITCH_PETS:
                    UpdateUI(subject);
                    break;
            }
        }

        public void UpdateUI(ISubject subject)
        {
            try
            {
                AutoBuffSkill currentBuffs = (AutoBuffSkill)(subject as Subject).Message.Data;

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

                this.chkStopBuffsOnCity.Checked = ProfileSingleton.GetCurrent().UserPreferences.StopBuffsCity;
                this.switchAmmoCheckBox.Checked = ProfileSingleton.GetCurrent().UserPreferences.SwitchAmmo;
                this.ammo1textBox.Text = ProfileSingleton.GetCurrent().UserPreferences.Ammo1Key.ToString();
                this.ammo2textBox.Text = ProfileSingleton.GetCurrent().UserPreferences.Ammo2Key.ToString();
                this.overweightKey.Text = ProfileSingleton.GetCurrent().UserPreferences.OverweightKey.ToString();

                RadioButton rdOverweightMode = (RadioButton)this.groupOverweight.Controls[ProfileSingleton.GetCurrent().UserPreferences.OverweightMode.ToString()];
                if (rdOverweightMode != null) { 
                    rdOverweightMode.Checked = true;
                };

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
                    ProfileSingleton.GetCurrent().AutobuffSkill.SetBuffMapping(newOrderedBuffList);
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
        private void chkStopBuffsOnCity_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            ProfileSingleton.GetCurrent().UserPreferences.StopBuffsCity = chk.Checked;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
        }

        private void switchAmmoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            ProfileSingleton.GetCurrent().UserPreferences.SwitchAmmo = chk.Checked;
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
                    ProfileSingleton.GetCurrent().UserPreferences.Ammo1Key = key;
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
                    ProfileSingleton.GetCurrent().UserPreferences.Ammo2Key = key;
                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
                }
            }
            catch { }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void overweightKey_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtBox = (TextBox)sender;
                if (txtBox.Text.ToString() != String.Empty)
                {
                    Key key = (Key)Enum.Parse(typeof(Key), txtBox.Text.ToString());
                    ProfileSingleton.GetCurrent().UserPreferences.OverweightKey = key;
                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
                }
            }
            catch { }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void overweightMode_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                if (!string.IsNullOrWhiteSpace(rb.Name))
                {
                    ProfileSingleton.GetCurrent().UserPreferences.OverweightMode = rb.Name;
                    ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().UserPreferences);
                }
            }
        }

    }
}
