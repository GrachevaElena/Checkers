#pragma once

// _ _ | 62 _ _ _ _ ... _ _ _ _ (съеденные шашки (10)) 22_ _ _ _ (количество съеденных шашек) 18_ _ _  _ _ _ (конечные координаты) 12_ _ _  _ _ _ (начальные координаты) 6_ _ _ _ (номер шашки)  2_ (изменился ли тип) 1_ (цвет шашки, не обязательно)

#define BLACK 1
#define WHITE 0

#define DAMKA 1
#define CHECKER 0

const int MaxNEaten = 12;

class Move {
	int Color;
	int StartCoord;
	int FinalCoord;
	int Num;
	int Type;
	int NEaten;
	int Eaten[MaxNEaten] = { 0 };
public:
	Move() :Color(0), Type(0), StartCoord(0), FinalCoord(0), Num(0), NEaten(0) {}
	friend int operator==(const Move& m1, const Move& m2);
	friend int operator!=(const Move& m1, const Move& m2);
	~Move() {}

	void Set(int _color, int _s_coord, int _f_coord, int _num, int _type) { SetColor(_color); SetStartCoord(_s_coord); SetFinalCoord(_f_coord); SetNum(_num); SetType(_type); }
	void SetVarEaten(unsigned long long n1, ...);

	void SetColor(int color) { Color = color; }
	void SetStartCoord(int coord) { StartCoord = coord; }
	void SetFinalCoord(int coord) { FinalCoord = coord;; }
	void SetNum(int num) { Num = num; }
	void SetType(int type) { Type = type; }
	void SetNEaten(int neaten) { NEaten = neaten; }
	void SetEaten(int* arrEaten) {
		for (int i = 0; i < GetNEaten(); i++)
			Eaten[i] = arrEaten[i];
	}

	int GetColor() { return Color; }
	int GetStartCoord() { return StartCoord; }
	int GetFinalCoord() { return FinalCoord; }
	int GetNum() { return Num; }
	int GetType() { return Type; }
	int GetNEaten() { return NEaten; }
	void GetEaten(int* arrEaten)
	{
		for (int i = 0; i < MaxNEaten; i++)
			arrEaten[i] = Eaten[i];
	}
};

