using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    public enum StatusGame
    {
        wait
    }

    interface iGame
    {
        void SetStatusGame(StatusGame st);
        void Set_ii(bool _ii);
        void SetSizeCell(int size);
        void SetSizeBoard(int size);

        int GetSizeCell();
        int GetSizeBoard();
    }
}
