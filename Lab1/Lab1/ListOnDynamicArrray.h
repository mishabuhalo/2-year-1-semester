#pragma once

#include "stdafx.h"
#include <iostream>
#include <string>
#include <vector>
#include <time.h>

using namespace std;


template<typename T>
class ListOnDynamicArray 
{
public:
	ListOnDynamicArray();
	~ListOnDynamicArray();
	void push_back(T data);
	void push_front(T data);
	void pop_front();
	void pop_back();
	void clear();
	void print();
	void remove(int pos);
	void insert(T data, int pos);
	void InsertionSort();
	int GetSize() { return size; }
	void QuickSort(int low, int high);
	int Partition(int low, int high);
	void Merge(int l, int m, int r);
	void MergeSort(int l, int r);
	T& operator[](const int index);
	void AddRandomElements();
private:
	T * DynamicArray;
	int size;

};


template<typename T>
ListOnDynamicArray<T>::ListOnDynamicArray()
{
	DynamicArray = new T[0];
	size = 0;
}

template<typename T>
ListOnDynamicArray<T>::~ListOnDynamicArray()
{
	clear();
}

template<typename T>
inline void ListOnDynamicArray<T>::push_back(T data)
{
	T* NewArray = new T[size + 1];
	for (int i = 0; i < size; i++)
	{
		NewArray[i] = DynamicArray[i];
	}
	NewArray[size] = data;

	delete[] DynamicArray;
	DynamicArray = NewArray;
	size++;
}

template<typename T>
inline void ListOnDynamicArray<T>::push_front(T data)
{
	T *NewArray = new T[size + 1];

	for (int i = 0; i < size; ++i)
	{
		NewArray[i + 1] = dynamicArray[i];
	}
	NewArray[0] = data;

	delete[] DynamicArray;

	DynamicArray = NewArray;
	size++;
}

template<typename T>
inline void ListOnDynamicArray<T>::pop_front()
{
	if (size != 0)
	{
		T* NewArray = new T[size - 1];

		for (int i = 0; i < size - 1; i++)
		{
			NewArray[i] = DynamicArray[i + 1];
		}

		delete[] DynamicArray;

		DynamicArray = NewArray;

		size--;

	}
}

template<typename T>
inline void ListOnDynamicArray<T>::pop_back()
{
	if (size != 0)
	{
		T *NewArray = new T[size - 1];

		for (int i = 0; i < size - 1; i++)
		{
			NewArray[i] = DynamicArray[i];
		}

		delete[] DynamicArray;

		DynamicArray = NewArray;
		size--;;
	}
}

template<typename T>
inline void ListOnDynamicArray<T>::print()
{
	for (int i = 0; i < size; i++)
	{
		cout << DynamicArray[i] << ' ';
	}
	cout << endl;
}

template<typename T>
inline void ListOnDynamicArray<T>::remove(int pos)
{
	if (pos < 0 || pos >= size)
	{
		return;
	}

	else if (pos == 0)
	{
		pop_front();
	}
	else if (pos == size - 1)
	{
		pop_back();
	}

	else
	{
		T *NewArray = new T[size - 1];

		for (int i = 0; i < pos - 1; i++)
		{
			NewArray[i] = DynamicArray[i];
		}
		for (int i = pos - 1; i < size - 1; i++)
		{
			NewArray[i] = DynamicArray[i + 1];
		}
		delete[] DynamicArray;

		DynamicArray = NewArray;
		size--;
	}
}

template<typename T>
inline void ListOnDynamicArray<T>::insert(T data, int pos)
{
	if (pos < 0 || pos > size)
	{
		return;
	}
	else if (pos == 0)
	{
		push_front(data);
	}
	else if (pos == size)
	{
		push_back(data);
	}
	else
	{
		T *NewArray = new T[size + 1];

		for (int i = 0; i < pos; i++)
		{
			NewArray[i] = DynamicArray[i];
		}
		NewArray[pos] = data;

		for (int i = pos; i < size; ++i)
		{
			NewArray[i + 1] = DynamicArray[i];
		}
		delete[] dynamicArray;

		DynamicArray = NewArray;
		size++;
	}
}

template<typename T>
inline void ListOnDynamicArray<T>::InsertionSort()
{
	int i, j;
	T key;
	for (i = 1; i < size; i++)
	{
		key = DynamicArray[i];
		j = i - 1;
		while (j >= 0 && DynamicArray[j] < key)
		{
			DynamicArray[j + 1] = DynamicArray[j];
			j--;
		}
		DynamicArray[j + 1] = key;
	}
}

template<typename T>
inline int ListOnDynamicArray<T>::Partition(int low, int high)
{

	T pivot = DynamicArray[high];
	int i = (low - 1);

	for (int j = low; j <= high - 1; j++)
	{
		if (DynamicArray[j] < pivot)
		{
			i++;
			swap(DynamicArray[i], DynamicArray[j]);
		}
	}
	swap(DynamicArray[i + 1], DynamicArray[high]);
	return (i + 1);
}



template<typename T>
inline void ListOnDynamicArray<T>::Merge(int l, int m, int r)
{
	int i, j, k;
	int n1 = m - l + 1;
	int n2 = r - m;
	T * L = new T[n1];
	T*R = new T[n2];

	for (i = 0; i < n1; i++)
		L[i] = DynamicArray[l + i];
	for (j = 0; j < n2; j++)
		R[j] = DynamicArray[m + 1 + j];

	i = 0;
	j = 0;
	k = l;
	while (i < n1 && j < n2)
	{
		if (L[i] <= R[j])
		{
			DynamicArray[k] = L[i];
			i++;
		}
		else
		{
			DynamicArray[k] = R[j];
			j++;
		}
		k++;
	}

	while (i < n1)
	{
		DynamicArray[k] = L[i];
		i++;
		k++;
	}


	while (j < n2)
	{
		DynamicArray[k] = R[j];
		j++;
		k++;
	}

}
template<typename T>
inline void ListOnDynamicArray<T>::MergeSort(int l, int r)
{
	if (l < r)
	{

		int m = l + (r - l) / 2;

		MergeSort(l, m);
		MergeSort(m + 1, r);

		Merge(l, m, r);
	}
}

template<typename T>
inline T & ListOnDynamicArray<T>::operator[](const int index)
{
	return DynamicArray[index-1];
}


inline void ListOnDynamicArray<int>::AddRandomElements()
{
	srand(time(0));
	int count = rand() % 100 + 1;

	int *NewArray = new int[size + count];

	for (int i = 0; i < size; i++)
	{
		NewArray[i] = DynamicArray[i];
	}

	for (int i = size; i < size + count; i++)
	{
		int countOfElement = rand() % 100 + 1;

		for (int j = 0; j < countOfElement; ++j)
		{
			NewArray[i] = rand() % 50;
		}
	}

	delete[] DynamicArray;

	DynamicArray = NewArray;
	size += count;
}



inline void ListOnDynamicArray < double > ::AddRandomElements()
{
	srand(time(0));
	int count = rand() % 100 + 1;

	double *NewArray = new double[size + count];

	for (int i = 0; i < size; i++)
	{
		NewArray[i] = DynamicArray[i];
	}

	for (int i = size; i < size + count; i++)
	{
		int countOfElement = rand() % 100 + 1;

		for (int j = 0; j < countOfElement; ++j)
		{
			NewArray[i] = (double)( rand() % 50);
		}
	}

	delete[] DynamicArray;

	DynamicArray = NewArray;
	size += count;
}


inline void ListOnDynamicArray < string > ::AddRandomElements()
{
	srand(time(0));
	int count = rand() % 100 + 1;

	string *NewArray = new string[size + count];

	for (int i = 0; i < size; i++)
	{
		NewArray[i] = DynamicArray[i];
	}

	for (int i = size; i < size + count; i++)
	{
		int countOfElement = rand() % 10 + 1;

		for (int j = 0; j < countOfElement; j++)
		{
			NewArray[i].push_back((char)(rand()%127));
		}
	}

	delete[] DynamicArray;

	DynamicArray = NewArray;
	size += count;
}

template<typename T>
inline void ListOnDynamicArray<T>::AddRandomElements()

{
	srand(time(0));
	int count = rand() % 5 + 1;

	T *NewArray = new T[size + count];

	for (int i = 0; i < size; i++)
	{
		NewArray[i] = DynamicArray[i];
	}

	for (int i = size; i < size + count; i++)
	{
		int countOfElement = rand() % 50;

		for (int j = 0; j < countOfElement; ++j)
		{
			NewArray[i].push_back((rand() % 10));
		}
	}

	delete[] DynamicArray;

	DynamicArray = NewArray;
	size += count;
}



template<typename T>
inline void ListOnDynamicArray<T>::QuickSort(int low, int high)
{
	if (low < high)
	{

		int pi = Partition(low, high);


		QuickSort(low, pi - 1);
		QuickSort(pi + 1, high);
	}
}

template<typename T>
void ListOnDynamicArray<T>::clear()
{
	delete[] DynamicArray;
	DynamicArray = new T[0];
	size = 0;
}

