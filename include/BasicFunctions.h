#pragma once
#include "ListOfCheckers.h"
#include "Move.h"

#define NULL 0

void Generate(ListOfCheckers&);
void GenerateForcing(ListOfCheckers& list);

const int CheckerPrice = 10;
const int DamkaPrice = 70;

int Evaluate(int color);
int SmartEvaluate(int color);

typedef int(*Evaluate_) (int);
const Evaluate_ evaluate[2] = { Evaluate,SmartEvaluate };

void MakeMove(Move&);
void UnMakeMove(Move&);