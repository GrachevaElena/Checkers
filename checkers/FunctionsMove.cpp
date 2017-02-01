#include "FunctionsMove.h"

#define CELL_ON_BOARD(cell) (cell>>6==0)
#define CELL_IS_BLACK(cell) (((cell>>3)^cell)&1)

inline int Inside(int cell)
{
	return (CELL_ON_BOARD(cell) && CELL_IS_BLACK(cell));
}

inline int CanMove(int cell)
{
	return (Inside(cell) && board.IsEmpty(cell));
}

inline int CanEat(int cell)
{
	//сие есть заглушка, я уверена
	return (Inside(cell) && board.IsEmpty(cell));
}

inline type GetMove();
int SearchMoveChecker(Checker *ch)
{
	if (CanMove(ch->GetCoord()+forwardLeft[ch->GetColor()]))
		cache.Push(GetMove());
	else if (CanEat(ch->GetCoord()+forwardLeft[ch->GetColor()]))
		return 1;
	return 0;
}

int SearchMoveDamka(Checker *ch)
{
	return 0;
}