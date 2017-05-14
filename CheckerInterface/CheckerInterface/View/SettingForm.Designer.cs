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
            this.panelcolor = new System.Windows.Forms.Panel();
            this.comboBox1color = new System.Windows.Forms.ComboBox();
            this.label1color = new System.Windows.Forms.Label();
            this.panel1botSettings = new System.Windows.Forms.Panel();
            this.comboBox1evaluate = new System.Windows.Forms.ComboBox();
            this.comboBox1depth = new System.Windows.Forms.ComboBox();
            this.comboBox1search = new System.Windows.Forms.ComboBox();
            this.label1serch = new System.Windows.Forms.Label();
            this.label1evaluate = new System.Windows.Forms.Label();
            this.label1depth = new System.Windows.Forms.Label();
            this.comboBox1player = new System.Windows.Forms.ComboBox();
            this.label1player = new System.Windows.Forms.Label();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2botSettings = new System.Windows.Forms.Panel();
            this.comboBox2evaluate = new System.Windows.Forms.ComboBox();
            this.comboBox2depth = new System.Windows.Forms.ComboBox();
            this.comboBox2search = new System.Windows.Forms.ComboBox();
            this.label2search = new System.Windows.Forms.Label();
            this.label2evaluate = new System.Windows.Forms.Label();
            this.label2depth = new System.Windows.Forms.Label();
            this.comboBox2player = new System.Windows.Forms.ComboBox();
            this.label2player = new System.Windows.Forms.Label();
            this.comboBox2color = new System.Windows.Forms.ComboBox();
            this.label2color = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelcolor.SuspendLayout();
            this.panel1botSettings.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel2botSettings.SuspendLayout();
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
            this.panel1.Controls.Add(this.panelcolor);
            this.panel1.Controls.Add(this.panel1botSettings);
            this.panel1.Controls.Add(this.comboBox1player);
            this.panel1.Controls.Add(this.label1player);
            this.panel1.Controls.Add(this.labelPlayer1);
            this.panel1.Location = new System.Drawing.Point(22, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 283);
            this.panel1.TabIndex = 3;
            this.panel1.Visible = false;
            // 
            // panelcolor
            // 
            this.panelcolor.Controls.Add(this.comboBox1color);
            this.panelcolor.Controls.Add(this.label1color);
            this.panelcolor.Location = new System.Drawing.Point(12, 44);
            this.panelcolor.Name = "panelcolor";
            this.panelcolor.Size = new System.Drawing.Size(262, 36);
            this.panelcolor.TabIndex = 8;
            // 
            // comboBox1color
            // 
            this.comboBox1color.Items.AddRange(new object[] {
            "White",
            "Black"});
            this.comboBox1color.Location = new System.Drawing.Point(129, 5);
            this.comboBox1color.Name = "comboBox1color";
            this.comboBox1color.Size = new System.Drawing.Size(118, 21);
            this.comboBox1color.TabIndex = 3;
            this.comboBox1color.SelectedIndexChanged += new System.EventHandler(this.comboBox1color_SelectedIndexChanged);
            // 
            // label1color
            // 
            this.label1color.AutoSize = true;
            this.label1color.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1color.Location = new System.Drawing.Point(4, 5);
            this.label1color.Name = "label1color";
            this.label1color.Size = new System.Drawing.Size(42, 18);
            this.label1color.TabIndex = 2;
            this.label1color.Text = "Color";
            // 
            // panel1botSettings
            // 
            this.panel1botSettings.Controls.Add(this.comboBox1evaluate);
            this.panel1botSettings.Controls.Add(this.comboBox1depth);
            this.panel1botSettings.Controls.Add(this.comboBox1search);
            this.panel1botSettings.Controls.Add(this.label1serch);
            this.panel1botSettings.Controls.Add(this.label1evaluate);
            this.panel1botSettings.Controls.Add(this.label1depth);
            this.panel1botSettings.Location = new System.Drawing.Point(5, 94);
            this.panel1botSettings.Name = "panel1botSettings";
            this.panel1botSettings.Size = new System.Drawing.Size(270, 136);
            this.panel1botSettings.TabIndex = 7;
            // 
            // comboBox1evaluate
            // 
            this.comboBox1evaluate.Items.AddRange(new object[] {
            "Simple evaluate",
            "Smart evaluate"});
            this.comboBox1evaluate.Location = new System.Drawing.Point(136, 92);
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
            "12",
            "13",
            "14"});
            this.comboBox1depth.Location = new System.Drawing.Point(136, 50);
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
            this.comboBox1search.Location = new System.Drawing.Point(136, 8);
            this.comboBox1search.Name = "comboBox1search";
            this.comboBox1search.Size = new System.Drawing.Size(118, 21);
            this.comboBox1search.TabIndex = 6;
            // 
            // label1serch
            // 
            this.label1serch.AutoSize = true;
            this.label1serch.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1serch.Location = new System.Drawing.Point(11, 8);
            this.label1serch.Name = "label1serch";
            this.label1serch.Size = new System.Drawing.Size(110, 18);
            this.label1serch.TabIndex = 4;
            this.label1serch.Text = "Search function";
            // 
            // label1evaluate
            // 
            this.label1evaluate.AutoSize = true;
            this.label1evaluate.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1evaluate.Location = new System.Drawing.Point(11, 92);
            this.label1evaluate.Name = "label1evaluate";
            this.label1evaluate.Size = new System.Drawing.Size(123, 18);
            this.label1evaluate.TabIndex = 4;
            this.label1evaluate.Text = "Evaluate function";
            // 
            // label1depth
            // 
            this.label1depth.AutoSize = true;
            this.label1depth.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1depth.Location = new System.Drawing.Point(11, 49);
            this.label1depth.Name = "label1depth";
            this.label1depth.Size = new System.Drawing.Size(112, 18);
            this.label1depth.TabIndex = 4;
            this.label1depth.Text = "Recursion depth";
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
            this.comboBox1player.SelectedIndexChanged += new System.EventHandler(this.comboBox1player_SelectedIndexChanged);
            // 
            // label1player
            // 
            this.label1player.AutoSize = true;
            this.label1player.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1player.Location = new System.Drawing.Point(16, 91);
            this.label1player.Name = "label1player";
            this.label1player.Size = new System.Drawing.Size(50, 18);
            this.label1player.TabIndex = 4;
            this.label1player.Text = "Player";
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
            this.panel2.Controls.Add(this.panel2botSettings);
            this.panel2.Controls.Add(this.comboBox2player);
            this.panel2.Controls.Add(this.label2player);
            this.panel2.Controls.Add(this.comboBox2color);
            this.panel2.Controls.Add(this.label2color);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(317, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(276, 283);
            this.panel2.TabIndex = 7;
            this.panel2.Visible = false;
            // 
            // panel2botSettings
            // 
            this.panel2botSettings.Controls.Add(this.comboBox2evaluate);
            this.panel2botSettings.Controls.Add(this.comboBox2depth);
            this.panel2botSettings.Controls.Add(this.comboBox2search);
            this.panel2botSettings.Controls.Add(this.label2search);
            this.panel2botSettings.Controls.Add(this.label2evaluate);
            this.panel2botSettings.Controls.Add(this.label2depth);
            this.panel2botSettings.Location = new System.Drawing.Point(5, 125);
            this.panel2botSettings.Name = "panel2botSettings";
            this.panel2botSettings.Size = new System.Drawing.Size(270, 136);
            this.panel2botSettings.TabIndex = 7;
            // 
            // comboBox2evaluate
            // 
            this.comboBox2evaluate.Items.AddRange(new object[] {
            "Simple evaluate",
            "Smart evaluate"});
            this.comboBox2evaluate.Location = new System.Drawing.Point(136, 92);
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
            "12",
            "13",
            "14"});
            this.comboBox2depth.Location = new System.Drawing.Point(136, 50);
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
            this.comboBox2search.Location = new System.Drawing.Point(136, 8);
            this.comboBox2search.Name = "comboBox2search";
            this.comboBox2search.Size = new System.Drawing.Size(118, 21);
            this.comboBox2search.TabIndex = 6;
            // 
            // label2search
            // 
            this.label2search.AutoSize = true;
            this.label2search.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2search.Location = new System.Drawing.Point(11, 8);
            this.label2search.Name = "label2search";
            this.label2search.Size = new System.Drawing.Size(110, 18);
            this.label2search.TabIndex = 4;
            this.label2search.Text = "Search function";
            // 
            // label2evaluate
            // 
            this.label2evaluate.AutoSize = true;
            this.label2evaluate.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2evaluate.Location = new System.Drawing.Point(11, 92);
            this.label2evaluate.Name = "label2evaluate";
            this.label2evaluate.Size = new System.Drawing.Size(123, 18);
            this.label2evaluate.TabIndex = 4;
            this.label2evaluate.Text = "Evaluate function";
            // 
            // label2depth
            // 
            this.label2depth.AutoSize = true;
            this.label2depth.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2depth.Location = new System.Drawing.Point(11, 49);
            this.label2depth.Name = "label2depth";
            this.label2depth.Size = new System.Drawing.Size(112, 18);
            this.label2depth.TabIndex = 4;
            this.label2depth.Text = "Recursion depth";
            // 
            // comboBox2player
            // 
            this.comboBox2player.Items.AddRange(new object[] {
            "Bot",
            "Human"});
            this.comboBox2player.Location = new System.Drawing.Point(141, 91);
            this.comboBox2player.Name = "comboBox2player";
            this.comboBox2player.Size = new System.Drawing.Size(118, 21);
            this.comboBox2player.TabIndex = 5;
            this.comboBox2player.SelectedIndexChanged += new System.EventHandler(this.comboBox2player_SelectedIndexChanged);
            // 
            // label2player
            // 
            this.label2player.AutoSize = true;
            this.label2player.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2player.Location = new System.Drawing.Point(16, 91);
            this.label2player.Name = "label2player";
            this.label2player.Size = new System.Drawing.Size(50, 18);
            this.label2player.TabIndex = 4;
            this.label2player.Text = "Player";
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
            // label2color
            // 
            this.label2color.AutoSize = true;
            this.label2color.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2color.Location = new System.Drawing.Point(16, 49);
            this.label2color.Name = "label2color";
            this.label2color.Size = new System.Drawing.Size(42, 18);
            this.label2color.TabIndex = 2;
            this.label2color.Text = "Color";
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
            this.panelcolor.ResumeLayout(false);
            this.panelcolor.PerformLayout();
            this.panel1botSettings.ResumeLayout(false);
            this.panel1botSettings.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel2botSettings.ResumeLayout(false);
            this.panel2botSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBox1color;
        private System.Windows.Forms.Label label1color;
        private System.Windows.Forms.ComboBox comboBox1evaluate;
        private System.Windows.Forms.ComboBox comboBox1depth;
        private System.Windows.Forms.ComboBox comboBox1search;
        private System.Windows.Forms.ComboBox comboBox1player;
        private System.Windows.Forms.Label label1serch;
        private System.Windows.Forms.Label label1evaluate;
        private System.Windows.Forms.Label label1depth;
        private System.Windows.Forms.Label label1player;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox2evaluate;
        private System.Windows.Forms.ComboBox comboBox2depth;
        private System.Windows.Forms.ComboBox comboBox2search;
        private System.Windows.Forms.ComboBox comboBox2player;
        private System.Windows.Forms.Label label2search;
        private System.Windows.Forms.Label label2evaluate;
        private System.Windows.Forms.Label label2depth;
        private System.Windows.Forms.Label label2player;
        private System.Windows.Forms.ComboBox comboBox2color;
        private System.Windows.Forms.Label label2color;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1botSettings;
        private System.Windows.Forms.Panel panel2botSettings;
        private System.Windows.Forms.Panel panelcolor;
    }
}