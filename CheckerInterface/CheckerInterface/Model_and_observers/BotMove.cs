using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    public class BotMove
    {
        public int end = new int();
        public Checker selectedChecker;
        public List<Tuple<int, int>> way;
        public int becomeDamka = new int();
        public List<Checker> eaten;
        public List<Tuple<int, int>> interm;

        public BotMove()
        {
            eaten = new List<Checker>();
            end = becomeDamka = 0;
            way = new List<Tuple<int, int>>();
            interm = new List<Tuple<int, int>>();
        }
        public void SetWay(int _x, int _y)
        {
            way.Add(new Tuple<int, int>(_x, _y));
        }
        public void AddEaten(Checker ch)
        {
            eaten.Add(ch);
        }
        public void AddInterm(Tuple<int,int> way)
        {
            interm.Add(way);
        }
        public void Clear()
        {
            eaten.Clear();
            way.Clear();
            interm.Clear();
        }

        public void SearchInterm()
        {
            Figure savedCh = selectedChecker.GetFigure();
            Moves m1 = new Moves(); int c = 0;
            m1.selectedChecker = selectedChecker;
            selectedChecker.SearchEat(m1);
            Game.board.DeleteCheckerFromBoard(selectedChecker.x, selectedChecker.y);//убрали шашку с доски
            SearchIntermRecursion(m1,c);
            Game.board.ReturnCheckerIntoBoard(selectedChecker);//вернули на доску
            AddInterm(way[0]);
            if (savedCh == Figure.checker) selectedChecker.SetChecker();
        }
        //don't look
        private bool SearchIntermRecursion(Moves m, int c)
        {
            for (int i = 0; i < 4; i++)
                for (int k = 0; k < eaten.Count; k++)
                    if ((m.way[i].Count!=0)&&(m.GetEatenChecker(m.way[i][0].Item1, m.way[i][0].Item2) == eaten[k]))//нашли шашку, которую можно есть
                    {
                        m.AddPreDelete(m.way[i][0].Item1, m.way[i][0].Item2);
                        int x_ = selectedChecker.x;
                        int y_ = selectedChecker.y;//сохранили координаты;
                        bool f = false;

                        for (int j = 0; j < m.way[i].Count; j++)//перебираем все ходы в том направлении
                        {
                            selectedChecker.x = m.way[i][j].Item1;
                            selectedChecker.y = m.way[i][j].Item2;//двигаем шашку

                            Moves m1 = new Moves();
                            m1.selectedChecker = selectedChecker;
                            if (selectedChecker.y == ((int)selectedChecker.GetColor()) * 7) //контроль за становлением дамки
                                selectedChecker.SetDamka();
                            selectedChecker.SearchEat(m1);
                            if (SearchIntermRecursion(m1, c+1))
                            {
                                f = true;
                                interm.Insert(0,m.way[i][j]);//надо вставлять в обратном порядке
                                break;
                            }                       
                        }

                        selectedChecker.x = x_;//подвинули обратно
                        selectedChecker.y = y_;
                        m.CancelLastPreDelete();
                        if (c+1 == eaten.Count) return true;//значит, на следующем шаге оно просто не нашло шашек, которые надо есть - конец
                        if (f) return true;
                    }
            return false;
        }


    }
}
