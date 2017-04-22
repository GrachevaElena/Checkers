namespace CheckerInterface.View
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.buttonPlay = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButtonWhiteBot = new System.Windows.Forms.RadioButton();
            this.radioButtonWhiteHuman = new System.Windows.Forms.RadioButton();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.radioButtonBlackBot = new System.Windows.Forms.RadioButton();
            this.radioButtonBlackHuman = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(441, 327);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(139, 37);
            this.buttonPlay.TabIndex = 2;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.labelPlayer1);
            this.panel1.Location = new System.Drawing.Point(22, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 297);
            this.panel1.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(32, 104);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(219, 170);
            this.panel4.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "There will be bot\'s settings";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radioButtonWhiteBot);
            this.panel3.Controls.Add(this.radioButtonWhiteHuman);
            this.panel3.Location = new System.Drawing.Point(3, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(164, 60);
            this.panel3.TabIndex = 2;
            // 
            // radioButtonWhiteBot
            // 
            this.radioButtonWhiteBot.AutoSize = true;
            this.radioButtonWhiteBot.Location = new System.Drawing.Point(26, 32);
            this.radioButtonWhiteBot.Name = "radioButtonWhiteBot";
            this.radioButtonWhiteBot.Size = new System.Drawing.Size(40, 17);
            this.radioButtonWhiteBot.TabIndex = 0;
            this.radioButtonWhiteBot.TabStop = true;
            this.radioButtonWhiteBot.Text = "bot";
            this.radioButtonWhiteBot.UseVisualStyleBackColor = true;
            // 
            // radioButtonWhiteHuman
            // 
            this.radioButtonWhiteHuman.AutoSize = true;
            this.radioButtonWhiteHuman.Location = new System.Drawing.Point(25, 9);
            this.radioButtonWhiteHuman.Name = "radioButtonWhiteHuman";
            this.radioButtonWhiteHuman.Size = new System.Drawing.Size(57, 17);
            this.radioButtonWhiteHuman.TabIndex = 0;
            this.radioButtonWhiteHuman.TabStop = true;
            this.radioButtonWhiteHuman.Text = "human";
            this.radioButtonWhiteHuman.UseVisualStyleBackColor = true;
            this.radioButtonWhiteHuman.Click += new System.EventHandler(this.RadButtonHumanOrBotWhite_Click);
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPlayer1.Location = new System.Drawing.Point(29, 10);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(47, 15);
            this.labelPlayer1.TabIndex = 1;
            this.labelPlayer1.Text = "White:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(296, 327);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(139, 37);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(315, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(276, 297);
            this.panel2.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Location = new System.Drawing.Point(32, 104);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(219, 170);
            this.panel5.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "There will be bot\'s settings";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.radioButtonBlackBot);
            this.panel6.Controls.Add(this.radioButtonBlackHuman);
            this.panel6.Location = new System.Drawing.Point(3, 38);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(164, 60);
            this.panel6.TabIndex = 2;
            // 
            // radioButtonBlackBot
            // 
            this.radioButtonBlackBot.AutoSize = true;
            this.radioButtonBlackBot.Location = new System.Drawing.Point(26, 32);
            this.radioButtonBlackBot.Name = "radioButtonBlackBot";
            this.radioButtonBlackBot.Size = new System.Drawing.Size(40, 17);
            this.radioButtonBlackBot.TabIndex = 0;
            this.radioButtonBlackBot.TabStop = true;
            this.radioButtonBlackBot.Text = "bot";
            this.radioButtonBlackBot.UseVisualStyleBackColor = true;
            // 
            // radioButtonBlackHuman
            // 
            this.radioButtonBlackHuman.AutoSize = true;
            this.radioButtonBlackHuman.Location = new System.Drawing.Point(25, 9);
            this.radioButtonBlackHuman.Name = "radioButtonBlackHuman";
            this.radioButtonBlackHuman.Size = new System.Drawing.Size(57, 17);
            this.radioButtonBlackHuman.TabIndex = 0;
            this.radioButtonBlackHuman.TabStop = true;
            this.radioButtonBlackHuman.Text = "human";
            this.radioButtonBlackHuman.UseVisualStyleBackColor = true;
            this.radioButtonBlackHuman.Click += new System.EventHandler(this.RadButtonHumanOrBotBlack_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(29, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Black:";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(612, 401);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPlay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingForm";
            this.Text = "Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioButtonWhiteBot;
        private System.Windows.Forms.RadioButton radioButtonWhiteHuman;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton radioButtonBlackBot;
        private System.Windows.Forms.RadioButton radioButtonBlackHuman;
        private System.Windows.Forms.Label label3;
    }
}