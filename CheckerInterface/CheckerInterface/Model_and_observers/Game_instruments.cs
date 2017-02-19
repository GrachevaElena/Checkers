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
        public static bool isEat = false;
        public bool processingEat = false;

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
        private void MoveChecker(Checker checker, int x, int y)//перемещение шашки и контроль за становлением дамки
        {
            board[checker.x, checker.y] = new LogicCell();
            notifyDeleteCheckerOrWay(checker.x, checker.y);
            board[x, y] = checker;
            checker.x = x;
            checker.y = y;
            checker.SetLight(false);
            if (y == ((int)checker.GetColor()) * 7) //контроль за становлением дамки
                checker.SetDamka();
            notifySetChecker(checker);
        }
        private void DeleteChecker(Checker checker)
        {
            checkers[(int)checker.GetOtherColor()].Remove(checker);
            board[checker.x, checker.y] = new LogicCell();
            notifyDeleteCheckerOrWay(checker.x, checker.y);
        }
        public void PreDeleteChecker(Checker checker)
        {
            moves.preDeleteChecker.Add(checker);
            checker.ChangeColor();
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
        public void SearchBeatingAndWriteToMove()//ищет есть ли взятия
        {
            foreach (Checker checker in checkers[(int)color])
            {
                if (checker.CanEat())
                {
                    isEat = true;
                    checker.SetLight(true);
                    moves.AddCanEat(checker);
                    notifySetChecker(checker);
                }
            }
        }
        private void SelectCheckerAndSearchWay(int x, int y)
        {
            Checker ch = board[x, y].GetChecker();
            if (moves.selectedChecker != null && moves.selectedChecker != ch)
                Miss();

            if (!isEat || isEat && ch.GetIsLight()) //(если нет взятий) или (есть взятия и шашка может есть)
            {
                moves.selectedChecker = ch;
                ch.SetLight(true);
                notifySetChecker(ch);
                if (isEat && ch.GetIsLight())
                    ch.SearchEat();
                else
                    ch.SearchWay();

                for (int i = 0; i < 4; i++)
                    {
                        foreach (Tuple<int, int> cell in moves.way[i])
                            board[cell.Item1, cell.Item2].SetIsWay(true);
                        notifySetWays(moves.way[i]);
                    }

            }
        }
        private void MakeMove(Checker ch, int x, int y)
        {
            MoveChecker(ch, x, y);
            Miss();
        }
        private bool MakeEat(Checker checker, int x, int y)
        {
            processingEat = true;
            PreDeleteChecker(moves.GetEatenChecker(x, y));
            MoveChecker(checker, x, y);
            if (checker.CanEat())
            {
                SelectCheckerAndSearchWay(x, y);            
                return false;
            }
            foreach (Checker ch in moves.preDeleteChecker)
            {
                DeleteChecker(ch);
            }
            processingEat = false;
            isEat = false;
            return true;
        }
        private void Miss()//графическая и логическая обработка, когда при нажатии на клетку произошел "промах" - нажатие на пустую клетку или шашку противника
        {      
            if (!processingEat)     
                for (int i = 0; i < 4; i++)
                {
                    foreach (Tuple<int, int> cell in moves.way[i])
                    {
                        board[cell.Item1, cell.Item2].SetIsWay(false);
                        if (board[cell.Item1, cell.Item2].isEmpty())
                            notifyDeleteCheckerOrWay(cell.Item1, cell.Item2);
                    }
                    moves.way[i].Clear();
                }
            if (!isEat && moves.selectedChecker != null)
            {
                moves.selectedChecker.SetLight(false);
                notifySetChecker(moves.selectedChecker);
            }
        }

    }
}
