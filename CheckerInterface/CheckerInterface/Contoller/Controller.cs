using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckerInterface.View;

namespace CheckerInterface
{
    public class Controller : iController
    {
        iGame game_model;
        Form1 form_view;
        SettingForm settingForm;

        public Controller(Game game, iSubject game_observer)
        {
            this.game_model = game;
            form_view = new Form1(this, game);
            game_observer.registerObserver(form_view);

            Application.EnableVisualStyles();
           //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form_view);
        }
        //main menu
        private void buttonClear()//очищает все ресурсы, вызывается после нажатия кнопок главного меню
        {
            form_view.VisibleButtons(false);
            form_view.ESC_on = false;
            form_view.timer.Enabled = false;
            game_model.SetStatusPlayers(StatusPlayer.empty, StatusPlayer.empty);
            game_model.ClearResource();
        }
        public void buttonOnePlayer()
        {
            buttonClear();
            form_view.CreateBoard();
            game_model.FillBoardAndListCheckers();
            game_model.SetGame(Color.white, StatusPlayer.human, StatusPlayer.bot, StatusGame.wait);
            game_model.StartGame();
        }
        public void buttonTwoPlayers()
        {
            buttonClear();
            form_view.CreateBoard();
            game_model.FillBoardAndListCheckers();
            game_model.SetGame(Color.white, StatusPlayer.human, StatusPlayer.human, StatusGame.wait);
            game_model.StartGame();
        }
        public void buttonLoadGame()
        {
            buttonClear();
        }
        public void buttonConstrutor()
        {
            buttonClear();
            form_view.CreateBoard();
            game_model.SetStatusApplication(StatusApplication.constructor);
            form_view.panel2.Visible = true;
        }
        public void buttonSetting()
        {
            buttonClear();
        }
        public void buttonBotVSBot()
        {
            buttonClear();
            form_view.CreateBoard();
            game_model.FillBoardAndListCheckers();
            game_model.SetGame(Color.white, StatusPlayer.bot, StatusPlayer.bot, StatusGame.wait);
            game_model.StartGame();
        }

        //contructor menu
        public void buttonAddChecker()
        {
            form_view.SetCheckedButDelete(false);
            if (form_view.RadiosButtonsIsChecked())
                form_view.SetColorButton(System.Drawing.Color.White, System.Drawing.Color.Gray);
            else form_view.SetColorButton(System.Drawing.Color.Gray, System.Drawing.Color.Gray);
        }
        public void buttonDeleteChecker()
        {
            form_view.SetCheckedButDelete(true);
            form_view.SetColorButton(System.Drawing.Color.Gray, System.Drawing.Color.White);
        }
        public void buttonPlayInConstructor()
        {
            form_view.panel2.Visible = false;
            settingForm = new SettingForm(this);
            settingForm.Show();
        }
        public void buttonPlaySetting()
        {
           if (settingForm.CanStartGame())
            {
                game_model.SetGame(settingForm.GetColorPlayer1(), settingForm.GetStatusPl1(), settingForm.GetStatusPl2(), StatusGame.wait);
                if ((game_model.GetStatusPlayer()==StatusPlayer.human)&&(game_model.SearchEatingAndWriteToMove()))
                    game_model.SetStatusGame(StatusGame.waitEat);
                settingForm.Close();
                game_model.StartGame();
            }
        }     //stting

        private void GameEnd()
        {
            form_view.timer.Enabled = false;
            game_model.SetStartColor(Color.empty);
            game_model.SetStatusPlayers(StatusPlayer.empty, StatusPlayer.empty);
            game_model.SetStatusApplication(StatusApplication.menu);          
        }
        public void ClickCell(int x, int y)
        {
            switch (game_model.GetStatusApplication())
            {
                case StatusApplication.game:
                    if (game_model.GetStatusPlayer() == StatusPlayer.human)
                    {
                        if (game_model.HumanStep(x, y) == true)//если человек сходил
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

                                        //######
                                        //game_model.CallBot               - включаем поиск хода
                                        //как только нашли ход:
                                        //form_view.timer.Enabled = true;  - включаем таймер, вызывается Time, там вызываем BotStep, отрисовываем пути
                                        //В Time когда отрисовали путь делаем:
                                        //  отключаем таймер
                                        //  NextPlayer()
                                        //  ClickCell(0,0) - цикл продолжается
                                        //######
                                        return;
                                }
                            else
                            {
                                //нет: конец игры
                                GameEnd();
                                MessageBox.Show("Game over");
                                return;
                            }
                        }
                    }
                    break;
                case StatusApplication.constructor:
                    if (form_view.RadiosButtonsIsChecked() && !form_view.IsCheckedButtonDelete())//если выбраны настройки для шашки и не выбран Delete
                    {
                        if ((x + y) % 2 == 1)
                        {
                            game_model.DeleteChecker(x, y);//удаляй старую шашку
                            game_model.CreateChecker(new Checker(form_view.GetChosenColor(), form_view.GetChosenFigure(), x, y));//вставляй новую
                        }
                    }
                    else if (form_view.IsCheckedButtonDelete())//если выбрана кнопка delete - удаляй шашку. 
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
                    if (game_model.GetStatusGame() == StatusGame.gameOver)
                    {
                        GameEnd();
                        return;
                    }
                    game_model.NextPlayer();

                    if (game_model.SearchAnyMove()) //есть ходы?
                    {
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
                    }
                    else
                    {
                        //нет: конец игры
                        GameEnd();
                        MessageBox.Show("Game over");
                        return;
                    }
                }
            }

        }

        public void keyEsc()
        {
            if (game_model.GetStatusApplication() == StatusApplication.menu) //если мы в меню ...
            {
                //do nothing =)
                form_view.VisibleButtons(true);
            } 
            else if (form_view.ESC_on == false)//если на esc не нажимали - открой меню
            {
                form_view.ESC_on = true;
                form_view.VisibleButtons(true);
            }
            else //если на esc нажимали - закрой меню
            {
                form_view.VisibleButtons(false);
                form_view.ESC_on = false;
            }     
        }
    }
}
