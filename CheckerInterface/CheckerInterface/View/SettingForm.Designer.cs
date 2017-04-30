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
            this.comboBox1evaluate = new System.Windows.Forms.ComboBox();
            this.comboBox1depth = new System.Windows.Forms.ComboBox();
            this.comboBox1search = new System.Windows.Forms.ComboBox();
            this.comboBox1player = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1color = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox2evaluate = new System.Windows.Forms.ComboBox();
            this.comboBox2depth = new System.Windows.Forms.ComboBox();
            this.comboBox2search = new System.Windows.Forms.ComboBox();
            this.comboBox2player = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox2color = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(454, 327);
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
            this.panel1.Controls.Add(this.comboBox1evaluate);
            this.panel1.Controls.Add(this.comboBox1depth);
            this.panel1.Controls.Add(this.comboBox1search);
            this.panel1.Controls.Add(this.comboBox1player);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox1color);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelPlayer1);
            this.panel1.Location = new System.Drawing.Point(22, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 283);
            this.panel1.TabIndex = 3;
            // 
            // comboBox1evaluate
            // 
            this.comboBox1evaluate.Items.AddRange(new object[] {
            "Simple evaluate",
            "Smart evaluate"});
            this.comboBox1evaluate.Location = new System.Drawing.Point(141, 228);
            this.comboBox1evaluate.Name = "comboBox1evaluate";
            this.comboBox1evaluate.Size = new System.Drawing.Size(118, 21);
            this.comboBox1evaluate.TabIndex = 6;
            // 
            // comboBox1depth
            // 
            this.comboBox1depth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBox1depth.Location = new System.Drawing.Point(141, 181);
            this.comboBox1depth.Name = "comboBox1depth";
            this.comboBox1depth.Size = new System.Drawing.Size(118, 21);
            this.comboBox1depth.TabIndex = 6;
            // 
            // comboBox1search
            // 
            this.comboBox1search.Items.AddRange(new object[] {
            "Full search",
            "Alpha-beta search",
            "Forced search"});
            this.comboBox1search.Location = new System.Drawing.Point(141, 140);
            this.comboBox1search.Name = "comboBox1search";
            this.comboBox1search.Size = new System.Drawing.Size(118, 21);
            this.comboBox1search.TabIndex = 6;
            // 
            // comboBox1player
            // 
            this.comboBox1player.Items.AddRange(new object[] {
            "Bot",
            "Human"});
            this.comboBox1player.Location = new System.Drawing.Point(141, 94);
            this.comboBox1player.Name = "comboBox1player";
            this.comboBox1player.Size = new System.Drawing.Size(118, 21);
            this.comboBox1player.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(16, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Search function";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Evaluate function";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(14, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Recursion depth";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(16, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Player";
            // 
            // comboBox1color
            // 
            this.comboBox1color.Items.AddRange(new object[] {
            "White",
            "Black"});
            this.comboBox1color.Location = new System.Drawing.Point(141, 49);
            this.comboBox1color.Name = "comboBox1color";
            this.comboBox1color.Size = new System.Drawing.Size(118, 21);
            this.comboBox1color.TabIndex = 3;
            this.comboBox1color.SelectedIndexChanged += new System.EventHandler(this.comboBox1color_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Color";
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPlayer1.ForeColor = System.Drawing.Color.Maroon;
            this.labelPlayer1.Location = new System.Drawing.Point(71, 10);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(64, 18);
            this.labelPlayer1.TabIndex = 1;
            this.labelPlayer1.Text = "Player1";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(305, 327);
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
            this.panel2.Controls.Add(this.comboBox2evaluate);
            this.panel2.Controls.Add(this.comboBox2depth);
            this.panel2.Controls.Add(this.comboBox2search);
            this.panel2.Controls.Add(this.comboBox2player);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.comboBox2color);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(317, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(276, 283);
            this.panel2.TabIndex = 7;
            // 
            // comboBox2evaluate
            // 
            this.comboBox2evaluate.Items.AddRange(new object[] {
            "Simple evaluate",
            "Smart evaluate"});
            this.comboBox2evaluate.Location = new System.Drawing.Point(141, 228);
            this.comboBox2evaluate.Name = "comboBox2evaluate";
            this.comboBox2evaluate.Size = new System.Drawing.Size(118, 21);
            this.comboBox2evaluate.TabIndex = 6;
            // 
            // comboBox2depth
            // 
            this.comboBox2depth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBox2depth.Location = new System.Drawing.Point(141, 181);
            this.comboBox2depth.Name = "comboBox2depth";
            this.comboBox2depth.Size = new System.Drawing.Size(118, 21);
            this.comboBox2depth.TabIndex = 6;
            // 
            // comboBox2search
            // 
            this.comboBox2search.Items.AddRange(new object[] {
            "Full search",
            "Alpha-beta search",
            "Forced search"});
            this.comboBox2search.Location = new System.Drawing.Point(141, 140);
            this.comboBox2search.Name = "comboBox2search";
            this.comboBox2search.Size = new System.Drawing.Size(118, 21);
            this.comboBox2search.TabIndex = 6;
            // 
            // comboBox2player
            // 
            this.comboBox2player.Items.AddRange(new object[] {
            "Bot",
            "Human"});
            this.comboBox2player.Location = new System.Drawing.Point(141, 94);
            this.comboBox2player.Name = "comboBox2player";
            this.comboBox2player.Size = new System.Drawing.Size(118, 21);
            this.comboBox2player.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(16, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Search function";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(12, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 18);
            this.label7.TabIndex = 4;
            this.label7.Text = "Evaluate function";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(14, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 18);
            this.label8.TabIndex = 4;
            this.label8.Text = "Recursion depth";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(16, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 18);
            this.label9.TabIndex = 4;
            this.label9.Text = "Player";
            // 
            // comboBox2color
            // 
            this.comboBox2color.Items.AddRange(new object[] {
            "White",
            "Black"});
            this.comboBox2color.Location = new System.Drawing.Point(141, 49);
            this.comboBox2color.Name = "comboBox2color";
            this.comboBox2color.Size = new System.Drawing.Size(118, 21);
            this.comboBox2color.TabIndex = 3;
            this.comboBox2color.SelectedIndexChanged += new System.EventHandler(this.comboBox2color_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(16, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 18);
            this.label10.TabIndex = 2;
            this.label10.Text = "Color";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.Color.Maroon;
            this.label11.Location = new System.Drawing.Point(71, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 18);
            this.label11.TabIndex = 1;
            this.label11.Text = "Player2";
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBox1color;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1evaluate;
        private System.Windows.Forms.ComboBox comboBox1depth;
        private System.Windows.Forms.ComboBox comboBox1search;
        private System.Windows.Forms.ComboBox comboBox1player;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox2evaluate;
        private System.Windows.Forms.ComboBox comboBox2depth;
        private System.Windows.Forms.ComboBox comboBox2search;
        private System.Windows.Forms.ComboBox comboBox2player;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox2color;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}