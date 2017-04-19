#include "gtest.h"
#include "Search.h"

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