#include "Search.h"
int UsualSearch(int color, int depth, Move* bestMove, int ev_num = 0);
int SearchAlphaBeta(int color, int depth, int alpha, int beta, Move * bestMove, int ev_num = 0);
int AlphaBetaForcing(int color, int depth, int alpha, int beta, Move * bestMove, int ev_num = 0);

Move Search(int color, int max_depth, ESearch type_search, EEvaluate type_evaluate) {
	Move bestMove;
	switch (type_search) {
	case EUsualSearch:
		UsualSearch(color, max_depth, &bestMove, type_evaluate);
		break;
	case EAlphaBetaSearch:
		SearchAlphaBeta(color, max_depth, -INF, INF, &bestMove, type_evaluate);
		break;
	case EForcedSearch:
		AlphaBetaForcing(color, max_depth, -INF, INF, &bestMove, type_evaluate);
		break;
	default:
		return Move();
	}
	return bestMove;
}