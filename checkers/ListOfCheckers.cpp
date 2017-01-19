#include "ListOfCheckers.h"
#include <fstream>

std::ifstream fios;
std::ofstream fouts;

#define OUTS fouts;
#define INS fins;

ListOfCheckers::ListOfCheckers()
{
	for (int i = 1; i < 12; i++) {
		List[i].SetNextNum(i + 1);
		List[i].SetPrevNum(i - 1);
	}
	List[0].SetNextNum(1);
	List[0].SetPrevNum(0);
	List[12].SetNextNum(0);
	List[12].SetPrevNum(11);//why was List[12].SetPrevNum(12) ? why SetPrevNum(12) ? why 12 ? why ? хD
}

void ListOfCheckers::GenerateInitialPosition(char* filename)
{
	//временно: генерирует позицию 0 - первоначальную расстановку шашек на доске
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

