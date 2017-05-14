#include "ListOfCheckers.h"

#include "gtest.h"

TEST(test_ListOfCheckers, iterator_operator_pointer) {
	ListOfCheckers white; white.Bind(12);
	white[1].SetCoord(63);
	ListOfCheckers::iterator it = white.begin();

	ASSERT_EQ(63, it->GetCoord());
}

TEST(test_ListOfCheckers, can_create_list_correctly)
{
	ListOfCheckers white; white.Bind(12);
	ListOfCheckers::iterator it=white.begin();
	int n = 0;

	for (; it; n++, it++);

	EXPECT_EQ(n, 12);
}

TEST(test_ListOfCheckers, can_delete_element)
{
	ListOfCheckers white; white.Bind(12);
	ListOfCheckers::iterator it = white.begin();


	white.Delete(2);

	EXPECT_EQ(it++, &(white[3]));
}

TEST(test_ListOfCheckers, can_determine_list_is_empty)
{
	ListOfCheckers white;
	for (int i = 1; i <= 12; i++)
		white.Delete(i);

	EXPECT_TRUE(white.IsEmpty());
}

TEST(test_ListOfCheckers, can_insert_element)
{
	ListOfCheckers white; white.Bind(12);
	ListOfCheckers::iterator it = white.begin();
	white.Delete(1);

	white.Insert(1);

	EXPECT_EQ(it, &(white[1]));
}

TEST(test_ListOfCheckers, can_insert_element_to_empty_list)
{
	ListOfCheckers white; white.Bind(12);
	ListOfCheckers::iterator it = white.begin();
	for (int i = 1; i <= 12; i++)
		white.Delete(i);

	white.Insert(1);

	EXPECT_EQ(it, &(white[1]));
}

TEST(test_ListOfCheckers, can_delete_element_if_size_is_one)
{
	ListOfCheckers white; white.Bind(12);
	ListOfCheckers::iterator it = white.begin();
	for (int i = 2; i <= 12; i++)
		white.Delete(i);

	white.Delete(1);

	EXPECT_TRUE(white.IsEmpty());
}

TEST(test_ListOfCheckers, can_generate_initial_position)
{
	ListOfCheckers white; white.Bind(12);
	ListOfCheckers::iterator it = white.begin();
	int color = WHITE;
	int types[7] = { 0,1,1,0,0,0,1 };
	int coords[7] = { 3,5,7,8,10,12,14 };

	white.GenerateInitialPosition(color, types, coords, 7);

	for (int i = 0; it; it++, i++) {
		ASSERT_EQ(it->GetCoord(), coords[i]);
		ASSERT_EQ(it->GetColor(), color);
		ASSERT_EQ(it->GetType(), types[i]);
	}
}

TEST(test_ListOfCheckers, can_bypassing_the_list)
{
	ListOfCheckers white; white.Bind(12);
	int count = 0;
	white.Delete(1);
	white.Delete(11);
	white.Delete(12);
	for (ListOfCheckers::iterator it = white.begin(); it != white.end(); it++)
	{
		(Checker*)it;
		count++;
	}
	EXPECT_EQ(count, 9);
}

