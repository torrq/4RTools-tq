﻿namespace _4RTools.Forms
{
    partial class AutopotForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutopotForm));
            this.txtHPpct = new System.Windows.Forms.NumericUpDown();
            this.labelSP = new System.Windows.Forms.Label();
            this.labelHP = new System.Windows.Forms.Label();
            this.txtAutopotDelay = new System.Windows.Forms.TextBox();
            this.picBoxSP = new System.Windows.Forms.PictureBox();
            this.picBoxHP = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHpKey = new System.Windows.Forms.TextBox();
            this.txtSPKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSPpct = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.firstHP = new System.Windows.Forms.RadioButton();
            this.firstSP = new System.Windows.Forms.RadioButton();
            this.chkStopWitchFC = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtHPpct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSPpct)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHPpct
            // 
            this.txtHPpct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHPpct.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHPpct.Location = new System.Drawing.Point(215, 35);
            this.txtHPpct.Name = "txtHPpct";
            this.txtHPpct.Size = new System.Drawing.Size(44, 25);
            this.txtHPpct.TabIndex = 39;
            this.txtHPpct.ValueChanged += new System.EventHandler(this.txtHPpctTextChanged);
            // 
            // labelSP
            // 
            this.labelSP.AutoSize = true;
            this.labelSP.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.labelSP.Location = new System.Drawing.Point(261, 80);
            this.labelSP.Name = "labelSP";
            this.labelSP.Size = new System.Drawing.Size(21, 20);
            this.labelSP.TabIndex = 38;
            this.labelSP.Text = "%";
            // 
            // labelHP
            // 
            this.labelHP.AutoSize = true;
            this.labelHP.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.labelHP.Location = new System.Drawing.Point(261, 37);
            this.labelHP.Name = "labelHP";
            this.labelHP.Size = new System.Drawing.Size(21, 20);
            this.labelHP.TabIndex = 37;
            this.labelHP.Text = "%";
            // 
            // txtAutopotDelay
            // 
            this.txtAutopotDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAutopotDelay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAutopotDelay.Location = new System.Drawing.Point(215, 115);
            this.txtAutopotDelay.Name = "txtAutopotDelay";
            this.txtAutopotDelay.Size = new System.Drawing.Size(44, 25);
            this.txtAutopotDelay.TabIndex = 36;
            this.txtAutopotDelay.TextChanged += new System.EventHandler(this.txtAutopotDelayTextChanged);
            // 
            // picBoxSP
            // 
            this.picBoxSP.BackColor = System.Drawing.Color.Transparent;
            this.picBoxSP.Image = ((System.Drawing.Image)(resources.GetObject("picBoxSP.Image")));
            this.picBoxSP.Location = new System.Drawing.Point(56, 71);
            this.picBoxSP.Name = "picBoxSP";
            this.picBoxSP.Size = new System.Drawing.Size(38, 38);
            this.picBoxSP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picBoxSP.TabIndex = 35;
            this.picBoxSP.TabStop = false;
            // 
            // picBoxHP
            // 
            this.picBoxHP.BackColor = System.Drawing.Color.Transparent;
            this.picBoxHP.Image = ((System.Drawing.Image)(resources.GetObject("picBoxHP.Image")));
            this.picBoxHP.Location = new System.Drawing.Point(56, 28);
            this.picBoxHP.Name = "picBoxHP";
            this.picBoxHP.Size = new System.Drawing.Size(38, 38);
            this.picBoxHP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxHP.TabIndex = 34;
            this.picBoxHP.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(172, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 41;
            this.label2.Text = "Delay";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(260, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 42;
            this.label1.Text = "ms";
            // 
            // txtHpKey
            // 
            this.txtHpKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHpKey.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHpKey.Location = new System.Drawing.Point(127, 35);
            this.txtHpKey.Name = "txtHpKey";
            this.txtHpKey.Size = new System.Drawing.Size(61, 25);
            this.txtHpKey.TabIndex = 43;
            // 
            // txtSPKey
            // 
            this.txtSPKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSPKey.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSPKey.Location = new System.Drawing.Point(127, 78);
            this.txtSPKey.Name = "txtSPKey";
            this.txtSPKey.Size = new System.Drawing.Size(61, 25);
            this.txtSPKey.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label3.Location = new System.Drawing.Point(95, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 20);
            this.label3.TabIndex = 45;
            this.label3.Text = "HP";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(98, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 20);
            this.label4.TabIndex = 46;
            this.label4.Text = "SP";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtSPpct
            // 
            this.txtSPpct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSPpct.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSPpct.Location = new System.Drawing.Point(215, 78);
            this.txtSPpct.Name = "txtSPpct";
            this.txtSPpct.Size = new System.Drawing.Size(44, 25);
            this.txtSPpct.TabIndex = 40;
            this.txtSPpct.ValueChanged += new System.EventHandler(this.txtSPpctTextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 20);
            this.label5.TabIndex = 47;
            this.label5.Text = "First";
            // 
            // firstHP
            // 
            this.firstHP.AutoSize = true;
            this.firstHP.Checked = true;
            this.firstHP.Location = new System.Drawing.Point(36, 41);
            this.firstHP.Name = "firstHP";
            this.firstHP.Size = new System.Drawing.Size(14, 13);
            this.firstHP.TabIndex = 48;
            this.firstHP.TabStop = true;
            this.firstHP.UseVisualStyleBackColor = true;
            this.firstHP.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // firstSP
            // 
            this.firstSP.AutoSize = true;
            this.firstSP.Location = new System.Drawing.Point(36, 84);
            this.firstSP.Name = "firstSP";
            this.firstSP.Size = new System.Drawing.Size(14, 13);
            this.firstSP.TabIndex = 49;
            this.firstSP.UseVisualStyleBackColor = true;
            this.firstSP.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // chkStopWitchFC
            // 
            this.chkStopWitchFC.AutoSize = true;
            this.chkStopWitchFC.Location = new System.Drawing.Point(12, 123);
            this.chkStopWitchFC.Name = "chkStopWitchFC";
            this.chkStopWitchFC.Size = new System.Drawing.Size(137, 17);
            this.chkStopWitchFC.TabIndex = 50;
            this.chkStopWitchFC.Text = "Stop on Critical Injury";
            this.chkStopWitchFC.UseVisualStyleBackColor = true;
            this.chkStopWitchFC.CheckedChanged += new System.EventHandler(this.chkStopWitchFC_CheckedChanged);
            // 
            // AutopotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.chkStopWitchFC);
            this.Controls.Add(this.firstSP);
            this.Controls.Add(this.firstHP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSPKey);
            this.Controls.Add(this.txtHpKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSPpct);
            this.Controls.Add(this.txtHPpct);
            this.Controls.Add(this.labelSP);
            this.Controls.Add(this.labelHP);
            this.Controls.Add(this.txtAutopotDelay);
            this.Controls.Add(this.picBoxSP);
            this.Controls.Add(this.picBoxHP);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AutopotForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AutopotForm";
            this.Load += new System.EventHandler(this.AutopotForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtHPpct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSPpct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown txtHPpct;
        private System.Windows.Forms.Label labelSP;
        private System.Windows.Forms.Label labelHP;
        private System.Windows.Forms.TextBox txtAutopotDelay;
        private System.Windows.Forms.PictureBox picBoxSP;
        private System.Windows.Forms.PictureBox picBoxHP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHpKey;
        private System.Windows.Forms.TextBox txtSPKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtSPpct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton firstHP;
        private System.Windows.Forms.RadioButton firstSP;
        private System.Windows.Forms.CheckBox chkStopWitchFC;
    }
}