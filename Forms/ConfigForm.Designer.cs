using System;
using System.Windows.Forms;

namespace _4RTools.Forms
{
    partial class ConfigForm
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
            this.skillsListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ammo2textBox = new System.Windows.Forms.TextBox();
            this.ammo1textBox = new System.Windows.Forms.TextBox();
            this.switchAmmoCheckBox = new System.Windows.Forms.CheckBox();
            this.chkStopBuffsOnCity = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.switchListBox = new System.Windows.Forms.ListBox();
            this.clientDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // skillsListBox
            // 
            this.skillsListBox.AllowDrop = true;
            this.skillsListBox.FormattingEnabled = true;
            this.skillsListBox.Location = new System.Drawing.Point(13, 25);
            this.skillsListBox.Name = "skillsListBox";
            this.skillsListBox.Size = new System.Drawing.Size(127, 225);
            this.skillsListBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Order of using Autobuffs";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ammo2textBox);
            this.groupBox1.Controls.Add(this.ammo1textBox);
            this.groupBox1.Controls.Add(this.switchAmmoCheckBox);
            this.groupBox1.Controls.Add(this.chkStopBuffsOnCity);
            this.groupBox1.Location = new System.Drawing.Point(309, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 197);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "4ROTools Settings";
            // 
            // ammo2textBox
            // 
            this.ammo2textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ammo2textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ammo2textBox.Location = new System.Drawing.Point(243, 74);
            this.ammo2textBox.Name = "ammo2textBox";
            this.ammo2textBox.Size = new System.Drawing.Size(45, 23);
            this.ammo2textBox.TabIndex = 309;
            // 
            // ammo1textBox
            // 
            this.ammo1textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ammo1textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ammo1textBox.Location = new System.Drawing.Point(192, 74);
            this.ammo1textBox.Name = "ammo1textBox";
            this.ammo1textBox.Size = new System.Drawing.Size(45, 23);
            this.ammo1textBox.TabIndex = 308;
            // 
            // switchAmmoCheckBox
            // 
            this.switchAmmoCheckBox.AutoSize = true;
            this.switchAmmoCheckBox.Location = new System.Drawing.Point(13, 74);
            this.switchAmmoCheckBox.Name = "switchAmmoCheckBox";
            this.switchAmmoCheckBox.Size = new System.Drawing.Size(135, 17);
            this.switchAmmoCheckBox.TabIndex = 307;
            this.switchAmmoCheckBox.Text = "Automatic Ammo Swap";
            this.switchAmmoCheckBox.UseVisualStyleBackColor = true;
            this.switchAmmoCheckBox.CheckedChanged += new System.EventHandler(this.switchAmmoCheckBox_CheckedChanged);
            // 
            // chkStopBuffsOnCity
            // 
            this.chkStopBuffsOnCity.AutoSize = true;
            this.chkStopBuffsOnCity.Location = new System.Drawing.Point(13, 27);
            this.chkStopBuffsOnCity.Name = "chkStopBuffsOnCity";
            this.chkStopBuffsOnCity.Size = new System.Drawing.Size(246, 17);
            this.chkStopBuffsOnCity.TabIndex = 0;
            this.chkStopBuffsOnCity.Text = "Pause autobuffs/skill timer/auto switch in town";
            this.chkStopBuffsOnCity.UseVisualStyleBackColor = true;
            this.chkStopBuffsOnCity.CheckedChanged += new System.EventHandler(this.chkStopBuffsOnCity_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "MasterBall Usage Order";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // switchListBox
            // 
            this.switchListBox.AllowDrop = true;
            this.switchListBox.FormattingEnabled = true;
            this.switchListBox.Location = new System.Drawing.Point(161, 25);
            this.switchListBox.Name = "switchListBox";
            this.switchListBox.Size = new System.Drawing.Size(127, 225);
            this.switchListBox.TabIndex = 4;
            // 
            // clientDTOBindingSource
            // 
            this.clientDTOBindingSource.DataSource = typeof(_4RTools.Model.ClientDTO);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 256);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.switchListBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.skillsListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfigForm";
            this.Text = "ConfigForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientDTOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      
        #endregion
        private System.Windows.Forms.BindingSource clientDTOBindingSource;
        private ListBox skillsListBox;
        private Label label2;
        private GroupBox groupBox1;
        private CheckBox chkStopBuffsOnCity;
        private TextBox ammo2textBox;
        private TextBox ammo1textBox;
        private CheckBox switchAmmoCheckBox;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private ToolTip toolTip3;
        private ToolTip toolTip4;
        private Label label1;
        private ListBox switchListBox;
    }
}