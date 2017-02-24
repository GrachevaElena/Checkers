using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    public partial class Game : iSubject, iGame
    {
        public static LogicBoard board = new LogicBoard();
        public static Moves moves = new Moves();

        private Color color;
        private List<iObserver> observers = new List<iObserver>();
        private List<Checker> []checkers = new List<Checker>[2];
        private List<Checker> selectedCheckers = new List<Checker>();

        public Game()
        {
            checkers[0] = new List<Checker>();
            checkers[1] = new List<Checker>();
        }

        public void FillBoardAndListCheckers()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 3; y++)
                    if ((x + y) % 2 == 1)
                        CreateChecker(new Checker(Color.black, Figure.checker, x, y));
                for (int y = 5; y < 8; y++)
                    if ((x + y) % 2 == 1)
                        CreateChecker(new Checker(Color.white, Figure.checker, x, y));
            }
        }
             
        private void CreateChecker(Checker ch)
        {
            checkers[(int)(ch.GetColor())].Add(ch);
            board[ch.x, ch.y] = ch;
            notifySetChecker(ch);
        }    
        private void MoveChecker(Checker checker, int x, int y, int type=0)//перемещение шашки и контроль за становлением дамки
        {
            board[checker.x, checker.y] = new LogicCell();
            notifyDeleteCheckerOrWay(checker.x, checker.y);
            board[x, y] = checker;
            checker.x = x;
            checker.y = y;
            checker.SetLight(false);
            if (type==1) checker.SetDamka();
            else if (y == ((int)checker.GetColor()) * 7) //контроль за становлением дамки
                checker.SetDamka();
            notifySetChecker(checker);
        }
        private void DeleteChecker(Checker checker)
        {
            checkers[(int)checker.GetOtherColor()].Remove(checker);
            board[checker.x, checker.y] = new LogicCell();
            notifyDeleteCheckerOrWay(checker.x, checker.y);
        }

        public bool SearchAnyMove()
        {
            foreach (Checker checker in checkers[(int)color])
            {
                if (checker.SearchAnyMove())
                    return true;
            }
            return false;
        }
        public void SearchEatingAndWriteToMove()//ищет есть ли взятия
        {
            foreach (Checker checker in checkers[(int)color])
            {
                if (checker.CanEat())
                {
                    statusGame = StatusGame.waitEat;
                    checker.SetLight(true);
                    moves.AddCanEat(checker);
                    notifySetChecker(checker);
                }
            }
        }
        private void SelectCheckerAndSearchWay(int x, int y)
        {
            Checker ch = board[x, y].GetChecker();
            moves.selectedChecker = ch;
            ch.SetLight(true);//поставили подсветку
            notifySetChecker(ch);//обновили на форме
            ch.SearchWay();//нашли пути

            for (int i = 0; i < 4; i++)//отобразили пути
                notifySetWays(moves.way[i]);
        }
        private void SelectCheckerAndSearchEat(int x, int y)
        {
            Checker ch = board[x, y].GetChecker();
            moves.selectedChecker = ch;
            ch.SetLight(true);//поставили подсветку
            notifySetChecker(ch);//обновили на форме
            ch.SearchEat();//нашли пути

            for (int i = 0; i < 4; i++)//отобразили пути
                notifySetWays(moves.way[i]);
        }
        private bool MakeEat(Checker checker, int x, int y)
        {
            moves.AddPreDelete(x, y);
            MoveChecker(checker, x, y);        
            if (checker.CanEat())      
                return false;
            foreach (Checker ch in moves.preDeleteChecker)
                DeleteChecker(ch);
            moves.preDeleteChecker.Clear();
            return true;
        }
        public void ClearWays()
        {
            for (int i = 0; i < 4; i++)
            {
                foreach (Tuple<int, int> cell in moves.way[i])//очищаем все пути
                {
                    board[cell.Item1, cell.Item2].SetIsWay(false);
                    if (board[cell.Item1, cell.Item2].isEmpty())
                        notifyDeleteCheckerOrWay(cell.Item1, cell.Item2);
                }
                moves.way[i].Clear();
            }
        }
        public void ClearSelectedCanEat()
        {
            foreach(Checker ch in moves.canEat)
            {
                ch.SetLight(false);
                notifySetChecker(ch);
            }
            moves.canEat.Clear();
        }
        public void ClearSelected()
        {
            moves.selectedChecker.SetLight(false);
            notifySetChecker(moves.selectedChecker);
        }
    }
}
