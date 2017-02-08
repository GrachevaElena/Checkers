#include "FunctionsMove.h"
#include "gtest.h"
#include "iostream"
inline int OnBoard(int cell);
inline int IsBlack(int cell);
inline int Inside(int cell);
inline int OnLastRow(int cell);
inline int Perp(int route);

inline int CanMove(int delta);
inline int CanEatChecker(int route);
inline int CanEatDamka(int route);

extern int color, coord, coordEaten;

TEST(test_functions_move, OnBoard) {
	ASSERT_TRUE(OnBoard(0));
	ASSERT_TRUE(OnBoard(63));
	ASSERT_FALSE(OnBoard(-1));
	ASSERT_FALSE(OnBoard(64));
}

TEST(test_functions_move, IsBlack) {
	ASSERT_TRUE(IsBlack(1));
	ASSERT_TRUE(IsBlack(26));
	ASSERT_FALSE(IsBlack(0));
	ASSERT_FALSE(IsBlack(27));
}

TEST(test_functions_move, Inside) {
	ASSERT_TRUE(Inside(1));
	ASSERT_TRUE(Inside(62));
	ASSERT_FALSE(Inside(0));
	ASSERT_FALSE(Inside(-100));
	ASSERT_FALSE(Inside(32));
}

TEST(test_functions_move, OnLastRow) {
	color = WHITE;
	ASSERT_TRUE(OnLastRow(8));
	ASSERT_FALSE(OnLastRow(23));
	color = BLACK;
	ASSERT_TRUE(OnLastRow(23));
	ASSERT_FALSE(OnLastRow(8));
}

TEST(test_functions_move, Perp) {
	ASSERT_TRUE(7 == Perp(9));
	ASSERT_TRUE(-7 == Perp(-9));
	ASSERT_TRUE(-9 == Perp(-7));
	ASSERT_TRUE(9 == Perp(7));
}

TEST(test_functions_move, CanMove) {
	coord = 5;

	ASSERT_TRUE(CanMove(coord+forwardRight[0]));
	ASSERT_TRUE(CanMove(coord+forwardRight[0]));
	ASSERT_TRUE(CanMove(coord+backRight[0]));
	ASSERT_FALSE(CanMove(coord+forwardLeft[0]));
}

TEST(test_functions_move, CanEatChecker) {
	coord = 35; color = WHITE;
	Checker ch[4]; 
	board[17] = &(ch[0]);
	board[26] = &(ch[1]);
	board[28] = &(ch[2]);
	board[44] = &(ch[3]);
	board[26]->SetColor(BLACK);
	board[28]->SetColor(BLACK);
	board[17]->SetColor(BLACK);
	board[44]->SetColor(WHITE);

	ASSERT_TRUE(CanEatChecker(backLeft[color]));
	ASSERT_FALSE(CanEatChecker(forwardRight[color]));
	ASSERT_FALSE(CanEatChecker(forwardLeft[color]));
	ASSERT_FALSE(CanEatChecker(backRight[color]));

	board[14] = &(ch[0]);
	board[28] = NULL;
	ASSERT_FALSE(CanEatChecker(backLeft[color]));

	board.Clean();
}

TEST(test_functions_move, CanEatDamka) {
	coord = 35; color = WHITE;
	Checker ch[4];
	board[8] = &(ch[0]);
	board[17] = &(ch[1]);
	board[53] = &(ch[2]);
	board[28] = &(ch[3]);
	board[17]->SetColor(BLACK);
	board[53]->SetColor(BLACK);
	board[8]->SetColor(BLACK);
	board[28]->SetColor(WHITE);

	ASSERT_TRUE(CanEatDamka(backRight[color]));
	ASSERT_FALSE(CanEatDamka(forwardRight[color]));
	ASSERT_FALSE(CanEatDamka(forwardLeft[color]));
	ASSERT_FALSE(CanEatDamka(backLeft[color]));

	board.Clean();
}


TEST(test_functions_move, SearchMoveChecker_return_1_if_can_eat)
{
	coord = 35; color = WHITE;
	Checker ch; ch.SetColor(BLACK);
	board[44] = &ch;
	color = WHITE;
	coord = 35;

	ASSERT_TRUE(SearchMoveChecker());

	board.Clean();
}

TEST(test_functions_move, SearchMoveDamka_return_1_if_can_eat)
{
	color = WHITE;
	Checker ch; ch.SetColor(BLACK);
	board[53] = &ch;
	color = WHITE;
	coord = 35;

	ASSERT_TRUE(SearchMoveDamka());

	board.Clean();
}

TEST(test_functions_move, SearchMoveChecker_saves_moves) {
	coord = 35; color = WHITE;
	Checker ch; ch.SetColor(WHITE);
	board[42] = &ch;

	SearchMoveChecker();

	ASSERT_EQ(1, cache.CurPos());

	board.Clean();
	cache.Clean();
}

TEST(test_functions_move, SearchMoveDamka_saves_moves) {
	coord = 35; color = WHITE;
	Checker ch; ch.SetColor(WHITE);
	board[42] = &ch;

	SearchMoveDamka();

	ASSERT_EQ(10, cache.CurPos());
	
	board.Clean();
	cache.Clean();
}

TEST(test_functions_move, SearchEatChecker_saves_moves) {
	coord = 30; color = WHITE;
	Checker ch[4];
	ch[0].SetColor(BLACK); board[21] = &(ch[0]);
	ch[1].SetColor(BLACK); board[35] = &(ch[1]);
	ch[2].SetColor(BLACK); board[37] = &(ch[2]);
	ch[3].SetColor(BLACK); board[51] = &(ch[3]);

	SearchEatChecker();

	ASSERT_EQ(3, cache.CurPos());

	board.Clean();
	cache.Clean();
}

TEST(test_functions_move, SearchEatDamka_saves_moves) {
	coord = 35; color = WHITE;
	Checker ch[4]; 
	ch[0].SetColor(BLACK); board[10] = &(ch[0]);
	ch[1].SetColor(BLACK); board[21] = &(ch[1]);
	ch[2].SetColor(BLACK); board[26] = &(ch[2]);
	ch[3].SetColor(BLACK); board[49] = &(ch[3]);

	SearchEatDamka();

	ASSERT_EQ(5, cache.CurPos());

	board.Clean();
	cache.Clean();
}


TEST(test_functions_move, SearchMoveChecker_become_damka) {
	coord = 17; color = WHITE;

	SearchMoveChecker();

	ASSERT_EQ(2, cache.CurPos());
	ASSERT_TRUE(cache.Pop().GetType());

	board.Clean();
	cache.Clean();
}

TEST(test_functions_move, SearchEatChecker_become_damka) {
	coord = 44; color = WHITE;
	Checker ch[2];
	ch[0].SetColor(BLACK); board[33] = &(ch[0]);
	ch[1].SetColor(BLACK); board[35] = &(ch[1]);

	SearchEatChecker();

	ASSERT_EQ(1, cache.CurPos());
	ASSERT_TRUE(cache.Pop().GetType());

	board.Clean();
	cache.Clean();
}

TEST(test_functions_move, SearchEatChecker_become_damka_if_in_corner) {
	coord = 60; color = WHITE;
	Checker ch[2];
	ch[0].SetColor(BLACK); board[51] = &(ch[0]);
	ch[1].SetColor(BLACK); board[49] = &(ch[1]);

	SearchEatChecker();

	ASSERT_EQ(1, cache.CurPos());
	Move move = cache.Pop();
	ASSERT_TRUE(move.GetType());
	ASSERT_EQ(move.GetCoord(), 56);

	board.Clean();
	cache.Clean();
}

TEST(test_functions_move, SearchEatChecker_become_damka_and_continue) {
	coord = 44; color = WHITE;
	Checker ch[3];
	ch[0].SetColor(BLACK); board[51] = &(ch[0]);
	ch[1].SetColor(BLACK); board[49] = &(ch[1]);
	ch[2].SetColor(BLACK); board[12] = &(ch[2]);

	SearchEatChecker();

	ASSERT_EQ(1, cache.CurPos());
	Move move = cache.Pop();
	ASSERT_TRUE(move.GetType());
	ASSERT_EQ(move.GetCoord(),5);

	board.Clean();
	cache.Clean();
}

TEST(test_functions_move, SearchEatChecker_SearchEatDamka_with_black_checker) {
	coord = 1; color = BLACK;
	Checker ch[5];
	ch[0].SetColor(WHITE); board[10] = &(ch[0]);
	ch[1].SetColor(WHITE); board[12] = &(ch[1]);
	ch[2].SetColor(WHITE); board[14] = &(ch[2]);
	ch[3].SetColor(WHITE); board[30] = &(ch[3]);
	ch[4].SetColor(WHITE); board[44] = &(ch[4]);
	ch[5].SetColor(WHITE); board[33] = &(ch[5]);

	SearchEatChecker();

	ASSERT_EQ(1, cache.CurPos());
	Move move = cache.Pop();
	ASSERT_TRUE(move.GetType());
	ASSERT_EQ(move.GetCoord(),24);

	board.Clean();
	cache.Clean();
}

TEST(test_functions_move, position_2_a) {
	coord = 23; color = WHITE;
	Checker ch[4];
	ch[0].SetColor(BLACK); board[28] = &(ch[0]);
	ch[1].SetColor(BLACK); board[12] = &(ch[1]);
	ch[2].SetColor(BLACK); board[14] = &(ch[2]);
	ch[3].SetColor(BLACK); board[30] = &(ch[3]);

	SearchEatChecker();

	EXPECT_EQ(2, cache.CurPos());
	EXPECT_EQ(cache.Pop().GetCoord(), 23);

	board.Clean();
	cache.Clean();
}

TEST(test_functions_move, position_2_b) {
	coord = 23; color = WHITE;
	Checker ch[3];
	ch[0].SetColor(BLACK); board[10] = &(ch[0]);
	ch[1].SetColor(BLACK); board[12] = &(ch[1]);
	ch[2].SetColor(BLACK); board[14] = &(ch[2]);

	SearchEatChecker();

	EXPECT_EQ(1, cache.CurPos());
	EXPECT_EQ(cache.Pop().GetCoord(), 1);

	board.Clean();
	cache.Clean();
}