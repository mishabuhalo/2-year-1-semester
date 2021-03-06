
#include "stdafx.h"
#include <iostream>
#include <vector>

#include "Base.h"
#include "Alpha.h"
#include "Beta.h"
#include "Gamma.h"
#include <time.h>
#include <string>
using namespace std;



void fillElements(vector <unique_ptr <Base>> &vect, int key)
{
	unique_ptr<Base> tmp;

	if (key == 1)
	{
		tmp = unique_ptr<Base>(new Alpha);
		cout << "Aded Alpha" << endl;

	}

	else if (key == 2)
	{
		tmp = unique_ptr<Base>(new Beta);
		cout << "Aded Beta" << endl;
	}

	else
	{
		tmp = unique_ptr<Base>(new Gamma);
		cout << "Aded Gamma" << endl;
	}

	vect.push_back(move(tmp));
}

void AddElement(vector <unique_ptr <Base>> &vect, int key)
{
	fillElements(vect, key);
}


void predictions(vector <unique_ptr <Base>> &vect)
{
	double newS = 0;

	for (int i = vect.size() - 1; i >= 0; i--)
	{
		if (typeid(*vect[i]).name() == typeid(Alpha).name())
		{
			newS += vect[i].get()->GetNumber();
		}

		else if (typeid(*vect[i]).name() == typeid(Beta).name())
		{
			newS = newS - 2 * vect[i].get()->GetNumber();
		}

		else
		{
			newS = newS + 13 + vect[i].get()->GetNumber();
		}

		newS = newS / 2 - 3 * vect[i].get()->count + 15;

	}
	cout << "The prediction value of S:=" << newS << endl;
}

void countSForCombination(vector<vector<int>> &cases)
{
	double result = 0;
	int tmp = cases[0][0];
	for (int i = 0; i < int(cases.size()); i++)
	{
		if (tmp == 0)
			result += cases[i][tmp + 1];
		else if (tmp == 1)
			result = result - 2 * cases[i][tmp + 1];
		else
			result = result + 13 + cases[i][tmp + 1];

		result = result / 2 - 3 * cases[i][tmp + 1] + 15;



	}
	cout << "For current combination S=" << result << endl;
}

void getCombinations(vector<vector<int>> &cases, int alphaID, int betaID, int GammaID, int M)
{

	cases[M - 1] = { 0, alphaID, betaID, GammaID };
	if (M != 1)
	{
		getCombinations(cases, alphaID + 1, betaID, GammaID, M - 1);

	}
	else
		countSForCombination(cases);


	cases[M - 1] = { 1, alphaID, betaID, GammaID };
	if (M != 1)
	{
		getCombinations(cases, alphaID, betaID + 1, GammaID, M - 1);
	}
	else
		countSForCombination(cases);


	cases[M - 1] = { 2, alphaID, betaID, GammaID };
	if (M != 1)
	{
		getCombinations(cases, alphaID, betaID, GammaID + 1, M - 1);
	}
	else
		countSForCombination(cases);



}
void createCombinations(int M)
{
	if (M > 0 && M < 7)
	{
		vector<vector<int>> cases(M, { 0,0,0,0 });
		getCombinations(cases, 1, 1, 1, M);
	}
}

void deleteElements(vector <unique_ptr <Base>> &vect)
{

	while (vect.size() > 0)
	{
		vect.back().reset();
		vect.pop_back();
	}

}
void deleteEnd(vector <unique_ptr <Base>> &vect)
{
	if (vect.size() != 0)
	{
		vect.back().reset();
		vect.pop_back();
	}

}
void demonstration()
{
	vector <unique_ptr<Base>> vect;
	string menu = "1 - exit\n2- add Alpha\n3 - add Beta\n4 - Add Gamma\n5 - delete End Element\n6 - count prediction for existing vector\n7 - delete all  elements\n\
8 - count global s for  all combinations(in this case for M=2) \n9 - show global s\n10 - show menu\n";
	cout << menu;
	while (true)
	{
		int ask;
		cin >> ask;
		if (ask == 1)
			break;
		else if (ask >= 2 && ask <= 4)
			AddElement(vect, ask - 1);
		else if (ask == 6)
			predictions(vect);
		else if (ask == 5)
			deleteEnd(vect);
		else if (ask == 8)
			createCombinations(2);
		else if (ask == 9)
			cout << "S=" << s << endl;
		else if (ask == 10)
			cout << menu;
		else if (ask == 7)
			deleteElements(vect);
	}
}

int main()
{
	Alpha::a = 0;
	Beta::b = 0;
	Gamma::g = 0;
	Beta::n = 0;
	demonstration();
	return 0;
}

