#include "ListOfCheckers.h"

ListOfCheckers::ListOfCheckers()
{
	for (int i = 1; i <= 12; i++) List[i].SetNum(i);

	for (int i = 1; i < 12; i++) {
		List[i].SetNextNum(i + 1);
		List[i].SetPrevNum(i - 1);
	}
	List[0].SetNextNum(1);
	List[0].SetPrevNum(0);
	List[12].SetNextNum(0);
	List[12].SetPrevNum(11);//why was List[12].SetPrevNum(12) ? why SetPrevNum(12) ? why 12 ? why ? хD
	//just becouse I'm from VMK
}

void ListOfCheckers::GenerateInitialPosition(int color, int * types, int * coords, int n)
{
	List[0].SetNextNum(1);
	for (int i = 1; i <= n; i++) {
		List[i].SetColor(color);
		List[i].SetCoord(coords[i-1]);
		List[i].SetType(types[i-1]);
		List[i].SetNextNum(i + 1);
	}
	List[n].SetNextNum(0);
}

void ListOfCheckers::Insert(int num)
{
	//считается, что у шашки установлены поля prev и next
	List[List[num].GetNextNum()].SetPrevNum(num);
	List[List[num].GetPrevNum()].SetNextNum(num);
}

void ListOfCheckers::Delete(int num)
{
	List[List[num].GetPrevNum()].SetNextNum(List[num].GetNextNum());
	List[List[num].GetNextNum()].SetPrevNum(List[num].GetPrevNum());
}

