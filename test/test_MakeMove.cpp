#include "gtest.h"
#include "Search.h"

TEST(test_MakeMove, can_make_simple_move) {
	int type = 0, coord = 28;
	checkers[0].GenerateInitialPosition(0, &type, &coord, 1);
	checkers[1].GenerateInitialPosition(1, 0, 0, 0);

	Move move;
	move.Set(0, 19, 1, 0);

	board.Set(checkers[0], checkers[1]);

	MakeMove(move);

	EXPECT_EQ(checkers[0][1].GetCoord(), 19);
	EXPECT_TRUE(board.IsEmpty(28));
	EXPECT_EQ(board[19], &(checkers[0][1]));

}