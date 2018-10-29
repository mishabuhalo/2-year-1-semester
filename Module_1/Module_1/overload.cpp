#include "stdafx.h"
#include "overload.h"
#include "math.h"
#include <iostream>
#include <string>
#include <list>



using namespace std;
int f(int n)
{
	int result = 1;
	if (n >= 0)
	{
		
		for (int i = 1; i <= n; i++)
		{
			result *= i;
		}
		return result / 115;
	}
	else return n * n*n / 215;
}

int f(double d)
{
	return exp(1 / sin(d)) / 315;
}

int f(string s)
{
	int result = 0;
	char gls[] = "aeiouy";
	for (int i =0; i < s.length(); i++)
	{
		for (int j = 0; j < strlen(gls); j++)
		{
			if (s[i] == gls[j])
				result++;
		}
	}
	return result;
}
int f(pair <int,int> p)
{
	return pow(p.second, p.first) / 515;
}


template <typename T>
int f(T a)
{
	return 7115;
}

