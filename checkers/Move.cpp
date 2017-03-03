#include "Move.h"

int operator==(const Move & m1, const Move & m2)
{
	if ((m1.move<<42) != (m2.move << 42)) return 0;
	int f, n = ((m1.move >> OFFSET_NEATEN) & MASK_NEATEN); long long coord;
	for (int i = 0; i < n; i++) {
		f = 0;
		coord = (m1.move >> (OFFSET_EATEN + i * 4))&MASK_NEATEN;
		for (int j = 0; j < n; j++)
			if (coord == ((m2.move >> (OFFSET_EATEN + j * 4))&MASK_NEATEN)) {
				f = 1;
				break;
			}
		if (!f) return 0;
	}
	return 1;
}

void Move::SetVarEaten(int n1, ...) {
	int * p = &n1;
	int n=0;
	move = move&INVMASK_EATEN&INVMASK_NEATEN;
	for (; (*p)&&(n<10); n++, p++) {
		move = move|((long long)(*p) << (n * 4 + OFFSET_EATEN));
	}
	SetNEaten(n);
}