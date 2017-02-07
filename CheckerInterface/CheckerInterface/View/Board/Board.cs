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
        private Cell [][]cells;
        public Board(iController controller, int sizeCell, Panel panel)
        {
            Cell.SetController(controller);
            this.controller = controller;
            this.sizeCell = sizeCell;
            cells = new Cell[8][];
            for (int i = 0; i < 8; i++)
            {
                cells[i] = new Cell[8];
                for (int j = 0; j < 8; j++)
                    cells[i][j] = new Cell(sizeCell, i, j, panel); 
            }

        }
    }
}
