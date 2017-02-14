#pragma once
#include "Cache.h"
#include "Checker.h"
#include "Board.h"
extern Cache cache;
extern Board board;

const int forwardLeft[2] = { -9, 9 }, forwardRight[2] = { 7,-7 }, backLeft[2] = { -7,7 }, backRight[2] = { 9,-9 };
//начало координат в левом верхнем углу, 0 - белые
//I really believe that it's finally correct
const int direct[4] = { 9, -7, -9, 7 }; //круг
const int forward[2][2] = { {-9,7},{9,-7} };

int SearchMoveChecker(Checker& ch);
int SearchMoveDamka(Checker& ch);
int SearchEatChecker(Checker& ch);
int SearchEatDamka(Checker& ch);

typedef int (*pSearch)(Checker& ch);
const pSearch SearchMove[2] = {SearchMoveChecker, SearchMoveDamka };
const pSearch SearchEat[2] = { SearchEatChecker, SearchEatDamka };
