#pragma once
#include "stdafx.h"
#include <iostream>
#include <list>
#include <functional>
#include <ctime>

using namespace std;

template<typename T>
class ListOnLibraryList 
{
public:
	ListOnLibraryList();
	~ListOnLibraryList();
	void push_back(T data);
	void push_front(T data);
	void pop_front();
	void pop_back();
	void clear();
	void print();
	void remove(int pos);
	void insert(T data, int pos);
	void sort();
	T& operator[](const int index);
	void AddRandomElements();

private:
	list<T> list;

};
template<typename T>
ListOnLibraryList<T>::ListOnLibraryList<T>()
{
}

template<typename T>
ListOnLibraryList<T>::~ListOnLibraryList<T>()
{
	list.clear();
}

template<typename T>
inline void ListOnLibraryList<T>::push_back(T data)
{
	list.push_back(data);
}

template<typename T>
inline void ListOnLibraryList<T>::push_front(T data)
{
	list.push_front(data);
}

template<typename T>
inline void ListOnLibraryList<T>::pop_front()
{
	list.pop_front();
}

template<typename T>
inline void ListOnLibraryList<T>::pop_back()
{
	list.pop_back();
}

template<typename T>
inline void ListOnLibraryList<T>::clear()
{
	list.clear();
}

template<typename T>
inline void ListOnLibraryList<T>::print()
{
	for (auto i = list.begin(); i != list.end(); ++i)
	{
		cout << *i << ' ';
	}
	cout << endl;
}

template<typename T>
inline void ListOnLibraryList<T>::remove(int pos)
{
	if (pos < 0 || pos >= list.size())
	{
		return;
	}
	else if (pos == 1)
	{
		pop_front();
	}
	else if (pos == list.size() )
	{
		pop_back();
	}
	else
	{
		auto i = list.begin();
		for (int j = 1; j < pos; ++j)
		{
			++i;
		}
		list.erase(i);
	}
}

template<typename T>
inline void ListOnLibraryList<T>::insert(T data, int pos)
{
	if (pos < 0 || pos > list.size())
	{
		return;
	}
	else if (pos == 0)
	{
		push_front(data);
	}
	else if (pos == list.size())
	{
		push_back(data);
	}
	else
	{
		auto i = list.begin();
		for (int j = 0; j < pos; ++j)
		{
			++i;
		}
		list.insert(i, data);
	}
}

template<typename T>
inline void ListOnLibraryList<T>::sort()
{
	list.sort();
}



template<typename T>
inline T & ListOnLibraryList<T>::operator[](const int index)
{

		auto i = list.begin();
		for (int j = 0; j < index-1; ++j)
		{
			++i;
		}
		return *i;
}

template<typename T>
inline void ListOnLibraryList<T>::AddRandomElements()
{
	srand(time(0));
	int count = rand() % 5 + 1;


	for (int i = 0; i < count; i++)
	{
		T temp;
		int countOfElement = rand() % 50;

		for (int j = 0; j < countOfElement; ++j)
		{
			temp.push_back((rand() % 10));
		}
		push_back(temp);
	}
}

inline void ListOnLibraryList<string>::AddRandomElements()
{
	srand(time(0));
	int count = rand() % 5 + 1;


	for (int i = 0; i < count; i++)
	{
		string temp;
		int countOfElement = rand() % 50;

		for (int j = 0; j < countOfElement; ++j)
		{
			temp.push_back((char)(rand() % 10));
		}
		push_back(temp);
	}


}

inline void ListOnLibraryList<double>::AddRandomElements()
{
	srand(time(0));
	int count = rand() % 5 + 1;


	for (int i = 0; i < count; i++)
	{
		double temp;
		int countOfElement = rand() % 50;

		for (int j = 0; j < countOfElement; ++j)
		{
			double temp = (rand() % 10);
		}
		push_back(temp);
	}


}

inline void ListOnLibraryList<int>::AddRandomElements()
{
	srand(time(0));
	int count = rand() % 5 + 1;


	for (int i = 0; i < count; i++)
	{
		int temp;
		int countOfElement = rand() % 50;

		for (int j = 0; j < countOfElement; ++j)
		{
			int temp = (rand() % 10);
		}
		push_back(temp);
	}


}

