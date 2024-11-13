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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkStopHealOnCity = new System.Windows.Forms.CheckBox();
            this.ammo2textBox = new System.Windows.Forms.TextBox();
            this.ammo1textBox = new System.Windows.Forms.TextBox();
            this.switchAmmoCheckBox = new System.Windows.Forms.CheckBox();
            this.textReinKey = new System.Windows.Forms.TextBox();
            this.getOffReinCheckBox = new System.Windows.Forms.CheckBox();
            this.chkStopBuffsOnRein = new System.Windows.Forms.CheckBox();
            this.chkStopBuffsOnCity = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.clientDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.chkStopOnAntiBot = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(127, 225);
            this.listBox1.TabIndex = 1;
            listBox1.MouseDown += listBox1_MouseDown;
            listBox1.DragOver += listBox1_DragOver;
            listBox1.DragDrop += listBox1_DragDrop;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ordem de uso de Autobuffs";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkStopOnAntiBot);
            this.groupBox1.Controls.Add(this.chkStopHealOnCity);
            this.groupBox1.Controls.Add(this.ammo2textBox);
            this.groupBox1.Controls.Add(this.ammo1textBox);
            this.groupBox1.Controls.Add(this.switchAmmoCheckBox);
            this.groupBox1.Controls.Add(this.textReinKey);
            this.groupBox1.Controls.Add(this.getOffReinCheckBox);
            this.groupBox1.Controls.Add(this.chkStopBuffsOnRein);
            this.groupBox1.Controls.Add(this.chkStopBuffsOnCity);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
            this.groupBox1.Location = new System.Drawing.Point(163, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 197);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurações TalesTools";
            // 
            // chkStopHealOnCity
            // 
            this.chkStopHealOnCity.AutoSize = true;
            this.chkStopHealOnCity.Location = new System.Drawing.Point(13, 51);
            this.chkStopHealOnCity.Name = "chkStopHealOnCity";
            this.chkStopHealOnCity.Size = new System.Drawing.Size(133, 17);
            this.chkStopHealOnCity.TabIndex = 310;
            this.chkStopHealOnCity.Text = "Pausar cura na cidade";
            this.chkStopHealOnCity.UseVisualStyleBackColor = true;
            this.chkStopHealOnCity.CheckedChanged += new System.EventHandler(this.chkStopHealOnCity_CheckedChanged);
            // 
            // ammo2textBox
            // 
            this.ammo2textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.ammo2textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ammo2textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ammo2textBox.ForeColor = System.Drawing.Color.White;
            this.ammo2textBox.Location = new System.Drawing.Point(245, 127);
            this.ammo2textBox.Name = "ammo2textBox";
            this.ammo2textBox.Size = new System.Drawing.Size(45, 23);
            this.ammo2textBox.TabIndex = 309;
            // 
            // ammo1textBox
            // 
            this.ammo1textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.ammo1textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ammo1textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ammo1textBox.ForeColor = System.Drawing.Color.White;
            this.ammo1textBox.Location = new System.Drawing.Point(194, 127);
            this.ammo1textBox.Name = "ammo1textBox";
            this.ammo1textBox.Size = new System.Drawing.Size(45, 23);
            this.ammo1textBox.TabIndex = 308;
            // 
            // switchAmmoCheckBox
            // 
            this.switchAmmoCheckBox.AutoSize = true;
            this.switchAmmoCheckBox.Location = new System.Drawing.Point(13, 129);
            this.switchAmmoCheckBox.Name = "switchAmmoCheckBox";
            this.switchAmmoCheckBox.Size = new System.Drawing.Size(168, 17);
            this.switchAmmoCheckBox.TabIndex = 307;
            this.switchAmmoCheckBox.Text = "Troca Automática de munição";
            this.switchAmmoCheckBox.UseVisualStyleBackColor = true;
            this.switchAmmoCheckBox.CheckedChanged += new System.EventHandler(this.switchAmmoCheckBox_CheckedChanged);
            // 
            // textReinKey
            // 
            this.textReinKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.textReinKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textReinKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textReinKey.ForeColor = System.Drawing.Color.White;
            this.textReinKey.Location = new System.Drawing.Point(194, 99);
            this.textReinKey.Name = "textReinKey";
            this.textReinKey.Size = new System.Drawing.Size(45, 23);
            this.textReinKey.TabIndex = 306;
            // 
            // getOffReinCheckBox
            // 
            this.getOffReinCheckBox.AutoSize = true;
            this.getOffReinCheckBox.Location = new System.Drawing.Point(13, 101);
            this.getOffReinCheckBox.Name = "getOffReinCheckBox";
            this.getOffReinCheckBox.Size = new System.Drawing.Size(175, 17);
            this.getOffReinCheckBox.TabIndex = 2;
            this.getOffReinCheckBox.Text = "Desmontar da Rédea ao atacar";
            this.getOffReinCheckBox.UseVisualStyleBackColor = true;
            this.getOffReinCheckBox.CheckedChanged += new System.EventHandler(this.getOffReinCheckBox_CheckedChanged);
            // 
            // chkStopBuffsOnRein
            // 
            this.chkStopBuffsOnRein.AutoSize = true;
            this.chkStopBuffsOnRein.Location = new System.Drawing.Point(13, 76);
            this.chkStopBuffsOnRein.Name = "chkStopBuffsOnRein";
            this.chkStopBuffsOnRein.Size = new System.Drawing.Size(166, 17);
            this.chkStopBuffsOnRein.TabIndex = 1;
            this.chkStopBuffsOnRein.Text = "Pausar autobuff-skill na rédea";
            this.chkStopBuffsOnRein.UseVisualStyleBackColor = true;
            this.chkStopBuffsOnRein.CheckedChanged += new System.EventHandler(this.chkStopBuffsOnRein_CheckedChanged);
            // 
            // chkStopBuffsOnCity
            // 
            this.chkStopBuffsOnCity.AutoSize = true;
            this.chkStopBuffsOnCity.Location = new System.Drawing.Point(13, 27);
            this.chkStopBuffsOnCity.Name = "chkStopBuffsOnCity";
            this.chkStopBuffsOnCity.Size = new System.Drawing.Size(262, 17);
            this.chkStopBuffsOnCity.TabIndex = 0;
            this.chkStopBuffsOnCity.Text = "Pausar autobuffs/skill timer/auto switch na cidade";
            this.chkStopBuffsOnCity.UseVisualStyleBackColor = true;
            this.chkStopBuffsOnCity.CheckedChanged += new System.EventHandler(this.chkStopBuffsOnCity_CheckedChanged);
            // 
            // clientDTOBindingSource
            // 
            this.clientDTOBindingSource.DataSource = typeof(_4RTools.Model.ClientDTO);
            // 
            // chkStopOnAntiBot
            // 
            this.chkStopOnAntiBot.AutoSize = true;
            this.chkStopOnAntiBot.Location = new System.Drawing.Point(13, 154);
            this.chkStopOnAntiBot.Name = "chkStopOnAntiBot";
            this.chkStopOnAntiBot.Size = new System.Drawing.Size(138, 17);
            this.chkStopOnAntiBot.TabIndex = 311;
            this.chkStopOnAntiBot.Text = "Pausar durante Anti-Bot";
            this.chkStopOnAntiBot.UseVisualStyleBackColor = true;
            this.chkStopOnAntiBot.CheckedChanged += new System.EventHandler(this.chkStopOnAntiBot_CheckedChanged);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(500, 256);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
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
        private ListBox listBox1;
        private Label label2;
        private GroupBox groupBox1;
        private CheckBox chkStopBuffsOnRein;
        private CheckBox chkStopBuffsOnCity;
        private CheckBox getOffReinCheckBox;
        private TextBox textReinKey;
        private TextBox ammo2textBox;
        private TextBox ammo1textBox;
        private CheckBox switchAmmoCheckBox;
        private CheckBox chkStopHealOnCity;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private ToolTip toolTip3;
        private ToolTip toolTip4;
        private CheckBox chkStopOnAntiBot;
    }
}