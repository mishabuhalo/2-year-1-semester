#pragma once
#include "stdafx.h"
#include <iostream>
#include "ListOnForwardList.h"
#include "ListOnDynamicArrray.h"

using namespace std;


int main()
{
	/*Forward_list<int> list;
	list.push_back(10);
	list.push_back(13);
	list.push_back(9);
	list.push_back(7);
	//list.insert(3, 2);
	//ist.pop_back();
	//list.pop_front();
	list.remove(1);

	for (int i = 0; i < list.GetSize(); i++)
	{
		cout << list[i] << endl;
	}*/
	ListOnDynamicArray<int> * list = new ListOnDynamicArray<int>;
	list->push_back(10);
	list->push_back(13);
	list->push_back(9);
	list->push_back(7);
	list->print();
	list->remove(2);
	list->print();
    return 0;
}

