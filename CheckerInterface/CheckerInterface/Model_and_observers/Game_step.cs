using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CheckerInterface
{
    enum StatusGame
    {
        wait,
        waitStep,
        waitEat,
        waitEatSelect,
        eating
    }
    public partial class Game : iSubject, iGame
    {
        [DllImport(@"Checkers.dll")] 
        static extern int CallBot(int[] w_coords, int[] w_types, int w_n, int[] b_coords, int[] b_types, int b_n, int color);


        private StatusGame statusGame = StatusGame.wait;
        public bool BotStep()
        {
            int w_n=checkers[0].Count;
            int[] w_coords=new int [w_n];
            int[] w_types = new int[w_n];
            int b_n = checkers[1].Count;
            int[] b_coords = new int[b_n];
            int[] b_types = new int[b_n];

            for(int i=0; i<w_n; i++)
            {
                w_coords[i] = (checkers[0][i].x << 3) | checkers[0][i].y;
                w_types[i] =(int) checkers[0][i].GetFigure();
            }
            for (int i = 0; i < b_n; i++)
            {
                b_coords[i] = (checkers[1][i].x << 3) | checkers[1][i].y;
                b_types[i] = (int)checkers[1][i].GetFigure();
            }

            // _.._(12)_(type1)______(f_c 6)______(num 4)_(end1)
            int res = CallBot(w_coords, w_types, w_n, b_coords, b_types, b_n, (int)color);

            if ((res & 1) == 1) return false;

            int num=(res>>1)&15;
            int finalX= (res >> 8) & 7, finalY = (res >> 5) & 7;
            int type=((res >> 11) & 1);

            MoveChecker(checkers[(int)color][num], finalX, finalY, type);

            res = res >> 12;
            for(int i=0; i<12; i++)
                if (((res >> i) & 1) == 1)
                    DeleteChecker(checkers[(int)(color == Color.black ? Color.white : Color.black)][i]);

            return true;
        }
        public void NextPlayer()
        {
            color = (Color)((int)color ^ 1);  
           //автоматически меняется StatusPlayer
        }
        public bool HumanStep(int x, int y) //true если ход закончен
        {
            bool isWay = board[x, y].GetIsWay();

            switch (statusGame)
            {
                case StatusGame.wait:
                    if (board[x, y].GetColor() == color)
                    {
                        SelectCheckerAndSearchWay(x, y);
                        statusGame = StatusGame.waitStep;
                    }
                    return false;
                case StatusGame.waitStep:
                    if (board[x, y].GetIsWay())
                    {
                        MoveChecker(moves.selectedChecker, x, y);
                        ClearWays();
                        statusGame = StatusGame.wait;
                        return true;
                    }
                    if (board[x, y].GetIsLight())
                        return false;
                    if (board[x, y].GetColor() == color)
                    {
                        ClearWays();
                        ClearSelected();
                        SelectCheckerAndSearchWay(x, y);
                        return false;
                    }
                    ClearWays();
                    ClearSelected();
                    statusGame = StatusGame.wait;                
                    return false;
                case StatusGame.waitEat:
                    if (board[x, y].GetIsLight())
                    {
                        SelectCheckerAndSearchEat(x, y);
                        statusGame = StatusGame.waitEatSelect;
                        return false;
                    }
                    ClearWays();
                    return false;
                case StatusGame.waitEatSelect:
                    if (board[x,y].GetIsWay())
                    {
                        if (MakeEat(moves.selectedChecker, x, y) == true)
                        {
                            ClearWays();
                            ClearSelectedCanEat();
                            statusGame = StatusGame.wait;
                            return true;
                        }
                        else
                        {
                            ClearWays();
                            ClearSelectedCanEat();
                            SelectCheckerAndSearchEat(x, y);
                            statusGame = StatusGame.eating;
                            return false;
                        }
                    }
                    if (board[x, y] == moves.selectedChecker)
                        return false;
                    if (board[x,y].GetIsLight())
                    {
                        ClearWays();
                        SelectCheckerAndSearchEat(x, y);                   
                        return false;
                    }
                    ClearWays();
                    statusGame = StatusGame.waitEat;
                    return false;

                case StatusGame.eating:
                    if (board[x, y].GetIsWay())
                    {
                        if (MakeEat(moves.selectedChecker, x, y) == true)
                        {
                            ClearWays();
                            ClearSelectedCanEat();
                            statusGame = StatusGame.wait;
                            return true;
                        }
                            ClearWays();
                            ClearSelectedCanEat();
                            SelectCheckerAndSearchEat(x, y);
                            return false;

                    }
                        return false;
            }
            return false;
        }        
        
    }
}
