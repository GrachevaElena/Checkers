#include "ListOfCheckers.h"

ListOfCheckers::ListOfCheckers()
{
	for (int i = 1; i <= 12; i++) List[i].SetNum(i);
	List[0].SetNextNum(0);
	List[0].SetPrevNum(0);
}

void ListOfCheckers::Bind(int n) {
	List[0].SetNextNum(1);
	List[0].SetPrevNum(n);
	for (int i = 1; i <= n; i++) {
		List[i].SetNextNum(i + 1);
		List[i].SetPrevNum(i - 1);
	}
	List[n].SetPrevNum(n - 1);
	List[n].SetNextNum(0);
}

void ListOfCheckers::GenerateInitialPosition(int color, int * types, int * coords, int n)
{
	Bind(n);
	for (int i = 1; i <= n; i++) {
		List[i].SetColor(color);
		List[i].SetCoord(coords[i-1]);
		List[i].SetType(types[i-1]);
	}
}

void ListOfCheckers::Insert(int num)
{
	//���������, ��� � ����� ����������� ���� prev � next
	List[List[num].GetNextNum()].SetPrevNum(num);
	List[List[num].GetPrevNum()].SetNextNum(num);
}

void ListOfCheckers::Delete(int num)
{
	List[List[num].GetPrevNum()].SetNextNum(List[num].GetNextNum());
	List[List[num].GetNextNum()].SetPrevNum(List[num].GetPrevNum());
}

