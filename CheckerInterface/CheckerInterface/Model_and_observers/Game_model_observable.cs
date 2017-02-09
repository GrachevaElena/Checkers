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
        white,
        black
    }
    public class Game_model_observable : iSubject, iGame
    {
        private StatusApplication statusApplication = StatusApplication.menu;
        private StatusGame statusGame;
        private StatusPlayer statusPlayer;
        private bool ii_white;
        private bool ii_black;

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
        public void SetStatusPlayer(StatusPlayer st)
        {
            statusPlayer = st;
        }
        public void SetNewGameTwoPlayers()
        {
            statusApplication = StatusApplication.game;
            statusGame = StatusGame.wait;
            statusPlayer = StatusPlayer.white;
        }

        public void Set_ii()
        {
            
        }

        public StatusApplication GetStatusApplication()
        {
            return statusApplication;
        }

        public void GameStep(Cell cell)
        {
            



        }
    }
}
