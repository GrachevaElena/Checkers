#include "Move.h"

int operator==(const Move & m1, const Move & m2)
{
	if ((m1.move&INVMASK_EATEN) != (m2.move&INVMASK_EATEN)) return 0;
	int f, coord, n = ((m1.move >> OFFSET_NEATEN) & MASK_NEATEN);
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
	for (; (*p)&&(n<12); n++, p++) {
		move = move|((*p) << (n * 4 + OFFSET_EATEN));
	}
	SetNEaten(n);
}