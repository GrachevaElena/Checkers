#include "Board.h"

Board::Board(ListOfCheckers & white, ListOfCheckers & black)
{
	for (auto it = white.begin(); it; it++)
		board[(*it).GetCoord()] = &(*it);
	for (auto it = black.begin(); it; it++)
		board[(*it).GetCoord()] = &(*it);
}

void Board::Set(ListOfCheckers & white, ListOfCheckers & black)
{
	for (int i = 0; i < 64; i++) board[i] = 0;
	for (auto it = white.begin(); it; it++)
		board[(*it).GetCoord()] = &(*it);
	for (auto it = black.begin(); it; it++)
		board[(*it).GetCoord()] = &(*it);
}
