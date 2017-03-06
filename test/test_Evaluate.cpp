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