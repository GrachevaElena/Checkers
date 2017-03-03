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
        public int x, y;
        public int becomeDamka = new int();
        public List<Checker> eaten;
        public Tuple<int, int> interm;
        public int numEaten = 0;

        public BotMove()
        {
            eaten = new List<Checker>();
            end = becomeDamka = 0;
        }
        public void SetWay(int _x, int _y)
        {
            x = _x; y = _y;
        }
        public void SetInterm(int x, int y)
        {
            interm=new Tuple<int, int>(x, y);
        }
        public void AddEaten(Checker ch)
        {
            eaten.Add(ch);
        }
        public void Clear()
        { 
            eaten.Clear();
        }
    }
}
