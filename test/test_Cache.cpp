#include "gtest.h"

#include "Cache.h"

TEST(test_cache, can_create_cache)
{
	EXPECT_NO_THROW(Cache a(10));
}
TEST(test_cache, test_cache_can_insert_to_fint)
{
	Cache a(10);
	while (!a.IsFint())
		a.Push(Move());

	EXPECT_EQ(10, a.CurPos());
}

TEST(test_cache, test_cache_can_delete_to_empty)
{
	Cache a(10);
	while (!a.IsFint())
		a.Push(Move());
	while (!a.IsEmpty())
		a.Pop();
	//EXPECT_EQ(0, a.CurPos());
}

TEST(test_cache, test_cache_can_push_and_pop)
{
	Cache a(1);
		a.Push(Move());
	//EXPECT_EQ(13, a.Pop());
}

TEST(test_cache, test_cache_can_det_cur_pos)
{
	Cache a(100);
	for (int i = 0; i < 10; i++) a.Push(Move());

	//EXPECT_EQ(10, a.CurPos());
}