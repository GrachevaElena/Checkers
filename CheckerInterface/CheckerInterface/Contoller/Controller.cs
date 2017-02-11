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

        public Controller(Game_model_observable game)
        {
            this.game_model = game;
            form_view = new Form1(this, game);
            Application.EnableVisualStyles();
           // Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form_view);
        }

        public void buttonOnePlayer()
        {
            form_view.VisibleButtons(false);
            form_view.ClearBoard();
        }
        public void buttonTwoPlayers()
        {
            form_view.VisibleButtons(false);
            form_view.CreateBoard();//можно инкапсулировать в один метод: SetNewGameClassic()
            form_view.FillBoard();

            game_model.SetNewGameTwoPlayers();

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

        public void ClickCell(Cell cell)
        {
            switch (game_model.GetStatusApplication())
            {
                case StatusApplication.game:
                    if (game_model.HumanStep(cell))
                    {
                        //update
                        game_model.Step();
                        game_model.NextPlayer();
                        //+update
                    } break;
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
