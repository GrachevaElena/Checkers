#pragma once

// ... _ _ _ _ (��������� �� ����������) _ _ _ _ (��������� �� ���������) _ _ _  _ _ _ (����������) _ (��� ������) _ (����)

#define WHITE 0
#define BLACK 1

#define CHECKER 0
#define DAMKA 1

class Checker
{
	int Check;
public:
	Checker() {}
	~Checker() {}

	void SetColor(int color) { Check = Check & (~1) | color; }
	void SetType(int type) { Check = Check & (~2) | (type << 1); }
	void SetCoord(int coord) { Check = Check & (~252) | (coord << 2); }

	int GetColor() { return  Check & 1; }
	int GetType() { return  (Check & 2) >> 1; }
	int GetCoord() { return  (Check & 252) >> 2; }

	void ChangeColor() { Check = Check ^ 1; }
	void ChangeType() { Check = Check ^ 2; }

	void SetNextNum(int num) { Check = Check & (~3840) | (num << 8); }
	void SetPrevNum(int num) { Check = Check & (~61440) | (num << 12); }

	int GetNextNum() { return  (Check & 3840) >> 8; }
	int GetPrevNum() { return  (Check & 61440) >> 12; }
};
