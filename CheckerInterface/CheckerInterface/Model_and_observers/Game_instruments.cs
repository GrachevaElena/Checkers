﻿using System;
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
        private List<Checker>[] checkers = new List<Checker>[2];
        private List<Checker> selectedCheckers = new List<Checker>();

        public static BotMove botMove = new BotMove();

        public Game()
        {
            checkers[0] = new List<Checker>();
            checkers[1] = new List<Checker>();
        }

        public void FillBoardOnForm()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (board[i, j].GetChecker() != null)
                        notifySetChecker(board[i, j].GetChecker());
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

        public int CreateChecker(Checker ch)
        {
            checkers[(int)(ch.GetColor())].Add(ch);
            board[ch.x, ch.y] = ch;
            notifySetChecker(ch);
            return 1;
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
        public int DeleteChecker(int x, int y) //удаляет только шашки, с путями не работает
        {
            if (!board[x, y].isEmpty() && board[x, y].GetChecker() != null) //если клетка не пустая и на ней есть шашка
            {
                Checker checker = board[x, y].GetChecker();
                checkers[(int)checker.GetColor()].Remove(checker);
                board[checker.x, checker.y] = new LogicCell();
                notifyDeleteCheckerOrWay(checker.x, checker.y);
                return -1;
            }
            return 0;
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
        public bool SearchEatingAndWriteToMove()//ищет есть ли взятия
        {
            bool f = false;
            foreach (Checker checker in checkers[(int)color])
            {
                if (checker.CanEat())
                {
                    //statusGame = StatusGame.waitEat;
                    f = true;
                    checker.SetLight(true);
                    moves.AddCanEat(checker);
                    notifySetChecker(checker);
                }
            }
            return f;
        }
        private void SelectCheckerAndSearchWay(int x, int y)
        {
            Checker ch = board[x, y].GetChecker();
            moves.selectedChecker = ch;
            SelectChecker(ch);
            ch.SearchWay();//нашли пути

            for (int i = 0; i < 4; i++)//отобразили пути
                notifySetWays(moves.way[i]);
        }
        private void SelectCheckerAndSearchEat(int x, int y)
        {
            Checker ch = board[x, y].GetChecker();
            moves.selectedChecker = ch;
            SelectChecker(ch);
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
            {
                ch.ChangeColor();
                DeleteChecker(ch.x, ch.y);
            }
            moves.preDeleteChecker.Clear();
            return true;
        }

        private void SelectChecker(Checker ch)
        {
            ch.SetLight(true);//поставили подсветку
            notifySetChecker(ch);//обновили на форме
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
            foreach (Checker ch in moves.canEat)
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
       
        public void SetArraysForBotStep()
        {
            w_n = checkers[0].Count;
            w_coords = new int[w_n];
            w_types = new int[w_n];
            b_n = checkers[1].Count;
            b_coords = new int[b_n];
            b_types = new int[b_n];

            for (int i = 0; i < w_n; i++)
            {
                w_coords[i] = (checkers[0][i].x << 3) | checkers[0][i].y;
                w_types[i] = (int)checkers[0][i].GetFigure();
            }
            for (int i = 0; i < b_n; i++)
            {
                b_coords[i] = (checkers[1][i].x << 3) | checkers[1][i].y;
                b_types[i] = (int)checkers[1][i].GetFigure();
            }
        }
        void DecipherRes(int res)
        {
            // _.._(12eaten)_(type1)______(f_c 6)______(num 4)_(end1)
            botMove.end = (res & 1);
            botMove.SetWay((res >> 8) & 7, (res >> 5) & 7);
            botMove.selectedChecker = checkers[(int)color][(res >> 1) & 15];
            botMove.becomeDamka = ((res >> 11) & 1);

            res = res >> 12;
            for (int i = 0; i < 12; i++)
                if (((res >> i) & 1) == 1)
                    botMove.AddEaten(checkers[(int)(color == Color.black ? Color.white : Color.black)][i]);
        }
        private void ShowBotWay(int x, int y)
        {
            SelectChecker(botMove.selectedChecker);
            List<Tuple<int, int>> tmp = new List<Tuple<int,int>>();
            tmp.Add(new Tuple<int, int>(x, y));
            notifySetWays(tmp);          //отобразили путь
        }

        public void ClearResource()
        {
            board = new LogicBoard();
            moves = new Moves();
            foreach (List<Checker> l in checkers)
                l.Clear();
            selectedCheckers.Clear();
            botMove = new BotMove();
        }

        public Color GetColOfCh(int x, int y)
        {
            return board[x, y].GetColor();
        }
    }
}
