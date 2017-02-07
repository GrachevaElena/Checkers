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
        iController controller;
        iGame game;
        Board board;
        public Form1(Controller _contoller, Game_model_observable _game)
        {
            controller = _contoller;
            game = _game;
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(OnKeyDown);
        }
        public Form1()//для проверки, а не запорол ли запуск программы)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(OnKeyDown);
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
            board = new Board(controller, 81, panel1);
            panel1.Size = new System.Drawing.Size(8 * 81, 8 * 81);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.buttonOnePlayer();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            controller.buttonTwoPlayers();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            controller.buttonLoadGame();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            controller.buttonConstrutor();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            controller.buttonSetting();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyCode.ToString(), "Key pressed!");
            if (e.KeyCode.ToString() == "Escape")
            {            
                controller.keyEsc();
            }
        }
    }
}
