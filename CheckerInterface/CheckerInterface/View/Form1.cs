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
        public bool ESC_on = false;

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
            //this.button3.Visible = vis;
            this.button4.Visible = vis;
            //this.button5.Visible = vis;
            this.button6.Visible = vis;
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

        private bool isCheckedButtonDelete = false;

        public bool RadiosButtonsIsChecked()
        {
            return ((WhiteRadioButton.Checked || BlackRadioButton.Checked) && (DamkaRadioButton.Checked || CheckerRadioButton.Checked));
        }
        public Color GetChosenColor()
        {
            if (WhiteRadioButton.Checked) return Color.white;
            if (BlackRadioButton.Checked) return Color.black;
            return Color.empty;
        }
        public Figure GetChosenFigure()
        {
            if (CheckerRadioButton.Checked) return Figure.checker;
            if (DamkaRadioButton.Checked) return Figure.damka;
            return Figure.empty;
        }
       /* public void SetForeColorButton(System.Drawing.Color colButtonAdd, System.Drawing.Color colButtonDelete)
        {
            buttonAdd.ForeColor = colButtonAdd;
            buttonDelete.ForeColor = colButtonDelete;
        }*/ //not used

        public void SetEmptyRadioButtons()
        {
            WhiteRadioButton.Checked = false;
            BlackRadioButton.Checked = false;
            DamkaRadioButton.Checked = false;
            CheckerRadioButton.Checked = false;
        }

        public void SelectAddChecker()
        {
            buttonAdd.FlatStyle = FlatStyle.Standard;
        }

        public void SelectDeleteChecker()
        {
            buttonAdd.FlatStyle = FlatStyle.Standard;
        }

        public void HideAddChecker()
        {
            buttonAdd.FlatStyle = FlatStyle.Popup;
        }

        public void HideDeleteChecker()
        {
            buttonAdd.FlatStyle = FlatStyle.Popup;
        }

        public void SetCheckedButDelete(bool f)
        {
            isCheckedButtonDelete = f;
        }
        public bool IsCheckedButtonDelete()
        {
            return isCheckedButtonDelete;
        }

        private void but1Play1_Click(object sender, EventArgs e)
        {
            controller.buttonOnePlayer();
        }
        private void but2Play2_Click(object sender, EventArgs e)
        {
            controller.buttonTwoPlayers();
        }
        private void but3Load_Click(object sender, EventArgs e)
        {
            controller.buttonLoadGame();
        }
        private void but4Constr_Click(object sender, EventArgs e)
        {
            controller.buttonConstrutor();
        }
        private void but5Setting_Click(object sender, EventArgs e)
        {
            controller.buttonSetting();
        }

        public void OnKeyDown(object sender, KeyEventArgs e)
        {
           // MessageBox.Show(e.KeyCode.ToString(), "Key pressed!");
            if (e.KeyCode.ToString() == "Escape")
            {            
                controller.keyEsc();
            }
        }

        void iObserver.updateEnableTimer()
        {
            timer.Enabled = true;
        }
        public void Time(object sender, EventArgs e)
        {
            controller.Time();
        }

        private void buttonAddCh_Click(object sender, EventArgs e)
        {
            controller.buttonAddChecker();
        }
        private void WhiteRadioBut_CheckedChanged(object sender, EventArgs e)
        {
            controller.buttonAddChecker();
        }
        private void BlackRadioBut_CheckedChanged(object sender, EventArgs e)
        {
            controller.buttonAddChecker();
        }
        private void ChRadioBut_CheckedChanged(object sender, EventArgs e)
        {
            controller.buttonAddChecker();
        }
        private void DamkaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            controller.buttonAddChecker();
        }
        private void buttonDeleteChecker_Click(object sender, EventArgs e)
        {
            controller.buttonDeleteChecker();
        }
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            controller.buttonPlayInConstructor();
        }
        private void but0botVSbot_Click(object sender, EventArgs e)
        {
            controller.buttonBotVSBot();
        }
    }
}
