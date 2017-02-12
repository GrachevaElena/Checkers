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

        void notifySetFigure(Color color, Figure figure, int x, int y, Light l);
        void notifyDeleteFigure(int x, int y);
    }
}
