using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    public partial class Game_model : iSubject, iGame
    {
        public void registerObserver(iObserver o)
        {
            observers.Add(o);
        }
        public void removeObserver(iObserver o)
        {
            observers.Remove(o);
        }
        public void notifySetFigure(Color color, Figure figure, int x, int y, Light l)
        {
            foreach (iObserver obs in observers)
                obs.updateSetFigure(color, figure, x, y, l);
        }
        public void notifyDeleteFigure(int x, int y)
        {
            foreach (iObserver obs in observers)
                obs.updateDeleteFigure(x, y);
        }
        public void notifySetWays(List<Tuple<int, int>> ways)
        {
            foreach (iObserver obs in observers)
                obs.updateWay(ways);
        }

    }
}
