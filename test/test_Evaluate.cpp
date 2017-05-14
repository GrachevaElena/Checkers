#include "gtest.h"
#include "BasicFunctions.h"

extern ListOfCheckers checkers[2];
TEST(test_Evaluate, can_evaluate_with_checkers_only) {
	int types[7] = { 0 };
	int coords[7] = { 0 };
	checkers[0].GenerateInitialPosition(0, types, coords, 5);
	checkers[1].GenerateInitialPosition(1, types, coords, 7);

	EXPECT_EQ(-2*CheckerPrice, Evaluate(0));
}

TEST(test_Evaluate, can_evaluate_with_damkas) {
	int types[7] = { 0,0,1,0,0,1,1 };
	int coords[7] = { 0 };
	checkers[0].GenerateInitialPosition(0, types, coords, 7);
	checkers[1].GenerateInitialPosition(1, types, coords, 5);

	EXPECT_EQ(2*DamkaPrice, Evaluate(0));
}

TEST(test_SmartEvaluate, can_evaluate_for_white) {
	int color = 0;
	const int nw = 4, nb = 1;
	int typesw[nw] = { 0 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 7,23,30,35 };
	int coordsb[nb] = { 62 };

	checkers[0].GenerateInitialPosition(0, typesw, coordsw, nw);
	checkers[1].GenerateInitialPosition(1, typesb, coordsb, nb);

	int e1 = SmartEvaluate(WHITE);
	checkers[0][2].SetCoord(14);
	int e2 = SmartEvaluate(WHITE);

	EXPECT_TRUE(e2 - e1<0);

}

TEST(test_SmartEvaluate, can_evaluate_for_black) {
	int color = 0;
	const int nw = 4, nb = 2;
	int typesw[nw] = { 0 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 7,23,30,35 };
	int coordsb[nb] = { 8,62 };

	checkers[0].GenerateInitialPosition(0, typesw, coordsw, nw);
	checkers[1].GenerateInitialPosition(1, typesb, coordsb, nb);

	int e1 = SmartEvaluate(BLACK);
	checkers[1][2].SetCoord(55);
	checkers[1][2].SetType(1);
	int e2 = SmartEvaluate(BLACK);

	EXPECT_TRUE(e2 - e1>0);

	e1 = SmartEvaluate(BLACK);
	checkers[1][1].SetCoord(17);
	e2 = SmartEvaluate(BLACK);

	EXPECT_TRUE(e2 - e1<0);
}