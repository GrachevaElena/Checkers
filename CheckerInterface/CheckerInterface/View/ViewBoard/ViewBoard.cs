using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckerInterface
{
    class ViewBoard
    {
        private int sizeCell;
        private Cell [,]cell;

        public ViewBoard(iController controller, int sizeCell, Panel panel)
        {    
            Cell.SetController(controller);
            this.sizeCell = sizeCell;
            cell = new Cell[8,8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    cell[i,j] = new Cell(sizeCell, i, j, panel); 
        }
        public Cell this [int index1, int index2]
        {
            get { return cell[index1, index2]; }
            set { cell[index1, index2] = value; }
        }  //индексатор          
    }
}
