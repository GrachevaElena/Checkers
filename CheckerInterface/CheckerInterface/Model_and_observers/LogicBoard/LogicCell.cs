using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    public class LogicCell
    {
        public virtual Color GetColor()
        {
            return Color.empty;
        }

        public virtual Figure GetFigure()
        {
            return Figure.empty;
        }

        public virtual bool isEmpty()
        {
            return true;
        }
        public virtual Checker GetChecker()
        {
            return new Checker();
        }

    }
}
