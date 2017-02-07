using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    class Controller : iController
    {
        iGame game_model;
        Form1 form_view;

        public void onePlayer()
        {
            form_view.VisibleButtons(false);
        }

        public void twoPlayers()
        {
            form_view.VisibleButtons(false);

        }

        public void loadGame()
        {
            form_view.VisibleButtons(false);
        }

        public void construtor()
        {
            form_view.VisibleButtons(false);
        }

        public void setting()
        {
            form_view.VisibleButtons(false);
        }
    }
}
