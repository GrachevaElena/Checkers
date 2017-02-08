#include "gtest.h"
#include "FunctionsMove.h"
#include "BasicFunctions.h"
#include "iostream"
using namespace std;
#include "string.h"

class test_Generate : public testing::Test{
public:
	int test(int n, Move* exp) {
		if (n > cache.CurPos())return 1;
		Move temp; int f; int n1 = cache.CurPos();
		for (int i = 0; i < n1; i++) {
			f = 0;
			temp = cache.Pop();
			for(int j=0; j<n; j++)
				if (exp[j] == temp) {
					f = 1;
					break;
				}
			if (!f) {
				int eaten[12];
				temp.GetEaten(eaten);
				for (int i = 0; i < temp.GetNEaten(); i++) {
					cout << eaten[i] << ' ';
				}
				return 2;
			}
		}
		return 0;
	}
};

TEST_F(test_Generate, checking_of_testing_func) {
	int color = 0;
	const int nw = 12, nb = 12;
	int typesw[nw] = { 0 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 5,7,14,21,23,30,37,39,46,53,55,62 };
	int coordsb[nb] = { 1,8,10,17,24,26,33,40,42,49,56,58 };

	const int n = 7;
	Move exp[n];
	exp[0].SetColor(color); exp[0].SetCoord(12); exp[0].SetNum(1); exp[0].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(12); exp[1].SetNum(4); exp[1].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(28); exp[2].SetNum(4); exp[2].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(28); exp[3].SetNum(7); exp[3].SetType(0);
	exp[4].SetColor(color); exp[4].SetCoord(44); exp[4].SetNum(7); exp[4].SetType(0);
	exp[5].SetColor(color); exp[5].SetCoord(44); exp[5].SetNum(10); exp[5].SetType(0);
	exp[6].SetColor(color); exp[6].SetCoord(60); exp[6].SetNum(10); exp[6].SetType(0);

	ListOfCheckers white, black;
	white.GenerateInitialPosition(0, typesw, coordsw, nw);
	black.GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(white, black);

	for (int i = 0; i < n; i++) {
		cache.Push(exp[i]);
	}

	EXPECT_EQ(0, test(n, exp));

	board.Clean();
	cache.Clean();
}

TEST_F(test_Generate, position_0) {
	int color = 0;
	const int nw=12, nb=12;
	int typesw[nw] = { 0 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 5,7,14,21,23,30,37,39,46,53,55,62 };
	int coordsb[nb] = { 1,8,10,17,24,26,33,40,42,49,56,58 };

	const int n = 7;
	Move exp[n];
	exp[0].SetColor(color); exp[0].SetCoord(12); exp[0].SetNum(1); exp[0].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(12); exp[1].SetNum(4); exp[1].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(28); exp[2].SetNum(4); exp[2].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(28); exp[3].SetNum(7); exp[3].SetType(0);
	exp[4].SetColor(color); exp[4].SetCoord(44); exp[4].SetNum(7); exp[4].SetType(0);
	exp[5].SetColor(color); exp[5].SetCoord(44); exp[5].SetNum(10); exp[5].SetType(0);
	exp[6].SetColor(color); exp[6].SetCoord(60); exp[6].SetNum(10); exp[6].SetType(0);

	ListOfCheckers white, black;
	white.GenerateInitialPosition(0, typesw, coordsw, nw);
	black.GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(white, black);

	Generate(white);

	EXPECT_EQ(0, test(n, exp));

	board.Clean();
	cache.Clean();
}

TEST_F(test_Generate, position_2) {
	int color = 0;
	const int nw = 1, nb = 5;
	int typesw[nw] = { 0 };
	int typesb[nb] = { 1,1,0,0,0 };
	int coordsw[nw] = { 23 };
	int coordsb[nb] = { 10,12,14,28,30};

	const int n = 4;
	Move exp[n];
	exp[0].SetColor(color); exp[0].SetCoord(1); exp[0].SetNum(1); exp[0].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(1); exp[1].SetNum(1); exp[1].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(23); exp[2].SetNum(1); exp[2].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(23); exp[3].SetNum(1); exp[3].SetType(0);
	int eaten[12];
	eaten[0] = 1; eaten[1] = 2; eaten[2] = 3;
	exp[0].SetNEaten(3); exp[0].SetEaten(eaten);
	eaten[0] = 1; eaten[1] = 4; eaten[2] = 5;
	exp[1].SetNEaten(3); exp[1].SetEaten(eaten);
	eaten[0] = 2; eaten[1] = 3; eaten[2] = 4; eaten[3] = 5;
	exp[2].SetNEaten(4); exp[2].SetEaten(eaten);
	eaten[0] = 2; eaten[1] = 3; eaten[2] = 4; eaten[3] = 5;
	exp[3].SetNEaten(4); exp[3].SetEaten(eaten);

	ListOfCheckers white, black;
	white.GenerateInitialPosition(0, typesw, coordsw, nw);
	black.GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(white, black);

	Generate(white);

	EXPECT_EQ(0, test(n, exp));

	board.Clean();
	cache.Clean();

}

TEST_F(test_Generate, position_3) {
	int color = 0;
	const int nw = 1, nb = 5;
	int typesw[nw] = { 1 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 39 };
	int coordsb[nb] = { 28,30,26,12,51 };

	const int n = 4;
	Move exp[n];
	exp[0].SetColor(color); exp[0].SetCoord(3); exp[0].SetNum(1); exp[0].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(8); exp[1].SetNum(1); exp[1].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(17); exp[2].SetNum(1); exp[2].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(60); exp[3].SetNum(1); exp[3].SetType(0);
	int eaten[12];
	eaten[0] = 2; eaten[1] = 4;
	exp[0].SetNEaten(2); exp[0].SetEaten(eaten);
	eaten[0] = 1; eaten[1] = 2; eaten[2] = 3;
	exp[1].SetNEaten(3); exp[1].SetEaten(eaten);
	eaten[0] = 1; eaten[1] = 2; eaten[2] = 3;
	exp[2].SetNEaten(3); exp[2].SetEaten(eaten);
	eaten[0] = 1; eaten[1] = 2; eaten[2] = 5;
	exp[3].SetNEaten(3); exp[3].SetEaten(eaten);

	ListOfCheckers white, black;
	white.GenerateInitialPosition(0, typesw, coordsw, nw);
	black.GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(white, black);

	Generate(white);

	EXPECT_EQ(0, test(n, exp));

	board.Clean();
	cache.Clean();

}

TEST_F(test_Generate, position_4) {
	int color = 0;
	const int nw = 1, nb = 5;
	int typesw[nw] = { 0 };
	int typesb[nb] = { 1,0,0,0,0 };
	int coordsw[nw] = { 24 };
	int coordsb[nb] = { 17,19,33,35,37 };

	const int n = 7;
	Move exp[n];
	exp[0].SetColor(color); exp[0].SetCoord(12); exp[0].SetNum(1); exp[0].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(12); exp[1].SetNum(4); exp[1].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(28); exp[1].SetNum(4); exp[1].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(28); exp[2].SetNum(7); exp[2].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(44); exp[2].SetNum(7); exp[2].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(44); exp[3].SetNum(10); exp[3].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(60); exp[3].SetNum(10); exp[3].SetType(0);

	ListOfCheckers white, black;
	white.GenerateInitialPosition(0, typesw, coordsw, nw);
	black.GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(white, black);

	Generate(white);

	EXPECT_EQ(0, test(n, exp));

	board.Clean();
	cache.Clean();

}

TEST_F(test_Generate, position_5) {
	int color = 0;
	const int nw = 1, nb = 6;
	int typesw[nw] = { 1 };
	int typesb[nb] = { 1,0,0,0,0,0 };
	int coordsw[nw] = { 23 };
	int coordsb[nb] = { 14,12,30,28,26,51 };

	const int n = 7;
	Move exp[n];
	exp[0].SetColor(color); exp[0].SetCoord(12); exp[0].SetNum(1); exp[0].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(12); exp[1].SetNum(4); exp[1].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(28); exp[1].SetNum(4); exp[1].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(28); exp[2].SetNum(7); exp[2].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(44); exp[2].SetNum(7); exp[2].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(44); exp[3].SetNum(10); exp[3].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(60); exp[3].SetNum(10); exp[3].SetType(0);

	ListOfCheckers white, black;
	white.GenerateInitialPosition(0, typesw, coordsw, nw);
	black.GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(white, black);

	Generate(white);

	EXPECT_EQ(0, test(n, exp));

	board.Clean();
	cache.Clean();

}

TEST_F(test_Generate, position_6) {
	int color = 0;
	const int nw = 4, nb = 6;
	int typesw[nw] = { 1,0,0,0 };
	int typesb[nb] = { 0};
	int coordsw[nw] = { 26,39,30,53 };
	int coordsb[nb] = { 21,19,17,35,51,62 };

	const int n = 7;
	Move exp[n];
	exp[0].SetColor(color); exp[0].SetCoord(12); exp[0].SetNum(1); exp[0].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(12); exp[1].SetNum(4); exp[1].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(28); exp[1].SetNum(4); exp[1].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(28); exp[2].SetNum(7); exp[2].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(44); exp[2].SetNum(7); exp[2].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(44); exp[3].SetNum(10); exp[3].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(60); exp[3].SetNum(10); exp[3].SetType(0);

	ListOfCheckers white, black;
	white.GenerateInitialPosition(0, typesw, coordsw, nw);
	black.GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(white, black);

	Generate(white);

	EXPECT_EQ(0, test(n, exp));

	board.Clean();
	cache.Clean();

}

TEST_F(test_Generate, position_7) {
	int color = 0;
	const int nw = 5, nb = 1;
	int typesw[nw] = { 0 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 7,14,23,30,35 };
	int coordsb[nb] = { 62 };

	const int n = 7;
	Move exp[n];
	exp[0].SetColor(color); exp[0].SetCoord(12); exp[0].SetNum(1); exp[0].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(12); exp[1].SetNum(4); exp[1].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(28); exp[1].SetNum(4); exp[1].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(28); exp[2].SetNum(7); exp[2].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(44); exp[2].SetNum(7); exp[2].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(44); exp[3].SetNum(10); exp[3].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(60); exp[3].SetNum(10); exp[3].SetType(0);

	ListOfCheckers white, black;
	white.GenerateInitialPosition(0, typesw, coordsw, nw);
	black.GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(white, black);

	Generate(white);

	EXPECT_EQ(0, test(n, exp));

	board.Clean();
	cache.Clean();

}

TEST_F(test_Generate, position_8) {
	int color = 0;
	const int nw = 5, nb = 1;
	int typesw[nw] = { 0 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 7,14,23,30,35 };
	int coordsb[nb] = { 26 };

	const int n = 7;
	Move exp[n];
	exp[0].SetColor(color); exp[0].SetCoord(12); exp[0].SetNum(1); exp[0].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(12); exp[1].SetNum(4); exp[1].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(28); exp[1].SetNum(4); exp[1].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(28); exp[2].SetNum(7); exp[2].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(44); exp[2].SetNum(7); exp[2].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(44); exp[3].SetNum(10); exp[3].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(60); exp[3].SetNum(10); exp[3].SetType(0);

	ListOfCheckers white, black;
	white.GenerateInitialPosition(0, typesw, coordsw, nw);
	black.GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(white, black);

	Generate(white);

	EXPECT_EQ(0, test(n, exp));

	board.Clean();
	cache.Clean();

}

TEST_F(test_Generate, position_9) {
	int color = 0;
	const int nw = 1, nb = 1;
	int typesw[nw] = { 0 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 26 };
	int coordsb[nb] = { 33 };

	const int n = 7;
	Move exp[n];
	exp[0].SetColor(color); exp[0].SetCoord(12); exp[0].SetNum(1); exp[0].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(12); exp[1].SetNum(4); exp[1].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(28); exp[1].SetNum(4); exp[1].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(28); exp[2].SetNum(7); exp[2].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(44); exp[2].SetNum(7); exp[2].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(44); exp[3].SetNum(10); exp[3].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(60); exp[3].SetNum(10); exp[3].SetType(0);

	ListOfCheckers white, black;
	white.GenerateInitialPosition(0, typesw, coordsw, nw);
	black.GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(white, black);

	Generate(white);

	EXPECT_EQ(0, test(n, exp));

	board.Clean();
	cache.Clean();

}

TEST_F(test_Generate, position_10) {
	int color = 0;
	const int nw = 2, nb = 4;
	int typesw[nw] = { 0 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 30,39 };
	int coordsb[nb] = { 17,19,21,44 };

	const int n = 7;
	Move exp[n];
	exp[0].SetColor(color); exp[0].SetCoord(12); exp[0].SetNum(1); exp[0].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(12); exp[1].SetNum(4); exp[1].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(28); exp[1].SetNum(4); exp[1].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(28); exp[2].SetNum(7); exp[2].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(44); exp[2].SetNum(7); exp[2].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(44); exp[3].SetNum(10); exp[3].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(60); exp[3].SetNum(10); exp[3].SetType(0);

	ListOfCheckers white, black;
	white.GenerateInitialPosition(0, typesw, coordsw, nw);
	black.GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(white, black);

	Generate(white);

	EXPECT_EQ(0, test(n, exp));

	board.Clean();
	cache.Clean();

}

TEST_F(test_Generate, position_11) {
	int color = 1;
	const int nw = 4, nb = 6;
	int typesw[nw] = { 1,0,0,0 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 26, 39,30,53 };
	int coordsb[nb] = { 21,19,17,35,51,62 };

	const int n = 7;
	Move exp[n];
	exp[0].SetColor(color); exp[0].SetCoord(12); exp[0].SetNum(1); exp[0].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(12); exp[1].SetNum(4); exp[1].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(28); exp[1].SetNum(4); exp[1].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(28); exp[2].SetNum(7); exp[2].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(44); exp[2].SetNum(7); exp[2].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(44); exp[3].SetNum(10); exp[3].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(60); exp[3].SetNum(10); exp[3].SetType(0);

	ListOfCheckers white, black;
	white.GenerateInitialPosition(0, typesw, coordsw, nw);
	black.GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(white, black);

	Generate(white);

	EXPECT_EQ(0, test(n, exp));

	board.Clean();
	cache.Clean();

}

TEST_F(test_Generate, position_12) {
	int color = 0;
	const int nw = 1, nb = 3;
	int typesw[nw] = { 1 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 42 };
	int coordsb[nb] = { 21,35,49 };

	const int n = 7;
	Move exp[n];
	exp[0].SetColor(color); exp[0].SetCoord(12); exp[0].SetNum(1); exp[0].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(12); exp[1].SetNum(4); exp[1].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(28); exp[1].SetNum(4); exp[1].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(28); exp[2].SetNum(7); exp[2].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(44); exp[2].SetNum(7); exp[2].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(44); exp[3].SetNum(10); exp[3].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(60); exp[3].SetNum(10); exp[3].SetType(0);

	ListOfCheckers white, black;
	white.GenerateInitialPosition(0, typesw, coordsw, nw);
	black.GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(white, black);

	Generate(white);

	EXPECT_EQ(0, test(n, exp));

	board.Clean();
	cache.Clean();

}

TEST_F(test_Generate, position_13) {
	int color = 0;
	const int nw = 1, nb = 4;
	int typesw[nw] = { 1 };
	int typesb[nb] = { 1 };
	int coordsw[nw] = { 1 };
	int coordsb[nb] = { 19,44,42,12 };

	const int n = 7;
	Move exp[n];
	exp[0].SetColor(color); exp[0].SetCoord(12); exp[0].SetNum(1); exp[0].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(12); exp[1].SetNum(4); exp[1].SetType(0);
	exp[1].SetColor(color); exp[1].SetCoord(28); exp[1].SetNum(4); exp[1].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(28); exp[2].SetNum(7); exp[2].SetType(0);
	exp[2].SetColor(color); exp[2].SetCoord(44); exp[2].SetNum(7); exp[2].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(44); exp[3].SetNum(10); exp[3].SetType(0);
	exp[3].SetColor(color); exp[3].SetCoord(60); exp[3].SetNum(10); exp[3].SetType(0);

	ListOfCheckers white, black;
	white.GenerateInitialPosition(0, typesw, coordsw, nw);
	black.GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(white, black);

	Generate(white);

	EXPECT_EQ(0, test(n, exp));

	board.Clean();
	cache.Clean();

}