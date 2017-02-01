#pragma once
typedef unsigned long long type;
class Cache
{
private:
	int Size;
	type *pData;
	type *pLast;
public:
	Cache():Size(0), pData(0), pLast(0){};
	Cache(int size) : Size(size) { pData = new type[size]; pLast = pData; };
	void Push(type data) {*pLast++ = data; }//запись данных в кэш, pLast++
	type& Pop() { return *(--pLast); }
	void Rollback(type *saved) { pLast = saved; }//указатель pLast переносится на сохраненную позицию saved
	int CurPos() { return (pLast - pData); }
	bool IsFull() { return CurPos()>= Size; }
	bool IsEmpty() { return CurPos() <= 0; }
	~Cache() { delete[] pData; }
};