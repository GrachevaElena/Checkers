using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    public class Checker : LogicCell
    {
        public int x, y;
        private Color color;
        private Figure figure;
        private static int[] dx = { 1, -1 };
        private static int[] dy = { -1, 1 };

        public Checker() { }
        public Checker(Color col, Figure fig, int x1, int y1)
        {
            color = col;
            figure = fig;
            x = x1;
            y = y1;
        }
        public override bool isEmpty()
        {
           return false;
        }
        public override Color GetColor()
        {
            return color;
        }
        public override Figure GetFigure()
        {
           return figure;
        }
        public override Checker GetChecker()
        {
            return this;
        }
        public override bool GetIsWay()
        {
            return false;
        }

        public             int GetLight()
        {
            return Convert.ToInt32(base.GetIsWay());
        }
        public Color GetOtherColor()
        {
            return color = (Color)((int)color ^ 1);
        }
        public      void SetLight(bool f)
        {
            SetIsWay(f);
        }
        public void ChangeColor()
        {
            color = (Color)((int)color ^ 1);
        }
        public            void SetDamka()
        {
            figure = Figure.damka;
        }      

        public override void SearchWay()
        {
            switch (GetFigure())
            {
                case Figure.checker:
                    for (int i = 0; i < 2; i++)
                    {
                        int x1 = x + dx[i];
                        int y1 = y + dy[(int)color];
                        if (Inside(x1, y1) && IsEmptyInBoard(x1, y1))
                        {
                            Game.moves.AddWay(x1, y1);
                            Game.board[x1, y1].SetIsWay(true);
                        }
                    }
                    break;
                case Figure.damka:

                    break;
            }
        }
        public override void  SearchEat()
        {
            switch (GetFigure())
            {
                case Figure.checker:
                    for (int i = 0; i < 2; i++)
                        for (int j = 0; j < 2; j++)
                        {
                            int x1 = x + dx[i];
                            int y1 = y + dy[j];
                            if (Inside(x1, y1) && Inside(x1 + dx[i], y1 + dy[j]) && CanBeEaten(Game.board[x1, y1], Game.board[x1 + dx[i], y1 + dy[j]]))
                            {
                                Game.moves.AddCanBeEaten(Game.board[x1, y1].GetChecker());
                                Game.moves.AddWay(x1 + dx[i], y1 + dy[j]);
                                Game.board[x1 + +dx[i], y1 + dy[j]].SetIsWay(true);
                            }
                        }
                    break;
                case Figure.damka:
                    for (int i = 0; i < 2; i++)
                        for (int j = 0; j < 2; j++)
                        {
                            int x1 = x + dx[i];
                            int y1 = y + dy[j];
                            while (Inside(x1, y1) && Inside(x1 + dx[i], y1 + dy[j]) && IsEmptyInBoard(x1, y1))
                            {
                                x1 += dx[i];
                                y1 = y + dy[j];
                            }
                                if (Inside(x1, y1) && Inside(x1 + dx[i], y1 + dy[j]) && CanBeEaten(Game.board[x1, y1], Game.board[x1 + dx[i], y1 + dy[j]]))
                                {
                                    Game.moves.AddCanBeEaten(Game.board[x1, y1].GetChecker());
                                    Game.moves.AddWay(x1 + dx[i], y1 + dy[j]);
                                    Game.board[x1 + +dx[i], y1 + dy[j]].SetIsWay(true);
                                }
                        }
                    break;
            }
        }

        public bool CanEat()
        {
            switch (GetFigure())
            {
                case Figure.checker:
                    for (int i = 0; i < 2; i++)
                        for (int j = 0; j < 2; j++)
                        {
                            int x1 = x + dx[i];
                            int y1 = y + dy[j];
                            if (Inside(x1, y1) && Inside(x1 + dx[i], y1 + dy[j]) && CanBeEaten(Game.board[x1, y1], Game.board[x1 + dx[i], y1 + dy[j]]))
                                return true;
                        }
                    return false;
                case Figure.damka:
                    for (int i = 0; i < 2; i++)
                        for (int j = 0; j < 2; j++)
                        {
                            int x1 = x + dx[i];
                            int y1 = y + dy[j];
                            while (Inside(x1, y1) && Inside(x1 + dx[i], y1 + dy[j]) && IsEmptyInBoard(x1, y1))
                            {
                                x1 += dx[i];
                                y1 = y + dy[j];
                            }
                            if (Inside(x1, y1) && Inside(x1 + dx[i], y1 + dy[j]) && CanBeEaten(Game.board[x1, y1], Game.board[x1 + dx[i], y1 + dy[j]]))
                                return true;
                        }
                    return false;
            }
            return false;
        }            
        public bool SearchAnyMove()
        {
            switch (GetFigure())
            {
                case Figure.checker:
                    for (int i = 0; i < 2; i++)
                        for (int j = 0; j < 2; j++)
                        {
                            int x1 = x + dx[i];
                            int y1 = y + dy[j];
                            if (Inside(x1, y1) && Game.board[x1, y1].isEmpty())
                                return true;
                            if (Inside(x1, y1) && Inside(x1 + dx[i], y1 + dy[j]) && CanBeEaten(Game.board[x1, y1], Game.board[x1 + dx[i], y1 + dy[j]]))
                                return true;
                        }
                    return false;
                case Figure.damka:

                    break;
            }
            return false;
        }

        private bool Inside(int x, int y)
        {
            return (x < 8 && y < 8 && x >= 0 && y >= 0);
        }
        private bool IsEmptyInBoard(int x, int y)
        {
            return (Game.board[x, y].isEmpty());
        }
        private bool CanBeEaten(LogicCell checker, LogicCell nextCell)
        {
            return (checker.GetColor() != Color.empty && color != checker.GetColor() && nextCell.isEmpty());
        }
    }
}
