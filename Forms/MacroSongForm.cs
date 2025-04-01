using System;
using _4RTools.Model;
using _4RTools.Utils;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Windows.Input;

namespace _4RTools.Forms
{
    public partial class MacroSongForm : Form, IObserver
    {
        public static int TOTAL_MACRO_LANES_FOR_SONGS = 8;
        public MacroSongForm(Subject subject)
        {
            subject.Attach(this);
            InitializeComponent();
            configureMacroLanes();
        }

        public void Update(ISubject subject) 
        { 
            switch((subject as Subject).Message.Code)
            {
                case MessageCode.PROFILE_CHANGED:
                    updateUi();
                    break;
                case MessageCode.TURN_ON:
                    ProfileSingleton.GetCurrent().SongMacro.Start();
                    break;
                case MessageCode.TURN_OFF:
                    ProfileSingleton.GetCurrent().SongMacro.Stop();
                    break;
            }

        }

        private void UpdatePanelData(int id)
        {
            try
            {
                Macro songMacro = ProfileSingleton.GetCurrent().SongMacro;
                GroupBox p = (GroupBox)this.Controls.Find("panelMacro" + id, true)[0];
                ChainConfig chainConfig = new ChainConfig(songMacro.ChainConfigs[id - 1]);
                FormUtils.ResetForm(p);

                //Update Trigger Macro Value
                Control[] c = p.Controls.Find("inTriggerMacro" + chainConfig.id, true);
                if (c.Length > 0)
                {
                    TextBox textBox = (TextBox)c[0];
                    textBox.Text = chainConfig.Trigger.ToString();
                }

                //Update Dagger Value
                Control[] cDagger = p.Controls.Find("inDaggerMacro" + chainConfig.id, true);
                if (cDagger.Length > 0)
                {
                    TextBox textBox = (TextBox)cDagger[0];
                    textBox.Text = chainConfig.DaggerKey.ToString();
                }

                //Update Instrument Value
                Control[] cInstrument = p.Controls.Find("inInstrumentMacro" + chainConfig.id, true);
                if (cInstrument.Length > 0)
                {
                    TextBox textBox = (TextBox)cInstrument[0];
                    textBox.Text = chainConfig.InstrumentKey.ToString();
                }


                List<string> names = new List<string>(chainConfig.macroEntries.Keys);
                foreach (string cbName in names)
                {
                    Control[] controls = p.Controls.Find(cbName, true);
                    if (controls.Length > 0)
                    {
                        TextBox textBox = (TextBox)controls[0];
                        textBox.Text = chainConfig.macroEntries[cbName].Key.ToString();
                    }
                }

                //Update Delay Macro Value
                Control[] d = p.Controls.Find("delayMac" + chainConfig.id, true);
                if (d.Length > 0)
                {
                    NumericUpDown delayInput = (NumericUpDown)d[0];
                    delayInput.Value = chainConfig.Delay;
                }
            } catch { }
        }

        private void onTextChange(object sender, EventArgs e)
        {
            Macro SongMacro = ProfileSingleton.GetCurrent().SongMacro;
            TextBox textBox = (TextBox)sender;
            Key key = (Key)Enum.Parse(typeof(Key), textBox.Text.ToString());

            if(textBox.Tag != null)
            {
                //Could be Trigger, Dagger or Instrument input
                string[] inputTag = textBox.Tag.ToString().Split(new[] { ":" }, StringSplitOptions.None);
                int macroid = short.Parse(inputTag[0]);
                string type = inputTag[1];
                ChainConfig chainConfig = ProfileSingleton.GetCurrent().SongMacro.ChainConfigs.Find(config => config.id == macroid);

                switch (type)
                {
                    case "Dagger":
                        chainConfig.DaggerKey = key;
                        break;
                    case "Instrument":
                        chainConfig.InstrumentKey= key;
                        break;
                    case "Trigger":
                        chainConfig.Trigger = key;
                        break;
                }
            }
            else
            {
                int macroID = short.Parse(textBox.Name.Split(new[] { "mac" }, StringSplitOptions.None)[1]);
                ChainConfig chainConfig = SongMacro.ChainConfigs.Find(songMacro => songMacro.id == macroID);
                if(chainConfig == null)
                {
                    SongMacro.ChainConfigs.Add(new ChainConfig(macroID, Key.None));
                    chainConfig = SongMacro.ChainConfigs.Find(songMacro => songMacro.id == macroID);
                }
                chainConfig.macroEntries[textBox.Name] = new MacroKey(key, chainConfig.Delay);
            }

            ProfileSingleton.SetConfiguration(SongMacro);
        }

        private void onDelayChange(object sender, EventArgs e)
        {
            Macro SongMacro = ProfileSingleton.GetCurrent().SongMacro;
            NumericUpDown delayInput = (NumericUpDown)sender;
            int macroID = Int16.Parse(delayInput.Name.Split(new[] { "delayMac" }, StringSplitOptions.None)[1]);
            ChainConfig chainConfig = SongMacro.ChainConfigs.Find(songMacro => songMacro.id == macroID);

            chainConfig.Delay = decimal.ToInt16(delayInput.Value);

            List<string> names = new List<string>(chainConfig.macroEntries.Keys);
            foreach (string cbName in names)
            {
                chainConfig.macroEntries[cbName].Delay = chainConfig.Delay;
            }
            ProfileSingleton.SetConfiguration(SongMacro);
        }

        private void onReset(object sender, EventArgs e)
        {
            Macro SongMacro = ProfileSingleton.GetCurrent().SongMacro;
            Button delayInput = (Button)sender;
            int btnResetID = Int16.Parse(delayInput.Name.Split(new[] { "btnResMac" }, StringSplitOptions.None)[1]);
            ProfileSingleton.SetConfiguration(SongMacro);
            this.UpdatePanelData(btnResetID);
        }


        private void updateUi()
        {
            for (int i = 1; i <= TOTAL_MACRO_LANES_FOR_SONGS; i++)
            {
                UpdatePanelData(i);
            }
        }

        private void configureMacroLanes()
        {
            for (int i = 1; i <= TOTAL_MACRO_LANES_FOR_SONGS; i++)
            {
                initializeLane(i);
            }
        }

        private void initializeLane(int id)
        {
            try
            {
                GroupBox p = (GroupBox)this.Controls.Find("panelMacro" + id, true)[0];
                foreach (Control c in p.Controls)
                {
                    if (c is TextBox)
                    {
                        TextBox textBox = (TextBox)c;
                        textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
                        textBox.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
                        textBox.TextChanged += new EventHandler(this.onTextChange);
                    }

                    if (c is Button)
                    {
                        Button resetButton = (Button)c;
                        resetButton.Click += new EventHandler(this.onReset);
                    }

                    if (c is NumericUpDown)
                    {
                        NumericUpDown numericUpDown = (NumericUpDown)c;
                        numericUpDown.ValueChanged += new EventHandler(this.onDelayChange);
                    }
                }
            } catch { }
        }

        private void inTriggerMacro1_TextChanged(object sender, EventArgs e)
        {

        }

        private void in1mac1_TextChanged(object sender, EventArgs e)
        {

        }

        private void in2mac1_TextChanged(object sender, EventArgs e)
        {

        }

        private void in4mac1_TextChanged(object sender, EventArgs e)
        {

        }

        private void in3mac1_TextChanged(object sender, EventArgs e)
        {

        }

        private void in5mac1_TextChanged(object sender, EventArgs e)
        {

        }

        private void in6mac1_TextChanged(object sender, EventArgs e)
        {

        }

        private void in8mac1_TextChanged(object sender, EventArgs e)
        {

        }

        private void in7mac1_TextChanged(object sender, EventArgs e)
        {

        }

        private void inDaggerMacro1_TextChanged(object sender, EventArgs e)
        {

        }

        private void inInstrumentMacro1_TextChanged(object sender, EventArgs e)
        {

        }

        private void in1mac2_TextChanged(object sender, EventArgs e)
        {

        }

        private void in2mac2_TextChanged(object sender, EventArgs e)
        {

        }

        private void in4mac2_TextChanged(object sender, EventArgs e)
        {

        }

        private void in3mac2_TextChanged(object sender, EventArgs e)
        {

        }

        private void in5mac2_TextChanged(object sender, EventArgs e)
        {

        }

        private void in6mac2_TextChanged(object sender, EventArgs e)
        {

        }

        private void in8mac2_TextChanged(object sender, EventArgs e)
        {

        }

        private void in7mac2_TextChanged(object sender, EventArgs e)
        {

        }

        private void inDaggerMacro2_TextChanged(object sender, EventArgs e)
        {

        }

        private void inInstrumentMacro2_TextChanged(object sender, EventArgs e)
        {

        }

        private void inDaggerMacro3_TextChanged(object sender, EventArgs e)
        {

        }

        private void inInstrumentMacro3_TextChanged(object sender, EventArgs e)
        {

        }

        private void in7mac3_TextChanged(object sender, EventArgs e)
        {

        }

        private void in5mac3_TextChanged(object sender, EventArgs e)
        {

        }

        private void in3mac3_TextChanged(object sender, EventArgs e)
        {

        }

        private void in1mac3_TextChanged(object sender, EventArgs e)
        {

        }

        private void inTriggerMacro3_TextChanged(object sender, EventArgs e)
        {

        }

        private void inTriggerMacro2_TextChanged(object sender, EventArgs e)
        {

        }

        private void in2mac3_TextChanged(object sender, EventArgs e)
        {

        }

        private void in4mac3_TextChanged(object sender, EventArgs e)
        {

        }

        private void in6mac3_TextChanged(object sender, EventArgs e)
        {

        }

        private void in8mac3_TextChanged(object sender, EventArgs e)
        {

        }

        private void in1mac4_TextChanged(object sender, EventArgs e)
        {

        }

        private void in2mac4_TextChanged(object sender, EventArgs e)
        {

        }

        private void in4mac4_TextChanged(object sender, EventArgs e)
        {

        }

        private void in3mac4_TextChanged(object sender, EventArgs e)
        {

        }

        private void inTriggerMacro4_TextChanged(object sender, EventArgs e)
        {

        }

        private void in1mac5_TextChanged(object sender, EventArgs e)
        {

        }

        private void inTriggerMacro5_TextChanged(object sender, EventArgs e)
        {

        }

        private void inTriggerMacro6_TextChanged(object sender, EventArgs e)
        {

        }

        private void inTriggerMacro7_TextChanged(object sender, EventArgs e)
        {

        }

        private void in1mac7_TextChanged(object sender, EventArgs e)
        {

        }

        private void in3mac7_TextChanged(object sender, EventArgs e)
        {

        }

        private void in5mac7_TextChanged(object sender, EventArgs e)
        {

        }

        private void in7mac7_TextChanged(object sender, EventArgs e)
        {

        }

        private void in8mac6_TextChanged(object sender, EventArgs e)
        {

        }

        private void in6mac6_TextChanged(object sender, EventArgs e)
        {

        }

        private void in4mac6_TextChanged(object sender, EventArgs e)
        {

        }

        private void in2mac6_TextChanged(object sender, EventArgs e)
        {

        }

        private void in1mac6_TextChanged(object sender, EventArgs e)
        {

        }

        private void in3mac6_TextChanged(object sender, EventArgs e)
        {

        }

        private void in5mac6_TextChanged(object sender, EventArgs e)
        {

        }

        private void in7mac6_TextChanged(object sender, EventArgs e)
        {

        }

        private void in8mac5_TextChanged(object sender, EventArgs e)
        {

        }

        private void in6mac5_TextChanged(object sender, EventArgs e)
        {

        }

        private void in4mac5_TextChanged(object sender, EventArgs e)
        {

        }

        private void in2mac5_TextChanged(object sender, EventArgs e)
        {

        }

        private void in3mac5_TextChanged(object sender, EventArgs e)
        {

        }

        private void in5mac5_TextChanged(object sender, EventArgs e)
        {

        }

        private void in7mac5_TextChanged(object sender, EventArgs e)
        {

        }

        private void in8mac4_TextChanged(object sender, EventArgs e)
        {

        }

        private void in6mac4_TextChanged(object sender, EventArgs e)
        {

        }

        private void in5mac4_TextChanged(object sender, EventArgs e)
        {

        }

        private void in7mac4_TextChanged(object sender, EventArgs e)
        {

        }

        private void inInstrumentMacro4_TextChanged(object sender, EventArgs e)
        {

        }

        private void inDaggerMacro5_TextChanged(object sender, EventArgs e)
        {

        }

        private void inInstrumentMacro5_TextChanged(object sender, EventArgs e)
        {

        }

        private void inDaggerMacro6_TextChanged(object sender, EventArgs e)
        {

        }

        private void inInstrumentMacro6_TextChanged(object sender, EventArgs e)
        {

        }

        private void inDaggerMacro7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
