#include "gtest.h"
#include "BasicFunctions.h"

TEST(test_Evaluate, can_evaluate_with_checkers_only) {
	ListOfCheckers white, black;
	int types[7] = { 0 };
	int coords[7] = { 0 };
	white.GenerateInitialPosition(0, types, coords, 5);
	black.GenerateInitialPosition(1, types, coords, 7);

	EXPECT_EQ(-2, Evaluate(white, black));
}

TEST(test_Evaluate, can_evaluate_with_damkas) {
	ListOfCheckers white, black;
	int types[7] = { 0,0,1,0,0,1,1 };
	int coords[7] = { 0 };
	white.GenerateInitialPosition(0, types, coords, 7);
	black.GenerateInitialPosition(1, types, coords, 5);

	EXPECT_EQ(14, Evaluate(white, black));
}