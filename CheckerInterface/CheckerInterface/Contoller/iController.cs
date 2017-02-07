using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    interface iController
    {
        void onePlayer();
        void twoPlayers();
        void loadGame();
        void construtor();
        void setting();

        void ClickCell(Cell cell);
    }
}
