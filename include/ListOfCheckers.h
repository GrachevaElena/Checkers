#pragma once
#include "Checker.h"

/*
Пусть у нас есть список head->1->4->6->8->11->head (индекс head=0)
Delete(1);
Delete(8);
head->4->6->11->head
Insert(7);
head->4->6->7->11->head
Insert(1);
head->1->4->6->7->11->head
*/

class ListOfCheckers {
public:					//чтобы не перегружать индексацию
	Checker List[13];	//12 шашек + голова, чтобы список никогда не был пустым
						//шашки будут нумероваться от 1 до 12

	ListOfCheckers();							//связывает первоначальный список шашек упорядоченно
	~ListOfCheckers() {}

	void GenerateInitialPosicion(int color);	//генерирует первоначальную позицию для шашек опр.цвета

	void Insert(int num);						//вставляет шашку с номером в список, не нарушая упорядоченности номеров
	void Delete(int num);						//удаляет шашку с номером из списка

	int IsEmpty() { if (List[0].GetNextNum == 0) return 1; return 0; }
};