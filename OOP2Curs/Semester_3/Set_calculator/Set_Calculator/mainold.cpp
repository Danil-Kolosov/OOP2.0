/*#include <iostream>
#include <vector>
//по умолчанию универсуум от 0 do 20
using namespace std;
int setQuantity = 0;
template <typename T>
class Set 
{
public:
	Set();
	Set(int size, int start = 0, int end = 20);
	void PrintSet();
	//vector<T>* AutoMadeSet();
	vector<T>* HandMadeSet();
	//методы
private:
	vector<T>* set=nullptr;
	int setSize = 0;
	int setNumber = 0;
};
template <typename T>
Set<T>::Set() 
{
	set = new vector<T>;
}

template <typename T>
Set<T>::Set(int size, int start=0, int end=20)
{
	vector<T>* newSet = new vector<T>;
	for (int i = 0; i < size; i++)
	{
		(*newSet).push_back(rand() % (end - start + 1) + start);
	}
	set = newSet;
	setSize = size;
	setNumber = setQuantity + 1;
	++setQuantity;
}

template<typename T>
vector<T>* AutoMadeSet()
{
	cout << "Введите колличество элемн";
	vector<int> vec;
	return vec;
}
template<typename T>
void Set<T>::PrintSet()
{
	cout<<
	for (int i = 0; i < setSize; i++) 
	{
		cout<<
	}
}

int main() {
	Set<int> set1(4);
	Set<T> 
	system("pause");
	return 0;
}
s*/