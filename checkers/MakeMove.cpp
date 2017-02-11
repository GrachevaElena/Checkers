#include "Search.h"

int i;
extern int eaten[12]; //см FunctionsMove.cpp
extern int color;	//см FunctionsMove.cpp

int savedCoord[MaxDepth]; //ууу костыль
int nSavedCoord=0;
void MakeMove(Move& move) {
	color = move.GetColor();

	move.GetEaten(eaten);
	for (i = 0; i < move.GetNEaten(); i++) {
		board[checkers[!color][eaten[i]].GetCoord()] = NULL;
		checkers[!color].Delete(eaten[i]);
	}

	board[checkers[color][move.GetNum()].GetCoord()] = NULL;
	board[move.GetCoord()] = &(checkers[color][move.GetNum()]);

	savedCoord[nSavedCoord++] = checkers[color][move.GetNum()].GetCoord();
	checkers[color][move.GetNum()].SetCoord(move.GetCoord());

	if (move.GetType()) checkers[color][move.GetNum()].ChangeType();

}

void UnMakeMove(Move& move) {
	color = move.GetColor();

	if (move.GetType()) checkers[color][move.GetNum()].ChangeType();

	checkers[color][move.GetNum()].SetCoord(savedCoord[--nSavedCoord]);

	board[checkers[color][move.GetNum()].GetCoord()] = &(checkers[color][move.GetNum()]);
	board[move.GetCoord()] = NULL;

	move.GetEaten(eaten);
	for (i = 0; i < move.GetNEaten(); i++) {
		board[checkers[!color][eaten[i]].GetCoord()] = &(checkers[!color][eaten[i]]);
		checkers[!color].Insert(eaten[i]);
	}

}