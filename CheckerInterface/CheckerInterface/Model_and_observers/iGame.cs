using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    interface iGame
    {
        void SetStatusApplication(StatusApplication st);
        void SetStatusGame(StatusGame st);
        void SetNewGameTwoPlayers();

        void Set_ii();

        StatusApplication GetStatusApplication();

        bool HumanStep(Cell cell);
        bool Step();
        bool NextPlayer();
    }
}
