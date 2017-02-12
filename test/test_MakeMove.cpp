#include "gtest.h"
#include "Search.h"

TEST(test_MakeMove, can_make_and_unmake_simple_move) {
	int type = 0, coord = 28;
	checkers[0].GenerateInitialPosition(0, &type, &coord, 1);
	checkers[1].GenerateInitialPosition(1, 0, 0, 0);

	Move move;
	move.Set(0,28, 19, 1, 0);

	board.Set(checkers[0], checkers[1]);

	MakeMove(move);

	EXPECT_EQ(checkers[0][1].GetCoord(), 19);
	EXPECT_TRUE(board.IsEmpty(28));
	EXPECT_EQ(board[19], &(checkers[0][1]));

	UnMakeMove(move);

	EXPECT_EQ(checkers[0][1].GetCoord(), 28);
	EXPECT_TRUE(board.IsEmpty(19));
	EXPECT_EQ(board[28], &(checkers[0][1]));
}

TEST(test_MakeMove, can_make_and_unmake_move_with_eaten) {
	int type = 1, coord = 28;
	checkers[0].GenerateInitialPosition(0, &type, &coord, 1);
	int types[3] = { 0 }; int coords[3] = { 35,51,46 };
	checkers[1].GenerateInitialPosition(1, types, coords, 3);

	Move move;
	move.Set(0,28, 39, 1, 0);
	move.SetVarEaten(1, 2, 3, 0);

	board.Set(checkers[0], checkers[1]);

	MakeMove(move);

	EXPECT_EQ(checkers[0][1].GetCoord(), 39);
	EXPECT_TRUE(board.IsEmpty(28));
	EXPECT_EQ(board[39], &(checkers[0][1]));

	EXPECT_TRUE(board.IsEmpty(35));
	EXPECT_TRUE(board.IsEmpty(51));
	EXPECT_TRUE(board.IsEmpty(46));

	EXPECT_TRUE(checkers[1].IsEmpty());

	UnMakeMove(move);

	EXPECT_EQ(checkers[0][1].GetCoord(), 28);
	EXPECT_TRUE(board.IsEmpty(39));
	EXPECT_EQ(board[28], &(checkers[0][1]));

	EXPECT_EQ(board[35], &(checkers[1][1]));
	EXPECT_EQ(board[51], &(checkers[1][2]));
	EXPECT_EQ(board[46], &(checkers[1][3]));

	EXPECT_TRUE(!checkers[1].IsEmpty());
}

TEST(test_MakeMove, can_make_and_unmake_move_with_changing_type) {
	int type = 0, coord = 33;
	checkers[0].GenerateInitialPosition(0, &type, &coord, 1);
	checkers[1].GenerateInitialPosition(1, 0, 0, 0);

	Move move;
	move.Set(0,33, 24, 1, 1);

	board.Set(checkers[0], checkers[1]);

	MakeMove(move);

	EXPECT_EQ(DAMKA, checkers[0][1].GetType());

	UnMakeMove(move);

	EXPECT_EQ(CHECKER, checkers[0][1].GetType());
}