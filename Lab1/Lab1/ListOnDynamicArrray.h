#pragma once

#include "stdafx.h"
#include <iostream>

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
	++length;
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

		for (int i = 0; i < pos-1; i++)
		{
			NewArray[i] = DynamicArray[i];
		}
		for (int i = pos-1; i < size - 1; i++)
		{
			NewArray[i] = DynamicArray[i + 1];
		}
		delete[] DynamicArray;

		DynamicArray = NewArray;
		size --;
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
void ListOnDynamicArray<T>::clear()
{
	delete[] DynamicArray;
	DynamicArray = new T[0];
	size = 0;
}

