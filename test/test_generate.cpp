#include "gtest.h"
#include "FunctionsMove.h"
#include "BasicFunctions.h"
#include "iostream"
using namespace std;

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
				cout <<temp.GetNum()<<' '<< temp.GetCoord() << "   ";
				int eaten[12];
				temp.GetEaten(eaten);
				for (int i = 0; i < temp.GetNEaten(); i++) {
					cout <<eaten[i] << ' ';
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
	exp[0].Set(color, 12, 1, 0);
	exp[1].Set(color, 12, 4, 0);
	exp[2].Set(color, 28, 4, 0); 
	exp[3].Set(color, 28, 7, 0); 
	exp[4].Set(color, 44, 7, 0); 
	exp[5].Set(color, 44, 10, 0);
	exp[6].Set(color, 60, 10, 0); 

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
	exp[0].Set(color, 12, 1, 0);
	exp[1].Set(color, 12, 4, 0);
	exp[2].Set(color, 28, 4, 0);
	exp[3].Set(color, 28, 7, 0);
	exp[4].Set(color, 44, 7, 0);
	exp[5].Set(color, 44, 10, 0);
	exp[6].Set(color, 60, 10, 0);

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
	exp[0].Set(color, 1, 1, 0);
	exp[1].Set(color, 1, 1, 0); 
	exp[2].Set(color, 23, 1, 0); 
	exp[3].Set(color, 23, 1, 0); 

	exp[0].SetVarEaten(1,2,3,0);
	exp[1].SetVarEaten(1,4,5,0);
	exp[2].SetVarEaten(2,3,4,5,0);
	exp[3].SetVarEaten(2,3,4,5,0);

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
	exp[0].Set(color, 3, 1, 0);
	exp[1].Set(color, 8, 1, 0);
	exp[2].Set(color, 17, 1, 0);
	exp[3].Set(color, 60, 1, 0);
	
	exp[0].SetVarEaten(2,4,0);
	exp[1].SetVarEaten(1,2,3,0);
	exp[2].SetVarEaten(1,2,3,0);
	exp[3].SetVarEaten(1,2,5,0);

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

	const int n = 4;
	Move exp[n];
	exp[0].Set(color, 46, 1, 0);
	exp[1].Set(color, 46, 1, 0);
	exp[2].Set(color, 24, 1, 1);
	exp[3].Set(color, 24, 1, 1);
	
	exp[0].SetVarEaten(3, 4, 5, 0);
	exp[1].SetVarEaten(1,2,5, 0);
	exp[2].SetVarEaten(1,2,3,4,0);
	exp[3].SetVarEaten(1,2,3,4);

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

	const int n = 8;
	Move exp[n];
	exp[0].Set(color, 60, 1, 0);
	exp[1].Set(color, 60, 1, 0);
	exp[2].Set(color, 23, 1, 0);
	exp[3].Set(color, 23, 1, 0);
	exp[4].Set(color, 58, 1, 0);
	exp[5].Set(color, 58, 1, 0);
	exp[6].Set(color, 8, 1, 0);
	exp[7].Set(color, 17, 1, 0);
	
	exp[0].SetVarEaten(1,2,5,6,0);
	exp[1].SetVarEaten(3,4,5,6,0);
	exp[2].SetVarEaten(1,2,3,4,0);
	exp[3].SetVarEaten(1,2,3,4,0);
	exp[4].SetVarEaten(3,6,0);
	exp[5].SetVarEaten(1,2,4,6,0);
	exp[6].SetVarEaten(3,5,0);
	exp[7].SetVarEaten(3,5,0);

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

	const int n = 5;
	Move exp[n];
	exp[0].Set(color, 8, 1, 0);
	exp[1].Set(color, 12, 1, 0);
	exp[2].Set(color, 5, 1, 0);
	exp[3].Set(color, 58, 1, 0);
	exp[4].Set(color, 12, 3, 0);
	
	exp[0].SetVarEaten(3, 0);
	exp[1].SetVarEaten(2, 0);
	exp[2].SetVarEaten(2, 0);
	exp[3].SetVarEaten(4,5, 0);
	exp[4].SetVarEaten(1, 0);

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

	const int n = 6;
	Move exp[n];
	exp[0].Set(color, 5, 2, 0);
	exp[1].Set(color, 21, 2, 0);
	exp[2].Set(color, 21, 4, 0);
	exp[3].Set(color, 37, 4, 0);
	exp[4].Set(color, 26, 5, 0);
	exp[5].Set(color, 42, 5, 0);

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

	const int n = 1;
	Move exp[n];
	exp[0].Set(color, 17, 5, 0);
	exp[0].SetVarEaten(1, 0);

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

	const int n = 1;
	Move exp[n];
	exp[0].Set(color, 40, 1, 1);
	exp[0].SetVarEaten(1,0);

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

	const int n = 1;
	Move exp[n];
	exp[0].Set(color, 8, 1, 1);
	exp[0].SetVarEaten(1,2,3, 0);

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

	const int n = 2;
	Move exp[n];
	exp[0].Set(color, 33, 2, 0);
	exp[1].Set(color, 44, 6, 0);

	exp[0].SetVarEaten(1, 0);
	exp[1].SetVarEaten(4, 0);

	ListOfCheckers white, black;
	white.GenerateInitialPosition(0, typesw, coordsw, nw);
	black.GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(white, black);

	Generate(black);

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

	const int n = 3;
	Move exp[n];
	exp[0].Set(color, 56, 1, 0);
	exp[1].Set(color, 7, 1, 0);
	exp[2].Set(color, 14, 1, 0);

	exp[0].SetVarEaten(3, 0);
	exp[1].SetVarEaten(1, 2, 0);
	exp[2].SetVarEaten(2, 2, 0);

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

	const int n = 4;
	Move exp[n];
	exp[0].Set(color, 49, 1, 0);
	exp[1].Set(color, 56, 1, 0);
	exp[2].Set(color, 24, 1, 0);
	exp[3].Set(color, 33, 1, 0);

	exp[0].SetVarEaten(1,3, 0);
	exp[1].SetVarEaten(1,3, 0);
	exp[2].SetVarEaten(1,2,3, 0);
	exp[3].SetVarEaten(1,2,3, 0);

	ListOfCheckers white, black;
	white.GenerateInitialPosition(0, typesw, coordsw, nw);
	black.GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(white, black);

	Generate(white);

	EXPECT_EQ(0, test(n, exp));

	board.Clean();
	cache.Clean();

}

TEST_F(test_Generate, position_1) {
	int color = 0;
	const int nw = 1, nb = 9;
	int typesw[nw] = { 1 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 14 };
	int coordsb[nb] = { 17,19,21,33,35,37,49,51,53 };

	ListOfCheckers white, black;
	white.GenerateInitialPosition(0, typesw, coordsw, nw);
	black.GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(white, black);

	Generate(white);

	int n = cache.CurPos(); int f=0;
	for (int i = 0; i < n; i++)
		if (cache.Pop().GetNEaten() == 9) f = 1;

	EXPECT_TRUE(f);


	board.Clean();
	cache.Clean();

}

TEST_F(test_Generate, position_with_10_eaten) {
	int color = 0;
	const int nw = 1, nb = 12;
	int typesw[nw] = { 1 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 3 };
	int coordsb[nb] = { 14,17,19,21,28,33,35,37,42,46,49,51 };

	ListOfCheckers white, black;
	white.GenerateInitialPosition(0, typesw, coordsw, nw);
	black.GenerateInitialPosition(1, typesb, coordsb, nb);

	board.Set(white, black);

	Generate(white);

	int n = cache.CurPos(); int f = 0;
	for (int i = 0; i < n; i++) {
		Move move= cache.Pop();
		if (move.GetNEaten() == 10) f = 1;
	}

	EXPECT_TRUE(f);


	board.Clean();
	cache.Clean();

}