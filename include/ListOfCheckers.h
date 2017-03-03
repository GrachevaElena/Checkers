#pragma once
#include "Checker.h"

class LChIterator {
	Checker* begin; //указатель на голову списка 
					//от этой бяки можно избавиться, только если хранить не номер следующей шашки, а расстояние до следующей шашки
	Checker* p; //шашка, на которую указывает итератор
public:
	LChIterator() {}
	LChIterator(Checker* p_, Checker* begin_) :p(p_), begin(begin_) {};

	LChIterator& operator++() { p = begin + p->GetNextNum(); return *this; }
	LChIterator& operator--() { p = begin + p->GetPrevNum(); return *this; }
	LChIterator& operator++(int) { p = begin + p->GetNextNum(); return *this; }
	LChIterator& operator--(int) { p = begin + p->GetPrevNum(); return *this; }

	operator Checker* () { return p; }
	Checker* operator->() { return p; }
	operator int() { return p - begin; }

	Checker operator* (LChIterator it) { return *(it.p); }
	friend int operator==(LChIterator it, Checker* pch) { if (pch == it.p) return 1; return 0; }
	friend int operator!=(LChIterator it1, LChIterator it2) { if (it1 == it2) return 0; return 1; }
};


class ListOfCheckers {				
	Checker List[13];	//12 шашек + голова, чтобы список никогда не был пустым
						//шашки нумеруются от 1 до 12
public:
	ListOfCheckers();							//связывает список
	~ListOfCheckers() {}

	void GenerateInitialPosition(int color, int* types, int* coords, int n);	//временно:генерирует первоначальную позицию

	void Insert(int num);						//вставляет шашку в список
	void Delete(int num);						//удаляет шашку из списка

	int IsEmpty() { if (List[0].GetNextNum() == 0) return 1; return 0; }
	Checker& operator[] (int i) { return List[i]; }

	void Clean() { List[0].SetNextNum(0); List[0].SetPrevNum(0); }
	void Bind(int n);

	typedef LChIterator iterator;
	iterator begin() { return iterator(&(List[List[0].GetNextNum()]),List); }
	iterator end() { return iterator(List, List); }
};
