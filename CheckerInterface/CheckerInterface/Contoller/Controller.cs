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

        public Controller(Game game, iSubject game_observer)
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
            game_model.ClearResource();
            form_view.CreateBoard();
            game_model.FillBoardAndListCheckers();
            game_model.SetStatusApplication(StatusApplication.game);
            game_model.SetStatusPlayers(StatusPlayer.human, StatusPlayer.bot);
            game_model.SetStartColor(Color.white);
            game_model.SetStatusGame(StatusGame.wait);
        }
        public void buttonTwoPlayers()
        {
            form_view.VisibleButtons(false);
            game_model.ClearResource();
            form_view.CreateBoard();
            game_model.FillBoardAndListCheckers();
            game_model.SetStatusApplication(StatusApplication.game);
            game_model.SetStatusPlayers(StatusPlayer.human, StatusPlayer.human);
            game_model.SetStartColor(Color.white);
            game_model.SetStatusGame(StatusGame.wait);
        }
        public void buttonLoadGame()
        {
            form_view.VisibleButtons(false);
        }
        public void buttonConstrutor()
        {
            form_view.VisibleButtons(false);
            game_model.ClearResource();
            game_model.SetStartColor(Color.empty);
            form_view.CreateBoard();
            game_model.SetStatusApplication(StatusApplication.constructor);
            form_view.panel2.Visible = true;
        }
        public void buttonSetting()
        {
            form_view.VisibleButtons(false);
        }
        Figure fig;
        public void buttonAddChecker()
        {
            if (game_model.GetStatusApplication() == StatusApplication.constructor)
                if ((form_view.WhiteRadioButton.Checked || form_view.BlackRadioButton.Checked) && (form_view.DamkaRadioButton.Checked || form_view.CheckerRadioButton.Checked))
                {
                    form_view.button6.BackColor = System.Drawing.Color.White;
                    form_view.button7.BackColor = System.Drawing.Color.Gray;
                    if (form_view.WhiteRadioButton.Checked) game_model.SetStartColor(Color.white);
                    if (form_view.BlackRadioButton.Checked) game_model.SetStartColor(Color.black);
                    if (form_view.CheckerRadioButton.Checked) fig = Figure.checker;
                    if (form_view.DamkaRadioButton.Checked) fig = Figure.damka;
                }
                else
                {
                    form_view.button6.BackColor = System.Drawing.Color.Gray;
                    game_model.SetStartColor(Color.empty);
                }
                    

        }
        public void buttonDeleteChecker()
        {
            form_view.button6.BackColor = System.Drawing.Color.Gray;
            form_view.button7.BackColor = System.Drawing.Color.White;
            form_view.WhiteRadioButton.Checked = false;
            form_view.BlackRadioButton.Checked = false;
            form_view.DamkaRadioButton.Checked = false;
            form_view.CheckerRadioButton.Checked = false;
            game_model.SetStartColor(Color.empty);
        }

        public void ClickCell(int x, int y)
        {
            //MessageBox.Show(x.ToString()+' '+y.ToString());
            switch (game_model.GetStatusApplication())
            {
                case StatusApplication.game:
                    if (game_model.GetStatusPlayer() == StatusPlayer.human)
                    {
                        if (game_model.HumanStep(x, y) == true)
                        {
                            game_model.NextPlayer();

                            if (game_model.SearchAnyMove()) //есть ходы?
                                switch (game_model.GetStatusPlayer()) //да
                                {
                                    case StatusPlayer.human:
                                        // надо ли есть?
                                        if (game_model.SearchEatingAndWriteToMove())
                                            game_model.SetStatusGame(StatusGame.waitEat);
                                        return;

                                    case StatusPlayer.bot:
                                        //включили таймер
                                        form_view.timer.Enabled = true;
                                        return;
                                }
                            else
                            {
                                //нет: конец игры
                                MessageBox.Show("Game over");
                                return;
                            }
                        }
                    }
                    break;
                case StatusApplication.constructor:
                    if (form_view.button6.BackColor == System.Drawing.Color.White)
                    {
                        if ((x + y) % 2 == 1)
                        {
                            game_model.DeleteChecker(x, y);
                            game_model.CreateChecker(new Checker(game_model.GetColor(), fig, x, y));
                        }
                    }
                    else if (form_view.button7.BackColor == System.Drawing.Color.White)
                        game_model.DeleteChecker(x, y);
                    break;
                default: MessageBox.Show("Error, status != game or constructor, status == "+ game_model.GetStatusApplication().ToString()); break;
            }

        }

        public void Time()
        {
            if (game_model.GetStatusPlayer() == StatusPlayer.bot)
            {
                if (game_model.BotStep() == true)
                {
                    game_model.NextPlayer();

                    if (game_model.SearchAnyMove()) //есть ходы?
                        switch (game_model.GetStatusPlayer()) //да
                        {
                            case StatusPlayer.human:
                                //выключили таймер
                                form_view.timer.Enabled = false;
                                // надо ли есть?
                                if (game_model.SearchEatingAndWriteToMove())
                                    game_model.SetStatusGame(StatusGame.waitEat);
                                return;

                            //если бот, то ничего не делаем
                        }
                    else
                    {
                        //нет: конец игры
                        MessageBox.Show("Game over");
                        return;
                    }
                }
            }

        }

        public void keyEsc()
        {
            form_view.VisibleButtons(true);
            form_view.panel2.Visible = false;
        }
    }
}
