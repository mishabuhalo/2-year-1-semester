#pragma once
#include "stdafx.h"
#include <iostream>
#include "ListOnForwardList.h"
#include "ListOnDynamicArrray.h"
#include "ListOnLibraryList.h"
#include "Dates.h"

using namespace std;


int main()
{
	srand(time(0));
	ListOnDynamicArray<Dates> list;
	Dates date;
	for (int i = 0; i < 2; i++)
	{
		list.push_back(date.AddNew());
	}
	for (int i = 1; i < list.GetSize()+1; i++)
	{
		list[i].PrintDate(list[i]);
	}

	list.QuickSort(0, list.GetSize()-1);

	for (int i = 1; i < list.GetSize() +1; i++)
	{
		list[i].PrintDate(list[i]);
	}
	cout << endl;
	//list[1].PrintDate(list[1]);
	list[2].CalculateDayOfTheWeek(list[2]);

	//list.print();
	


	/*ListOnDynamicArray<int> * list = new ListOnDynamicArray<int>;
	list->push_back(10);
	list->push_back(13);
	list->push_back(9);
	list->push_back(7);
	list->push_back(22);
	list->push_back(14);s
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

