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
	//Forward_list<Dates> list;
	//ListOnDynamicArray<Dates> list;
	ListOnLibraryList<Dates> list;
	Dates date;
	Dates date1;
	Dates fixedData;
	date.AddNewDate();
	date1.AddNewDate();
	fixedData.AddNewDate();
	
	list.push_back(date);
	list.push_back(date1);
	list.push_back(fixedData);

	date.PrintDate(list[1]);
	date.PrintDate(list[2]);
	date.PrintDate(list[3]);
	list.sort();
	cout << endl;
	date.PrintDate(list[1]);
	date.PrintDate(list[2]);
	date.PrintDate(list[3]);
	//date.PrintDate(list[3]);
	
	


	/*for (int i = 0; i < list.GetSize(); i++)
	{
		cout << list[i] << ' ';
	}
	list.MergeSort(&list.root);
	cout << endl;

	for (int i = 0; i < list.GetSize(); i++)
	{
		cout << list[i] << ' ';
	*/
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

