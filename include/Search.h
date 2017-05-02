#pragma once
#include "BasicFunctions.h"
#include "Board.h"
#include "Cache.h"

#define INF (12*DamkaPrice+1)

enum ESearch {
	EUsualSearch,
	EAlphaBetaSearch,
	EForcedSearch
};
enum EEvaluate {
	ESimpleEvaluate,
	ESmartEvaluate
};

extern Board board;
extern Cache cache;
const int MaxCache = 10000;

extern ListOfCheckers checkers[2];

const int MaxDepth = 4;

Move Search(int color,int max_depth,ESearch type_search,EEvaluate type_evaluate);
