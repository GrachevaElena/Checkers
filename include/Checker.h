#pragma once

// ... _ _ _ _ (указатель на предыдущий) _ _ _ _ (указатель на следующий) _ _ _  _ _ _ (координаты) _ (тип фигуры) _ (цвет)

#define WHITE 0
#define BLACK 1

#define CHECKER 0
#define DAMKA 1

class Checker
{
	int Check;
public:
	Checker() {};
	~Checker() {}

	int GetColor() { return  Check & 1; }
	int GetType() { return  Check & 2; }
	int GetCoord() { return  Check & 252; }

	void SetColor(int color) { Check = Check & (~1) | color; }
	void SetType(int type) { Check = Check & (~2) | (type << 1); }
	void SetCoord(int coord) { Check = Check & (~252) | (coord << 2); }

	void ChangeColor() { Check = Check ^ 1; }
	void ChangeType() { Check = Check ^ 2; }

protected:
	int GetNextNum() { return  Check & 3840; }
	int GetPrevNum() { return  Check & 61440; }

	void SetNextNum(int num) { Check = Check & (~3840) | (num << 10); }
	void SetPrevNum(int num) { Check = Check & (~61440) | (num << 14); }
};

