using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    public class Checker : LogicCell
    {
        public int x, y;
        private Color color;
        private Figure figure;
        private static int[] dx = { 1, -1 };
        private static int[] dy = { -1, 1 };

        public Checker() { }
        public Checker(Color col, Figure fig, int x1, int y1)
        {
            color = col;
            figure = fig;
            x = x1;
            y = y1;
        }
        public override bool isEmpty()
        {
           return false;
        }
        public override Color GetColor()
        {
            return color;
        }
        public override Figure GetFigure()
        {
           return figure;
        }
        public override Checker GetChecker()
        {
            return this;
        }

        public override void SearchWay(List<Tuple<int, int>> way, LogicBoard board)
        {
            switch (GetFigure())
            {
                case Figure.checker:
                    for (int i = 0; i < 2; i++)
                    {
                        int _x = x + dx[i];
                        int _y = y + dy[(int)color];
                        if (Inside(_x, _y) && board[_x, _y].isEmpty())
                        {
                            way.Add(new Tuple <int, int>( _x, _y));
                            board[_x, _y].SetIsWay(true);
                        }
                    }
                    break;
                case Figure.damka:

                    break;
            }
        }
        public void SerchEat(List<Checker> eat)
        {
            switch (GetFigure())
            {
                case Figure.checker:

                    break;
                case Figure.damka:

                    break;
            }
        }
        public bool IsEat()
        {
            return false;
        }            
        private bool Inside(int x, int y)
        {
            return (x < 8 && y < 8 && x >= 0 && y >= 0);
        }
    }
}
