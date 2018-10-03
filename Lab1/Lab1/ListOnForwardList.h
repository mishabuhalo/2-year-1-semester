#pragma once

#include "stdafx.h"
#include <iostream>
#include <vector>
#include <ctime>


using namespace std;



template <typename T>
struct  Node 
{

	T data;
	Node *pNext;
	Node(T data = T(), Node *pNext = NULL)
	{
		this->data = data;
		this->pNext = pNext;
	}
};

template <typename T>
 class Forward_list 
{
public:
	Node<T> *root;
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
	Node<T> * SortedInsert(Node<T> * root, Node<T> * newnode);
	Node<T> *InsertSort(Node<T> *root);
	Node<T> *GetTail(Node<T> *root);
	Node<T> *Partition(Node<T> *head, Node<T> *end, Node<T> **newRoot, Node<T> **newTail);
	Node<T> *QuickSortRec(Node<T> *head, Node<T> *end);
	void QuickSort(Node<T> **root);
	Node<T> *SortedMerge(Node<T> * firsthalf, Node<T> * secondhalf);
	void FrontBackSplit(Node<T> * source, Node<T>** head, Node<T> **end);
	void MergeSort(Node<T> **root);
	void AddRandomElements();
	
private:
	int Size;
	

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
	else if (pos == 1)
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

template<typename T>
inline Node<T> * Forward_list<T>::SortedInsert(Node<T> * root, Node<T> * newnode)
{

	if (root == NULL || newnode->data < root->data)
	{
		newnode->pNext = root;
		root = newnode;
		return root;
	}
	else
	{
		Node<T> *current = root;
		while (current->pNext && !(newnode->data < current->pNext->data))
			current = current->pNext;
		newnode->pNext = current->pNext;
		current->pNext = newnode;
	}
	return root;
}

template<typename T>
inline Node<T> * Forward_list<T>::InsertSort(Node<T> * root)
{
	Node<T> *result = NULL;
	while (root)
	{
		Node<T> *newnode = root;
		root = root->pNext;
		result = SortedInsert(result, newnode);
	}
	return result;
}

template<typename T>
inline Node<T>* Forward_list<T>::GetTail(Node<T>* root)
{
	while (root != NULL && root->pNext != NULL)
		root = root->pNext;
	return root;
}

template<typename T>
inline Node<T>* Forward_list<T>::Partition(Node<T>* head, Node<T>* end, Node<T>** newRoot, Node<T>** newTail)
{
	Node<T> *pivot = end;
	Node<T> *prev = NULL, *cur = head, *tail = pivot;

	while (cur != pivot)
	{
		if (cur->data < pivot->data)
		{
			if ((*newRoot) == NULL)
				(*newRoot) = cur;

			prev = cur;
			cur = cur->pNext;
		}
		else
		{
			if (prev)
				prev->pNext = cur->pNext;
			Node<T> *tmp = cur->pNext;
			cur->pNext = NULL;
			tail->pNext = cur;
			tail = cur;
			cur = tmp;
		}
	}
 
	if ((*newRoot) == NULL)
		(*newRoot) = pivot;

	(*newTail) = tail;

	return pivot;
}

template<typename T>
inline Node<T>* Forward_list<T>::QuickSortRec(Node<T>* head, Node<T>* end)
{
	
	if (!head || head == end)
		return head;

	Node<T> *newHead = NULL, *newEnd = NULL;


	Node<T> *pivot = Partition(head, end, &newHead, &newEnd);

 
	if (newHead != pivot)
	{
		Node<T> *tmp = newHead;
		while (tmp->pNext != pivot)
			tmp = tmp->pNext;
		tmp->pNext = NULL;

		newHead = QuickSortRec(newHead, tmp);

		tmp = GetTail(newHead);
		tmp->pNext = pivot;
	}

	pivot->pNext = QuickSortRec(pivot->pNext, newEnd);

	return newHead;
}

template<typename T>
inline void Forward_list<T>::QuickSort(Node<T> ** root)
{
	(*root) = QuickSortRec(*root, GetTail(*root));

}

template<typename T>
inline Node<T>* Forward_list<T>::SortedMerge(Node<T>* firsthalf, Node<T>* secondhalf)
{
	Node<T>* result = NULL;

	if (firsthalf == NULL)
		return(secondhalf);
	else if (secondhalf == NULL)
		return(firsthalf);

	if (firsthalf->data <= secondhalf->data)
	{
		result = firsthalf;
		result->pNext = SortedMerge(firsthalf->pNext, secondhalf);
	}
	else
	{
		result = secondhalf;
		result->pNext = SortedMerge(firsthalf, secondhalf->pNext);
	}
	return(result);
}

template<typename T>
inline void Forward_list<T>::FrontBackSplit(Node<T>* source, Node<T>** head, Node<T>** end)
{
	Node<T>* fast;
	Node<T>* slow;
	slow = source;
	fast = source->pNext;

	while (fast != NULL)
	{
		fast = fast->pNext;
		if (fast != NULL)
		{
			slow = slow->pNext;
			fast = fast->pNext;
		}
	}

	
	*head = source;
	*end = slow->pNext;
	slow->pNext = NULL;
}

template<typename T>
inline void Forward_list<T>::MergeSort(Node<T>** root)
{
	 Node<T>* head = *root;
	 Node<T>* a;
	 Node<T>* b;

	if ((head == NULL) || (head->pNext == NULL))
	{
		return;
	}

	FrontBackSplit(head, &a, &b);

	MergeSort(&a);
	MergeSort(&b);

	*root = SortedMerge(a, b);
}

template<typename T>
inline void Forward_list<T>::AddRandomElements()
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

inline void Forward_list<string>::AddRandomElements()
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

inline void Forward_list<double>::AddRandomElements()
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

inline void Forward_list<int>::AddRandomElements()
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




