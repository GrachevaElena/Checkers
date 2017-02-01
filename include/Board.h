#pragma once
#include "ListOfCheckers.h"
class Board {
	Checker* board[64];
public:
	Board() { for (int i = 0; i < 64; i++) board[i] = 0; }
	Board(ListOfCheckers& white, ListOfCheckers& black) { Set(white, black); }
	void Set(ListOfCheckers& white, ListOfCheckers& black);
	int IsEmpty(int cell) { return board[cell] == 0; }
	Checker& operator [](int cell) { if (IsEmpty(cell)) { throw 1; return Checker(); } return *(board[cell]); }
};