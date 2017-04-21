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
        public int count = 0;

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

        /*public void ChangeLocationOfBoard(int x, int y)
        {
            panel1.Location = new Point(x,y);
        }*/
        public void CreateBoard(StatusApplication appl)
        {
            int sizeCell = 0;
            if (appl == StatusApplication.game)
            {
                sizeCell = 81;
                panel1.Location = new Point((919 - sizeCell * 8) / 2, 12);
                panel1.Size = new System.Drawing.Size(8 * sizeCell, 8 * sizeCell);
            }
            else
            {
                sizeCell = 70;
                panel1.Location = new Point(90, 62);
                panel1.Size = new System.Drawing.Size(8 * sizeCell, 8 * sizeCell);
            }
            if (board == null)
            {
                Cell.SetImages();
            }
            else
            {
                board.Delete(panel1);
            }
            board = new ViewBoard(controller, sizeCell, panel1);
        }



        private bool isCheckedButtonDelete = false;
        private bool isCheckedButtonAdd = false;

        /*public bool RadiosButtonsIsChecked()
        {
            return ((WhiteRadioButton.Checked || BlackRadioButton.Checked) && (DamkaRadioButton.Checked || CheckerRadioButton.Checked));
        }*/ //not used
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

        /*public void SetEmptyRadioButtons()
        {
            WhiteRadioButton.Checked = false;
            BlackRadioButton.Checked = false;
            DamkaRadioButton.Checked = false;
            CheckerRadioButton.Checked = false;
        }*/ //not used

        private void ChangePanels()
        {
            panel1.Enabled = true;
            panel1.Visible = true;
            panelBackground.BackColor = System.Drawing.Color.Transparent;
            //panelBackground.BackgroundImageLayout=
        }
        public void SelectAddChecker()
        {
            isCheckedButtonAdd = true;
            buttonAdd.BackColor = System.Drawing.Color.Snow;
        }

        public void SelectDeleteChecker()
        {
            isCheckedButtonDelete = true;
            buttonDelete.BackColor = System.Drawing.Color.Snow;
        }

        public void HideAddChecker()
        {
            isCheckedButtonAdd = false;
            buttonAdd.BackColor = System.Drawing.Color.White;
        }

        public void HideDeleteChecker()
        {
            isCheckedButtonDelete = false;
            buttonDelete.BackColor = System.Drawing.Color.White;
        }

        public bool IsCheckedButtonDelete()
        {
            return isCheckedButtonDelete;
        }

        public bool IsCheckedButtonAdd()
        {
            return isCheckedButtonAdd;
        }

        private void but1Play1_Click(object sender, EventArgs e)
        {
            ChangePanels();
            controller.buttonOnePlayer();
        }
        private void but2Play2_Click(object sender, EventArgs e)
        {
            ChangePanels();
            controller.buttonTwoPlayers();
        }
        private void but4Constr_Click(object sender, EventArgs e)
        {
            ChangePanels();
            controller.buttonConstrutor();
        }
        private void but0botVSbot_Click(object sender, EventArgs e)
        {
            ChangePanels();
            controller.buttonBotVSBot();
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
            //controller.buttonAddChecker();
        }
        private void BlackRadioBut_CheckedChanged(object sender, EventArgs e)
        {
            //controer.buttonAddChecker();
        }
        private void ChRadioBut_CheckedChanged(object sender, EventArgs e)
        {
           // controller.buttonAddChecker();
        }
        private void DamkaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //controer.buttonAddChecker();
        }
        
        private void buttonDeleteChecker_Click(object sender, EventArgs e)
        {
            controller.buttonDeleteChecker();
        }
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            controller.buttonPlayInConstructor();
        }
    }
}
