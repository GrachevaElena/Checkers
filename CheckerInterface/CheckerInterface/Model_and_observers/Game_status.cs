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
    public enum Search
    {
        FullSearch,
        AlphaBetaSearch,
        ForcedSearch,
        empty
    }
    public enum Evaluate
    {
        SimpleEvaluate,
        SmartEvaluate,
        empty
    }
    public partial class Game : iSubject, iGame
    {
        private StatusApplication statusApplication = StatusApplication.menu;
        private StatusPlayer[] statusPlayer = new StatusPlayer[2];
        private Evaluate[] statusEvaluate = new Evaluate[2];
        private Search[] statusSearch = new Search[2];
        private int[] statusDepth = new int[2];
        private Color winner = new Color();

        public Color GetWinner()
        {
            return winner;
        }
        public void SetWinner(Color w)
        {
            winner=w;
        }

        private Color GetOtherColor(Color color)
        {
            return color == Color.white ? Color.black : Color.white;
        }
        public void SetGame(Color startColor, StatusPlayer pl1, StatusPlayer pl2, int depth1, int depth2,
           Search s1, Search s2, Evaluate e1, Evaluate e2, StatusGame statusGame)
        {
            statusApplication = StatusApplication.game;
            color = startColor;
            statusPlayer[(int)color] = pl1;
            statusPlayer[(int)GetOtherColor(color)] = pl2;
            statusSearch[(int)color] = s1;
            statusSearch[(int)GetOtherColor(color)] = s2;
            statusDepth[(int)color] = depth1;
            statusDepth[(int)GetOtherColor(color)] = depth2;
            statusEvaluate[(int)color] = e1;
            statusEvaluate[(int)GetOtherColor(color)] = e2;
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
        public Color GetEnemyColor()
        {
            return color == Color.white ? Color.black : Color.white;
        }
    }
}
