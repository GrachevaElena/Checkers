using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    public enum Light
    {
        off,
        on
    }

    public partial class Game_model : iSubject, iGame
    {
        private LogicBoard board = new LogicBoard();
        private Color color;
        private List<iObserver> observers = new List<iObserver>();
        private List<Checker> []checkers = new List<Checker>[2];
        private List<Checker> selectedCheckers = new List<Checker>();

        public Game_model()
        {
            checkers[0] = new List<Checker>();
            checkers[1] = new List<Checker>();
        }
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

        public void FillBoardAndListCheckers()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 3; y++)
                    if ((x + y) % 2 == 1)
                        CreateFigure(Color.black, Figure.checker, x, y);
                for (int y = 5; y < 8; y++)
                    if ((x + y) % 2 == 1)
                        CreateFigure(Color.white, Figure.checker, x, y);
            }
        }
             
        private void CreateFigure(Color col, Figure fig, int x, int y)
        {
            checkers[(int)(col)].Add(new Checker(col,fig, x, y));
            board[x, y] = checkers[(int)(col)].Last();
            notifySetFigure(col, fig, x, y, Light.off);
        }    
        private void SetFigure(Checker checker)
        {
            board[checker.x, checker.y] = checker;
            notifySetFigure(checker.GetColor(), checker.GetFigure(), checker.x, checker.y, Light.off);
        }
        private void SelectFigure(Checker checker)
        {
            selectedCheckers.Add(checker);
            notifySetFigure(checker.GetColor(), checker.GetFigure(), checker.x, checker.y, Light.on);
        }
        private void UnselectFigures()
        {
            foreach (Checker checker in selectedCheckers)
                notifySetFigure(checker.GetColor(), checker.GetFigure(), checker.x, checker.y, Light.off);
            selectedCheckers.Clear();
        }
        private void DeleteFigure(Checker checker)
        {
            checkers[(int)checker.GetColor()].Remove(checker);
            board[checker.x, checker.y] = new LogicCell();
            notifyDeleteFigure(checker.x, checker.y);
        }
    }
}
