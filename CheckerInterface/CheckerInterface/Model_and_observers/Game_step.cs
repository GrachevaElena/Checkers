using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CheckerInterface
{
    public enum StatusGame
    {
        wait,
        isEat
    }
    public partial class Game_model
    {
        private List<Tuple<LogicCell, int, int>> way;
        private List<Checker> eat;

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
                    statusGame = StatusGame.wait;
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
                switch (statusGame)
                {
                    case StatusGame.wait:
                    if (board[x,y].GetColor() == color)
                    {
                        UnselectFigures();
                        SelectFigure(board[x, y].GetChecker());

                    }
                    else UnselectFigures();
                    return false;
                }

            return false;
        }
        public bool isEat()//ищет есть ли взятия
        {
            foreach (Checker ch in checkers[(int)color])
            {

            }
            return false;
        }

        void ClearWays()
        {
            foreach (Tuple<LogicCell, int, int> cell in way)
            {
                cell.Item1.isEmpty();
                notifyDeleteFigure(cell.Item2, cell.Item3);

            }
}
    }
}
