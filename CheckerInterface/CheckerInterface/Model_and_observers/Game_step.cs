using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CheckerInterface
{
    public partial class Game : iSubject, iGame
    {    
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
            if (isWay && !isEat)//если клетка путь и нет взятий
            {
                MakeMove(moves.selectedChecker, x, y);
                return true;
            }
            else if (isWay && isEat)//если клетка путь и есть взятия
            {
                return MakeEat(moves.selectedChecker, x, y);               
            }
            else if (board[x, y].GetColor() == color)//если клетка твоего цвета
            {
                SelectCheckerAndSearchWay(x, y);
                return false;
            }
            else Miss();//если промах
            return false;
        }        
        /*public void MakeMove(Checker checker, int x, int y)
        {
            notifyDeleteCheckerOrWay(checker.x, checker.y);
            MoveChecker(checker, x , y);
            ClearWays();
           // UnselectFigures();
        }
        public void MakeEat(Checker checker, int x, int y)
        {

        }*/
    }
}
