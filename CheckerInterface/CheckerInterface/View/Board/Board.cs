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
        protected iController controller;
        private int sizeCell;
        private Cell [,]cells;
        private System.Drawing.Bitmap[,,] imgFigure = new System.Drawing.Bitmap[2, 2, 2];

        public Board(iController controller, int sizeCell, Panel panel)
        {
            imgFigure[(int)Color.white-1, (int)Figure.checker - 1, 0] = Properties.Resources.WhiteChecker;
            imgFigure[(int)Color.white - 1, (int)Figure.checker - 1, 1] = Properties.Resources.LightWhiteChecker;
            imgFigure[(int)Color.white - 1, (int)Figure.damka - 1, 0] = Properties.Resources.WhiteQueen;
            imgFigure[(int)Color.white - 1, (int)Figure.damka - 1, 1] = Properties.Resources.LightWhiteQueen;

            imgFigure[(int)Color.black - 1, (int)Figure.checker - 1, 0] = Properties.Resources.BlackChecker;
            imgFigure[(int)Color.black - 1, (int)Figure.checker - 1, 1] = Properties.Resources.LightBlackChecker;
            imgFigure[(int)Color.black - 1, (int)Figure.damka - 1, 0] = Properties.Resources.BlackQueen;
            imgFigure[(int)Color.black - 1, (int)Figure.damka - 1, 1] = Properties.Resources.LightBlackQueen;

            Cell.SetController(controller);
            this.controller = controller;
            this.sizeCell = sizeCell;
            cells = new Cell[8,8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    cells[i,j] = new Cell(sizeCell, i, j, panel); 

        }
        public void Fill()
        {
            
        }
    }
}
