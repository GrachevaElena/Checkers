#include "Search.h"

Cache cache(MaxCache);

static int tmp;
int Search(int color, int depth, Move* bestMove) {

	if (depth == 0)  return Evaluate(color);  //если на мах глубине

	int score = -INF;
	Move* saved = cache.GetpLast();

	Generate(checkers[color]);

	for (Move* pmove = saved; pmove < cache.GetpLast(); pmove++) {
		MakeMove(*pmove);
		tmp = -Search(!color, depth - 1, 0);
		UnMakeMove(*pmove);
		if (score < tmp) {
			score = tmp;
			if (bestMove) *bestMove = *pmove;
		}
	}

	cache.Rollback(saved);

	return score;
}


int SearchAlphaBeta(int color, int depth, int alpha, int beta, Move * bestMove) {

	if (depth == 0) return Evaluate(color); //если на мах глубине

	Move* saved = cache.GetpLast();

	Generate(checkers[color]);

	for (Move* pmove = saved; pmove < cache.GetpLast(); pmove++) {
		MakeMove(*pmove);
		tmp = -SearchAlphaBeta(!color, depth - 1, -beta, -alpha, 0);
		UnMakeMove(*pmove);
		
		if (tmp > alpha) {
			alpha = tmp;
			if (bestMove) *bestMove = *pmove;
		}
		if (alpha>=beta){
			cache.Rollback(saved);
			return alpha;//вернуть то, что меньше, чтобы не перезаписал
		}
	}

	cache.Rollback(saved);
	return alpha;
}