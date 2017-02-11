using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    public enum StatusApplication
    {
        game,
        constructor,
        menu
    }
    public enum StatusGame
    {
        wait
    }
    public enum StatusPlayer
    {
        bot,
        human
    }
    public class Game_model_observable : iSubject, iGame
    {
        private StatusApplication statusApplication = StatusApplication.menu;
        private StatusGame statusGame;
        private StatusPlayer []statusPlayer = new StatusPlayer[2];
        private Color color;

        public void registerObserver(iObserver o)
        {

        }
        public void removeObserver(iObserver o)
        {

        }
        public void notifyObservers()
        {

        }

        public void SetStatusApplication(StatusApplication st)
        {
            statusApplication = st;
        }
        public void SetStatusGame(StatusGame st)
        {
            statusGame = st;
        }
        public void SetStatusPlayer(StatusPlayer st, Color color)
        {
            statusPlayer[(int)color] = st;
        }
        public void SetNewGameTwoPlayers()
        {
            statusApplication = StatusApplication.game;         
            color = Color.white;
            statusPlayer[(int)Color.white] = StatusPlayer.human;
            statusPlayer[(int)Color.black] = StatusPlayer.human;
        }

        public void Set_ii()
        {
            
        }

        public StatusApplication GetStatusApplication()
        {
            return statusApplication;
        }

        private void ChangeColor()
        {
            color = (Color)((int)color^1);
        }
        public bool Step()
        {
            switch (statusPlayer[(int)color])
            {
                case StatusPlayer.bot: return true;/*1)конец игры? иначе: 2)вызов dll 3) получение лучшего хода 4)изменение модели 5) запрос на обновление 6 NextPlayer()*/
                case StatusPlayer.human:
                    //проверка на конец игры
                    statusGame = StatusGame.wait;
                    return true;                
            }
            return true;
        }
        public bool NextPlayer()
        {
            ChangeColor();
            return false;
        }
        public bool HumanStep(Cell cell)
        {
            if (statusPlayer[(int)color] == StatusPlayer.human)
            {
                switch (statusGame)
                {
                    case StatusGame.wait:
                        break;
                }
            }
            return false;       
        }
    }
}
