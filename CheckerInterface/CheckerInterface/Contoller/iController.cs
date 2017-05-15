using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    public interface iController
    {
        void buttonBotVSBot();
        void buttonOnePlayer();
        void buttonTwoPlayers();
        void buttonConstrutor();
        void buttonSetting();
        void buttonAddChecker();
        void buttonDeleteChecker();
        void buttonPlayInConstructor();
        void buttonPlaySetting();
        void CloseSettings();
        void keyEsc();

        void ClickCell(int x, int y);
        void Time();
    }
}
