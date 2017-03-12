#include "BasicFunctions.h"

extern ListOfCheckers checkers[2];
const int Price[2] = { CheckerPrice,DamkaPrice };

const int ev_board[2][64] = {
	//for white
	{
		-1,7,-1,7,-1,7,-1,7,
		5,-1,5,-1,5,-1,5,-1,
		-1,3,-1,3,-1,3,-1,3,
		2,-1,1,-1,1,-1,1,-1,
		-1,0,-1,0,-1,0,-1,1,
		0,-1,0,-1,0,-1,0,-1,
		-1,1,-1,1,-1,1,-1,1,
		5,-1,5,-1,5,-1,5,-1
	},
	//for black
	{
		-1,5,-1,5,-1,5,-1,5,
		1,-1,1,-1,1,-1,1,-1,
		-1,0,-1,0,-1,0,-1,0,
		1,-1,0,-1,0,-1,0,-1,
		-1,1,-1,1,-1,1,-1,2,
		3,-1,3,-1,3,-1,3,-1,
		-1,5,-1,5,-1,5,-1,5,
		7,-1,7,-1,7,-1,7,-1,
	}
};

int Evaluate(int color)
{
	LChIterator it;
	int sum = 0;
	for (it = checkers[color].begin(); it; it++)
		sum += Price[it->GetType()];
	for (it = checkers[!color].begin(); it; it++)
		sum -= Price[it->GetType()];
	return sum;
}

int SmartEvaluate(int color)
{
	LChIterator it;
	int sum = 0;
	for (it = checkers[color].begin(); it; it++)
		sum += Price[it->GetType()] + ev_board[it->GetColor()][it->GetInvCoord()];
	for (it = checkers[!color].begin(); it; it++)
		sum -= Price[it->GetType()] + ev_board[it->GetColor()][it->GetInvCoord()];
	return sum;
}
