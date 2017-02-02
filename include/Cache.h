#pragma once
#include "Move.h"
class Cache
{
private:
	int Size;
	Move *pData;
	Move *pLast;
public:
	Cache():Size(0), pData(0), pLast(0){};
	Cache(int size) : Size(size) { pData = new Move[size]; pLast = pData; };
	void Push(Move data) {*pLast++ = data; }//������ ������ � ���, pLast++
	Move& Pop() { return *(--pLast); }
	void Rollback(Move *saved) { pLast = saved; }//��������� pLast ����������� �� ����������� ������� saved
	int CurPos() { return (pLast - pData); }
	bool IsFull() { return CurPos()>= Size; }
	bool IsEmpty() { return CurPos() <= 0; }
	~Cache() { delete[] pData; }
};