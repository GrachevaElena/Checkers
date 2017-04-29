#include "BasicFunctions.h"

extern ListOfCheckers checkers[2];
const int Price[2] = { CheckerPrice,DamkaPrice };

const int ev_board[2][2][64] = 
{
	{
		//for white checker
		{
			-1, 42, -1, 17, -1,  0, -1,-10,
			 0, -1, 32, -1, 13, -1,  0, -1,
			-1, 43, -1, 25, -1,  7, -1, 20,
			 0, -1, 32, -1, 13, -1,  0, -1,
			-1, 43, -1, 23, -1,  7, -1, 20,
			 0, -1, 32, -1, 21, -1,  0, -1,
			-1, 43, -1, 23, -1,  8, -1, 20,
			 0, -1, 31, -1, 17, -1,-10, -1,
		},
		//for white damka
		{
			-1,  7, -1,  6, -1,  6, -1,  9,
			 7, -1,  7, -1,  6, -1,  9, -1,
			-1,  7, -1,  7, -1,  9, -1,  7,
			 7, -1,  7, -1,  9, -1,  6, -1,
			-1,  6, -1,  9, -1,  7, -1,  7,
			 7, -1,  9, -1,  7, -1,  7, -1,
			-1,  9, -1,  6, -1,  7, -1,  7,
			 9, -1,  6, -1,  6, -1,  7, -1,
		}
	},
	{
		//for black checker
		{
			 -1,-10, -1,  17, -1, 31, -1,  0,
			 20, -1,  8,  -1, 23, -1, 43, -1,
			 -1,  0, -1,  21, -1, 32, -1,  0,
			 20, -1,  7,  -1, 23, -1, 43, -1,
			 -1,  0, -1,  13, -1, 32, -1,  0,
			 20, -1,  7,  -1, 25, -1, 43, -1,
			 -1,  0, -1,  13, -1, 32, -1,  0,
			-10, -1,  0,  -1, 17, -1, 42, -1,
		},
		//for black damka
		{
			-1,  7, -1,  6, -1,  6, -1,  9,
			 7, -1,  7, -1,  6, -1,  9, -1,
			-1,  7, -1,  7, -1,  9, -1,  7,
			 7, -1,  7, -1,  9, -1,  6, -1,
			-1,  6, -1,  9, -1,  7, -1,  7,
			 7, -1,  9, -1,  7, -1,  7, -1,
			-1,  9, -1,  6, -1,  7, -1,  7,
			 9, -1,  6, -1,  6, -1,  7, -1,
		}
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
		sum += Price[it->GetType()] + ev_board[it->GetColor()][it->GetType()][it->GetCoord()];
	for (it = checkers[!color].begin(); it; it++)
		sum -= Price[it->GetType()] + ev_board[it->GetColor()][it->GetType()][it->GetCoord()];
	return sum;
}
