using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    public interface iObserver
    {
        void updateSetChecker(Checker ch);
        void updateDeleteChecker(int x, int y);
        void updateWay(List<Tuple<int, int>> ways);
    }

}
