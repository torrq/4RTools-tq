﻿using System.Windows.Forms;
using System;
using System.Windows.Input;
using _4RTools.Model;
using _4RTools.Utils;

namespace _4RTools.Forms
{
    public partial class AutopotForm : Form, IObserver
    {
        private Autopot autopot;
        private readonly bool isYgg;

        public AutopotForm(Subject subject, bool isYgg)
        {
            InitializeComponent();
            if (isYgg)
            {
                this.picBoxHP.Image = Resources._4RTools.ETCResource.Ygg;
                this.picBoxSP.Image = Resources._4RTools.ETCResource.Ygg;
                this.chkStopWitchFC.Hide();
            }
            subject.Attach(this);
            this.isYgg = isYgg;
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.Code)
            {
                case MessageCode.PROFILE_CHANGED:
                    this.autopot = this.isYgg ? ProfileSingleton.GetCurrent().AutopotYgg : ProfileSingleton.GetCurrent().Autopot;
                    InitializeApplicationForm();
                    break;
                case MessageCode.TURN_OFF:
                    this.autopot.Stop();
                    break;
                case MessageCode.TURN_ON:
                    this.autopot.Start();
                    break;
            }
        }

        private void InitializeApplicationForm()
        {
            this.txtHpKey.Text = this.autopot.HPKey.ToString();
            this.txtSPKey.Text = this.autopot.SPKey.ToString();
            this.txtHPpct.Text = this.autopot.HPPercent.ToString();
            this.txtSPpct.Text = this.autopot.SPPercent.ToString();
            this.txtAutopotDelay.Text = this.autopot.Delay.ToString();
            this.chkStopWitchFC.Checked = this.autopot.StopWitchFC;
            RadioButton rdHealFirst = (RadioButton)this.Controls[ProfileSingleton.GetCurrent().Autopot.FirstHeal];
            if (rdHealFirst != null) { rdHealFirst.Checked = true; };

            txtHpKey.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            txtHpKey.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            txtHpKey.TextChanged += new EventHandler(this.OnHpTextChange);
            txtSPKey.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            txtSPKey.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            txtSPKey.TextChanged += new EventHandler(this.OnSpTextChange);


        }

        private void OnHpTextChange(object sender, EventArgs e)
        {
            Key key = (Key)Enum.Parse(typeof(Key), txtHpKey.Text.ToString());
            this.autopot.HPKey = key;
            ProfileSingleton.SetConfiguration(this.autopot);
            this.ActiveControl = null;
        }

        private void OnSpTextChange(object sender, EventArgs e)
        {
            Key key = (Key)Enum.Parse(typeof(Key), txtSPKey.Text.ToString());
            this.autopot.SPKey = key;
            ProfileSingleton.SetConfiguration(this.autopot);
            this.ActiveControl = null;
        }

        private void TxtAutopotDelayTextChanged(object sender, EventArgs e)
        {
            try
            {
                this.autopot.Delay = Int16.Parse(this.txtAutopotDelay.Text);
                ProfileSingleton.SetConfiguration(this.autopot);
            }
            catch (Exception ex)
            {
                var exception = ex;
            }
        
        }

        private void TxtHPpctTextChanged(object sender, EventArgs e)
        {
            try
            {
                this.autopot.HPPercent = Int16.Parse(this.txtHPpct.Text);
                ProfileSingleton.SetConfiguration(this.autopot);
            }
            catch (Exception ex)
            {
                var exception = ex;
            }

        }

        private void ChkStopWitchFC_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            this.autopot.StopWitchFC = chk.Checked;
            ProfileSingleton.SetConfiguration(this.autopot);
        }

        private void TxtSPpctTextChanged(object sender, EventArgs e)
        {
            try
            {
                this.autopot.SPPercent = Int16.Parse(this.txtSPpct.Text);
                ProfileSingleton.SetConfiguration(this.autopot);
            }
            catch (Exception)
            {
            }
        }
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                this.autopot.FirstHeal = rb.Name;
                ProfileSingleton.SetConfiguration(this.autopot);
            }
        }

        private void AutopotForm_Load(object sender, EventArgs e)
        {

        }
    }
}
