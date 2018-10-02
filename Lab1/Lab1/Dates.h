#pragma once
#pragma once
#include "stdafx.h"
#include <iostream>



using namespace std;
class Dates
{
public:
	Dates();
	~Dates();
	void IscorrectDate(Dates date1);
	void CalculateDayOfTheWeek(Dates data);
	void DifferenceBetweenDates(Dates data1, Dates data2, Dates fixedDate);
	void AddDifference(Dates data, int jdn);
	void AddNewDate();
	void PrintDate(Dates date);
	int jdn(Dates data);

private:
	int year, month, day, hour, minute, second;

};

Dates::Dates()
{
	
}

Dates::~Dates()
{
}

inline void Dates::IscorrectDate(Dates date)
{
	double  result;
	result = date.year / 400 *3;

	cout << "The difference between this data and this data in gregorian calendar is about " << result << " days" << endl;
}

inline void Dates::CalculateDayOfTheWeek(Dates data1)
{
	int a1 = (14 - data1.month) / 12;
	int y1 = data1.year + 4800 - a1;
	int m1 = data1.month + (12 * a1) - 3;
	int jdn1 = data1.day + (153 * m1 + 2) / 5 + 365 * y1 + y1 / 4 - 32083;
	int result = jdn1 % 7;

	if (result = 0)
		cout << "Monday" << endl;
	else
	if (result = 1)
		cout << "Tuesday" << endl;
	else
	if (result = 2)
		cout << "Wednesday" << endl;
	else
	if (result = 3)
		cout << "Thursday" << endl;
	else
	if (result = 4)
		cout << "Friday" << endl;
	else
	if (result = 5)
		cout << "Saturday" << endl;
	else
	if (result = 6)
		cout << "Sunday" << endl;


}

inline void Dates::DifferenceBetweenDates(Dates data1, Dates data2, Dates fixedDate)
{
	
	int jdn1 = jdn(data1);

	int jdn2 = jdn(data2);
	int result = abs(jdn2 - jdn1);
	cout << "The difference betwenn two dates is about " << jdn2 - jdn1 << " days" << endl;
	char c;
	cout << "Do you want to add this difference to some fixed data? (y/n)" << endl;
	cin >> c;
	if (c == 'y')
		AddDifference(fixedDate, result);
	else
		return;

}

inline void Dates::AddDifference(Dates fixedDate, int result)
{
	int jdn1 = jdn(fixedDate);
	int newJdn = jdn1 + result;
	int c = newJdn + 32082;
	int d = (4 * c + 3) / 1461;
	int e = c - (1461 * d) / 4;
	int m = (5 * e + 2) / 153;
	int day = e - (153 * m + 2) / 5 + 1;
	int month = m + 3 - 12 * (m / 10);
	int year = d - 4800 + m / 10;
	cout << "New data will be :" << day << ':' << month << ':' << year << 'p' << endl;

}

inline void Dates::AddNewDate()
{

	cout << "Enter your data: " << endl;
	cout << "Enter year: ";
	cin >> year;
	cout << "Enter month: ";
	cin >> month;
	cout << "Enter day: ";
	cin >> day;
	cout << "Enter hour: ";
	cin >> hour;
	cout << "Enter minute: ";
	cin >> minute;
	cout << "Enter second: ";
	cin >> second;
	

}

inline void Dates::PrintDate(Dates date)
{
	cout << date.day << '.' << date.month << '.' << date.year << "p " << date.hour << ':' << date.minute << ':' << date.second << endl;
}

inline int Dates::jdn(Dates data1)
{
	int a1 = (14 - data1.month) / 12;
	int y1 = data1.year + 4800 - a1;
	int m1 = data1.month + (12 * a1) - 3;
	int jdn1 = data1.day + (153 * m1 + 2) / 5 + 365 * y1 + y1 / 4 - 32083;
	return jdn1;
}
