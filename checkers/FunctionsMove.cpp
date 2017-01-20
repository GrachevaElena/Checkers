#include "FunctionsMove.h"
inline int Inside(int coord, int delta)
{
	return (coord / 8 + delta / 8 < 8 && coord % 8 + delta % 8 < 8);
}
inline int CanMove(int coord, int delta)
{
	return (Inside(coord, delta) && board[coord+delta]->Empty());
}
inline int CanEat(int coord, int delta)
{
	return (Inside(coord, delta) && board[coord + delta]->Empty());
}
inline type GetMove();
int SearchMoveChecker(Checker *ch)
{
	if (CanMove(ch->GetCoord(), forwardLeft[ch->GetColor()]))
		cache.Push(GetMove());
	else if (CanEat(ch->GetCoord(), forwardLeft[ch->GetColor()]))
		return 1;
	return 0;
}

int SearchMoveDamka(Checker *ch)
{
	return 0;
}