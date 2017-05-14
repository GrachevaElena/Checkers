#include "FunctionsMove.h"

static int color;
static int coord;
static int num;

//��� ������� � ���������� ���������� (� ������)
void SetColor(int _c) {
	::color = _c;
}
void SetCoord(int _c) {
	::coord = _c;
}
void SetNum(int _n) {
	::num = _n;
}

static int coordEaten;
static int eaten[12]; static int nEaten = 0;
static int type_bool;

//��������������� ������� - �������
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
	return !(Inside(cell + forwardRight[::color]) || Inside(cell + forwardLeft[::color]));
}

//���������� ���������������� ����������� � ���������
inline int Perp(int route) //7<->9, -7<->-9, �.�. ������ ��������� �������������� �����������
{
	return (route ^ (7<<1));
}



//����� �� ��������� �� ������ � �����������
inline int CanMove(int _coord)	
{
	return (Inside(_coord) && board.IsEmpty(_coord));
}

//����� �� ���� � �������� �����������
inline int CanEatChecker(int route)	
{
	return (Inside(::coord + 2 * route) && !board.IsEmpty(::coord+route)&&board.IsEmpty(::coord+2*route)&&(board[::coord+route]->GetColor()!=::color));
}

int temp_i;
inline int CanEatDamka(int route) //��������� ���������� �����, ������� ����� ������
{
	for (temp_i = 1; CanMove(::coord + temp_i*route); temp_i++);
	if (!Inside(::coord + temp_i*route) || (board[::coord + temp_i*route]->GetColor() == ::color)) return 0;
	if (CanMove(::coord + (temp_i + 1)*route)) {
		::coordEaten= ::coord + temp_i*route;
		return 1;
	}
	return 0;
}



//������ ����
static Move temp_move;
inline Move GetMove(int finalCoord) { //������ ��� ������� �����
	temp_move.SetColor(::color);
	temp_move.SetNum(::num);
	temp_move.SetFinalCoord(finalCoord);
	temp_move.SetNEaten(::nEaten);
	temp_move.SetEaten(::eaten);
	temp_move.SetType(::type_bool);
	return temp_move;
}



//������ ���: ������� �����, ������ �� ���� � �.�.
inline void MakeMoveChecker(int route) {
	::eaten[::nEaten++] = board[::coord + route]->GetNum();
	board[::coord + route]->ChangeColor();
	::coord += 2 * route;
	if (OnLastRow(::coord)) ::type_bool = 1;
}
inline void UnMakeMoveChecker(int route) {
	::coord -= 2 * route;
	board[::coord + route]->ChangeColor();
	::nEaten--;
	::type_bool = 0;
}
inline void MakeMoveDamka(int& savedCoord, int& savedCoordEaten) {
	savedCoord = ::coord; savedCoordEaten = ::coordEaten;
	::eaten[::nEaten++] = board[::coordEaten]->GetNum();
	::coord = ::coordEaten;
	board[::coordEaten]->ChangeColor();
}
inline void UnMakeMoveDamka(int savedCoord, int savedCoordEaten) {
	board[savedCoordEaten]->ChangeColor();
	::coord = savedCoord;
	::nEaten--;
}



//������������ ��������, ������� � 3 ������������
void SearchEatDamkaInRay(int);
void SearchEatCheckerInRay(int route)
{
	int f = 0;

	MakeMoveChecker(route);//������ �� ��������� ������

	if (::type_bool) {
		if (CanEatDamka(Perp(route))) {f++; SearchEatDamkaInRay(Perp(route));}
	} //���������� ����� � ���������� ����������� �� ������ �����
	else {
		if (CanEatChecker(route)) { f++; SearchEatCheckerInRay(route); }
		if (CanEatChecker(Perp(route))) { f++; SearchEatCheckerInRay(Perp(route)); }
		if (CanEatChecker(-Perp(route))) { f++; SearchEatCheckerInRay(-Perp(route)); }
	}

	//���������� ���a, ���� ������ ������ ����
	if (f == 0) cache.Push(GetMove(::coord));

	UnMakeMoveChecker(route);
}

void SearchEatDamkaInRay(int route)
{
	int f = 0, savedCoord, savedCoordEaten;

	MakeMoveDamka(savedCoord, savedCoordEaten);//������ �� ��������� �����

	//���� ������ � ������� �����-������
	do {
		::coord += route;
		if (CanEatDamka(Perp(route))) { f++; SearchEatDamkaInRay(Perp(route)); }
		if (CanEatDamka(-Perp(route))) { f++; SearchEatDamkaInRay(-Perp(route)); }
	} while (CanMove(::coord + route));
	//���� ������� ����������, �������, ������ �� ����
	if (CanEatDamka(route)) { f++; SearchEatDamkaInRay(route); }

	//���������� ���� �����, ���� ������ ������ ����
	if (f == 0) do {
		cache.Push(GetMove(::coord));
		::coord -= route;
	} while (CanMove(::coord));

	UnMakeMoveDamka(savedCoord, savedCoordEaten);
}



//������� � 4 ������������, �������� �������, ����. ��������
int SearchEatChecker(Checker& ch)
{
	::color = ch.GetColor(); ::coord = ch.GetCoord(); ::num = ch.GetNum(); temp_move.SetStartCoord(::coord);

	for(int j=0; j<4; j++) if (CanEatChecker(direct[j])) SearchEatCheckerInRay(direct[j]);

	return 0;
}

int SearchEatDamka(Checker& ch)
{
	::color = ch.GetColor(); ::coord = ch.GetCoord(); ::num = ch.GetNum(); temp_move.SetStartCoord(::coord);

	for (int j = 0; j<4; j++) if (CanEatDamka(direct[j])) SearchEatDamkaInRay(direct[j]);

	return 0;
}


//���������� 1, ���� ����� ����
int SearchMoveChecker(Checker& ch)
{
	::color = ch.GetColor(); ::coord = ch.GetCoord(); ::num = ch.GetNum(); temp_move.SetStartCoord(::coord);

	int j;

	for (j = 0; j<4; j++)
		if (CanEatChecker(direct[j])) return 1;

	for (j = 0; j<2; j++)
		if (CanMove(::coord + forward[::color][j])) {
			if (OnLastRow(::coord + forward[::color][j])) ::type_bool = 1;
			cache.Push(GetMove(::coord + forward[::color][j]));
			::type_bool = 0;
		}

	return 0;
}

int SearchMoveDamka(Checker& ch)
{
	::color = ch.GetColor(); ::coord = ch.GetCoord(); ::num = ch.GetNum(); temp_move.SetStartCoord(::coord);

	int i, j;

	for (j = 0; j<4; j++)
		if (CanEatDamka(direct[j])) return 1;

	for (j = 0; j<4; j++)
		for (i = 1; CanMove(::coord + i*direct[j]); i++) cache.Push(GetMove(::coord + i*direct[j]));

	return 0;
}