#include "gtest.h"
#include "Move.h"

TEST(test_Move, can_set_get_color) {
	Move move;
	move.SetColor(1);

	EXPECT_EQ(1, move.GetColor());
}

TEST(test_Move, can_set_get_type) {
	Move move;
	move.SetType(1);

	EXPECT_EQ(1, move.GetType());
}

TEST(test_Move, can_set_get_start_coord) {
	Move move;
	move.SetFinalCoord(10);

	EXPECT_EQ(10, move.GetFinalCoord());
}

TEST(test_Move, can_set_get_final_coord) {
	Move move;
	move.SetFinalCoord(10);

	EXPECT_EQ(10, move.GetFinalCoord());
}

TEST(test_Move, can_set_get_numchecker) {
	Move move;
	move.SetNum(2);

	EXPECT_EQ(2, move.GetNum());
}

TEST(test_Move, can_set_get_neaten) {
	Move move;
	move.SetNEaten(5);

	EXPECT_EQ(5, move.GetNEaten());
}

TEST(test_Move, can_set_get) {
	int arr[MaxNEaten] = { 12,5 }, arrres[MaxNEaten];
	Move move;
	move.SetNEaten(2);
	ASSERT_EQ(2, move.GetNEaten());
	
	move.SetEaten(arr);
	move.GetEaten(arrres);
	for (int i = 0; i < MaxNEaten; i++)
		EXPECT_EQ(arrres[i], arr[i]);
}

TEST(test_Move, can_set_get_eaten_in_arr) {
	int arr[MaxNEaten] = { 12,5,7,9,10,3,2,1,8,4 };
	Move move;
	move.SetNEaten(10);
	move.SetEaten(arr);

	int arrres[MaxNEaten];
	move.GetEaten(arrres);

	for (int i = 0; i < 10; i++)
		EXPECT_EQ(arrres[i], arr[i]);
}

TEST(test_Move, can_set_get_in_general) {
	int arr[MaxNEaten] = { 1,2,3, 0, 0, 0, 0, 0 , 0, 0/*,9,10,3,2,1,8,4*/ }, arrres[MaxNEaten];
	Move move;
	move.SetColor(BLACK);
	move.SetStartCoord(1);
	move.SetFinalCoord(4);
	move.SetNum(3);
	move.SetNEaten(10);
	move.SetType(1);
	move.SetEaten(arr);
	move.GetEaten(arrres);
	int t = move.GetNEaten();

	EXPECT_EQ(BLACK, move.GetColor());
	EXPECT_EQ(1, move.GetType());
	EXPECT_EQ(3, move.GetNum());
	EXPECT_EQ(1, move.GetStartCoord());
	EXPECT_EQ(4, move.GetFinalCoord());
	EXPECT_EQ(10, move.GetNEaten());

	move.GetEaten(arrres);
	for (int i = 0; i < MaxNEaten; i++)
		EXPECT_EQ(arrres[i], arr[i]);
}

TEST(test_Move, can_compare_if_neaten_diff) {
	Move move, move1;
	move.SetNEaten(3); move.SetNEaten(4);

	EXPECT_FALSE(move1==move);
}

TEST(test_Move, can_compare) {
	Move move, move1;
	move.SetNEaten(3); move1.SetNEaten(3);
	int eaten[3] = { 8,3,7 }, eaten1[3] = { 7,8,3 };
	move.SetEaten(eaten); move1.SetEaten(eaten1);

	EXPECT_TRUE(move1 == move);
}

TEST(test_Move, can_SetEaten_if_variable_n_of_parametrs) {
	Move move;
	move.SetVarEaten(1, 2, 3, 4, 0);
	int res[MaxNEaten];

	move.GetEaten(res);

	EXPECT_EQ(move.GetNEaten(), 4);
	for (int i = 0; i < 4; i++)
		EXPECT_EQ(i + 1, res[i]);
}