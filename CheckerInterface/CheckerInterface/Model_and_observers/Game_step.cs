using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CheckerInterface
{
    enum StatusGame
    {
        wait,
        waitStep,
        waitEat,
        waitEatSelect,
        eating
    }
    public partial class Game : iSubject, iGame
    {
        private StatusGame statusGame = StatusGame.wait;
        /*public bool Step()
        {
            switch (statusPlayer[(int)color])
            {
                case StatusPlayer.bot: return true;/*1)конец игры? иначе: 2)вызов dll 3) получение лучшего хода 4)изменение модели 5) запрос на обновление 6 NextPlayer()*/
               /* case StatusPlayer.human:
                    //проверка на конец игры
                    return true;
            }
            return true;
        }*/
        public void NextPlayer()
        {
            color = (Color)((int)color ^ 1);            
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
