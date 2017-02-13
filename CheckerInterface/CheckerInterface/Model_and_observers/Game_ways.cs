using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    public partial class Game_model : iSubject, iGame
    {
        private List<Tuple<int, int>> way = new List<Tuple<int, int>>();

        void ClearWays()
        {
            foreach (Tuple<int, int> cell in way)
            {
               board[cell.Item1, cell.Item2].isEmpty();
               notifyDeleteFigure(cell.Item1, cell.Item2);
            }
            way.Clear();
        }
    }
}
