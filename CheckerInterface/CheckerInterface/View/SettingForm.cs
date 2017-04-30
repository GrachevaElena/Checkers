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
        public SettingForm(iController contr)
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
        }
        public bool CanStartGame()
        {
            return true;
        }
        public Color GetColorPlayer1()
        {
            return (Color)comboBox1color.SelectedIndex;
        }
        public StatusPlayer GetStatusPl1()
        {
            return (StatusPlayer)comboBox1player.SelectedIndex;
        }
        public StatusPlayer GetStatusPl2()
        {
            return (StatusPlayer)comboBox2player.SelectedIndex;
        }
        public Evaluate GetEvaluatePl1()
        {
            return (Evaluate)comboBox1evaluate.SelectedIndex;
        }
        public Evaluate GetEvaluatePl2()
        {
            return (Evaluate)comboBox2evaluate.SelectedIndex;
        }
        public Search GetSearchPl1()
        {
            return (Search)comboBox1search.SelectedIndex;
        }
        public Search GetSearchPl2()
        {
            return (Search)comboBox2search.SelectedIndex;
        }
        public int GetDepthPl1()
        {
            return comboBox1depth.SelectedIndex + 1;
        }
        public int GetDepthPl2()
        {
            return comboBox2depth.SelectedIndex + 1;
        }
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            controller.buttonPlaySetting();
        }

        private void RadButtonHumanOrBotBlack_Click(object sender, EventArgs e)
        {

        }

        private void RadButtonHumanOrBotWhite_Click(object sender, EventArgs e)
        {

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
    }
}
