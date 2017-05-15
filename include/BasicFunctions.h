#pragma once
#include "ListOfCheckers.h"
#include "Move.h"

#define NULL 0

void Generate(ListOfCheckers&);
void GenerateCaptures(ListOfCheckers& list);

const int CheckerPrice = 50;
const int DamkaPrice = 350;

int Evaluate(int color);
int SmartEvaluate(int color);

typedef int(*Evaluate_) (int);
const Evaluate_ evaluate[2] = { Evaluate,SmartEvaluate };

void MakeMove(Move&);
void UnMakeMove(Move&);