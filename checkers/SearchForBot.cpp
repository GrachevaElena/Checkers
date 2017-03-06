#include "Search.h"
int UsualSearch(int color, int depth, Move* bestMove, int ev_num = 0);
int SearchAlphaBeta(int color, int depth, int alpha, int beta, Move * bestMove, int ev_num = 0);

Move Search(int color, int type_search, int max_depth) {
	Move bestMove;
	switch (type_search) {
	case USUAL_SEARCH:
		UsualSearch(color, max_depth, &bestMove, USUAL_EVALUATE);
		break;
	case USUAL_SEARCH_SMART:
		UsualSearch(color, max_depth, &bestMove, SMART_EVALUATE);
		break;
	case ALPHA_BETA_SEARCH:
		SearchAlphaBeta(color, max_depth, -INF, INF, &bestMove,USUAL_EVALUATE);
		break;
	case ALPHA_BETA_SEARCH_SMART:
		SearchAlphaBeta(color, max_depth, -INF, INF, &bestMove,SMART_EVALUATE);
		break;
	default:
		return Move();
	}
	return bestMove;
}