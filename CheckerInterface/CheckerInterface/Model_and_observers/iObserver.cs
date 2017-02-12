using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    public interface iObserver
    {
        void updateSetFigure(Color color, Figure figure, int x, int y, Light l);
        void updateDeleteFigure(int x, int y);
    }

}
