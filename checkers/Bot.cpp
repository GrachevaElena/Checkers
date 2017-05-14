#include "Bot.h"
#include "Search.h"

Board board;
ListOfCheckers checkers[2];

int Encrypt(Move bestMove);

//���� ���������� ����� �� ������� �������, �.�. ����� ���������� ������ ��������� �����
extern "C" __declspec(dllexport) int __stdcall CallBot(
	int* w_coords, int* w_types, int w_n, //white checkers
	int* b_coords, int* b_types, int b_n,  //black checkers
	int color, int max_depth,
	int type_search, int type_evaluate//parametrs
) 
{
	
	//����������� �����
	checkers[WHITE].GenerateInitialPosition(WHITE, w_types, w_coords, w_n);
	checkers[BLACK].GenerateInitialPosition(BLACK, b_types, b_coords, b_n);

	board.Set(checkers[WHITE], checkers[BLACK]);

	//����� Search
	Move bestMove=Search(color,max_depth, (ESearch)type_search,(EEvaluate) type_evaluate);

	//�������
	checkers[WHITE].Clean();
	checkers[BLACK].Clean();
	board.Clean();

	return Encrypt(bestMove);
}


int Encrypt(Move bestMove) {
	//�������������� bestMove � res: ����� �� ����(1���)->����� �����(4)->�������� ���������� �����(6)->
	//->��������� �� ���(1)->��������� �����(12)
	int res = 0;
	Move emptyMove;
	if (bestMove == emptyMove) res |= 1;
	else {
		res |= (bestMove.GetNum() - 1) << 1;
		res |= bestMove.GetFinalCoord() << 5;
		res |= bestMove.GetType() << 11;
		int eaten[MaxNEaten]; bestMove.GetEaten(eaten);
		//������������ ������-������, ��� ��� ���������
		for (int i = 0; i < bestMove.GetNEaten(); i++) {
			res |= 1 << (12 + eaten[i] - 1);
		}
	}
	return res;
}