#pragma once
#include "Search.h"
//���� ���������� ����� �� ������� �������, �.�. ����� ���������� ������ ��������� �����
extern "C" __declspec(dllexport) int __stdcall CallBot(
	int* w_coords,int* w_types,int w_n,
	int* b_coords, int* b_types, int b_n,
	int color, int max_depth,
	int type_search, int type_evaluate
);
