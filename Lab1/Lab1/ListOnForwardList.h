#pragma once

#include "stdafx.h"
#include <iostream>

using namespace std;

template <typename T>
 class Forward_list
{
public:
	Forward_list();
	~Forward_list();
	void push_back(T data);
	void pop_front();
	void pop_back();
	void remove(int pos);
	void clear();
	int GetSize() { return Size; }
	T& operator[](const int index);
	void insert(T data, int pos);

private:

	template <typename T>
	class  Node
	{
	public:
		T data;
		Node *pNext;
		Node(T data = T(), Node *pNext = NULL)
		{
			this->data = data;
			this->pNext = pNext;
		}
	};
	int Size;
	Node<T> *root;

};

template <typename T>
Forward_list<T>::Forward_list()
{
	Size = 0;
	root = NULL;
}

template <typename T>
Forward_list<T>::~Forward_list()
{
	clear();
}

template<typename T>
void Forward_list<T>::push_back(T data)
{
	if (root == NULL)
	{
		root = new Node<T>(data);

	}
	else
	{
		Node<T> *tmp = this->root;
		while (tmp->pNext != NULL)
		{
			tmp = tmp->pNext;
		}
		tmp->pNext = new Node<T>(data);
	}
	Size++;
}

template<typename T>
void Forward_list<T>::pop_front()
{
	Node<T> * tmp = this->root;
	root = root->pNext;

	delete tmp;
	Size--;
}

template<typename T>
inline void Forward_list<T>::pop_back()
{
	if (Size != 0)
	{
		Node<T> * tmp = this->root;
		while (tmp->pNext->pNext != 0)
		{
			tmp = tmp->pNext;
			
		}
		delete tmp->pNext;
		tmp->pNext = NULL;
		Size--;
	}
}

template<typename T>
inline void Forward_list<T>::remove(int pos)
{
	if (pos < 0 || pos >= Size)
	{
		return;
	}
	else if (pos == 0)
	{
		pop_front();
	}
	else if (pos == Size)
	{
		pop_back();
	}
	else
	{
		int i = 1;
		Node<T> * tmp = this->root;
		while (i < pos-1)
		{
			tmp = tmp->pNext;
			i++;
		}
		Node<T> *newNode = tmp->pNext;
		tmp->pNext = tmp->pNext->pNext;
		delete newNode;
		Size--;
	}
}

template<typename T>
void Forward_list<T>::clear()
{
	while (Size)
	{
		pop_front();
	}
}

template<typename T>
T & Forward_list<T>::operator[](const int index)
{
	int counter = 0;
	Node<T> *tmp = this->root;
	while (tmp != NULL)
	{
		if (counter == index)
		{
			return tmp->data;
		}
		tmp = tmp->pNext;
		counter++;
	}
}

template<typename T>
inline void Forward_list<T>::insert(T data, int pos)
{
	if (pos < 0 || pos > Size)
	{
		return;
	}

	else if (pos == 0)
	{
		Node<T> *newNode = new Node<T>(data);
		if (Size == 0)
		{
			root = newNode;
		}
		else
		{
			newNode->pNext = root;
			root = newNode;
		}
		Size++;
	}
	else if (pos == Size)
	{
		push_back(data);
	}
	else
	{
		int i = 1;
		Node<T> *tmp = this->root;
		while(i!=pos)
		{
			tmp = tmp->pNext;
			i++;
		}

		Node<T> *NewNode = new Node<T>(data);
		NewNode->pNext = tmp->pNext;
		tmp->pNext = NewNode;

		Size++;
	}
	
}



