using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CheckerInterface
{
    public enum StatusGame
    {
        wait,
        waitStep,
        waitEat,
        waitEatSelect,
        eating,
        endEating,
        сalculating,
        gameOver
    }
    public partial class Game : iSubject, iGame
    {

        [DllImport(@"Checkers.dll")] 
        static extern int CallBot(int[] w_coords, int[] w_types, int w_n, 
            int[] b_coords, int[] b_types, int b_n, 
            int color, int type_search, int max_depth);

        private StatusGame statusGame = StatusGame.wait;

        int w_n, b_n;
        int[] w_types, b_types;
        int[] w_coords, b_coords;
        public bool BotStep()
        {
            switch (statusGame)
            {
                case StatusGame.wait:
                    statusGame = StatusGame.сalculating;
                    SetArraysForBotStep();
                    int res = CallBot(w_coords, w_types, w_n, b_coords, b_types, b_n, (int)color, 3, 5);
                    DecipherRes(res);

                    if (botMove.end == 1)
                    {
                        statusGame = StatusGame.gameOver;
                        MessageBox.Show("Bot thinks, it lost");                      
                        return true;
                    }

                    if (botMove.eaten.Count == 0)
                    {
                        ShowBotWay(botMove.way[0].Item1, botMove.way[0].Item2);
                        statusGame = StatusGame.waitStep;
                    }
                    else
                    {
                        botMove.SearchInterm();
                        ShowBotWay(botMove.interm[0].Item1, botMove.interm[0].Item2);
                        if (botMove.eaten.Count>1) statusGame = StatusGame.eating;
                        else statusGame = StatusGame.endEating;
                    }
                    return false;

                case StatusGame.waitStep:
                    MoveChecker(botMove.selectedChecker, botMove.way[0].Item1, botMove.way[0].Item2);
                    botMove.Clear();
                    statusGame = StatusGame.wait;
                    return true;

                case StatusGame.eating:
                    MoveChecker(botMove.selectedChecker, botMove.interm[0].Item1, botMove.interm[0].Item2);
                    botMove.interm.Remove(botMove.interm[0]);
                    ShowBotWay(botMove.interm[0].Item1, botMove.interm[0].Item2);
                    if (botMove.interm[0] == botMove.way[0]) statusGame = StatusGame.endEating;
                    return false;

                case StatusGame.endEating:
                    MoveChecker(botMove.selectedChecker, botMove.way[0].Item1, botMove.way[0].Item2);
                    foreach (Checker ch in botMove.eaten)
                        DeleteChecker(ch.x, ch.y);
                    botMove.Clear();
                    statusGame = StatusGame.wait;
                    return true;
                case StatusGame.gameOver:
                    return true;
                case StatusGame.сalculating:
                    return false;
            }
            return false;
        }

        public void NextPlayer()
        {
            color = (Color)((int)color ^ 1);  
           //автоматически меняется StatusPlayer
        }

        public bool HumanStep(int x, int y) //true если ход закончен
        {
            bool isWay = board[x, y].GetIsWay();

            switch (statusGame)
            {
                case StatusGame.wait:
                    if (board[x, y].GetColor() == color)
                    {
                        SelectCheckerAndSearchWay(x, y);
                        statusGame = StatusGame.waitStep;
                    }
                    return false;
                case StatusGame.waitStep:
                    if (board[x, y].GetIsWay())
                    {
                        MoveChecker(moves.selectedChecker, x, y);
                        ClearWays();
                        statusGame = StatusGame.wait;
                        return true;
                    }
                    if (board[x, y].GetIsLight())
                        return false;
                    if (board[x, y].GetColor() == color)
                    {
                        ClearWays();
                        ClearSelected();
                        SelectCheckerAndSearchWay(x, y);
                        return false;
                    }
                    ClearWays();
                    ClearSelected();
                    statusGame = StatusGame.wait;                
                    return false;
                case StatusGame.waitEat:
                    if (board[x, y].GetIsLight())
                    {
                        SelectCheckerAndSearchEat(x, y);
                        statusGame = StatusGame.waitEatSelect;
                        return false;
                    }
                    ClearWays();
                    return false;
                case StatusGame.waitEatSelect:
                    if (board[x,y].GetIsWay())
                    {
                        if (MakeEat(moves.selectedChecker, x, y) == true)
                        {
                            ClearWays();
                            ClearSelectedCanEat();
                            statusGame = StatusGame.wait;
                            return true;
                        }
                        else
                        {
                            ClearWays();
                            ClearSelectedCanEat();
                            SelectCheckerAndSearchEat(x, y);
                            statusGame = StatusGame.eating;
                            return false;
                        }
                    }
                    if (board[x, y] == moves.selectedChecker)
                        return false;
                    if (board[x,y].GetIsLight())
                    {
                        ClearWays();
                        SelectCheckerAndSearchEat(x, y);                   
                        return false;
                    }
                    ClearWays();
                    statusGame = StatusGame.waitEat;
                    return false;

                case StatusGame.eating:
                    if (board[x, y].GetIsWay())
                    {
                        if (MakeEat(moves.selectedChecker, x, y) == true)
                        {
                            ClearWays();
                            ClearSelectedCanEat();
                            statusGame = StatusGame.wait;
                            return true;
                        }
                            ClearWays();
                            ClearSelectedCanEat();
                            SelectCheckerAndSearchEat(x, y);
                            return false;

                    }
                        return false;
            }
            return false;
        }                
    }
}
