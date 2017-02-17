#include "Search.h"
#include "gtest.h"

int TestSearch(int color, int depth, int& nSteps, int out = 0, Move* firstMoves = 0, int nFirstMoves = 0, Move* bestMove = 0);

TEST(test_TestSearch, position_with_two_branches_possible_amputation_in_second) {
	const int nw = 6, nb = 1;
	int typesw[nw] = { 1,1,1,1,1,1 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 10,12,26,44,46,60 };
	int coordsb[nb] = { 3 };

	checkers[0].GenerateInitialPosition(0, typesw, coordsw, nw);
	checkers[1].GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(checkers[0], checkers[1]);

	Move move[2];
	move[0].Set(0, 60, 53, 6, 0);
	move[1].Set(0, 60, 42, 6, 0);

	int nVertices = 0; Move bestMove;

	EXPECT_EQ(27, TestSearch(0, 2, nVertices,1, move, 2, &bestMove));
	EXPECT_EQ(move[0], bestMove);
	EXPECT_EQ(nVertices, 7);

	board.Clean();
}