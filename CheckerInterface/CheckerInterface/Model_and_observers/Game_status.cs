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
    public enum StatusPlayer
    {
        bot,
        human,
        empty
    }
    public partial class Game : iSubject, iGame
    {
        private StatusApplication statusApplication = StatusApplication.menu;
        private StatusPlayer[] statusPlayer = new StatusPlayer[2];

        public void SetGame(Color startColor, StatusPlayer pl1, StatusPlayer pl2, StatusGame statusGame)
        {
            statusApplication = StatusApplication.game;
            color = startColor;
            statusPlayer[0] = pl1;
            statusPlayer[1] = pl2;
            this.statusGame = statusGame;
        }
        public void StartGame()
        {
            if (this.GetStatusPlayer() == StatusPlayer.bot)
                notifyEnableTimer();
        }
        public void SetStatusApplication(StatusApplication st)
        {
            statusApplication = st;
        }
        public void SetStatusPlayers(StatusPlayer pl1, StatusPlayer pl2)
        {
            statusPlayer[0] = pl1;
            statusPlayer[1] = pl2;
        }
        public void SetStatusGame(StatusGame statusGame)
        {
            this.statusGame = statusGame;
        }
        public void SetStartColor(Color col)
        {
            color = col;
        }

        public StatusApplication GetStatusApplication()
        {
            return statusApplication;
        }
        public StatusGame GetStatusGame()
        {
            return statusGame;
        }
        public StatusPlayer GetStatusPlayer()
        {
            return statusPlayer[(int)color];
        }
        public Color GetColor()
        {
            return color;
        }
    }
}
