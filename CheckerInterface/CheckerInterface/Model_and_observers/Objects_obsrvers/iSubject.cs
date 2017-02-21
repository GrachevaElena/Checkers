using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    public interface iSubject
    {
        void registerObserver(iObserver o);
        void removeObserver(iObserver o);

        void notifySetChecker(Checker ch);
        void notifySetWays(List<Tuple<int, int>> way);
        void notifyDeleteCheckerOrWay(int x, int y);
    }
}
