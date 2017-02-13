using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    public class LogicCell
    {
        private bool way = false;
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
        public virtual void SearchWay(List<Tuple<int, int>> way, LogicBoard board) { }

        public void SetIsWay(bool w)
        {
            way = w;
        }
        public bool GetIsWay()
        {
            return way;
        }
    }
}
