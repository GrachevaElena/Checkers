#include "Search.h"
#include "stdio.h"

extern Cache cache;
extern Board board;

extern ListOfCheckers checkers[2];


static int tmp;
int TestSearch(int color, int depth, int& nVertices, int out = 0, Move* firstMoves = 0, int nFirstMoves = 0, Move* bestMove = 0) {

	if (depth == 0) {

		if (out) printf_s("  Evaluate=%d\n", Evaluate(color));

		return Evaluate(color);  //если на мах глубине
	}

	int score = -INF;
	Move* saved = cache.GetpLast();

	if (firstMoves) {
		for (int i = 0; i < nFirstMoves; i++)
			cache.Push(firstMoves[i]);
	}
	else Generate(checkers[color]);

	for (Move* pmove = saved; pmove < cache.GetpLast(); pmove++) {

		nVertices++;
		if(out) printf_s("depth=%d, color=%d, num=%d, %d->%d\n", depth,color,pmove->GetNum(),pmove->GetStartCoord(), pmove->GetFinalCoord());
		
		MakeMove(*pmove);
		tmp = -TestSearch(!color, depth - 1, nVertices,out);
		UnMakeMove(*pmove);
		if (score < tmp) {
			score = tmp;
			if (bestMove) *bestMove = *pmove;
		}
	}

	cache.Rollback(saved);

	if (out) printf_s(" returned %d\n", score);
	return score;
}




int TestSearchAlphaBeta0(int color, int depth, int alpha, int beta, int& nVertices, int out = 0, Move* firstMoves=0, int nFirstMoves = 0, Move* bestMove=0) {

	if (depth == 0) {

		if (out) printf_s("  Evaluate=%d\n", Evaluate(color));

		return Evaluate(color);  //если на мах глубине
	}

	Move* saved = cache.GetpLast();

	if (firstMoves) {
		for (int i = 0; i < nFirstMoves; i++)
			cache.Push(firstMoves[i]);
	}
	else Generate(checkers[color]);

	for (Move* pmove = saved; pmove < cache.GetpLast(); pmove++) {

		nVertices++;
		if (out) printf_s("depth=%d, color=%d, num=%d, %d->%d\n", depth, color, pmove->GetNum(), pmove->GetStartCoord(), pmove->GetFinalCoord());

		MakeMove(*pmove);
		tmp = -TestSearchAlphaBeta0(!color, depth - 1, -beta, -alpha, nVertices,out);
		UnMakeMove(*pmove);

		if (tmp > alpha) {
			alpha = tmp;
			if (bestMove) *bestMove = *pmove;
		}
		if (alpha >= beta) {
			cache.Rollback(saved);
			if (out) printf_s(" returned %d\n", beta);
			return beta;//вернуть неизмененное alpha
		}
	}

	cache.Rollback(saved);

	if (out) printf_s(" returned %d\n", alpha);
	return alpha;
}

int TestSearchAlphaBeta1(int color, int depth, int beta, int& nVertices, int out = 0, Move* firstMoves = 0, int nFirstMoves = 0, Move* bestMove = 0) {

	if (depth == 0) {

		if (out) printf_s("  Evaluate=%d\n", Evaluate(color));

		return Evaluate(color);  //если на мах глубине
	}

	int alpha = -INF;//можно завести рекурсивно, а не передавать
	Move* saved = cache.GetpLast();

	if (firstMoves) {
		for (int i = 0; i < nFirstMoves; i++)
			cache.Push(firstMoves[i]);
	}
	else Generate(checkers[color]);

	for (Move* pmove = saved; pmove < cache.GetpLast(); pmove++) {

		nVertices++;
		if (out) printf_s("depth=%d, color=%d, num=%d, %d->%d\n", depth, color, pmove->GetNum(), pmove->GetStartCoord(), pmove->GetFinalCoord());

		MakeMove(*pmove);
		tmp = -TestSearchAlphaBeta1(!color, depth - 1, -alpha, nVertices, out);
		UnMakeMove(*pmove);

		if (tmp > alpha) {
			alpha = tmp;
			if (bestMove) *bestMove = *pmove;
		}
		if (alpha >= beta) {
			cache.Rollback(saved);
			if (out) printf_s(" returned %d\n", beta);
			return beta;//вернуть неизмененное значение
		}
	}

	cache.Rollback(saved);

	if (out) printf_s(" returned %d\n", alpha);
	return alpha;
}

int TestSearchAlphaBeta2(int color, int depth, int beta, int& nVertices, int out = 0, Move* firstMoves = 0, int nFirstMoves = 0, Move* bestMove = 0) {

	if (depth == 0) {

		if (out) printf_s("  Evaluate=%d\n", Evaluate(color));

		return Evaluate(color);  //если на мах глубине
	}

	int alpha = -INF;
	Move* saved = cache.GetpLast();

	if (firstMoves) {
		for (int i = 0; i < nFirstMoves; i++)
			cache.Push(firstMoves[i]);
	}
	else Generate(checkers[color]);

	for (Move* pmove = saved; pmove < cache.GetpLast(); pmove++) {

		nVertices++;
		if (out) printf_s("depth=%d, color=%d, num=%d, %d->%d\n", depth, color, pmove->GetNum(), pmove->GetStartCoord(), pmove->GetFinalCoord());

		MakeMove(*pmove);
		tmp = -TestSearchAlphaBeta2(!color, depth - 1, -alpha, nVertices, out);
		UnMakeMove(*pmove);

		if (tmp > alpha) {
			alpha = tmp;
			if (bestMove) *bestMove = *pmove;
		}
		if (alpha >= beta) {
			cache.Rollback(saved);
			if (out) printf_s(" returned %d\n", beta);
			return alpha;//чтобы лишней записи не было
		}
	}

	cache.Rollback(saved);

	if (out) printf_s(" returned %d\n", alpha);
	return alpha;
}