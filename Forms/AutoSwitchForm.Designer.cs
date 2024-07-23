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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ITEMin319 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ITEMin30 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SKILLin30 = new System.Windows.Forms.TextBox();
            this.NEXTITEMin30 = new System.Windows.Forms.TextBox();
            this.NEXTITEMin319 = new System.Windows.Forms.TextBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.NEXTITEMin110 = new System.Windows.Forms.TextBox();
            this.SKILLin110 = new System.Windows.Forms.TextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.ITEMin110 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 10;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 10;
            this.toolTip1.ReshowDelay = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 297;
            this.label1.Text = "Skill";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 64);
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
            this.ITEMin319.Location = new System.Drawing.Point(52, 65);
            this.ITEMin319.Name = "ITEMin319";
            this.ITEMin319.Size = new System.Drawing.Size(45, 23);
            this.ITEMin319.TabIndex = 295;
            this.ITEMin319.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.ITEMin319.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.ITEMin319.TextChanged += new EventHandler(this.onTextChange);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 304;
            this.label2.Text = "Item";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(11, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 303;
            this.pictureBox2.TabStop = false;
            // 
            // ITEMin30
            // 
            this.ITEMin30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.ITEMin30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ITEMin30.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ITEMin30.ForeColor = System.Drawing.Color.White;
            this.ITEMin30.Location = new System.Drawing.Point(52, 26);
            this.ITEMin30.Name = "ITEMin30";
            this.ITEMin30.Size = new System.Drawing.Size(45, 23);
            this.ITEMin30.TabIndex = 302;
            this.ITEMin30.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.ITEMin30.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.ITEMin30.TextChanged += new EventHandler(this.onTextChange);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 305;
            this.label3.Text = "Próximo item";
            // 
            // SKILLin30
            // 
            this.SKILLin30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.SKILLin30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SKILLin30.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SKILLin30.ForeColor = System.Drawing.Color.White;
            this.SKILLin30.Location = new System.Drawing.Point(143, 26);
            this.SKILLin30.Name = "SKILLin30";
            this.SKILLin30.Size = new System.Drawing.Size(45, 23);
            this.SKILLin30.TabIndex = 307;
            this.SKILLin30.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.SKILLin30.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.SKILLin30.TextChanged += new EventHandler(this.onTextChange);
            // 
            // NEXTITEMin30
            // 
            this.NEXTITEMin30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.NEXTITEMin30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NEXTITEMin30.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.NEXTITEMin30.ForeColor = System.Drawing.Color.White;
            this.NEXTITEMin30.Location = new System.Drawing.Point(239, 26);
            this.NEXTITEMin30.Name = "NEXTITEMin30";
            this.NEXTITEMin30.Size = new System.Drawing.Size(45, 23);
            this.NEXTITEMin30.TabIndex = 309;
            this.NEXTITEMin30.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.NEXTITEMin30.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.NEXTITEMin30.TextChanged += new EventHandler(this.onTextChange);
            // 
            // NEXTITEMin319
            // 
            this.NEXTITEMin319.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.NEXTITEMin319.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NEXTITEMin319.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.NEXTITEMin319.ForeColor = System.Drawing.Color.White;
            this.NEXTITEMin319.Location = new System.Drawing.Point(239, 65);
            this.NEXTITEMin319.Name = "NEXTITEMin319";
            this.NEXTITEMin319.Size = new System.Drawing.Size(45, 23);
            this.NEXTITEMin319.TabIndex = 308;
            this.NEXTITEMin319.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.NEXTITEMin319.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.NEXTITEMin319.TextChanged += new EventHandler(this.onTextChange);
            // 
            // pictureBox13
            // 
            this.pictureBox13.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox13.Image")));
            this.pictureBox13.Location = new System.Drawing.Point(110, 33);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(19, 11);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox13.TabIndex = 310;
            this.pictureBox13.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(156, 71);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(19, 11);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 313;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(203, 33);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(19, 11);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 312;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(203, 110);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(19, 11);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 319;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(110, 110);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(19, 11);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox6.TabIndex = 318;
            this.pictureBox6.TabStop = false;
            // 
            // NEXTITEMin110
            // 
            this.NEXTITEMin110.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.NEXTITEMin110.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NEXTITEMin110.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.NEXTITEMin110.ForeColor = System.Drawing.Color.White;
            this.NEXTITEMin110.Location = new System.Drawing.Point(239, 103);
            this.NEXTITEMin110.Name = "NEXTITEMin110";
            this.NEXTITEMin110.Size = new System.Drawing.Size(45, 23);
            this.NEXTITEMin110.TabIndex = 317;
            this.NEXTITEMin110.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.NEXTITEMin110.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.NEXTITEMin110.TextChanged += new EventHandler(this.onTextChange);
            // 
            // SKILLin110
            // 
            this.SKILLin110.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.SKILLin110.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SKILLin110.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SKILLin110.ForeColor = System.Drawing.Color.White;
            this.SKILLin110.Location = new System.Drawing.Point(143, 103);
            this.SKILLin110.Name = "SKILLin110";
            this.SKILLin110.Size = new System.Drawing.Size(45, 23);
            this.SKILLin110.TabIndex = 316;
            this.SKILLin110.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.SKILLin110.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.SKILLin110.TextChanged += new EventHandler(this.onTextChange);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(11, 102);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(24, 24);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 315;
            this.pictureBox7.TabStop = false;
            // 
            // ITEMin110
            // 
            this.ITEMin110.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(56)))));
            this.ITEMin110.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ITEMin110.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ITEMin110.ForeColor = System.Drawing.Color.White;
            this.ITEMin110.Location = new System.Drawing.Point(52, 103);
            this.ITEMin110.Name = "ITEMin110";
            this.ITEMin110.Size = new System.Drawing.Size(45, 23);
            this.ITEMin110.TabIndex = 314;
            this.ITEMin110.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.ITEMin110.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.ITEMin110.TextChanged += new EventHandler(this.onTextChange);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 320;
            this.label4.Text = "(Escudo 2)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 321;
            this.label5.Text = "(Perg Éden)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(224, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 322;
            this.label6.Text = "(Escudo GTB)";
            // 
            // AutoSwitchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.NEXTITEMin110);
            this.Controls.Add(this.SKILLin110);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.ITEMin110);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox13);
            this.Controls.Add(this.NEXTITEMin30);
            this.Controls.Add(this.NEXTITEMin319);
            this.Controls.Add(this.SKILLin30);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ITEMin30);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ITEMin319);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(155)))), ((int)(((byte)(164)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AutoSwitchForm";
            this.Text = "AutoSwitchForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox ITEMin319;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox ITEMin30;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SKILLin30;
        private System.Windows.Forms.TextBox NEXTITEMin30;
        private System.Windows.Forms.TextBox NEXTITEMin319;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.TextBox NEXTITEMin110;
        private System.Windows.Forms.TextBox SKILLin110;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.TextBox ITEMin110;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}