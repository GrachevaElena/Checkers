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
        }
        public bool CanStartGame()
        {
            return true;
        }
        /*public Color GetColorPlayer1()
        {
            if (radioWhitePlayer1.Checked) return Color.white;
            if (radioBlackPlayer1.Checked) return Color.black;
            return Color.empty;
        }*/
        public StatusPlayer GetStatusPl1()
        {
            if (radioButtonWhiteBot.Checked) return StatusPlayer.bot;
            return StatusPlayer.human;
        }
        public StatusPlayer GetStatusPl2()
        {
            if (radioButtonBlackBot.Checked) return StatusPlayer.bot;
            return StatusPlayer.human;
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
    }
}
