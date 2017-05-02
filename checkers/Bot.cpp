#include "Bot.h"
#include "Search.h"
#include "statistics_func.h"

Board board;
ListOfCheckers checkers[2];

int Encrypt(Move bestMove);

//надо передавать шашки по порядку номеров, т.к. будут возвращены номера съеденных шашек
extern "C" __declspec(dllexport) int __stdcall CallBot(
	int* w_coords, int* w_types, int w_n, //white checkers
	int* b_coords, int* b_types, int b_n,  //black checkers
	int color, int max_depth,
	int type_search, int type_evaluate,
	int f = 0, int nGame = 0, int nStep = 0)//parametrs
{
	
	//расстановка шашек
	checkers[WHITE].GenerateInitialPosition(WHITE, w_types, w_coords, w_n);
	checkers[BLACK].GenerateInitialPosition(BLACK, b_types, b_coords, b_n);

	board.Set(checkers[WHITE], checkers[BLACK]);

	//вызов Search
	Move bestMove= Search(color,max_depth, (ESearch)type_search,(EEvaluate) type_evaluate);

	//очистка
	checkers[WHITE].Clean();
	checkers[BLACK].Clean();
	board.Clean();

	if (f)
	{
		PrintStatistics(nGame, nStep);
	}

	return Encrypt(bestMove);
}


int Encrypt(Move bestMove) {
	//преобразование bestMove в res: конец ли игры(1бит)->номер шашки(4)->конечные координаты шашки(6)->
	//->изменился ли вид(1)->съеденные шашки(12)
	int res = 0;
	Move emptyMove;
	if (bestMove == emptyMove) res |= 1;
	else {
		res |= (bestMove.GetNum() - 1) << 1;
		res |= bestMove.GetFinalCoord() << 5;
		res |= bestMove.GetType() << 11;
		int eaten[MaxEaten]; bestMove.GetEaten(eaten);
		//записываются справа-налево, как все остальное
		for (int i = 0; i < bestMove.GetNEaten(); i++) {
			res |= 1 << (12 + eaten[i] - 1);
		}
	}
	return res;
}