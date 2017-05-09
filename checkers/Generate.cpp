#include "BasicFunctions.h"
#include "FunctionsMove.h"

ListOfCheckers::iterator it;
int mustEat;
Move* saved;

void Generate(ListOfCheckers& list) {
	mustEat = 0; saved = cache.GetpLast();

	for (it = list.begin(); it && (!mustEat); it++) 
		mustEat = SearchMove[it->GetType()](*it);

	if (mustEat) {
		cache.Rollback(saved);
		for (it = list.begin(); it; it++) {
			board[it->GetCoord()] = 0;
			SearchEat[it->GetType()](*it);
			board[it->GetCoord()] = &(*it);
		}
	}
}

void GenerateCaptures(ListOfCheckers& list)
{
	for (it = list.begin(); it; it++) 
	{
		board[it->GetCoord()] = 0;
		SearchEat[it->GetType()](*it);
		board[it->GetCoord()] = &(*it);
	}
}