using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    public interface iController
    {
        void buttonOnePlayer();
        void buttonTwoPlayers();
        void buttonLoadGame();
        void buttonConstrutor();
        void buttonSetting();
        void keyEsc();

        void ClickCell(Cell cell);
    }
}
