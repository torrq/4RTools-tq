using _4RTools.Utils;
using System.Windows.Forms;
using System;

namespace _4RTools.Forms
{
    partial class AutoSwitchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoSwitchForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ITEMin319 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NEXTITEMin319 = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.AutoSwitchGP = new System.Windows.Forms.GroupBox();
            this.btnAddAutoSwitch = new System.Windows.Forms.Button();
            this.skillCB = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 10;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 10;
            this.toolTip1.ReshowDelay = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(412, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 296;
            this.pictureBox1.TabStop = false;
            // 
            // ITEMin319
            // 
            this.ITEMin319.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.ITEMin319.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ITEMin319.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ITEMin319.ForeColor = System.Drawing.Color.White;
            this.ITEMin319.Location = new System.Drawing.Point(453, 30);
            this.ITEMin319.Name = "ITEMin319";
            this.ITEMin319.Size = new System.Drawing.Size(45, 23);
            this.ITEMin319.TabIndex = 295;
            this.ITEMin319.TextChanged += new System.EventHandler(this.onTextChange);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(462, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 304;
            this.label2.Text = "Item";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(527, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 305;
            this.label3.Text = "Próximo item";
            // 
            // NEXTITEMin319
            // 
            this.NEXTITEMin319.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.NEXTITEMin319.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NEXTITEMin319.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.NEXTITEMin319.ForeColor = System.Drawing.Color.White;
            this.NEXTITEMin319.Location = new System.Drawing.Point(538, 30);
            this.NEXTITEMin319.Name = "NEXTITEMin319";
            this.NEXTITEMin319.Size = new System.Drawing.Size(45, 23);
            this.NEXTITEMin319.TabIndex = 308;
            this.NEXTITEMin319.TextChanged += new System.EventHandler(this.onTextChange);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(508, 36);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(19, 11);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 313;
            this.pictureBox4.TabStop = false;
            // 
            // AutoSwitchGP
            // 
            this.AutoSwitchGP.AutoSize = true;
            this.AutoSwitchGP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AutoSwitchGP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
            this.AutoSwitchGP.Location = new System.Drawing.Point(12, 43);
            this.AutoSwitchGP.Name = "AutoSwitchGP";
            this.AutoSwitchGP.Size = new System.Drawing.Size(292, 37);
            this.AutoSwitchGP.TabIndex = 314;
            this.AutoSwitchGP.TabStop = false;
            this.AutoSwitchGP.Text = "Customizados";
            // 
            // btnAddAutoSwitch
            // 
            this.btnAddAutoSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.btnAddAutoSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAutoSwitch.ForeColor = System.Drawing.Color.White;
            this.btnAddAutoSwitch.Location = new System.Drawing.Point(259, 10);
            this.btnAddAutoSwitch.Name = "btnAddAutoSwitch";
            this.btnAddAutoSwitch.Size = new System.Drawing.Size(45, 23);
            this.btnAddAutoSwitch.TabIndex = 316;
            this.btnAddAutoSwitch.Text = "Add";
            this.btnAddAutoSwitch.UseVisualStyleBackColor = false;
            this.btnAddAutoSwitch.Click += new System.EventHandler(this.btnNewSwitch);
            // 
            // skillCB
            // 
            this.skillCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.skillCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.skillCB.ForeColor = System.Drawing.Color.White;
            this.skillCB.Location = new System.Drawing.Point(12, 12);
            this.skillCB.Name = "skillCB";
            this.skillCB.Size = new System.Drawing.Size(241, 21);
            this.skillCB.TabIndex = 317;
            // 
            // AutoSwitchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(606, 388);
            this.Controls.Add(this.skillCB);
            this.Controls.Add(this.btnAddAutoSwitch);
            this.Controls.Add(this.AutoSwitchGP);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.NEXTITEMin319);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ITEMin319);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AutoSwitchForm";
            this.Text = "AutoSwitchForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox ITEMin319;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NEXTITEMin319;
        private System.Windows.Forms.PictureBox pictureBox4;
        private GroupBox AutoSwitchGP;
        private Button btnAddAutoSwitch;
        private ComboBox skillCB;
    }
}