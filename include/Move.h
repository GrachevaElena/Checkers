#pragma once

//  _ _ _ _ ... _ _ _ _ (съеденные шашки) _ _ _ _ (количество съеденных шашек) _ _ _  _ _ _ (конечные координаты) _ _ _ _ (номер шашки)  _ (изменился ли тип) _ (цвет шашки, не обязательно)

#define BLACK 1
#define WHITE 0

#define DAMKA 1
#define CHECKER 0


#define OFFSET_COLOR 0
#define OFFSET_TYPE 1
#define OFFSET_NUM 2
#define OFFSET_COORD 6
#define OFFSET_NEATEN 12
#define OFFSET_EATEN 16

#define MASK_COLOR 1
#define MASK_TYPE 1
#define MASK_NUM 15
#define MASK_COORD 63
#define MASK_NEATEN 15
#define MASK_EATEN 281474976710655

#define INVMASK_COLOR ~(MASK_COLOR<<OFFSET_COLOR)
#define INVMASK_TYPE ~(MASK_TYPE<<OFFSET_TYPE)
#define INVMASK_NUM ~(MASK_NUM<<OFFSET_NUM)
#define INVMASK_COORD ~(MASK_COORD<<OFFSET_COORD)
#define INVMASK_NEATEN ~(MASK_NEATEN<<OFFSET_NEATEN)
#define INVMASK_EATEN ~(MASK_EATEN<<OFFSET_EATEN)

class Move {
	long long move;
public:
	Move() { move = 0; }
	Move(int n) { move = n; }
	operator long long() { return move; }
	friend int operator==(const Move& m1, const Move& m2);
	~Move() {}

	void Set(int _color, int _coord, int _num, int _type) { SetColor(_color); SetCoord(_coord); SetNum(_num); SetType(_type); }
	void SetVarEaten(int n1,...);

	void SetColor(int color) { move = move & INVMASK_COLOR | (color << OFFSET_COLOR); }
	void SetCoord(int coord) { move = move & INVMASK_COORD | (coord << OFFSET_COORD); }
	void SetNum(int num) { move = move & INVMASK_NUM | (num << OFFSET_NUM); }
	void SetType(int type) { move = move & INVMASK_TYPE | (type << OFFSET_TYPE); }
	void SetNEaten(int neaten) { move = move & INVMASK_NEATEN | (neaten << OFFSET_NEATEN); }
	void SetEaten(long long eaten) { move = move & INVMASK_EATEN | (eaten << OFFSET_EATEN); }
	void SetEaten(int* arrEaten) { move = move & INVMASK_EATEN; for (int i = 0; i < GetNEaten(); i++) move = move | ((long long)arrEaten[i] << (OFFSET_EATEN + 4 * i)); }

	int GetColor() { return move & MASK_COLOR; }
	int GetCoord() { return (move >> OFFSET_COORD) & MASK_COORD; }
	int GetNum() { return (move >> OFFSET_NUM) & MASK_NUM; }
	int GetType() { return (move >> OFFSET_TYPE) & MASK_TYPE; }
	int GetNEaten() { return (move >> OFFSET_NEATEN) & MASK_NEATEN; }
	long long GetEaten() { return (move >> OFFSET_EATEN) & MASK_EATEN; }
	void GetEaten(int* arrEaten) { for (int i = 0; i < 12; i++) arrEaten[i] = (move >> (OFFSET_EATEN + i * 4)) & MASK_NUM; }
};