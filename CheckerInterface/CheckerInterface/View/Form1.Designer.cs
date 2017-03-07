namespace CheckerInterface
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BlackRadioButton = new System.Windows.Forms.RadioButton();
            this.WhiteRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DamkaRadioButton = new System.Windows.Forms.RadioButton();
            this.CheckerRadioButton = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(223, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(367, 73);
            this.button1.TabIndex = 0;
            this.button1.Text = "One player";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(223, 130);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(367, 73);
            this.button2.TabIndex = 1;
            this.button2.Text = "Two players";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(223, 209);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(367, 73);
            this.button3.TabIndex = 2;
            this.button3.Text = "Load game";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(16, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 578);
            this.panel1.TabIndex = 3;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(223, 367);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(367, 73);
            this.button5.TabIndex = 4;
            this.button5.Text = "Setting";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(223, 288);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(367, 73);
            this.button4.TabIndex = 3;
            this.button4.Text = "Constructor";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(21, 37);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(119, 65);
            this.button6.TabIndex = 5;
            this.button6.Text = "Add";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BlackRadioButton);
            this.groupBox1.Controls.Add(this.WhiteRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(21, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 63);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Color";
            // 
            // BlackRadioButton
            // 
            this.BlackRadioButton.AutoSize = true;
            this.BlackRadioButton.Location = new System.Drawing.Point(6, 46);
            this.BlackRadioButton.Name = "BlackRadioButton";
            this.BlackRadioButton.Size = new System.Drawing.Size(52, 17);
            this.BlackRadioButton.TabIndex = 1;
            this.BlackRadioButton.TabStop = true;
            this.BlackRadioButton.Text = "Black";
            this.BlackRadioButton.UseVisualStyleBackColor = true;
            this.BlackRadioButton.CheckedChanged += new System.EventHandler(this.BlackRadioButton_CheckedChanged);
            // 
            // WhiteRadioButton
            // 
            this.WhiteRadioButton.Location = new System.Drawing.Point(6, 19);
            this.WhiteRadioButton.Name = "WhiteRadioButton";
            this.WhiteRadioButton.Size = new System.Drawing.Size(85, 17);
            this.WhiteRadioButton.TabIndex = 0;
            this.WhiteRadioButton.TabStop = true;
            this.WhiteRadioButton.Text = "White";
            this.WhiteRadioButton.UseVisualStyleBackColor = true;
            this.WhiteRadioButton.CheckedChanged += new System.EventHandler(this.WhiteRadioButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DamkaRadioButton);
            this.groupBox2.Controls.Add(this.CheckerRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(21, 201);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(119, 63);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Type";
            // 
            // DamkaRadioButton
            // 
            this.DamkaRadioButton.AutoSize = true;
            this.DamkaRadioButton.Location = new System.Drawing.Point(6, 46);
            this.DamkaRadioButton.Name = "DamkaRadioButton";
            this.DamkaRadioButton.Size = new System.Drawing.Size(59, 17);
            this.DamkaRadioButton.TabIndex = 1;
            this.DamkaRadioButton.TabStop = true;
            this.DamkaRadioButton.Text = "Damka";
            this.DamkaRadioButton.UseVisualStyleBackColor = true;
            this.DamkaRadioButton.CheckedChanged += new System.EventHandler(this.DamkaRadioButton_CheckedChanged);
            // 
            // CheckerRadioButton
            // 
            this.CheckerRadioButton.Location = new System.Drawing.Point(6, 19);
            this.CheckerRadioButton.Name = "CheckerRadioButton";
            this.CheckerRadioButton.Size = new System.Drawing.Size(85, 17);
            this.CheckerRadioButton.TabIndex = 0;
            this.CheckerRadioButton.TabStop = true;
            this.CheckerRadioButton.Text = "Checker";
            this.CheckerRadioButton.UseVisualStyleBackColor = true;
            this.CheckerRadioButton.CheckedChanged += new System.EventHandler(this.CheckerRadioButton_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Location = new System.Drawing.Point(729, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(176, 455);
            this.panel2.TabIndex = 8;
            this.panel2.Visible = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(21, 280);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(119, 65);
            this.button7.TabIndex = 8;
            this.button7.Text = "Delete";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(21, 361);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(119, 65);
            this.button8.TabIndex = 9;
            this.button8.Text = "Play";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 683);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;               
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton BlackRadioButton;
        public System.Windows.Forms.RadioButton WhiteRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.RadioButton DamkaRadioButton;
        public System.Windows.Forms.RadioButton CheckerRadioButton;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button button7;
        public System.Windows.Forms.Button button8;
    }
}

