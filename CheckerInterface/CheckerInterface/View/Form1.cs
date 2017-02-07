using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckerInterface
{
    public partial class Form1 : Form, iObserver 
    {
        iController contoller;
        iGame game;
        public Form1(Controller _contoller, Game_model_observable _game)
        {
            contoller = _contoller;
            game = _game;
            InitializeComponent();
        }

        void iObserver.upDate()
        {

        }
        public void VisibleButtons(bool vis)
        {
            this.button1.Visible = vis;
            this.button2.Visible = vis;
            this.button3.Visible = vis;
            this.button4.Visible = vis;
            this.button5.Visible = vis;
        }
        public void CreateBoard()
        {
            //Board board = new Board()
        }

        private void button1_Click(object sender, EventArgs e)
        {
            contoller.onePlayer();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            contoller.twoPlayers();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            contoller.loadGame();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            contoller.construtor();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            contoller.setting();
        }
    }
}
