#pragma once
#include "ListOfCheckers.h"
class Board {
	Checker* board[64];
public:
	Board() { for (int i = 0; i < 64; i++) board[i] = 0; }
	Board(ListOfCheckers& white, ListOfCheckers& black) { Set(white, black); }
	void Set(ListOfCheckers& white, ListOfCheckers& black);
	int IsEmpty(int cell) { return board[cell] == 0; }
	Checker*& operator [](int cell) { return board[cell]; }
	void Clean(){ for (int i = 0; i < 64; i++) board[i] = 0; }
};