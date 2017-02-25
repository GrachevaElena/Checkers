using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    public class BotMove
    {
        public int end=new int();
        public Checker selectedChecker;
        public List<Tuple<int, int>> way;
        public int becomeDamka = new int();
        public List<Checker> eaten;

        public BotMove()
        {
            way = new List<Tuple<int, int>>();
            eaten = new List<Checker>();
            end = becomeDamka = 0;
        }
        public void SetWay(int x, int y)
        {
            way.Add(new Tuple<int, int>(x,y));
        }
        public void AddEaten(Checker ch)
        {
            eaten.Add(ch);
        }
        public void Clear()
        {
            way.Clear();
            eaten.Clear();
        }
    }
}
