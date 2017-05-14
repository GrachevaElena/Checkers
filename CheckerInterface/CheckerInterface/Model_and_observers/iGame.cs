﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    interface iGame
    {
        void StartGame();
        void SetGame(Color startColor, StatusPlayer pl1, StatusPlayer pl2, int depth1, int depth2, 
            Search s1, Search s2, Evaluate e1, Evaluate e2, StatusGame statusGame);
        void SetStatusApplication(StatusApplication st);
        void SetStatusPlayers(StatusPlayer pl1, StatusPlayer pl2);
        void SetStatusGame(StatusGame statusGame);
        void SetStartColor(Color color);
        void FillBoardOnForm();
        void FillBoardAndListCheckers();
        int CreateChecker(Checker ch);
        int DeleteChecker(int x, int y);

        StatusApplication GetStatusApplication();
        StatusGame GetStatusGame();
        StatusPlayer GetStatusPlayer();
        Color GetColor();
        Color GetEnemyColor();
        Color GetColOfCh(int x, int y);

        bool HumanStep(int x, int y);
        bool BotStep();
        bool SearchEatingAndWriteToMove();
        bool SearchAnyMove();
        void NextPlayer();
        void ClearResource();
    }
}
