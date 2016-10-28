#include "ListOfCheckers.h"

#include "gtest.h"

TEST(ListOfCheckers, can_create_list_correctly)
{
	ListOfCheckers white;
	int n=0;

	for (int num = white.GetFirstNum(); num; num = white[num].GetNextNum(), n++);

	EXPECT_EQ(n, 12);
}

TEST(ListOfCheckers, can_determine_list_is_empty)
{
	ListOfCheckers white;
	for (int i = 1; i <= 12; i++)
		white.Delete(i);

	EXPECT_TRUE(white.IsEmpty());
}

TEST(ListOfCheckers, can_insert_element)
{

}

TEST(ListOfCheckers, can_insert_element_to_empty_list)
{

}

TEST(ListOfCheckers, can_delete_element)
{

}

TEST(ListOfCheckers, can_delete_element_if_size_is_one)
{

}

TEST(ListOfCheckers, can_generate_initial_position)
{
	ASSERT_TRUE(1);
}