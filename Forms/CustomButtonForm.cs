using System;
using System.Windows.Forms;
using _4RTools.Utils;
using _4RTools.Model;
using System.Windows.Input;

namespace _4RTools.Forms
{
    public partial class CustomButtonForm : Form, IObserver
    {

        private Custom custom;
        public CustomButtonForm(Subject subject)
        {
            InitializeComponent();
            toolTip1.SetToolTip(label1, "Simulates alt+right mouse button for quick transfer of items between storage and inventory");
            toolTip1.SetToolTip(pictureBox2, "Simulates alt+right mouse button for quick transfer of items between storage and inventory");
            subject.Attach(this);
        }

        public void Update(ISubject subject)
        {

            switch ((subject as Subject).Message.Code)
            {
                case MessageCode.PROFILE_CHANGED:
                    InitializeApplicationForm();
                    break;
                case MessageCode.TURN_OFF:
                    this.custom.Stop();
                    break;
                case MessageCode.TURN_ON:
                    this.custom.Start();
                    break;
            }
        }

        private void InitializeApplicationForm()
        {
            this.custom = ProfileSingleton.GetCurrent().Custom; 
            this.txtTransferKey.Text = custom.tiMode.ToString();

            this.txtTransferKey.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.txtTransferKey.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.txtTransferKey.TextChanged += new EventHandler(onTransferKeyChange);
            this.ActiveControl = null;
        }

        private void onTransferKeyChange(object sender, EventArgs e)
        {
            Key key = (Key)Enum.Parse(typeof(Key), this.txtTransferKey.Text.ToString());
            try
            {
                this.custom.tiMode = key;
                ProfileSingleton.SetConfiguration(this.custom);
            }
            catch { }
            this.ActiveControl = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtTransferKey_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
