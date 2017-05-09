#pragma once
//_ _ _ _ (номер) ... _ _ _ _ (указатель на предыдущий) _ _ _ _ (указатель на следующий) _ _ _  _ _ _ (координаты) _ (тип фигуры) _ (цвет)

#define WHITE 0
#define BLACK 1

#define CHECKER 0
#define DAMKA 1

class Checker
{
	int Color;
	int Type;
	int Coord;
	int Num;
	int NextNum;
	int PrevNum;
public:
	Checker(): Color(0), Type(0),Coord(0),Num(0),NextNum(0),PrevNum(0) {  }
	~Checker() {}

	void SetColor(int color) { Color = color; }
	void SetType(int type) { Type=type; }
	void SetCoord(int coord) { Coord=coord; }
	void SetNum(int num) { Num = num; } //устанавливается 1 раз

	int GetColor() { return  Color; }
	int GetType() { return  Type; }
	int GetCoord() { return  Coord; }
	int GetNum() { return Num; }

	void ChangeColor() { Color = Color^1; }
	void ChangeType() { Type = Type ^ 1; }

	friend class ListOfCheckers;
	friend class LChIterator;

protected:
	void SetNextNum(int num) { NextNum=num; }
	void SetPrevNum(int num) { PrevNum = num; }

	int GetNextNum() { return  NextNum; }
	int GetPrevNum() { return  PrevNum; }

};

