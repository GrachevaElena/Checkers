#pragma once
#include "BasicFunctions.h"
#include "Board.h"
#include "Cache.h"

#define INFINITY (12*DamkaPrice+1)

extern Board board;
extern Cache cache;

extern ListOfCheckers checkers[2];

const int MaxDepth = 4;

int Search(int color, int depth, Move* bestMove);