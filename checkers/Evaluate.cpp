#include "BasicFunctions.h"

const int Prise[2] = { CheckerPrice,DamkaPrice };

int Evaluate(ListOfCheckers & player, ListOfCheckers & enemy)
{
	LChIterator it;
	int sum = 0;
	for (it = player.begin(); it; it++)
		sum += Prise[it->GetType()];
	for (it = enemy.begin(); it; it++)
		sum -= Prise[it->GetType()];
	return sum;
}
