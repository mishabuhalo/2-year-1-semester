#include "stdafx.h"
#include <iostream>

using namespace std;

template <typename T>
class Forward_list
{
public :
	Forward_list();
	~Forward_list();
	void push_back(T data); 
	void pop_front();
	void clear();
	int GetSize() { return Size; }
	T& operator[](const int index);

private:

	template <typename T>
	class  Node
	{
	public:
		T data;
		Node *pNext;
		Node(T data =T(), Node *pNext = NULL)
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
	while (tmp!= NULL)
	{
		if (counter == index)
		{
			return tmp->data;
		}
		tmp = tmp->pNext;
		counter++;
	}
}

int main()
{
	Forward_list<int> list;
	list.push_back(10);
	list.push_back(13);
	for (int i = 0; i < list.GetSize(); i++)
	{
		cout << list[i] << endl;
	}
    return 0;
}

