#include "FunctionsMove.h"


int color; //в дальнейшем перенеси в Generate
int coord;
int i;
int coordEaten;

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

//возвращает перпендикул€рное направление к заданному
inline int Perp(int route) 
{
	return (route ^ 240);
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

inline int CanEatDamka(int route) //сохран€ет координаты шашки, которую можно съесть
{
	for (i = 0; CanMove(coord + i*route); i++);
	if (!Inside(coord + i*route) || (board[coord + i*route]->GetColor == color)) return 0;
	if (CanMove(coord + (i + 1)*route)) {
		coordEaten = coord + i*route;
		return 1;
	}
	return 0;
}

//запись хода
Move temp_move;
inline Move GetMove(Checker *ch, int finalCoord) { //только дл€ простой шашки
	//temp_move.SetColor(color);
	temp_move.SetNum(ch->GetNum());
	temp_move.SetCoord(finalCoord);
	return temp_move;
}


int SearchMoveChecker(Checker *ch)
{
	color = ch->GetColor(); //в дальнейшем перенеси в Generate
	coord = ch->GetCoord(); //см тоже глобально
	if (CanEatChecker(backRight[color])) return 1;
	if (CanEatChecker(backLeft[color])) return 1;
	if (CanEatChecker(forwardLeft[color])) return 1;
	if (CanEatChecker(forwardRight[color])) return 1;

	if (CanMove(forwardRight[color])) cache.Push(GetMove(ch, coord + forwardRight[color]));
	if (CanMove(forwardLeft[color])) cache.Push(GetMove(ch, coord + forwardLeft[color]));

	return 0;
}

int SearchMoveDamka(Checker *ch)
{
	color = ch->GetColor(); //в дальнейшем перенеси в Generate
	coord = ch->GetCoord(); //см тоже глобально
	if (CanEatDamka(backRight[color])) return 1;
	if (CanEatDamka(backLeft[color])) return 1;
	if (CanEatDamka(forwardLeft[color])) return 1;
	if (CanEatDamka(forwardRight[color])) return 1;

	for (i = 0; CanMove(coord + i*backRight[color]); i++) cache.Push(GetMove(ch, coord + i*backRight[color]));
	for (i = 0; CanMove(coord + i*backLeft[color]); i++) cache.Push(GetMove(ch, coord + i*backLeft[color]));
	for (i = 0; CanMove(coord + i*forwardLeft[color]); i++) cache.Push(GetMove(ch, coord + i*forwardLeft[color]));
	for (i = 0; CanMove(coord + i*forwardRight[color]); i++) cache.Push(GetMove(ch, coord + i*forwardRight[color]));
}

inline void MakeMoveChecker(int route) {
	board[coord + route]->ChangeColor();
	coord +=2 * route;
}
inline void UnMakeMoveChecker(int route){
	coord -= 2 * route;
	board[coord + route]->ChangeColor();
}
int SearchEatCheckerInRay(int route)
{
	MakeMoveChecker(route);
	if (CanEatChecker(route)) SearchEatCheckerInRay(route);
	if (CanEatChecker(Perp(route))) SearchEatCheckerInRay(Perp(route));
	if (CanEatChecker(-Perp(route))) SearchEatCheckerInRay(-Perp(route));
	UnMakeMoveChecker(route);
}

int savedCoordEaten;
inline void MakeMoveDamka(int route) {
	board[coordEaten]->ChangeColor();
	savedCoordEaten = coordEaten;
	coord += coordEaten + route;
}
inline void UnMakeMoveDamka(int route) {
	coord -= savedCoordEaten+route;
	board[savedCoordEaten]->ChangeColor();
}
int SearchEatDamkaInRay(int route) 
{
	MakeMoveDamka(route);
	if (CanEatDamka(route)) SearchEatDamkaInRay(route);
	if (CanEatDamka(Perp(route))) SearchEatDamkaInRay(Perp(route));
	if (CanEatDamka(-Perp(route))) SearchEatDamkaInRay(-Perp(route));
	UnMakeMoveDamka(route);
}

int SearchEatChecker(Checker* ch) 
{
	coord = ch->GetCoord();
	if (CanEatChecker(backRight[color])) SearchEatCheckerInRay(backRight[color]);
	if (CanEatChecker(backLeft[color])) SearchEatCheckerInRay(backLeft[color]);
	if (CanEatChecker(forwardLeft[color])) SearchEatCheckerInRay(forwardLeft[color]);
	if (CanEatChecker(forwardRight[color])) SearchEatCheckerInRay(forwardRight[color]);
	return 0;
}

int SearchEatDamka(Checker* ch)
{
	coord = ch->GetCoord();
	if (CanEatDamka(backRight[color])) SearchEatDamkaInRay(backRight[color]);
	if (CanEatDamka(backLeft[color])) SearchEatDamkaInRay(backLeft[color]);
	if (CanEatDamka(forwardLeft[color])) SearchEatDamkaInRay(forwardLeft[color]);
	if (CanEatDamka(forwardRight[color])) SearchEatDamkaInRay(forwardRight[color]);
	return 0;
}