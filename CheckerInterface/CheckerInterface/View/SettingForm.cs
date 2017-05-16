using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckerInterface.View
{
    public partial class SettingForm : Form
    {
        iController controller;
        TypeSettingForm id;
        public SettingForm(iController contr, TypeSettingForm _id )
        {
            InitializeComponent();
            controller = contr;

            comboBox1color.SelectedIndex = 0; comboBox2color.SelectedIndex= 1;
            comboBox1depth.SelectedIndex = 5; comboBox2depth.SelectedIndex = 3;
            comboBox1search.SelectedIndex = 1; comboBox2search.SelectedIndex = 1;
            comboBox1player.SelectedIndex = 0; comboBox2player.SelectedIndex = 0;
            comboBox1evaluate.SelectedIndex = 1; comboBox2evaluate.SelectedIndex = 1;
            comboBox1color.DropDownStyle = comboBox1depth.DropDownStyle = 
                comboBox1search.DropDownStyle = comboBox1player.DropDownStyle = comboBox1evaluate.DropDownStyle =
                comboBox2color.DropDownStyle = comboBox2depth.DropDownStyle =
                comboBox2search.DropDownStyle = comboBox2player.DropDownStyle = comboBox2evaluate.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            id = _id;
            CreatePanels(id);
        }
        private void CreatePanels(TypeSettingForm id)
        {
            switch (id)
            {
                case TypeSettingForm.botVSbot:
                    panel1.Visible = true;
                    panel2.Visible = true;
                    panelcolor.Location = new Point(12, 44);
                    label1color.Visible = label2color.Visible = label1player.Visible = label2player.Visible =
                        comboBox1color.Visible = comboBox2color.Visible = comboBox1player.Visible = comboBox2player.Visible = false;
                    panel2botSettings.Location = panel1botSettings.Location = new Point(5, 76);
                    labelPlayer1.Text = "Bot1(white)";
                    label11.Text = "Bot2(black)";
                    comboBox1color.SelectedIndex = 0;
                    break;
                case TypeSettingForm.humanVSbot:
                    panel1.Visible = true;
                    panel1.Location = new Point(170, 26);
                    panel1botSettings.Location = new Point(5, 91);
                    panelcolor.Location = new Point(12, 52);
                    label1player.Visible =  comboBox1player.Visible  = false;
                    label1color.Visible = true;
                    labelPlayer1.Text = "Bot";
                    comboBox1color.SelectedIndex = 1;
                    break;
                case TypeSettingForm.constructor:
                    panel1.Visible = true;
                    panel2.Visible = true;
                    panelcolor.Location = new Point(12, 44);
                    label1color.Visible = label2color.Visible = label1player.Visible = label2player.Visible =
                        comboBox1color.Visible = comboBox2color.Visible = comboBox1player.Visible = comboBox2player.Visible = true;
                    panel2botSettings.Location = panel1botSettings.Location = new Point(5, 125);
                    labelPlayer1.Text = "Player1";
                    label11.Text = "Player2";
                    comboBox1color.SelectedIndex = 0;
                    break;
            }
        }
       /* public bool CanStartGame()
        {
            return true;
        }*/
        public Color GetColorPlayer1()
        {
            if (id == TypeSettingForm.constructor) return (Color) comboBox1color.SelectedIndex;
            return Color.white;
        }
        public StatusPlayer GetStatusPl1()
        {
            if (id == TypeSettingForm.botVSbot) return StatusPlayer.bot;
            if (id == TypeSettingForm.humanVSbot)
                if (comboBox1color.SelectedIndex == 0) return StatusPlayer.bot;
            else return StatusPlayer.human;
            return (StatusPlayer)comboBox1player.SelectedIndex;
        }
        public StatusPlayer GetStatusPl2()
        {
            if (id == TypeSettingForm.botVSbot) return StatusPlayer.bot;
            if (id == TypeSettingForm.humanVSbot)
                if (comboBox1color.SelectedIndex == 0) return StatusPlayer.human;
                else return StatusPlayer.bot;
            return (StatusPlayer)comboBox2player.SelectedIndex;
        }
        public Evaluate GetEvaluatePl1()
        {
            if (id == TypeSettingForm.humanVSbot)
            {
                if (comboBox1color.SelectedIndex == 1)
                    return Evaluate.empty;
                else return (Evaluate)comboBox1evaluate.SelectedIndex;
            }
            if (id == TypeSettingForm.constructor)
                if (comboBox1player.SelectedIndex == 1) return Evaluate.empty;
            return (Evaluate)comboBox1evaluate.SelectedIndex;
        }
        public Evaluate GetEvaluatePl2()
        {
            if (id == TypeSettingForm.humanVSbot)
            {
                if (comboBox1color.SelectedIndex == 0)
                    return Evaluate.empty;
                else return (Evaluate)comboBox1evaluate.SelectedIndex;
            }
            if (id == TypeSettingForm.constructor)
                if (comboBox2player.SelectedIndex == 1) return Evaluate.empty;
            return (Evaluate)comboBox2evaluate.SelectedIndex;
        }
        public Search GetSearchPl1()
        {
            if (id == TypeSettingForm.humanVSbot)
            {
                if (comboBox1color.SelectedIndex == 1)
                    return Search.empty;
                else return (Search)comboBox1search.SelectedIndex;
            }
            if (id == TypeSettingForm.constructor)
                if (comboBox1player.SelectedIndex == 1) return Search.empty;
            return (Search)comboBox1search.SelectedIndex;
        }
        public Search GetSearchPl2()
        {
            if (id == TypeSettingForm.humanVSbot)
            {
                if (comboBox1color.SelectedIndex == 0)
                    return Search.empty;
                else return (Search)comboBox1search.SelectedIndex;
            }
            if (id == TypeSettingForm.constructor)
                if (comboBox2player.SelectedIndex == 1) return Search.empty;
            return (Search)comboBox2search.SelectedIndex;
        }
        public int GetDepthPl1()
        {
            if (id == TypeSettingForm.humanVSbot)
            {
                if (comboBox1color.SelectedIndex == 1)
                    return 0;
                else return comboBox1depth.SelectedIndex + 1;
            }
            if (id == TypeSettingForm.humanVSbot && comboBox1color.SelectedIndex==1)
                return 0;
            return comboBox1depth.SelectedIndex + 1;
        }
        public int GetDepthPl2()
        {
            if (id == TypeSettingForm.humanVSbot) {
                if (comboBox1color.SelectedIndex == 0)
                    return 0;
                else return comboBox1depth.SelectedIndex + 1;
            }
            if (id == TypeSettingForm.constructor)
                if (comboBox2player.SelectedIndex == 1) return 0;
            return comboBox2depth.SelectedIndex + 1;
        }
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            controller.buttonPlaySetting();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            controller.CloseSettings();
        }

        private void comboBox1color_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2color.SelectedIndex == 0 && comboBox1color.SelectedIndex == 0) comboBox2color.SelectedIndex = 1;
            else if (comboBox2color.SelectedIndex == 1 && comboBox1color.SelectedIndex == 1) comboBox2color.SelectedIndex = 0;
        }

        private void comboBox2color_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2color.SelectedIndex == 0 && comboBox1color.SelectedIndex == 0) comboBox1color.SelectedIndex = 1;
            else if (comboBox2color.SelectedIndex == 1 && comboBox1color.SelectedIndex == 1) comboBox1color.SelectedIndex = 0;
        }

        private void comboBox1player_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1player.SelectedIndex == 1) panel1botSettings.Enabled = false;
            else panel1botSettings.Enabled = true;
        }

        private void comboBox2player_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2player.SelectedIndex == 1) panel2botSettings.Enabled = false;
            else panel2botSettings.Enabled = true;
        }

    }
}
