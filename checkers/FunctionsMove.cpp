#include "FunctionsMove.h"

Cache cache(100);
Board board;

int color; //в дальнейшем перенести в Generate
int coord;
int num;
int coordEaten;
int eaten[12]; int nEaten = 0;
int type_bool;

//вспомогательные функции - услови€
inline int OnBoard(int cell)
{
	return (cell >> 6 == 0);
}

inline int IsBlack(int cell)
{
	return (((cell >> 3) ^ cell) & 1);
}

inline int Inside(int cell)
{
	return (OnBoard(cell) && IsBlack(cell));
}

inline int OnLastRow(int cell) 
{
	return !(Inside(cell + forwardRight[color]) || Inside(cell + forwardLeft[color]));
}

//возвращает перпендикул€рное направление к заданному
inline int Perp(int route) //7<->9, -7<->-9, т.е. задает абсолютно проивоположное направление
{
	return (route ^ (7<<1));
}



//может ли двигатьс€ на клетку с координаами
inline int CanMove(int _coord)	
{
	return (Inside(_coord) && board.IsEmpty(_coord));
}

//может ли есть в заданном направлении
inline int CanEatChecker(int route)	
{
	return (Inside(coord + 2 * route) && !board.IsEmpty(coord+route)&&board.IsEmpty(coord+2*route)&&(board[coord+route]->GetColor()!=color));
}

int temp_i;
inline int CanEatDamka(int route) //сохран€ет координаты шашки, которую можно съесть
{
	for (temp_i = 1; CanMove(coord + temp_i*route); temp_i++);
	if (!Inside(coord + temp_i*route) || (board[coord + temp_i*route]->GetColor() == color)) return 0;
	if (CanMove(coord + (temp_i + 1)*route)) {
		coordEaten= coord + temp_i*route;
		return 1;
	}
	return 0;
}



//запись хода
Move temp_move;
inline Move GetMove(int finalCoord) { //только дл€ простой шашки
	temp_move.SetColor(color);
	temp_move.SetNum(num);
	temp_move.SetCoord(finalCoord);
	temp_move.SetNEaten(nEaten);
	temp_move.SetEaten(eaten);
	temp_move.SetType(type_bool);
	return temp_move;
}



//делают ход: двигают шашки, мен€ют им цвет и т.д.
inline void MakeMoveChecker(int route) {
	eaten[nEaten++] = board[coord + route]->GetNum();
	board[coord + route]->ChangeColor();
	coord += 2 * route;
	if (OnLastRow(coord)) type_bool = 1;
}
inline void UnMakeMoveChecker(int route) {
	coord -= 2 * route;
	board[coord + route]->ChangeColor();
	nEaten--;
	type_bool = 0;
}
inline void MakeMoveDamka(int& savedCoord, int& savedCoordEaten) {
	savedCoord = coord; savedCoordEaten = coordEaten;
	eaten[nEaten++] = board[coordEaten]->GetNum();
	coord = coordEaten;
	board[coordEaten]->ChangeColor();
}
inline void UnMakeMoveDamka(int savedCoord, int savedCoordEaten) {
	board[savedCoordEaten]->ChangeColor();
	coord = savedCoord;
	nEaten--;
}



//осущесвл€ю рекурсию, смотр€т в 3 направлени€х
void SearchEatDamkaInRay(int);
void SearchEatCheckerInRay(int route)
{
	int f = 0;

	MakeMoveChecker(route);//встала за съеденной шашкой

	if (type_bool) {
		if (CanEatDamka(Perp(route))) {f++; SearchEatDamkaInRay(Perp(route));}
	} //продолжает поиск в оставшемс€ направлении на правах дамки
	else {
		if (CanEatChecker(route)) { f++; SearchEatCheckerInRay(route); }
		if (CanEatChecker(Perp(route))) { f++; SearchEatCheckerInRay(Perp(route)); }
		if (CanEatChecker(-Perp(route))) { f++; SearchEatCheckerInRay(-Perp(route)); }
	}

	//сохранение ходa, если нельз€ больше есть
	if (f == 0) cache.Push(GetMove(coord));

	UnMakeMoveChecker(route);
}

void SearchEatDamkaInRay(int route)
{
	int f = 0, savedCoord, savedCoordEaten;

	MakeMoveDamka(savedCoord, savedCoordEaten);//встала на съеденную шашку

	//идем вперед и смотрим влево-вправо
	do {
		coord += route;
		if (CanEatDamka(Perp(route))) { f++; SearchEatDamkaInRay(Perp(route)); }
		if (CanEatDamka(-Perp(route))) { f++; SearchEatDamkaInRay(-Perp(route)); }
	} while (CanMove(coord + route));
	//если впереди преп€тсвие, смотрим, нельз€ ли есть
	if (CanEatDamka(route)) { f++; SearchEatDamkaInRay(route); }

	//сохранение всех ходов, если некуда больше есть
	if (f == 0) do {
		cache.Push(GetMove(coord));
		coord -= route;
	} while (CanMove(coord));

	UnMakeMoveDamka(savedCoord, savedCoordEaten);
}



//смотр€т в 4 направлени€х, вызывают функции, осущ. рекурсию
int SearchEatChecker(Checker* ch) 
{
	color = ch->GetColor(); //в дальнейшем перенеси в Generate
	coord = ch->GetCoord(); //см тоже глобально
	num = ch->GetNum();//в дальнейшем перенеси в Generate

	for(int j=0; j<4; j++) if (CanEatChecker(direct[j])) SearchEatCheckerInRay(direct[j]);

	return 0;
}

int SearchEatDamka(Checker* ch)
{
	color = ch->GetColor(); //в дальнейшем перенеси в Generate
	coord = ch->GetCoord(); //см тоже глобально
	num = ch->GetNum();//в дальнейшем перенеси в Generate

	for (int j = 0; j<4; j++) if (CanEatDamka(direct[j])) SearchEatDamkaInRay(direct[j]);

	return 0;
}


//возвращают 1, если можно есть
int SearchMoveChecker(Checker *ch)
{
	int j;
	color = ch->GetColor(); //в дальнейшем перенеси в Generate
	coord = ch->GetCoord(); //см тоже глобально
	num = ch->GetNum();//в дальнейшем перенеси в Generate

	for (j = 0; j<4; j++)
		if (CanEatChecker(direct[j])) return 1;

	for (j = 0; j<2; j++)
		if (CanMove(coord + forward[color][j])) {
			if (OnLastRow(coord + forward[color][j])) type_bool = 1;
			cache.Push(GetMove(coord + forward[color][j]));
			type_bool = 0;
		}

	return 0;
}

int SearchMoveDamka(Checker *ch)
{
	int i, j;
	color = ch->GetColor(); //в дальнейшем перенеси в Generate
	coord = ch->GetCoord(); //см тоже глобально
	num = ch->GetNum();//в дальнейшем перенеси в Generate

	for (int j = 0; j<4; j++)
		if (CanEatDamka(direct[j])) return 1;

	for (int j = 0; j<4; j++)
		for (i = 1; CanMove(coord + i*direct[j]); i++) cache.Push(GetMove(coord + i*direct[j]));

	return 0;
}