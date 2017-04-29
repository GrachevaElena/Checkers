#pragma once
#include "Move.h"
class Cache
{
private:
	int Size;
	Move *pData;//”казатель на начало
	Move *pLast;
public:
	int TEST_MAX_SIZE = 0;
	int GET_MAX_SIZE()
	{
		return TEST_MAX_SIZE;
	}
	inline void TEST_UPDATE()
	{
		if (CurPos() > TEST_MAX_SIZE) TEST_MAX_SIZE = CurPos();
	}

	Cache():Size(0), pData(0), pLast(0){};
	Cache(int size) : Size(size) { pData = new Move[size]; pLast = pData; };
	void Push(Move data) { *pLast++ = data; TEST_UPDATE(); }//запись данных в кэш, pLast++
	Move& Pop() { return *(--pLast); }
	Move* GetpLast() { return pLast; }
	void Rollback(Move *saved) { pLast = saved; /*TEST_UPDATE(); */ }//указатель pLast переноситс€ на сохраненную позицию saved
	int CurPos() { return (pLast - pData); }
	Move operator[](int i) { return *(pData + sizeof(Move)*i); }
	bool IsFull() { return CurPos()>= Size; }
	bool IsEmpty() { return CurPos() <= 0; }
	void Clean() { pLast = pData; TEST_MAX_SIZE = 0; }
	~Cache() { delete[] pData; }
};