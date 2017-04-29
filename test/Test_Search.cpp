#include "gtest.h"
#include "Search.h"
#include "ctime"
#include "iostream"
int SearchAlphaBeta(int color, int depth, int alpha, int beta, Move* bestMove = 0,int type=0);

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

TEST(test_AlphaBetaSearch, end_of_game) {
	const int nw = 6, nb = 1;
	int typesw[nw] = { 1,1,1,1,1,1 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 10,12,26,44,46,60 };
	int coordsb[nb] = { 42 };

	checkers[0].GenerateInitialPosition(0, typesw, coordsw, nw);
	checkers[1].GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(checkers[0], checkers[1]);

	Move BestMove, s;
	SearchAlphaBeta(1, 2, -INF, INF, &BestMove);

	EXPECT_TRUE(BestMove != s);

	board.Clean();
}