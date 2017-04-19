#include "gtest.h"
#include "Bot.h"

TEST(test_CallBot, can_call_bot_and_return_best_move_position_6) {
	int color = 0;
	const int nw = 4, nb = 6;
	int typesw[nw] = { 1,0,0,0 };
	int typesb[nb] = { 0 };
	int coordsw[nw] = { 26,39,30,53 };
	int coordsb[nb] = { 21,19,17,35,51,62 };

	// 0..011000 (4, 5 eaten)|0|111010 (=58)|0001(=1)|0
	int res = CallBot(coordsw, typesw, nw, coordsb, typesb, nb, color, ALPHA_BETA_SEARCH_SMART, MaxDepth);//,ALPHA_BETA_SEARCH,MaxDepth);

	EXPECT_EQ(24, res >> 12);//съеденные совпадают
	EXPECT_EQ(0, (res >>11)&1);//тип совпадает
	EXPECT_EQ(58, (res >> 5) & 63);//совпадают конечные координаты
	EXPECT_EQ(0, (res >> 1) & 15);//совпадает номер 
	EXPECT_EQ(0, res&1);//совпадает поле "конец игры"
}