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

        //промежуточные переменные, нужны для общения между функциями
        private int way_x, way_y;
        private int eaten_x, eaten_y;

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

        public int GetLight()
        {
            return Convert.ToInt32(base.GetIsWay());
        }
        public Color GetOtherColor()
        {
            return color = (Color)((int)color ^ 1);
        }
        public void SetLight(bool f)
        {
            SetIsWay(f);
        }
        public void ChangeColor()
        {
            color = (Color)((int)color ^ 1);
        }
        public void SetDamka()
        {
            figure = Figure.damka;
        }
        public void SetChecker()
        {
            figure = Figure.checker;
        }


        public bool CanMoveInRay(int dx, int dy/*orts of ray*/)
        //+сохраняет съеденную шашку в way_x, way_y
        {
            switch (GetFigure())
            {
                case Figure.checker:
                    if (Checker.dy[(int)color] != dy) return false;
                    int x1 = x + dx;
                    int y1 = y + dy;
                    if (Inside(x1, y1) && Game.board[x1, y1].isEmpty())
                    {
                        way_x = x1;
                        way_y = y1;
                        return true;
                    }
                    return false;

                case Figure.damka:
                    way_x = -1;
                    way_y = -1;
                    return false;
            }
            return false;
        }

        public bool CanEatInRay(int dx, int dy/*orts of ray*/)
        //+сохраняет съеденную шашку в eaten_x, eaten_y
        {
            int x1 = x + dx;
            int y1 = y + dy;
            switch (GetFigure())
            {
                case Figure.checker:
                    if (Inside(x1, y1) && Inside(x1 + dx, y1 + dy) && CanBeEaten(Game.board[x1, y1], Game.board[x1 + dx, y1 + dy]))
                    {
                        eaten_x = x1;
                        eaten_y = y1;
                        return true;
                    }
                    return false;

                case Figure.damka:
                    while (Inside(x1, y1) && Inside(x1 + dx, y1 + dy) && IsEmptyInBoard(x1, y1))
                    {
                        x1 += dx;
                        y1 = y + dy;
                    }
                    if (Inside(x1, y1) && Inside(x1 + dx, y1 + dy) && CanBeEaten(Game.board[x1, y1], Game.board[x1 + dx, y1 + dy]))
                    {
                        eaten_x = x1;
                        eaten_y = y1;
                        return true;
                    }
                    return false;
            }
            return false;
        }

        //разбила функции на 2 см выше
        public void SearchWay(Moves m)
        {
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    if (CanMoveInRay(dx[i], dy[j]))
                    {
                        if (way_x == -1) return;//временно
                        m.AddWay(way_x, way_y);
                        Game.board[way_x, way_y].SetIsWay(true);
                    }
                }

        }
        public void SearchEat(Moves m)
        {
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    if (CanEatInRay(dx[i], dy[j]))
                    {
                        m.AddCanBeEaten(Game.board[eaten_x, eaten_y].GetChecker());
                        m.AddWay(eaten_x + dx[i], eaten_y + dy[j]);
                        Game.board[eaten_x + +dx[i], eaten_y + dy[j]].SetIsWay(true);
                    }
                }
        }
        public override void SearchWay()
        {
            SearchWay(Game.moves);
        }
        public override void SearchEat()
        {
            SearchEat(Game.moves);
        }
        public bool CanEat()
        {
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    if (CanEatInRay(dx[i], dy[j])) return true;
            return false;
        }

        public bool SearchAnyMove()
        {
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    if (CanMoveInRay(dx[i], dy[j])) return true;
                    else if (CanEatInRay(dx[i], dy[j])) return true;
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
