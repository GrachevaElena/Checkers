#pragma once
#include "Cache.h"
#include "Checker.h"
#include "Board.h"
extern Cache cache;
extern Board board;

const int forwardLeft[2] = { -9, 7 }, forwardRight[2] = { 7,-9 }, backLeft[2] = { -7,9 }, backRight[2] = { 9,-7 };
//начало координат в левом верхнем углу, 0 - белые

int SearchMoveChecker(Checker *ch);
int SearchMoveDamka(Checker *ch);
int SearchEatChecker(Checker *ch);
int SearchEatDamka(Checker *ch);

typedef int (*pSearch)(Checker *ch);
const pSearch SearchMove[2] = {SearchMoveChecker, SearchMoveDamka };
const pSearch SearchEat[2] = { SearchEatChecker, SearchEatDamka };

