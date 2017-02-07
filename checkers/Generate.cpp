#include "BasicFunctions.h"
#include "FunctionsMove.h"

ListOfCheckers::iterator it;
int mustEat;
Move* saved;
void Generate(ListOfCheckers& list) {
	mustEat = 0; saved = cache.GetpLast();
	it = list.begin();
	color = it->GetColor();

	for (; it && (!mustEat); it++) {
		coord = it->GetCoord(); num = it->GetNum();
		mustEat = SearchMove[it->GetType()]();
	}

	if (mustEat) {
		cache.Rollback(saved);
		for (it = list.begin(); it; it++) {
			coord = it->GetCoord(); num = it->GetNum();
			SearchEat[it->GetType()]();
		}
	}
}