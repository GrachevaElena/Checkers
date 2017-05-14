#include "Move.h"

int operator==(const Move & m1, const Move & m2)
{
	if (m1.Color != m2.Color) return 0;
	if (m1.Type != m2.Type) return 0;
	if (m1.Num != m2.Num) return 0;
	if (m1.StartCoord != m2.StartCoord) return 0;
	if (m1.FinalCoord != m2.FinalCoord) return 0;
	if (m1.NEaten != m2.NEaten) return 0;
	int f = 0;
	for (int i = 0; i < m1.NEaten; i++) {
		f = 0;
		for (int j=0; j<m2.NEaten; j++)
			if (m1.Eaten[i] == m2.Eaten[i]) f=1;
		if (f = 0) return 0;
	}
	return 1;
}

int operator!=(const Move & m1, const Move & m2) {
	return !(m1 == m2);
}

void Move::SetVarEaten(unsigned long long n1, ...) {
	unsigned long long* p = &n1;
	int n = 0;
	for (; (p[n]) && (n<MaxNEaten); n++) {
		Eaten[n] = p[n];
	}
	SetNEaten(n);
}