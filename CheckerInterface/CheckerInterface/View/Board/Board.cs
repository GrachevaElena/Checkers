using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckerInterface
{
    class Board
    {
       // protected iController controller;
        private int sizeCell;
        private Cell [,]cell;

        public Board(iController controller, int sizeCell, Panel panel)
        {
           /* imgFigure[(int)Color.white, (int)Figure.checker, 0] = Properties.Resources.WhiteChecker;
            imgFigure[(int)Color.white, (int)Figure.checker, 1] = Properties.Resources.LightWhiteChecker;
            imgFigure[(int)Color.white, (int)Figure.damka, 0] = Properties.Resources.WhiteQueen;
            imgFigure[(int)Color.white, (int)Figure.damka, 1] = Properties.Resources.LightWhiteQueen;

            imgFigure[(int)Color.black, (int)Figure.checker, 0] = Properties.Resources.BlackChecker;
            imgFigure[(int)Color.black, (int)Figure.checker, 1] = Properties.Resources.LightBlackChecker;
            imgFigure[(int)Color.black, (int)Figure.damka, 0] = Properties.Resources.BlackQueen;
            imgFigure[(int)Color.black, (int)Figure.damka, 1] = Properties.Resources.LightBlackQueen;*/

            Cell.SetController(controller);
            //this.controller = controller;
            this.sizeCell = sizeCell;
            cell = new Cell[8,8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    cell[i,j] = new Cell(sizeCell, i, j, panel); 

        }
        public Cell this [int index1, int index2]
        {
            get
            {
                return cell[index1, index2];
            }
            set
            {
                cell[index1, index2] = value;
            }
        }  //индексатор
        public void Fill()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 3; j++)
                    if ((i + j) % 2 == 1)
                        cell[i, j].SetFigure(Color.black, Figure.checker);
            for (int i = 0; i < 8; i++)
                for (int j = 5; j < 8; j++)
                    if ((i + j) % 2 == 1)
                        cell[i, j].SetFigure(Color.white, Figure.checker);
        }
        public void Clear()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (!cell[i, j].isEmpty())
                        cell[i, j].SetEmpty();
        }
    }
}
