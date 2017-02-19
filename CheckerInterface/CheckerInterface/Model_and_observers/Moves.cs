using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    public class Moves
    {
        public List<Tuple<int, int>> []way = new List<Tuple<int, int>>[4]; //шашка может идти в 4 направлениях
        public Checker []canBeEaten = new Checker[4];//за 1 шаг шашка съест не более 1 шашки из 1, 2, 3 или 4 возможных 
        public Checker selectedChecker;
        public List<Checker> preDeleteChecker = new List<Checker>();
        public List<Checker> canEat = new List<Checker>();
        public Moves()
        {
            for (int i = 0; i<4; i++)
                way[i] = new List<Tuple<int, int>>();
        }
        public void AddWay(int x, int y)
        {
            way[FindIndex(x, y)].Add(new Tuple<int, int>(x, y));
        }
        public void AddCanBeEaten(Checker ch)
        {
            canBeEaten[FindIndex(ch.x, ch.y)] = ch;
        }
        public void AddPreDelete(int x, int y)
        {
            preDeleteChecker.Add(canBeEaten[FindIndex(x,y)]);
            preDeleteChecker.Last().ChangeColor();
        }
        public Checker GetEatenChecker(int x, int y)
        {
            return canBeEaten[FindIndex(x, y)];
        }
        public void AddCanEat(Checker checker)
        {          
            canEat.Add(checker);
        }
        private int FindIndex(int x, int y)
        {
            if (x - selectedChecker.x < 0 && y - selectedChecker.y > 0)
                return 0;
            if (x - selectedChecker.x > 0 && y - selectedChecker.y > 0)
                return 1;
            if (x - selectedChecker.x < 0 && y - selectedChecker.y < 0)
                return 2;
            return 3;
        }
    }
}
