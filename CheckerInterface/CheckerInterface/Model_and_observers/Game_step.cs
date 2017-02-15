using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CheckerInterface
{
    public partial class Game_model : iSubject, iGame
    {
        private List<Checker> eaten = new List<Checker>();
        private List<Tuple<int, int>> way = new List<Tuple<int, int>>();
        private bool isEat = false;
        
        public void SearchFiguresWhoCanEat()
        {
            isEat = false;
            foreach (Checker checker in checkers[(int)color])
            {
                if (checker.IsEat(board))
                {
                    checker.IsEat(board);
                    isEat = true;
                    selectedCheckers.Add(checker);
                }
            } 
                    
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
        public void NextPlayer()
        {
            color = (Color)((int)color ^ 1);            
        }
        public bool HumanStep(int x, int y) //true если ход закончен
        {
            bool isWay = board[x, y].GetIsWay();
            ClearWays();
            if (isWay && !isEat)
            {
                MakeMove(selectedCheckers.Last(), x, y);                
                return true;
            }  
            if (isWay && isEat)
            {
                //MakeMove
                //return true or false
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
        public void MakeMove(Checker checker, int x, int y)
        {
            notifyDeleteFigure(checker.x, checker.y);
            SetFigure(checker, x , y);
            ClearWays();
            UnselectFigures();
        }
        public void MakeEat(Checker checker, int x, int y)
        {

        }
        public bool IsEat()//ищет есть ли взятия
        {
            foreach (Checker checker in checkers[(int)color])
            {
                if (checker.IsEat(board))
                    return true;
            }
            return false;
        }

        void ClearWays()
        {
            foreach (Tuple<int, int> cell in way)
            {
                board[cell.Item1, cell.Item2].isEmpty();
                notifyDeleteFigure(cell.Item1, cell.Item2);
            }
            way.Clear();
        }
    }
}
