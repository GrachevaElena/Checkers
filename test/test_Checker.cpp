#include "Checker.h"

#include "gtest.h"


TEST(Checker, created_checker_is_null)
{
	Checker ch;

	ASSERT_EQ(0, ch.GetType());
}

TEST(Checker, can_set_and_get_type)
{
	Checker ch;

	ch.SetType(DAMKA);

	ASSERT_EQ(ch.GetType(),DAMKA);
}

TEST(Checker, can_set_and_get_color)
{
	Checker ch;

	ch.SetColor(BLACK);

	ASSERT_EQ(ch.GetColor(), BLACK);
}

TEST(Checker, can_set_and_get_coord) 
{
	Checker ch;
	ch.SetCoord(1);

	ch.SetCoord(24);

	ASSERT_EQ(ch.GetCoord(), 24);
}

TEST(Checker, can_set_and_get_next_num) 
{
	Checker ch;
	ch.SetNextNum(11);

	ch.SetNextNum(6);

	ASSERT_EQ(ch.GetNextNum(), 6);
}

TEST(Checker, can_set_and_get_prev_num) 
{
	Checker ch;
	ch.SetPrevNum(10);

	ch.SetPrevNum(1);

	ASSERT_EQ(ch.GetPrevNum(), 1);
}

TEST(Checker, can_change_color) 
{
	Checker ch;

	ch.ChangeColor();

	ASSERT_EQ(ch.GetColor(), BLACK);
}

TEST(Checker, can_change_type) 
{
	Checker ch;
	ch.SetType(DAMKA);

	ch.ChangeType();

	ASSERT_EQ(ch.GetType(), CHECKER);

}

TEST(Checker, all_set_methods_run_correctly_in_agregate) 
{
	Checker ch;
	ch.SetType(DAMKA);
	ch.SetColor(WHITE);
	ch.SetCoord(45);
	ch.SetNextNum(9);
	ch.SetPrevNum(3);

	ASSERT_EQ(ch.GetType(), DAMKA);
	ASSERT_EQ(ch.GetColor(), WHITE);
	ASSERT_EQ(ch.GetCoord(), 45);
	ASSERT_EQ(ch.GetNextNum(), 9);
	ASSERT_EQ(ch.GetPrevNum(), 3);
}