#include "Board.h"
#include "gtest.h"

TEST(test_Board, can_create) {
	ListOfCheckers white, black;
	white[4].SetCoord(3);
	black[8].SetCoord(48);
	black[8].SetType(DAMKA);
	Board board(white, black);

	EXPECT_EQ(CHECKER, board[3]->GetType());
	EXPECT_EQ(DAMKA, board[48]->GetType());

	black[8].SetCoord(62);
	board.Set(white, black);

	ASSERT_EQ(0,board[48]);
	EXPECT_EQ(DAMKA, board[62]->GetType());
}

TEST(test_Board, can_set) {
	ListOfCheckers white, black;
	black[8].SetCoord(48);
	Board board(white, black);
	black[8].SetCoord(62);
	black[8].SetType(DAMKA);
	board.Set(white, black);

	ASSERT_EQ(0, board[48]);
	EXPECT_EQ(DAMKA, board[62]->GetType());
}

TEST(test_Board, can_check_if_is_empty) {
	Board board;

	EXPECT_TRUE(board.IsEmpty(3));

	ListOfCheckers white, black;
	white[9].SetCoord(3);
	board.Set(white, black);

	EXPECT_FALSE(board.IsEmpty(3));
}