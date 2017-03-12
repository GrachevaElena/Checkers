using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    interface iGame
    {
        void StartGame();
        void SetGame(StatusApplication st, Color startColor, StatusPlayer pl1, StatusPlayer pl2, StatusGame statusGame);
        void SetStatusApplication(StatusApplication st);
        void SetStatusPlayers(StatusPlayer pl1, StatusPlayer pl2);
        void SetStatusGame(StatusGame statusGame);
        void SetStartColor(Color color);
        void FillBoardAndListCheckers();
        void CreateChecker(Checker ch);
        void DeleteChecker(int x, int y);

        StatusApplication GetStatusApplication();
        StatusPlayer GetStatusPlayer();
        Color GetColor();

        bool HumanStep(int x, int y);
        bool BotStep();
        bool SearchEatingAndWriteToMove();
        bool SearchAnyMove();
        void NextPlayer();
        void ClearResource();
    }
}
