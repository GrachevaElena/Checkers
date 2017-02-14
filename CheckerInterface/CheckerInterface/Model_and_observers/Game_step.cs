using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CheckerInterface
{
    public partial class Game_model
    {
        private List<Checker> eat;
        private bool isEat = false;

        private void ChangeColor()
        {
            color = (Color)((int)color ^ 1);
        }
        public bool Step()
        {
            switch (statusPlayer[(int)color])
            {
                case StatusPlayer.bot: return true;/*1)конец игры? иначе: 2)вызов dll 3) получение лучшего хода 4)изменение модели 5) запрос на обновление 6 NextPlayer()*/
                case StatusPlayer.human:
                    //проверка на конец игры
                    return true;
            }
            return true;
        }
        public bool NextPlayer()
        {
            ChangeColor();
            return false;
        }
        public bool HumanStep(int x, int y) //true если ход закончен
        {
            bool isWay = board[x, y].GetIsWay();
            ClearWays();
            if (isWay)
            {
                //MakeMove
                return true;
            }         
            if (isEat)
            {
                //MakeMove
                return false;
            }      
            if (board[x, y].GetColor() == color )
            {
                SelectFigureAndSearchWay(x, y);
                return false;
            }
             UnselectFigures();
             return false;
        }
        public void SelectFigureAndSearchWay(int x, int y)
        {
            if (selectedCheckers.Count() == 1)
                UnselectFigures();
            SelectFigure(board[x, y].GetChecker());
            board[x, y].SearchWay(way, board);
            notifySetWays(way);
        }
        public bool IsEat()//ищет есть ли взятия
        {
            foreach (Checker ch in checkers[(int)color])
            {

            }
            return false;
        }
    }
}
