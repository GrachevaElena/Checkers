#pragma once
#include "ListOfCheckers.h"
#include "Move.h"

#define NULL 0

const int CheckerPrice = 1;
const int DamkaPrice = 7;

void Generate(ListOfCheckers&);

int Evaluate(ListOfCheckers& , ListOfCheckers& );

void MakeMove(Move&);
void UnMakeMove(Move&);