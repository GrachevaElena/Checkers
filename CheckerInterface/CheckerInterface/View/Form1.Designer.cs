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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BlackRadioButton = new System.Windows.Forms.RadioButton();
            this.WhiteRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DamkaRadioButton = new System.Windows.Forms.RadioButton();
            this.CheckerRadioButton = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.panelBackground = new System.Windows.Forms.Panel();
            this.panelborder = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelBackground.SuspendLayout();
            this.panelborder.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Peru;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.button1.Location = new System.Drawing.Point(276, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(367, 73);
            this.button1.TabIndex = 0;
            this.button1.Text = "One player";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.but1Play1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Peru;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.button2.Location = new System.Drawing.Point(276, 350);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(367, 73);
            this.button2.TabIndex = 1;
            this.button2.Text = "Two players";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.but2Play2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(29, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 538);
            this.panel1.TabIndex = 3;
            this.panel1.Visible = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.Peru;
            this.button6.FlatAppearance.BorderSize = 2;
            this.button6.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.ForeColor = System.Drawing.Color.SaddleBrown;
            this.button6.Location = new System.Drawing.Point(276, 160);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(367, 73);
            this.button6.TabIndex = 5;
            this.button6.Text = "Bot VS Bot";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.but0botVSbot_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Peru;
            this.button4.FlatAppearance.BorderSize = 2;
            this.button4.FlatAppearance.CheckedBackColor = System.Drawing.Color.White;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.ForeColor = System.Drawing.Color.SaddleBrown;
            this.button4.Location = new System.Drawing.Point(276, 445);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(367, 73);
            this.button4.TabIndex = 3;
            this.button4.Text = "Constructor";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.but4Constr_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BlackRadioButton);
            this.groupBox1.Controls.Add(this.WhiteRadioButton);
            this.groupBox1.Enabled = false;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.groupBox1.Location = new System.Drawing.Point(11, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 75);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Color";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // BlackRadioButton
            // 
            this.BlackRadioButton.AutoSize = true;
            this.BlackRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BlackRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(56)))), ((int)(((byte)(2)))));
            this.BlackRadioButton.Location = new System.Drawing.Point(6, 50);
            this.BlackRadioButton.Name = "BlackRadioButton";
            this.BlackRadioButton.Size = new System.Drawing.Size(60, 21);
            this.BlackRadioButton.TabIndex = 1;
            this.BlackRadioButton.Text = "Black";
            this.BlackRadioButton.UseVisualStyleBackColor = true;
            this.BlackRadioButton.CheckedChanged += new System.EventHandler(this.BlackRadioBut_CheckedChanged);
            // 
            // WhiteRadioButton
            // 
            this.WhiteRadioButton.Checked = true;
            this.WhiteRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WhiteRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(56)))), ((int)(((byte)(2)))));
            this.WhiteRadioButton.Location = new System.Drawing.Point(6, 22);
            this.WhiteRadioButton.Name = "WhiteRadioButton";
            this.WhiteRadioButton.Size = new System.Drawing.Size(85, 25);
            this.WhiteRadioButton.TabIndex = 0;
            this.WhiteRadioButton.TabStop = true;
            this.WhiteRadioButton.Text = "White";
            this.WhiteRadioButton.UseVisualStyleBackColor = true;
            this.WhiteRadioButton.CheckedChanged += new System.EventHandler(this.WhiteRadioBut_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DamkaRadioButton);
            this.groupBox2.Controls.Add(this.CheckerRadioButton);
            this.groupBox2.Enabled = false;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(56)))), ((int)(((byte)(2)))));
            this.groupBox2.Location = new System.Drawing.Point(11, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(119, 75);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Type";
            // 
            // DamkaRadioButton
            // 
            this.DamkaRadioButton.AutoSize = true;
            this.DamkaRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DamkaRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(56)))), ((int)(((byte)(2)))));
            this.DamkaRadioButton.Location = new System.Drawing.Point(6, 50);
            this.DamkaRadioButton.Name = "DamkaRadioButton";
            this.DamkaRadioButton.Size = new System.Drawing.Size(70, 21);
            this.DamkaRadioButton.TabIndex = 1;
            this.DamkaRadioButton.Text = "Damka";
            this.DamkaRadioButton.UseVisualStyleBackColor = true;
            this.DamkaRadioButton.CheckedChanged += new System.EventHandler(this.DamkaRadioButton_CheckedChanged);
            // 
            // CheckerRadioButton
            // 
            this.CheckerRadioButton.Checked = true;
            this.CheckerRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckerRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(56)))), ((int)(((byte)(2)))));
            this.CheckerRadioButton.Location = new System.Drawing.Point(6, 22);
            this.CheckerRadioButton.Name = "CheckerRadioButton";
            this.CheckerRadioButton.Size = new System.Drawing.Size(85, 25);
            this.CheckerRadioButton.TabIndex = 0;
            this.CheckerRadioButton.TabStop = true;
            this.CheckerRadioButton.Text = "Checker";
            this.CheckerRadioButton.UseVisualStyleBackColor = true;
            this.CheckerRadioButton.CheckedChanged += new System.EventHandler(this.ChRadioBut_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(242)))), ((int)(((byte)(200)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.buttonDelete);
            this.panel2.Controls.Add(this.buttonPlay);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(721, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(161, 455);
            this.panel2.TabIndex = 8;
            this.panel2.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonAdd);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Location = new System.Drawing.Point(10, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(140, 250);
            this.panel3.TabIndex = 10;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.White;
            this.buttonAdd.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(93)))), ((int)(((byte)(5)))));
            this.buttonAdd.Location = new System.Drawing.Point(11, 18);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(119, 37);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAddCh_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.White;
            this.buttonDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(93)))), ((int)(((byte)(5)))));
            this.buttonDelete.Location = new System.Drawing.Point(21, 273);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(119, 37);
            this.buttonDelete.TabIndex = 0;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDeleteChecker_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonPlay.Enabled = false;
            this.buttonPlay.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.buttonPlay.FlatAppearance.BorderSize = 2;
            this.buttonPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPlay.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonPlay.Location = new System.Drawing.Point(21, 366);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(119, 65);
            this.buttonPlay.TabIndex = 9;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = false;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // panelBackground
            // 
            this.panelBackground.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelBackground.BackgroundImage")));
            this.panelBackground.Controls.Add(this.button4);
            this.panelBackground.Controls.Add(this.panel2);
            this.panelBackground.Controls.Add(this.button2);
            this.panelBackground.Controls.Add(this.button1);
            this.panelBackground.Controls.Add(this.button6);
            this.panelBackground.Controls.Add(this.panelborder);
            this.panelBackground.Location = new System.Drawing.Point(-1, -1);
            this.panelBackground.Name = "panelBackground";
            this.panelBackground.Size = new System.Drawing.Size(919, 683);
            this.panelBackground.TabIndex = 9;
            // 
            // panelborder
            // 
            this.panelborder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(129)))), ((int)(((byte)(45)))));
            this.panelborder.Controls.Add(this.panel1);
            this.panelborder.Enabled = false;
            this.panelborder.Location = new System.Drawing.Point(46, 25);
            this.panelborder.Name = "panelborder";
            this.panelborder.Size = new System.Drawing.Size(712, 590);
            this.panelborder.TabIndex = 9;
            this.panelborder.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 683);
            this.Controls.Add(this.panelBackground);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Russian Checkers";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelBackground.ResumeLayout(false);
            this.panelborder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton BlackRadioButton;
        private System.Windows.Forms.RadioButton WhiteRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton DamkaRadioButton;
        private System.Windows.Forms.RadioButton CheckerRadioButton;
        public System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Panel panelBackground;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelborder;
    }
}

