#include "ListOfCheckers.h"
#include <fstream>

std::ifstream fios;
std::ofstream fouts;

#define OUTS fouts;
#define INS fins;

ListOfCheckers::ListOfCheckers()
{
	for (int i = 0; i < 12; i++)
		List[i].SetNextNum(i + 1);
	List[13].SetNextNum(0);
}

void ListOfCheckers::GenerateInitialPosition(char* filename)
{
	
}

void ListOfCheckers::Insert(int num)
{

}

void ListOfCheckers::Delete(int num)
{
}
