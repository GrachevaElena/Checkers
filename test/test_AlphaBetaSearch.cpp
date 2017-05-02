#include "gtest.h"
#include "Search.h"
#include <stdio.h>
#include "statistics_func.h"
int SearchAlphaBeta(int, int, int, int, Move*, int =0);

TEST(test_AlphaBetaSearch, end_of_game) {
	const int nw = 6, nb = 1;
	int typesw[nw] = { 1,1,1,1,1,1 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 10,12,26,44,46,60 };
	int coordsb[nb] = { 42 };

	checkers[0].GenerateInitialPosition(0, typesw, coordsw, nw);
	checkers[1].GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(checkers[0], checkers[1]);

	Move BestMove,s;
	SearchAlphaBeta(1, 2, -INF,INF,&BestMove);

	EXPECT_TRUE(BestMove != s);

	board.Clean();
}

TEST(test_AlphaBetaSearch_MAX_SIZE, MAX_SIZE_CACHE) {
	const int nw = 4, nb = 1;
	int typesw[nw] = { 1,1,1, 1};
	int typesb[nb] = { 1 };
	int coordsw[nw] = { 51, 24, 58, 23};
	int coordsb[nb] = { 8 };

	checkers[0].GenerateInitialPosition(0, typesw, coordsw, nw);
	checkers[1].GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(checkers[0], checkers[1]);

	Move BestMove, s;

	cache.Clean();
	Clear();
	SearchAlphaBeta(0, 8, -INF, INF, &BestMove, 1);
	printf("######## %d #########\n", cache.GET_MAX_SIZE());
	
	PrintStatistics(cache);

	board.Clean();
}