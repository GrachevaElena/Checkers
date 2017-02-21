#pragma once
//надо передавать шашки по порядку номеров, т.к. будут возвращены номера съеденных шашек
extern "C" __declspec(dllexport) int __stdcall CallBot(int* w_coords,int* w_types,int w_n, int* b_coords, int* b_types, int b_n,int color );
