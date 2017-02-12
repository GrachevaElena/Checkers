#include "Search.h"

int i;
extern int eaten[12]; 
extern int color;

void MakeMove(Move& move) {
	color = move.GetColor();

	move.GetEaten(eaten);
	for (i = 0; i < move.GetNEaten(); i++) {
		board[checkers[!color][eaten[i]].GetCoord()] = NULL;
		checkers[!color].Delete(eaten[i]);
	}

	board[checkers[color][move.GetNum()].GetCoord()] = NULL;
	board[move.GetFinalCoord()] = &(checkers[color][move.GetNum()]);

	checkers[color][move.GetNum()].SetCoord(move.GetFinalCoord());

	if (move.GetType()) checkers[color][move.GetNum()].ChangeType();

}

void UnMakeMove(Move& move) {
	color = move.GetColor();

	if (move.GetType()) checkers[color][move.GetNum()].ChangeType();

	checkers[color][move.GetNum()].SetCoord(move.GetStartCoord());

	board[checkers[color][move.GetNum()].GetCoord()] = &(checkers[color][move.GetNum()]);
	board[move.GetFinalCoord()] = NULL;

	move.GetEaten(eaten);
	for (i = 0; i < move.GetNEaten(); i++) {
		board[checkers[!color][eaten[i]].GetCoord()] = &(checkers[!color][eaten[i]]);
		checkers[!color].Insert(eaten[i]);
	}

}