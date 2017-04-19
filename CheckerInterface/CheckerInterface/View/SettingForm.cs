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
            return (radioWhitePlayer1.Checked || radioBlackPlayer1.Checked);
        }
        public Color GetColorPlayer1()
        {
            if (radioWhitePlayer1.Checked) return Color.white;
            if (radioBlackPlayer1.Checked) return Color.black;
            return Color.empty;
        }
        public StatusPlayer GetStatusPl1()
        {
            if (checkBoxBot1.Checked) return StatusPlayer.bot;
            return StatusPlayer.human;
        }
        public StatusPlayer GetStatusPl2()
        {
            if (checkBoxBot2.Checked) return StatusPlayer.bot;
            return StatusPlayer.human;
        }
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            controller.buttonPlaySetting();
        }
    }
}
