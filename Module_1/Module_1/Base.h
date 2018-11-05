#pragma once
#include <iostream>
#include <memory>
#include <vector>

using namespace std;
double s = 0;
class Base
{
public:
	Base();
	virtual ~Base();
	static int a;
	static int b;
	static int g;
	static int n;
	int count;
	unique_ptr<Base> Base1;
	unique_ptr<Base> Base2;
	vector<unique_ptr<Base>> * GetVector(vector<unique_ptr<Base>> vect);
	int GetNumber()
	{
		return number;
	}

	
	
protected : 
	int number;

};
int Base::n;


Base::Base()
{
	n++;
	count = n;
}

Base::~Base()
{
	s = s / 2 - 3*count + 15;
}

inline vector<unique_ptr<Base>>* Base::GetVector(vector<unique_ptr<Base>> vect)
{
	return &vect;
}
