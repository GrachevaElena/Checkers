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
	void Push(Move data) {*pLast++ = data; }//запись данных в кэш, pLast++
	Move& Pop() { return *(--pLast); }
	Move* GetpLast() { return pLast; }
	void Rollback(Move *saved) { pLast = saved; }//указатель pLast переносится на сохраненную позицию saved
	int CurPos() { return (pLast - pData); }
	Move operator[](int i) { return *(pData + sizeof(Move)*i); }
	bool IsFull() { return CurPos()>= Size; }
	bool IsEmpty() { return CurPos() <= 0; }
	void Clean() { pLast = pData; }
	~Cache() { delete[] pData; }
};