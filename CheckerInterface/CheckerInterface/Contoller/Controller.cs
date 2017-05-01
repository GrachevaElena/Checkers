using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckerInterface.View;

namespace CheckerInterface
{
    public enum TypeSettingForm
    {
        botVSbot,
        humanVSbot,
        constructor
    } 
    public class Controller : iController
    {
        iGame game_model;
        Form1 form_view;
        SettingForm settingForm;

        public Controller(Game game, iSubject game_observer)
        {
            this.game_model = game;
            //form_view.count[0]=new int();
            //form_view.count[1] = new int();
            form_view = new Form1(this, game);
            game_observer.registerObserver(form_view);

            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form_view);
        }
        //main menu
        private void buttonClear()//очищает все ресурсы, вызывается после нажатия кнопок главного меню
        {
            if (game_model.GetStatusApplication() == StatusApplication.constructor)
                form_view.panel2.Visible = false;
            form_view.count[0] = form_view.count[1] = 0;
            form_view.VisibleButtons(false);
            form_view.ESC_on = false;
            form_view.timer.Enabled = false;
            game_model.SetStatusPlayers(StatusPlayer.empty, StatusPlayer.empty);
            game_model.ClearResource();
        }
        public void buttonOnePlayer()
        {
            game_model.SetStatusApplication(StatusApplication.game);
            if (settingForm != null) settingForm.Close();
            settingForm = new SettingForm(this, TypeSettingForm.humanVSbot);
            settingForm.Show();
        }
        public void buttonTwoPlayers()
        {
            buttonClear();
            form_view.ChangePanels();
            game_model.SetStatusApplication(StatusApplication.game);
            form_view.CreateBoard(StatusApplication.game);
            game_model.FillBoardAndListCheckers();
            game_model.SetGame(Color.white, StatusPlayer.human, StatusPlayer.human,0, 0,
                Search.empty, Search.empty, Evaluate.empty, Evaluate.empty, StatusGame.wait);
            game_model.StartGame();
        }
        public void buttonLoadGame()
        {
            buttonClear();
        }
        public void buttonConstrutor()
        {
            buttonClear();
            form_view.ChangePanels();
            form_view.CreateBoard(StatusApplication.constructor);
            game_model.SetStatusApplication(StatusApplication.constructor);
            form_view.panel2.Visible = true;
            form_view.SelectAddChecker();
        }
        public void buttonSetting()
        {
            buttonClear();
        }
        public void buttonBotVSBot()
        {
            game_model.SetStatusApplication(StatusApplication.game);
            if (settingForm != null) settingForm.Close();
            settingForm = new SettingForm(this, TypeSettingForm.botVSbot);
            settingForm.Show();
        }

        //contructor menu
        public void buttonAddChecker()
        {
            form_view.HideDeleteChecker();
            form_view.SelectAddChecker();
        }
        public void buttonDeleteChecker()
        {
            form_view.HideAddChecker();
            form_view.SelectDeleteChecker();
        }
        public void buttonPlayInConstructor()
        {
            if (settingForm != null) settingForm.Close();
            settingForm = new SettingForm(this, TypeSettingForm.constructor);
            settingForm.Show();
        }
        public void CloseSettings()
        {
            settingForm.Close();
            settingForm = null;
        }
        public void buttonPlaySetting()
        {
            if (settingForm.CanStartGame())
            {
                form_view.CreateBoard(StatusApplication.game);
                if (game_model.GetStatusApplication() == StatusApplication.constructor)
                {
                    game_model.FillBoardOnForm();
                    form_view.panel2.Visible = false;
                }
                else
                {
                    buttonClear();
                    form_view.ChangePanels();
                    game_model.FillBoardAndListCheckers();
                }
                game_model.SetGame(settingForm.GetColorPlayer1(), settingForm.GetStatusPl1(), settingForm.GetStatusPl2(), settingForm.GetDepthPl1(), settingForm.GetDepthPl2(),
                    settingForm.GetSearchPl1(), settingForm.GetSearchPl2(), settingForm.GetEvaluatePl1(), settingForm.GetEvaluatePl2(), StatusGame.wait);
                if ((game_model.GetStatusPlayer() == StatusPlayer.human) && (game_model.SearchEatingAndWriteToMove()))
                    game_model.SetStatusGame(StatusGame.waitEat);
                settingForm.Close();
                settingForm = null;
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
                    if (form_view.IsCheckedButtonAdd())//если выбраны настройки для шашки и не выбран Delete
                    {                        
                        if ((x + y) % 2 == 1)
                        {
                            Color col = form_view.GetChosenColor();
                            if (form_view.count[(int)col] < 12 || col == game_model.GetColOfCh(x, y))
                                form_view.count[(int)game_model.GetColOfCh(x,y)] += game_model.DeleteChecker(x, y);//удаляй старую шашку
                            if (form_view.count[(int)col] < 12)
                                form_view.count[(int)col] += game_model.CreateChecker(new Checker(col, form_view.GetChosenFigure(), x, y));//вставляй новую
                        }
                    }
                    else if (form_view.IsCheckedButtonDelete())//если выбрана кнопка delete - удаляй шашку. 
                    {
                        form_view.count[(int)game_model.GetColOfCh(x, y)] += game_model.DeleteChecker(x, y);
                    }
                    if (form_view.count[0] > 0 && form_view.count[1] > 0) form_view.SetButtonPlayEnabled(true);
                    else form_view.SetButtonPlayEnabled(false);
                    break;
                    //default: MessageBox.Show("Error, status != game or constructor, status == "+ game_model.GetStatusApplication().ToString()); break;
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
