#include "CheckCall.h"
extern "C" __declspec(dllexport) int __stdcall Call(int x, int y)
{
	return ((x << 3) | y);
}