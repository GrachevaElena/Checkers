#pragma once
#include "Cache.h"
void ClearStatistics();
void PrintStatistics(int numGame, int numStep, int depth, int typeSearch, int typeEvalute, int color);
void CalculateAverSizeOfMovie(int sizeMove);
void CalculateMaxSize(int sizeCache);