#include "gtest.h"
#include "Search.h"
#include "ctime"
#include "iostream"
int SearchAlphaBeta(int color, int depth, int alpha, int beta, Move* bestMove = 0,int type=0);
int AlphaBetaForcing(int color, int depth, int alpha, int beta, Move * bestMove, int ev_num = 0);

TEST(test_AlphaBetaSearch, performance) {
	int color = 0;
	const int nw = 12, nb = 12;
	int typesw[nw] = { 0 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 5,7,14,21,23,30,37,39,46,53,55,62 };
	int coordsb[nb] = { 1,8,10,17,24,26,33,40,42,49,56,58 };

	checkers[0].GenerateInitialPosition(0, typesw, coordsw, nw);
	checkers[1].GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(checkers[0], checkers[1]);

	int t1 = clock();
	SearchAlphaBeta(1, 5, -INF, INF);
	int t2 = clock();

	std::cout << t2 - t1 << std::endl;

	EXPECT_TRUE(1);

	board.Clean();
}

TEST(test_AlphaBetaSearch_Smart, can_evaluate_normally) {
	const int nb = 2;
	int typesb[nb] = { 0 };
	int coordsb[nb] = { 24,58 };

	checkers[0].GenerateInitialPosition(0, 0, 0, 0);
	checkers[1].GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(checkers[0], checkers[1]);

	Move bestMove;
	SearchAlphaBeta(1, 1, -INF, INF, &bestMove, 1);

	EXPECT_EQ(bestMove.GetFinalCoord(), 51);

	board.Clean();
}

TEST(test_AlphaBetaSearch_forcing, can_force) {
	const int nw = 1, nb = 5;
	int typesw[nw] = { 0 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 30 };
	int coordsb[nb] = { 21, 37, 35, 51, 33 };

	checkers[0].GenerateInitialPosition(0, typesw, coordsw, nw);
	checkers[1].GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(checkers[0], checkers[1]);

	Move BestMove;
	int t = AlphaBetaForcing(0, 0, -INF, INF, &BestMove, 0);
	int mustRes = DamkaPrice - 2*CheckerPrice;
	EXPECT_EQ(t, mustRes);

	board.Clean();
}