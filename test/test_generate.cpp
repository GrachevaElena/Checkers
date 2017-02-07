#include "gtest.h"
#include "FunctionsMove.h"
#include "BasicFunctions.h"
#include "fstream"
using namespace std;
#include "string.h"

ifstream ostr;
ifstream istr;
int _color;
int n;
int _end[32];
char s_istr[24]= "Positions\\ins\\Position*", s_ostr[43] = "Positions\\expected_outs_generate\\Position*";
ListOfCheckers white, black;

int test(char _n) {
	s_istr[22] = _n;
	s_ostr[41] = _n;
	istr.open(s_istr);
	ostr.open(s_ostr);

	istr >> _color;
	white.GenerateInitialPosition(istr);
	black.GenerateInitialPosition(istr);

	ostr >> _color;
	ostr >> n;
	for (int i = 0; i < n; i++) ostr >> _end[i];

	if (_color == WHITE) {
		Generate(white);
	}
	else Generate(black);

	if (cache.CurPos() != n) return 1;

	int f = 1;
	for (int i = 0; i < n; i++) {
		f = 0;
		for (int j = 0; j < n; j++)
			if (_end[i] == cache[j].GetCoord()) f = 1;
		if (!f) return 2;
	}

	return 0;
}


TEST(Generate, position_0) {
	EXPECT_EQ(0,test('0'),0);
}

TEST(Generate, position_2) {
	EXPECT_EQ(0,test('2'), 0);
}

TEST(Generate, position_3) {
	EXPECT_EQ(0,test('3'));
}

TEST(Generate, position_4) {
	EXPECT_EQ(0,test('4'));
}

TEST(Generate, position_5) {
	EXPECT_EQ(0,test('5'));
}

TEST(Generate, position_6) {
	EXPECT_EQ(0,test('6'));
}

TEST(Generate, position_7) {
	EXPECT_EQ(0,test('7'));
}

TEST(Generate, position_8) {
	EXPECT_EQ(0,test('8'));
}

TEST(Generate, position_9) {
	EXPECT_EQ(0,test('9'));
}

TEST(Generate, position_10) {
	EXPECT_EQ(0,test('10'));
}

TEST(Generate, position_11) {
	EXPECT_EQ(0,test('11'));
}

TEST(Generate, position_12) {
	EXPECT_EQ(0,test('12'));
}

TEST(Generate, position_13) {
	EXPECT_EQ(0,test('13'));
}