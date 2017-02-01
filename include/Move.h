#pragma once

//  _ _ _ _ ... _ _ _ _ (съеденные шашки) _ _ _ _ (количество съеденных шашек) _ _ _  _ _ _ (конечные координаты) _ _ _ _ (номер шашки)  _ (тип: шашка или дамка) _ (цвет шашки, не обязательно)

#define BLACK 1
#define WHITE 0

#define DAMKA 1
#define CHECKER 0


//не смотри на эти макросы
#define COLOROFFSET 0
#define TYPEOFFSET 1
#define NUMCHECKEROFFSET 2
#define COORDOFFSET 6
#define NEATENOFFSET 12
#define EATENOFFSET 16

#define MAXCOLOR 1
#define MAXTYPE 1
#define MAXNUMCHECKER 15
#define MAXCOORD 63
#define MAXNEATEN 15
#define MAXEATEN 281474976710655

#define COLORPOS ~(MAXCOLOR<<COLOROFFSET)
#define TYPEPOS ~(MAXTYPE<<TYPEOFFSET)
#define NUMCHECKERPOS ~(MAXNUMCHECKER<<NUMCHECKEROFFSET)
#define COORDPOS ~(MAXCOORD<<COORDOFFSET)
#define NEATENPOS ~(MAXNEATEN<<NEATENOFFSET)
#define EATENPOS ~(MAXEATEN<<EATENOFFSET)

class Move {
	long long move;
public:
	Move() { move = 0; }
	Move(int n) { move = n; }
	operator long long() { return move; }
	friend int operator==(const Move& m1, const Move& m2) { return m1.move == m2.move; }
	~Move() {}

	void SetColor(int color) { move = move & COLORPOS | (color << COLOROFFSET); }
	void SetCoord(int coord) { move = move & COORDPOS | (coord << COORDOFFSET); }
	void SetNumChecker(int numchecker) { move = move & NUMCHECKERPOS | (numchecker << NUMCHECKEROFFSET); }
	void SetType(int type) { move = move & TYPEPOS | (type << TYPEOFFSET); }
	void SetNEaten(long long neaten) { move = move & NEATENPOS | (neaten << NEATENOFFSET); }
	void SetEaten(long long eaten) { move = move & EATENPOS | (eaten << EATENOFFSET); }
	void SetEaten(int* arrEaten) { move = move&EATENPOS; for (int i = 0; i < GetNEaten(); i++) move = move | ((long long)arrEaten[i] << (EATENOFFSET + 4 * i)); }

	int GetColor() { return move & MAXCOLOR; }
	int GetCoord() { return (move >> COORDOFFSET) & MAXCOORD; }
	int GetNumChecker() { return (move >> NUMCHECKEROFFSET) & MAXNUMCHECKER; }
	int GetType() { return (move >> TYPEOFFSET) & MAXTYPE; }
	long long GetNEaten() { return (move >> NEATENOFFSET) & MAXNEATEN; }
	long long GetEaten() { return (move >> EATENOFFSET) & MAXEATEN; }
	void GetEaten(int* arrEaten) { for (int i = 0; i < 12; i++) arrEaten[i] = (move >> (EATENOFFSET + i * 4)) & MAXNUMCHECKER; }

	
};