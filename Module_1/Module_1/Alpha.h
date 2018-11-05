#pragma once
#include <iostream>
#include "Base.h"
using namespace std;

class Alpha : public Base
{
public:
	
	Alpha();
	~Alpha();

};

int Alpha::a;

Alpha::Alpha()
{
	a++;
	number = a;
}

Alpha::~Alpha()
{
	s +=number;
}