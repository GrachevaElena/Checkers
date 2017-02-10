#include "Search.h"

int i;
extern int eaten[12]; //см FunctionsMove.cpp
extern int color;	//см FunctionsMove.cpp

void MakeMove(Move& move) {
	color = move.GetColor();

	move.GetEaten(eaten);
	for (i = 0; i < move.GetNEaten(); i++) {
		board[checkers[!color][eaten[i]].GetCoord()] = NULL;
		checkers[!color].Delete(eaten[i]);
	}

	board[checkers[color][move.GetNum()].GetCoord()] = NULL;
	board[move.GetCoord()] = &(checkers[color][move.GetNum()]);

	checkers[color][move.GetNum()].SetCoord(move.GetCoord());

	if (move.GetType()) checkers[color][move.GetNum()].ChangeType();

}

void UnMakeMove(Move& move) {
	color = move.GetColor();

	if (move.GetType()) checkers[color][move.GetNum()].ChangeType();

	checkers[color][move.GetNum()].SetCoord(move.GetCoord());

	board[checkers[color][move.GetNum()].GetCoord()] = &(checkers[color][move.GetNum()]);
	board[move.GetCoord()] = NULL;

	move.GetEaten(eaten);
	for (i = 0; i < move.GetNEaten(); i++) {
		board[checkers[!color][eaten[i]].GetCoord()] = &(checkers[!color][eaten[i]]);
		checkers[!color].Insert(eaten[i]);
	}

}