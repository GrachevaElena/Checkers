using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckerInterface
{
    public class Controller : iController
    {
        iGame game_model;
        Form1 form_view;
        iSubject game_observer;

        public Controller(Game_model game, iSubject game_observer)
        {
            this.game_model = game;
            form_view = new Form1(this, game);
            game_observer.registerObserver(form_view);

            Application.EnableVisualStyles();
           //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form_view);
        }

        public void buttonOnePlayer()
        {
            form_view.VisibleButtons(false);
        }
        public void buttonTwoPlayers()
        {
            form_view.VisibleButtons(false);
            form_view.CreateBoard();
            game_model.FillBoardAndListCheckers();
            game_model.SetStatusApplication(StatusApplication.game);
            game_model.SetStatusPlayers(StatusPlayer.human, StatusPlayer.human);
            game_model.SetStartColor(Color.white);      

        }
        public void buttonLoadGame()
        {
            form_view.VisibleButtons(false);
        }
        public void buttonConstrutor()
        {
            form_view.VisibleButtons(false);
        }
        public void buttonSetting()
        {
            form_view.VisibleButtons(false);
        }

        public void ClickCell(int x, int y)
        {
            //MessageBox.Show(x.ToString()+' '+y.ToString());
            switch (game_model.GetStatusApplication())
            {
                case StatusApplication.game:
                    if (game_model.GetStatusPlayer() == StatusPlayer.human)
                        game_model.HumanStep(x, y);
                    break;
                case StatusApplication.constructor: break;
                default: MessageBox.Show("Error, status != game or constructor, status == "+ game_model.GetStatusApplication().ToString()); break;
            }

        }

        public void keyEsc()
        {
            form_view.VisibleButtons(true);
        }
    }
}
