#include "statistics_func.h"
#define _CRT_SECURE_NO_WARNINGS


#include <string>
#include <iostream>
#include <stdio.h>
#include <algorithm>

#include <iostream>
#include <fstream>
using namespace std;

//static int numStep = 0;
//static int numGame = 0;

double averSizeMovies = 0;
int numMovies = 0;
int maxSizeCache = 0;

void ClearStatistics()
{
	averSizeMovies = 0;
	numMovies = 0;
	maxSizeCache = 0;
}
void CalculateAverSizeOfMovie(int sizeMove)
{
	averSizeMovies = (averSizeMovies * numMovies + sizeMove) / (numMovies + 1);
	numMovies++;
}
void CalculateMaxSize(int n)
{
	maxSizeCache = (n > maxSizeCache ? n : maxSizeCache);
}
string IntToStr(int n)
{
	string s;
	if (n == 0)
		s.push_back('0');
	while (n)
	{
		s.push_back((n % 10) + '0');
		n /= 10;
	}
	for (int i = 0; i < s.length()/2; i++)
		swap(s[i], s[s.length() - i - 1]);
	return s;
}
/*void Read_num_of_game_step()
{
	FILE *f = freopen("curGame.txt", "r", stdin);
	cin >> numGame >> numStep;
	fclose(stdin);
	if (f)
		fclose(f);
}*/
void PrintStatistics(int numGame, int numStep, int depth, int typeSearch, int typeEvalute, int color)
{
	//Read_num_of_game_step();
	char *col[] = { {" white"}, {" black"} };
	char *search[] = { { " search" },{ " A_B" }, {" forcing"} };
	char *ev[] = { { " simple_ev" },{ " smart_ev" } };
	string s = "statistics " + IntToStr(numGame) + search[typeSearch] + IntToStr(depth) + ".txt";
	ofstream f(s, fstream::app);

	if (!f.is_open())
		f = ofstream(s);

	f << "\nnum_step_" << numStep<<" depth_"<<depth<<" max_size_of_cache_" << maxSizeCache;
	f << " aver_size_of_move_" <<averSizeMovies<<search[typeSearch]<<ev[typeEvalute]<<col[color];

	f.close();
	maxSizeCache = 0;
	numMovies = 0;
	averSizeMovies = 0;
}