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
        public List<Tuple<int, int>> move;
        public int becomeDamka = new int();
        public List<Checker> eaten;
        public List<Tuple<int, int>> allInterm;
        public Tuple<int, int> interm;
        public int numEaten = 0;

        public BotMove()
        {
            eaten = new List<Checker>();
            end = becomeDamka = 0;
            move = new List<Tuple<int, int>>();
            allInterm = new List<Tuple<int, int>>();
        }
        public void SetWay(int _x, int _y)
        {
            move.Add(new Tuple<int,int>(_x, _y));
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
