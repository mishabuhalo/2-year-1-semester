#pragma once
#include "stdafx.h"
#include <iostream>
#include "ListOnForwardList.h"
#include "ListOnDynamicArrray.h"
#include "ListOnLibraryList.h"

using namespace std;


int main()
{
	Forward_list<int> list;
	list.push_back(10);
	list.push_back(13);
	list.push_back(9);
	list.push_back(7);
	list.push_back(22);
	list.push_back(14);
	list.push_back(49);
	list.push_back(5);
	list.push_back(2);
	list.push_back(25);
	//list.insert(3, 2);
	//ist.pop_back();
	//list.pop_front();
	//list.remove(1);

	for (int i = 0; i < list.GetSize(); i++)
	{
		cout << list[i] << ' ';
	}
	list.MergeSort(&list.root);
	cout << endl;

	for (int i = 0; i < list.GetSize(); i++)
	{
		cout << list[i] << ' ';
	}
	/*ListOnDynamicArray<int> * list = new ListOnDynamicArray<int>;
	list->push_back(10);
	list->push_back(13);
	list->push_back(9);
	list->push_back(7);
	list->push_back(22);
	list->push_back(14);
	list->push_back(49);
	list->print();
	list->remove(2);
	//list->QuickSort(0, list->GetSize()-1);
	list->MergeSort(0, list->GetSize() - 1);
	list->print();*/
	/*ListOnLibraryList<int> list;
	list.push_back(10);
	list.push_back(13);
	list.push_back(9);
	list.push_back(7);
	list.push_back(22);
	list.push_back(14);
	list.push_back(49);
	list.print();
	list.sort();
	list.print();*/
	
    return 0;
}

