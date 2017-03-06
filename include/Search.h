#pragma once
#include "BasicFunctions.h"
#include "Board.h"
#include "Cache.h"

#define INF (12*DamkaPrice+1)

#define USUAL_SEARCH 0
#define USUAL_SEARCH_SMART 1
#define ALPHA_BETA_SEARCH 2
#define ALPHA_BETA_SEARCH_SMART 3

#define SMART_EVALUATE 1
#define USUAL_EVALUATE 0

extern Board board;
extern Cache cache;
const int MaxCache = 1000;

extern ListOfCheckers checkers[2];

const int MaxDepth = 8;

Move Search(int color, int type_search, int max_depth);