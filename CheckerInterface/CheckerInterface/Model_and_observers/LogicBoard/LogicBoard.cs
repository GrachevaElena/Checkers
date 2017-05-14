﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    public enum Figure
    {
        checker,
        damka,
        empty
    }
    public enum Color
    {
        white,
        black,
        empty
    }
    public class LogicBoard
    {
        public LogicCell[,] cell;
        public LogicBoard()
        {
            cell = new LogicCell[8, 8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    cell[i, j] = new LogicCell();
        }
        public LogicCell this[int index1, int index2]
        {
            get { return cell[index1, index2]; }
            set { cell[index1, index2] = value; }
        }
        public void DeleteCheckerFromBoard(int x,int y)
        {
            cell[x, y] = new LogicCell();
        }
        public void ReturnCheckerIntoBoard(Checker ch)
        {
            cell[ch.x, ch.y] = ch;
        }
    }
}
