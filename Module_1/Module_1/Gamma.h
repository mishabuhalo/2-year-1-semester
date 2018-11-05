#pragma once
#include <iostream>
#include "Base.h"
using namespace std;


class Gamma : public Base
{
public:
	Gamma();
	~Gamma();


};

Gamma::Gamma()
{
	g++;
	number = g;
}
int Gamma::g;

Gamma::~Gamma()
{
	s = s + number +13;
}