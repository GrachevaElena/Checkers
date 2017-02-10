#include "BasicFunctions.h"

const int Price[2] = { CheckerPrice,DamkaPrice };

int Evaluate(ListOfCheckers & player, ListOfCheckers & enemy)
{
	LChIterator it;
	int sum = 0;
	for (it = player.begin(); it; it++)
		sum += Price[it->GetType()];
	for (it = enemy.begin(); it; it++)
		sum -= Price[it->GetType()];
	return sum;
}
