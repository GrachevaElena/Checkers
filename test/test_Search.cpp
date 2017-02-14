#include "gtest.h"
#include "Search.h"

TEST(test_Search, position8) {
	Move exp;
	exp.Set(0, 35, 17, 5, 0);
	exp.SetVarEaten(1, 0);

	int color = 0;
	const int nw = 5, nb = 1;
	int typesw[nw] = { 0 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 7,14,23,30,35 };
	int coordsb[nb] = { 26 };

	checkers[color].GenerateInitialPosition(0, typesw, coordsw, nw);
	checkers[!color].GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(checkers[color], checkers[!color]);

	Move bestMove;

	EXPECT_EQ(INFINITY, Search(color, MaxDepth, &bestMove));
	EXPECT_EQ(bestMove, exp);

	board.Clean();
}

TEST(test_Search, position1) {
	int color = 0;
	const int nw = 1, nb = 9;
	int typesw[nw] = { 1 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 14 };
	int coordsb[nb] = { 17,19,21,33,35,37,49,51,53 };

	checkers[color].GenerateInitialPosition(0, typesw, coordsw, nw);
	checkers[!color].GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(checkers[color], checkers[!color]);

	Move bestMove;

	EXPECT_EQ(INFINITY, Search(color, MaxDepth, &bestMove));

	board.Clean();
}

TEST(test_Search, position6) {
	Move exp;
	exp.Set(0, 26, 58, 1, 0);
	exp.SetVarEaten(4, 5, 0);

	int color = 0;
	const int nw = 4, nb = 6;
	int typesw[nw] = { 1,0,0,0 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 26,39,30,53 };
	int coordsb[nb] = { 21,19,17,35,51,62 };

	checkers[color].GenerateInitialPosition(0, typesw, coordsw, nw);
	checkers[!color].GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(checkers[color], checkers[!color]);

	Move bestMove;

	EXPECT_EQ(14, Search(color, 3, &bestMove));
	EXPECT_EQ(bestMove, exp);

	board.Clean();
}