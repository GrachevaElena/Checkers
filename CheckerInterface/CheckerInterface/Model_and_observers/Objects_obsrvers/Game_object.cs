using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    public partial class Game : iSubject, iGame
    {
        public void registerObserver(iObserver o)
        {
            observers.Add(o);
        }
        public void removeObserver(iObserver o)
        {
            observers.Remove(o);
        }
        public void notifySetChecker(Checker ch)
        {
            foreach (iObserver obs in observers)
                obs.updateSetChecker(ch);
        }
        public void notifyDeleteCheckerOrWay(int x, int y)
        {
            foreach (iObserver obs in observers)
                obs.updateDeleteChecker(x, y);
        }
        public void notifySetWays(List<Tuple<int, int>> ways)
        {
            foreach (iObserver obs in observers)
                obs.updateWay(ways);
        }
        public void notifyEnableTimer()
        {
            foreach (iObserver obs in observers)
                obs.updateEnableTimer();
        }  
    }
}
