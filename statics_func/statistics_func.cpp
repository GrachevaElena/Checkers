#include "statistics_func.h"
#define _CRT_SECURE_NO_WARNINGS


#include <string>
#include <iostream>
#include <stdio.h>
#include <algorithm>

#include <iostream>
#include <fstream>
using namespace std;

static int numStep = 0;
static int numGame = 0;
double averSizeMovies = 0;
int numMovies = 0;


void Clear()
{
	averSizeMovies = 0;
	numMovies = 0;
}
void CalculateAverSizeOfMovie(int sizeMove)
{
	averSizeMovies = (averSizeMovies * numMovies + sizeMove) / (numMovies + 1);
	numMovies++;
}
string IntToStr(int n)
{
	string s;
	if (n == 0)
		s.push_back('0');
	while (n)
	{
		s.push_back(n % 10);
		n /= 10;
	}
	reverse(s.begin(), s.end());
	return s;
}
void Read_num_of_game_step()
{
	FILE *f = freopen("curGame.txt", "r", stdin);
	cin >> numGame >> numStep;
	fclose(stdin);
	if (f)
		fclose(f);
}
void PrintStatistics(Cache &c)
{
	Read_num_of_game_step();
	string s = "statistics " + IntToStr(numGame) + ".txt";

	ofstream f;
	f.open(s, std::fstream::app);
	streambuf *bak = cout.rdbuf(f.rdbuf());

	cout << "\nnum_step_" << numStep <<" max_size_of_cache_" << c.GET_MAX_SIZE();
	cout << " aver_size_of_move_" <<averSizeMovies<<" num_of_clipping_";

	cout.rdbuf(bak);
	f.close();
}