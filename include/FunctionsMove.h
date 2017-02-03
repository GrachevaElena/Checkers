#pragma once
#include "Cache.h"
#include "Checker.h"
#include "Board.h"
extern Cache cache(100);
extern Board board;

int forwardLeft[2] = {7,-9}, forwardRight[2] = {9,-7}, backLeft[2] = {-9,7}, backRight[2] = {-7,9};

int SearchMoveChecker(Checker *ch);
int SearchMoveDamka(Checker *ch);
int SearchEatChecker(Checker *ch);
int SearchEatDamka(Checker *ch);

typedef int (*pSearch)(Checker *ch);
pSearch SearchMove[2] = {&SearchMoveChecker, &SearchMoveDamka };
pSearch SearchEat[2] = { &SearchEatChecker, &SearchEatDamka };

inline int OnBoard(int cell);
inline int IsBlack(int cell);
inline int Inside(int cell);
inline int Perp(int route);

inline int CanMove(int delta);
inline int CanEatChecker(int route);
inline int CanEatDamka(int route);