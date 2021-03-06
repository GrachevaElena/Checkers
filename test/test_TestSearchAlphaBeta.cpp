#include "Search.h"
#include "gtest.h"

int TestSearchAlphaBeta0(int color, int depth, int alpha, int beta, int& nVertices, int out = 0, Move* firstMoves = 0, int nFirstMoves = 0, Move* bestMove = 0);
int TestSearchAlphaBeta1(int color, int depth, int beta, int& nVertices, int out = 0, Move* firstMoves = 0, int nFirstMoves = 0, Move* bestMove = 0);
int TestSearchAlphaBeta2(int color, int depth, int beta, int& nVertices, int out = 0, Move* firstMoves = 0, int nFirstMoves = 0, Move* bestMove = 0);

TEST(test_TestAlphaBetaSearch0, position14_amputation_depth_is_2) {
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

	EXPECT_EQ(4 * DamkaPrice - CheckerPrice, TestSearchAlphaBeta0(0, 2,-INF, INF, nVertices, 0, move, 2, &bestMove));
	EXPECT_EQ(move[0], bestMove);
	EXPECT_EQ(nVertices, 6);

	board.Clean();
}

TEST(test_TestAlphaBetaSearch1, position14_amputation_depth_is_2) {
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

	EXPECT_EQ(4 * DamkaPrice - CheckerPrice, TestSearchAlphaBeta1(0, 2, INF, nVertices, 0, move, 2, &bestMove));
	EXPECT_EQ(move[0], bestMove);
	EXPECT_EQ(nVertices, 6);

	board.Clean();
}

TEST(test_TestAlphaBetaSearch2, position14_amputation_depth_is_2) {
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

	EXPECT_EQ(4*DamkaPrice-CheckerPrice, TestSearchAlphaBeta2(0, 2, INF, nVertices, 0, move, 2, &bestMove));
	EXPECT_EQ(move[0], bestMove);
	EXPECT_EQ(nVertices, 6);

	board.Clean();
}




TEST(test_TestAlphaBetaSearch0, position15_amputation_depth_is_3) {
	const int nw = 2, nb = 8;
	int typesw[nw] = { 0 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 56,55 };
	int coordsb[nb] = { 12,14,42,58,46,5,26,10 };

	checkers[0].GenerateInitialPosition(0, typesw, coordsw, nw);
	checkers[1].GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(checkers[0], checkers[1]);

	Move move[2];
	move[0].Set(0, 56, 21, 1, 0);
	move[1].Set(0, 56, 51, 1, 0);

	int nVertices = 0; Move bestMove;

	EXPECT_EQ(-5*CheckerPrice, TestSearchAlphaBeta0(0, 3, -INF, INF, nVertices, 0, move, 2, &bestMove));
	EXPECT_EQ(move[0], bestMove);
	EXPECT_EQ(nVertices, 8);

	board.Clean();
}

TEST(test_TestAlphaBetaSearch1, position15_amputation_depth_is_3) {
	const int nw = 2, nb = 8;
	int typesw[nw] = { 0 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 56,55 };
	int coordsb[nb] = { 12,14,42,58,46,5,26,10 };

	checkers[0].GenerateInitialPosition(0, typesw, coordsw, nw);
	checkers[1].GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(checkers[0], checkers[1]);

	Move move[2];
	move[0].Set(0, 56, 21, 1, 0);
	move[1].Set(0, 56, 51, 1, 0);

	int nVertices = 0; Move bestMove;

	EXPECT_EQ(-5 * CheckerPrice, TestSearchAlphaBeta1(0, 3, INF, nVertices, 0, move, 2, &bestMove));
	EXPECT_EQ(move[0], bestMove);
	EXPECT_EQ(nVertices, 8);

	board.Clean();
}

TEST(test_TestAlphaBetaSearch2, position15_amputation_depth_is_3) {
	const int nw = 2, nb = 8;
	int typesw[nw] = { 0 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 56,55 };
	int coordsb[nb] = { 12,14,42,58,46,5,26,10 };

	checkers[0].GenerateInitialPosition(0, typesw, coordsw, nw);
	checkers[1].GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(checkers[0], checkers[1]);

	Move move[2];
	move[0].Set(0, 56, 21, 1, 0);
	move[1].Set(0, 56, 51, 1, 0);

	int nVertices = 0; Move bestMove;

	EXPECT_EQ(-5 * CheckerPrice, TestSearchAlphaBeta2(0, 3, INF, nVertices, 0, move, 2, &bestMove));
	EXPECT_EQ(move[0], bestMove);
	EXPECT_EQ(nVertices, 8);

	board.Clean();
}