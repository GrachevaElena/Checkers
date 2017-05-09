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
        void iObserver.updateWay(List<Tuple<int, int>> ways)
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
        Label[,] forBorder;
        public void CreateBoard(StatusApplication appl)
        {
            panelborder.Controls.Clear();
            panelborder.Controls.Add(panel1);
            panelborder.Enabled = true;
            panelborder.Visible = true;
            panel1.Enabled = true;
            panel1.Visible = true;
            //panelBackground.BackColor = System.Drawing.Color.Transparent;
            int sizeCell = 0;
            int sizeBorderDivCell = 0;
            if (appl == StatusApplication.game)
            {
                sizeCell = 73;
                sizeBorderDivCell = 8;
                panelborder.Location= new Point((919 - (sizeCell+sizeBorderDivCell) * 8) / 2 , 12);
                panelborder.Size= new System.Drawing.Size(8 * (sizeCell+sizeBorderDivCell), 8 * (sizeCell + sizeBorderDivCell));
                SetInBorder(sizeCell, sizeBorderDivCell * 4, panelborder);
                panel1.Location = new Point(sizeBorderDivCell*4,sizeBorderDivCell*4);
                panel1.Size = new System.Drawing.Size(8 * sizeCell, 8 * sizeCell);
            }
            else
            {
                sizeCell = 63;
                sizeBorderDivCell = 7;
                panelborder.Location = new Point(90, 62);
                panelborder.Size = new System.Drawing.Size(8 * (sizeCell + sizeBorderDivCell), 8 * (sizeCell + sizeBorderDivCell));
                SetInBorder(sizeCell,sizeBorderDivCell*4, panelborder);
                panel1.Location = new Point(sizeBorderDivCell * 4, sizeBorderDivCell * 4);
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

        public void SetInBorder(int sizeCell, int sizeBorder, Panel panel)
        {
            forBorder = new Label[4, 8];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 8; j++)
                {
                    forBorder[i, j] = new Label();
                    panel.Controls.Add(forBorder[i, j]);
                    //forBorder[i, j].BorderStyle = BorderStyle.FixedSingle;
                    forBorder[i, j].BackColor = panel.BackColor;
                    forBorder[i, j].ForeColor = System.Drawing.Color.White;
                    forBorder[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    forBorder[i, j].Font = new Font("Arial", 12, FontStyle.Bold);
                }
            for (int j = 0; j < 8; j++)
            {
                forBorder[0, j].Size = forBorder[1, j].Size = new System.Drawing.Size(sizeCell, sizeBorder);
                forBorder[0, j].Location = new Point(sizeBorder + j * sizeCell, 0);
                forBorder[1, j].Location = new Point(sizeBorder + j * sizeCell, sizeCell * 8 + sizeBorder);
                forBorder[2, j].Size = forBorder[3, j].Size = new System.Drawing.Size(sizeBorder, sizeCell);
                forBorder[2, j].Location = new Point(0, sizeBorder + j * sizeCell);
                forBorder[3, j].Location = new Point(sizeCell * 8 + sizeBorder, sizeBorder + j * sizeCell);
            }
            for (int j = 7; j >= 0; j--)
            {
                forBorder[0, j].Text = forBorder[1, j].Text = ((Char)('A' + j)).ToString();
                forBorder[2, j].Text = forBorder[3, j].Text = (8 -  j).ToString();
            }
        }
        private bool isCheckedButtonDelete = false;
        private bool isCheckedButtonAdd = false;

        public int[] count = {0, 0, 0};
        
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
        public void SetButtonPlayEnabled(bool f)
        {
            buttonPlay.Enabled = f;
            if (f)
            {
                buttonPlay.FlatStyle = FlatStyle.Flat;
                buttonPlay.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
                buttonPlay.BackColor = System.Drawing.Color.NavajoWhite;
            }
            else
            {
                buttonPlay.FlatStyle = FlatStyle.Standard;
                buttonPlay.BackColor = System.Drawing.Color.WhiteSmoke;
            }
        }
        public void SelectAddChecker()
        {
            isCheckedButtonAdd = true;
            buttonAdd.BackColor = System.Drawing.Color.WhiteSmoke;
            buttonAdd.FlatAppearance.BorderSize = 1;

            groupBox1.Enabled = groupBox2.Enabled = true;
        }

        public void SelectDeleteChecker()
        {
            isCheckedButtonDelete = true;
            buttonDelete.BackColor = System.Drawing.Color.WhiteSmoke;
        }

        public void HideAddChecker()
        {
            isCheckedButtonAdd = false;
            buttonAdd.BackColor = System.Drawing.Color.White;
            buttonAdd.FlatAppearance.BorderSize = 1;

            groupBox1.Enabled = groupBox2.Enabled = false;
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
            controller.buttonOnePlayer();
        }
        private void but2Play2_Click(object sender, EventArgs e)
        {
            controller.buttonTwoPlayers();
        }
        private void but4Constr_Click(object sender, EventArgs e)
        {
            controller.buttonConstrutor();
        }
        private void but0botVSbot_Click(object sender, EventArgs e)
        {
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
            buttonAdd.FlatAppearance.BorderSize = 2;
        }
        private void BlackRadioBut_CheckedChanged(object sender, EventArgs e)
        {
            //controer.buttonAddChecker();
        }
        private void ChRadioBut_CheckedChanged(object sender, EventArgs e)
        {
            buttonAdd.FlatAppearance.BorderSize = 2;
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
