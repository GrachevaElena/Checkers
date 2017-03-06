#include "BasicFunctions.h"

extern ListOfCheckers checkers[2];
const int Price[2] = { CheckerPrice,DamkaPrice };

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
	return 0;
}
