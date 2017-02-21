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

void SetColor(int);
void SetCoord(int);
void SetNum(int);

TEST(test_functions_move, OnBoard) {
	EXPECT_TRUE(OnBoard(0));
	EXPECT_TRUE(OnBoard(63));
	EXPECT_FALSE(OnBoard(-1));
	EXPECT_FALSE(OnBoard(64));
}

TEST(test_functions_move, IsBlack) {
	EXPECT_TRUE(IsBlack(1));
	EXPECT_TRUE(IsBlack(26));
	EXPECT_FALSE(IsBlack(0));
	EXPECT_FALSE(IsBlack(27));
}

TEST(test_functions_move, Inside) {
	EXPECT_TRUE(Inside(1));
	EXPECT_TRUE(Inside(62));
	EXPECT_FALSE(Inside(0));
	EXPECT_FALSE(Inside(-100));
	EXPECT_FALSE(Inside(32));
}

TEST(test_functions_move, OnLastRow) {
	SetColor (WHITE);
	EXPECT_TRUE(OnLastRow(8));
	EXPECT_FALSE(OnLastRow(23));
	SetColor(BLACK);
	EXPECT_TRUE(OnLastRow(23));
	EXPECT_FALSE(OnLastRow(8));
}

TEST(test_functions_move, Perp) {
	EXPECT_TRUE(7 == Perp(9));
	EXPECT_TRUE(-7 == Perp(-9));
	EXPECT_TRUE(-9 == Perp(-7));
	EXPECT_TRUE(9 == Perp(7));
}

TEST(test_functions_move, CanMove) {
	int coord = 5;

	EXPECT_TRUE(CanMove(coord+forwardRight[0]));
	EXPECT_TRUE(CanMove(coord+forwardRight[0]));
	EXPECT_TRUE(CanMove(coord+backRight[0]));
	EXPECT_FALSE(CanMove(coord+forwardLeft[0]));
}

TEST(test_functions_move, CanEatChecker) {
	SetCoord(35); SetColor(WHITE);
	Checker ch[4]; 
	board[17] = &(ch[0]);
	board[26] = &(ch[1]);
	board[28] = &(ch[2]);
	board[44] = &(ch[3]);
	board[26]->SetColor(BLACK);
	board[28]->SetColor(BLACK);
	board[17]->SetColor(BLACK);
	board[44]->SetColor(WHITE);

	EXPECT_TRUE(CanEatChecker(backLeft[WHITE]));
	EXPECT_FALSE(CanEatChecker(forwardRight[WHITE]));
	EXPECT_FALSE(CanEatChecker(forwardLeft[WHITE]));
	EXPECT_FALSE(CanEatChecker(backRight[WHITE]));

	board[14] = &(ch[0]);
	board[28] = NULL;
	EXPECT_FALSE(CanEatChecker(backLeft[WHITE]));

	board.Clean();
}

TEST(test_functions_move, CanEatDamka) {
	SetCoord(35); SetColor(WHITE);
	Checker ch[4];
	board[8] = &(ch[0]);
	board[17] = &(ch[1]);
	board[53] = &(ch[2]);
	board[28] = &(ch[3]);
	board[17]->SetColor(BLACK);
	board[53]->SetColor(BLACK);
	board[8]->SetColor(BLACK);
	board[28]->SetColor(WHITE);

	EXPECT_TRUE(CanEatDamka(backRight[WHITE]));
	EXPECT_FALSE(CanEatDamka(forwardRight[WHITE]));
	EXPECT_FALSE(CanEatDamka(forwardLeft[WHITE]));
	EXPECT_FALSE(CanEatDamka(backLeft[WHITE]));

	board.Clean();
}


TEST(test_functions_move, SearchMoveChecker_return_1_if_can_eat)
{
	Checker ch1; ch1.SetColor(WHITE); ch1.SetCoord(35);
	Checker ch; ch.SetColor(BLACK);
	board[44] = &ch;

	EXPECT_TRUE(SearchMoveChecker(ch1));

	board.Clean();
}

TEST(test_functions_move, SearchMoveDamka_return_1_if_can_eat)
{
	Checker ch1; ch1.SetColor(WHITE); ch1.SetCoord(26);
	Checker ch; ch.SetColor(BLACK);
	board[53] = &ch;

	EXPECT_TRUE(SearchMoveDamka(ch1));

	board.Clean();
}

TEST(test_functions_move, SearchMoveChecker_saves_moves) {
	Checker ch1; ch1.SetColor(WHITE); ch1.SetCoord(35);
	Checker ch; ch.SetColor(WHITE);
	board[42] = &ch;

	SearchMoveChecker(ch1);

	EXPECT_EQ(1, cache.CurPos());

	board.Clean();
	cache.Clean();
}

TEST(test_functions_move, SearchMoveDamka_saves_moves) {
	Checker ch1; ch1.SetColor(WHITE); ch1.SetCoord(35);
	Checker ch; ch.SetColor(WHITE);
	board[42] = &ch;

	SearchMoveDamka(ch1);

	EXPECT_EQ(10, cache.CurPos());
	
	board.Clean();
	cache.Clean();
}

TEST(test_functions_move, SearchEatChecker_saves_moves) {
	Checker ch1; ch1.SetColor(WHITE); ch1.SetCoord(30);
	Checker ch[4];
	ch[0].SetColor(BLACK); board[21] = &(ch[0]);
	ch[1].SetColor(BLACK); board[35] = &(ch[1]);
	ch[2].SetColor(BLACK); board[37] = &(ch[2]);
	ch[3].SetColor(BLACK); board[51] = &(ch[3]);

	SearchEatChecker(ch1);

	EXPECT_EQ(3, cache.CurPos());

	board.Clean();
	cache.Clean();
}

TEST(test_functions_move, SearchEatDamka_saves_moves) {
	Checker ch1; ch1.SetColor(WHITE); ch1.SetCoord(35);
	Checker ch[4]; 
	ch[0].SetColor(BLACK); board[10] = &(ch[0]);
	ch[1].SetColor(BLACK); board[21] = &(ch[1]);
	ch[2].SetColor(BLACK); board[26] = &(ch[2]);
	ch[3].SetColor(BLACK); board[49] = &(ch[3]);

	SearchEatDamka(ch1);

	EXPECT_EQ(5, cache.CurPos());

	board.Clean();
	cache.Clean();
}


TEST(test_functions_move, SearchMoveChecker_become_damka) {
	Checker ch1; ch1.SetColor(WHITE); ch1.SetCoord(17);

	SearchMoveChecker(ch1);

	EXPECT_EQ(2, cache.CurPos());
	EXPECT_TRUE(cache.Pop().GetType());

	board.Clean();
	cache.Clean();
}

TEST(test_functions_move, SearchEatChecker_become_damka) {
	Checker ch1; ch1.SetColor(WHITE); ch1.SetCoord(44);
	Checker ch[2];
	ch[0].SetColor(BLACK); board[33] = &(ch[0]);
	ch[1].SetColor(BLACK); board[35] = &(ch[1]);

	SearchEatChecker(ch1);

	EXPECT_EQ(1, cache.CurPos());
	EXPECT_TRUE(cache.Pop().GetType());

	board.Clean();
	cache.Clean();
}

TEST(test_functions_move, SearchEatChecker_become_damka_if_in_corner) {
	Checker ch1; ch1.SetColor(WHITE); ch1.SetCoord(60);
	Checker ch[2];
	ch[0].SetColor(BLACK); board[51] = &(ch[0]);
	ch[1].SetColor(BLACK); board[49] = &(ch[1]);

	SearchEatChecker(ch1);

	EXPECT_EQ(1, cache.CurPos());
	Move move = cache.Pop();
	EXPECT_TRUE(move.GetType());
	EXPECT_EQ(move.GetFinalCoord(), 56);

	board.Clean();
	cache.Clean();
}

TEST(test_functions_move, SearchEatChecker_become_damka_and_continue) {
	Checker ch1; ch1.SetColor(WHITE); ch1.SetCoord(44);
	Checker ch[3];
	ch[0].SetColor(BLACK); board[51] = &(ch[0]);
	ch[1].SetColor(BLACK); board[49] = &(ch[1]);
	ch[2].SetColor(BLACK); board[12] = &(ch[2]);

	SearchEatChecker(ch1);

	EXPECT_EQ(1, cache.CurPos());
	Move move = cache.Pop();
	EXPECT_TRUE(move.GetType());
	EXPECT_EQ(move.GetFinalCoord(),5);

	board.Clean();
	cache.Clean();
}

TEST(test_functions_move, SearchEatChecker_SearchEatDamka_with_black_checker) {
	Checker ch1; ch1.SetColor(BLACK); ch1.SetCoord(1);
	Checker ch[5];
	ch[0].SetColor(WHITE); board[10] = &(ch[0]);
	ch[1].SetColor(WHITE); board[12] = &(ch[1]);
	ch[2].SetColor(WHITE); board[14] = &(ch[2]);
	ch[3].SetColor(WHITE); board[30] = &(ch[3]);
	ch[4].SetColor(WHITE); board[44] = &(ch[4]);
	ch[5].SetColor(WHITE); board[33] = &(ch[5]);

	SearchEatChecker(ch1);

	EXPECT_EQ(1, cache.CurPos());
	Move move = cache.Pop();
	EXPECT_TRUE(move.GetType());
	EXPECT_EQ(move.GetFinalCoord(),24);

	board.Clean();
	cache.Clean();
}

TEST(test_functions_move, position_2_a) {
	Checker ch1; ch1.SetColor(WHITE); ch1.SetCoord(23);
	Checker ch[4];
	ch[0].SetColor(BLACK); board[28] = &(ch[0]);
	ch[1].SetColor(BLACK); board[12] = &(ch[1]);
	ch[2].SetColor(BLACK); board[14] = &(ch[2]);
	ch[3].SetColor(BLACK); board[30] = &(ch[3]);

	SearchEatChecker(ch1);

	EXPECT_EQ(2, cache.CurPos());
	EXPECT_EQ(cache.Pop().GetFinalCoord(), 23);

	board.Clean();
	cache.Clean();
}

TEST(test_functions_move, position_2_b) {
	Checker ch1; ch1.SetColor(WHITE); ch1.SetCoord(23);
	Checker ch[3];
	ch[0].SetColor(BLACK); board[10] = &(ch[0]);
	ch[1].SetColor(BLACK); board[12] = &(ch[1]);
	ch[2].SetColor(BLACK); board[14] = &(ch[2]);

	SearchEatChecker(ch1);

	EXPECT_EQ(1, cache.CurPos());
	EXPECT_EQ(cache.Pop().GetFinalCoord(), 1);

	board.Clean();
	cache.Clean();
}