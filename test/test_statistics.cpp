#include "gtest.h"
#include "Search.h"
#include "statistics_func.h"

int SearchAlphaBeta(int color, int depth, int alpha, int beta, Move* bestMove = 0, int type = 0);

TEST(test_AlphaBetaSearch_MAX_SIZE, MAX_SIZE_3) {
	const int nw = 4, nb = 1;
	int typesw[nw] = { 1,1,1, 1 };
	int typesb[nb] = { 1 };
	int coordsw[nw] = { 51, 24, 58, 23 };
	int coordsb[nb] = { 8 };

	checkers[0].GenerateInitialPosition(0, typesw, coordsw, nw);
	checkers[1].GenerateInitialPosition(1, typesb, coordsb, nb);
	
	board.Set(checkers[0], checkers[1]);
	Move BestMove;

	cache.Clean();
	ClearStatistics();
	SearchAlphaBeta(0, 10, -INF, INF, &BestMove, 0);
	PrintStatistics();

	board.Clean();
}