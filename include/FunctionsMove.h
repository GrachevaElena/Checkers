#pragma once
#include "Cache.h"
#include "Checker.h"
extern Cache cache(100);
extern  Checker *board[64];
int forwardLeft[2] = {7,-9}, forwardRight[2] = {9,-7}, backLeft[2] = {-9,7}, backRight[2] = {-7,9};

int SearchMoveChecker(Checker *ch);
int SearchMoveDamka(Checker *ch);
int SearchEatChecker(Checker *ch);
int SearchEatDamka(Checker *ch);

typedef int (*pSearch)(Checker *ch);
pSearch SearchMove[2] = {&SearchMoveChecker, &SearchMoveDamka };
pSearch SearchEat[2] = { &SearchEatChecker, &SearchEatDamka };
