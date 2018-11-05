#pragma once
#include <iostream>
#include "Base.h"
using namespace std;

class Beta : public Base
{
public:
	Beta();
	~Beta();


};

Beta::Beta()
{
	b++;
	number = b;
}
int Beta::b;

Beta::~Beta()
{
	s = s - 2 * number;
}