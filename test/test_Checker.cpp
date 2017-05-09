#include "Checker.h"

#include "gtest.h"

class test_Checker: public testing::Test, public Checker {
	//делается для открытого доступа к protected функциям
};

TEST_F(test_Checker, created_checker_is_NULL)
{
	ASSERT_EQ(0, GetType());
}

TEST_F(test_Checker, can_set_and_get_type)
{
	SetType(DAMKA);

	ASSERT_EQ(GetType(),DAMKA);
}

TEST_F(test_Checker, can_set_and_get_color)
{
	SetColor(BLACK);

	ASSERT_EQ(GetColor(), BLACK);
}

TEST_F(test_Checker, can_set_and_get_coord)
{
	SetCoord(1);

	SetCoord(24);

	ASSERT_EQ(GetCoord(), 24);
}

TEST_F(test_Checker, can_set_and_get_next_num)
{
	SetNextNum(11);

	SetNextNum(6);

	ASSERT_EQ(GetNextNum(), 6);
}

TEST_F(test_Checker, can_set_and_get_prev_num)
{
	SetPrevNum(10);

	SetPrevNum(1);

	ASSERT_EQ(GetPrevNum(), 1);
}

TEST_F(test_Checker, can_set_and_get_num) {
	SetNum(4);

	ASSERT_EQ(4, GetNum());
}

TEST_F(test_Checker, can_change_color)
{
	SetColor(WHITE);

	ChangeColor();

	ASSERT_EQ(GetColor(), BLACK);
}

TEST_F(test_Checker, can_change_type)
{
	SetType(DAMKA);

	ChangeType();

	ASSERT_EQ(GetType(), CHECKER);

}

TEST_F(test_Checker, all_set_methods_run_correctly_in_agregate)
{
	SetNum(4);
	SetType(DAMKA);
	SetColor(WHITE);
	SetCoord(45);
	SetNextNum(9);
	SetPrevNum(3);

	ASSERT_EQ(GetType(), DAMKA);
	ASSERT_EQ(GetColor(), WHITE);
	ASSERT_EQ(GetCoord(), 45);
	ASSERT_EQ(GetNextNum(), 9);
	ASSERT_EQ(GetPrevNum(), 3);
	ASSERT_EQ(GetNum(), 4);
}