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
        public ViewBoard board;
        public Timer timer;

        public Form1(Controller _contoller, Game _game)
        {
            timer = new Timer();
            timer.Interval = 600;
            timer.Tick += Time;

            controller = _contoller;
            game = _game;
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(OnKeyDown);
        }

        void iObserver.updateSetChecker(Checker ch)
        {
            board[ch.x, ch.y].SetChecker(ch);
        }
        void iObserver.updateDeleteChecker(int x, int y)
        {
            board[x, y].SetEmpty();
        }
        public void updateWay(List<Tuple<int, int>> ways)
        {
            foreach (Tuple<int, int> cell in ways)
                board[cell.Item1, cell.Item2].SetWay();
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
            panel1.Size = new System.Drawing.Size(8 * 81, 8 * 81);
            if (board == null)
            {
                board = new ViewBoard(controller, 81, panel1);
                Cell.SetImages();
            }
            else
                board.ClearCell();
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

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyCode.ToString(), "Key pressed!");
            if (e.KeyCode.ToString() == "Escape")
            {            
                controller.keyEsc();
            }
        }

        public void Time(object sender, EventArgs e)
        {
            controller.Time();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            controller.buttonAddChecker();
        }


        private void WhiteRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            controller.buttonAddChecker();
        }

        private void BlackRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            controller.buttonAddChecker();
        }

        private void CheckerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            controller.buttonAddChecker();
        }

        private void DamkaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            controller.buttonAddChecker();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            controller.buttonDeleteChecker();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            controller.buttonPlayInConstructor();
        }
    }
}
