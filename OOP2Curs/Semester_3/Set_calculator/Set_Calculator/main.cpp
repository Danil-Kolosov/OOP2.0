#include <iostream>
#include <vector>
#include <string>
using namespace std;

class Set 
{
public:
	Set();
	~Set();
	Set(int, int, int);
	void PrintSet(int);
	void PrintAllSets();
	void MadeSet();
	void AutoMadeSet();
	void HandMadeSet();
	void SetIntersection(int,int, int);
	void SetAssociation(int, int, int);
	void SetDifference(int, int, int);
	void SetSymmetricalDifference(int, int);
	void SetAddition(int);
	void IsSetInSet(int, int);
	bool FindElement(int, vector<int>*);
	void SetUniversalSet();
	void DeleteSet();
	void CheckInput(int&);
	void CheckInput(string&);
	void manageOperations(int);
	void startMenu();
private:
	vector<vector<int>*> set;
	vector<int> universalSet;
	string alphavit = "ABCDEFGHIGKLMNOPQRSTUVWXYZ";
};
Set::Set() 
{
}
Set::~Set()
{
	for (int i = 0; i < set.size(); i++)
		delete set[i];
}
Set::Set(int setSize=0, int start=0, int end=20)
{

}
bool Set::FindElement(int element, vector<int>* currentSet)
{
	for (int i = 0; i < currentSet->size(); i++)
	{
		if ((*currentSet)[i] == element)
			return true;
	}
	return false;
}
void Set::CheckInput(string& neededInput)
{
	bool flag = true;
	while(flag)
	{
		cin >> neededInput;
		for (int i = 0; i < alphavit.size(); i++)
		{
			bool result = alphavit.find(neededInput)<set.size();
			if (neededInput[0] == alphavit[i])
				if (result)
					flag = false;
		}
		if (flag)
			cout << "Ошибка. Введены не корректные данные\n";
	}
}
void Set::CheckInput(int& neededInput)
{
	double input=1.1;
	bool fl = true;
	while (fl)
	{
		if(!(cin >> input))
			cout << "Ошибка. Введены не корректные данные\n" << endl;
		else if ((input - int(input) != 0) && !FindElement(int(input),&universalSet))
			cout << "Ошибка. Введены не корректные данные\n" << endl;
		else
			fl = false;
		cin.clear();
		cin.ignore(numeric_limits<streamsize>::max(), '\n');//очищаем буфер введённых данных
	}
	neededInput = int(input);
}
void Set::SetUniversalSet()
{
	universalSet.clear();
	cout << "Введите количество элементов универсального множества: ";
	int universalSetSize;
	CheckInput(universalSetSize);
	cout << "Задать универсальное множесто:"<<endl<<"1. Вводом с клавиатуры\n2. Автоматически\n";
	int answerCode1,answerCode2;
	CheckInput(answerCode1);
	srand(time(NULL));
	switch(answerCode1)
	{
		int element;
		case 1:
		{
			cout << "1. Диапозоном\n2. Отдельными элементами\n";
			CheckInput(answerCode2);
			switch (answerCode2)
			{
			case 1: 
			{
				int start, end;
				cout << "Введите верхний и нижний диапозоны: "<<endl;
				do
				{
					CheckInput(start);
					CheckInput(end);
					if (end - start > universalSetSize)
						cout << "Выбран слишком большой диапозон для заданого колличества элементов"<<endl;
				}
				while (end - start > universalSetSize);
				for (int i = start; i < end + 1; i++)
				{
					universalSet.push_back(i);
				}
				break;
			}
			case 2: 
			{
				cout << "Вводите элементы: ";
				for (int i = 0; i < universalSetSize; i++)
				{
					CheckInput(element);
					if (!FindElement(element, &universalSet))
						universalSet.push_back(element);
					else
					{
						cout << "Был введён повторяющийся элемент";
						i--;
					}
				}
				break;
			}

		}
		break;
		}
		case 2:
		{
			for (int i = 0; i < universalSetSize; i++)
			{
				element= rand() % (0 - 21 + 1) + 21;
				if (!FindElement(element, &universalSet))
					universalSet.push_back(element);
				else
					i--;
			}
			break;
		}
		default:
			cout << "Ошибка. Введены не корректные данные\n";
			SetUniversalSet();
			break;
	}
	cout << "Следующеe множество задано как универсум: " << universalSet[0];
	for(int i=1;i<universalSet.size();i++)
	{
		cout << " " << universalSet[i];
	}
	cout << endl;
}
void Set::MadeSet()
{
	if (universalSet.size() == 0)
		cout << "Сначала нужно задать универсальное множество\n";
	else
	{
		cout << "1. Вводом с клавиатуры\n2. Автоматически\n";
		int command;
		CheckInput(command);
		switch (command)
		{
		case 1:
			HandMadeSet();
			PrintSet(set.size());
			break;
		case 2:
			AutoMadeSet();
			PrintSet(set.size());
			break;
		default:
			cout << "Введено не корректное значение";
			MadeSet();
			break;
		}
	}
}
void Set::AutoMadeSet()
{
	vector<int>* newSet = new vector<int>;
	int setSize;
	int startUniversum = 0;
	int endUniversum = 20;
	string answer = "";
	do 
	{
		cout << "Введите количество элементов в множестве: ";
		CheckInput(setSize);
		if (setSize > universalSet.size())
		{
			cout << "Количество элементов в множестве не может превышать колличесвто элементов универсального множества\n";
			setSize = -1;
		}
	} while (setSize < 0);
	srand(time(NULL));
	
	for (int i = 0; i < setSize; i++)
	{
		int randomIndex = rand() % ((universalSet.size()-1) - 0 + 1) + 0;
		if (!FindElement(universalSet[randomIndex], newSet))
			(*newSet).push_back(universalSet[randomIndex]);
		else
			i--;
	}
	set.push_back(newSet);
}
void Set::PrintSet(int currentNumber)
{
	int setIndex = currentNumber - 1;
	
	int setSize = set[setIndex]->size();
	cout << endl;
	if (setSize == 0)
		cout << "Множество " << alphavit[setIndex] << ": " << "Пустое множество";
	else
	{
		
		cout << "Множество " << alphavit[setIndex] << ": " << (*set[setIndex])[0];
		for (int i = 1; i < setSize; i++)
		{
			cout << ' ' << (*set[setIndex])[i];
		}
	}
	cout << endl;
	
}
void Set::HandMadeSet()
{
	int setSize;
	int element;
	int startUniversum = 0;
	int endUniversum = 20;
	do
	{
		cout << "Введите количество элементов в множестве: ";
		CheckInput(setSize);
		if (setSize > universalSet.size())
		{
			cout << "Количество элементов в множестве не может превышать количество элементов универсального множества\n";
			setSize = -1;
		}
	} while (setSize < 0);
	vector<int>* newSet = new vector<int>{};
	cout << "Введите элементы множества:" << endl;
	for (int i = 0; i < setSize; i++)
	{
		CheckInput(element);
		if (FindElement(element,&universalSet) && !FindElement(element, newSet))
			newSet->push_back(element);
		else
		{
			i = i - 1;
			cout << "Ошибка. некореектный ввод\n";
		}
	}
	set.push_back(newSet);
}
void Set::SetIntersection(int setNumber1, int setNumber2, int comand=0)
{
	if (set.size() == 0 || set.size() == 1)
		cout << "Для данной операции необходимо хотябы 2 множества\n";
	else
	{
		int setIndex1 = setNumber1 - 1;
		int setIndex2 = setNumber2 - 1;
		vector<int>* newSet = new vector<int>;
		for (int i = 0; i < set[setIndex1]->size(); i++)
		{
			for (int j = 0; j < set[setIndex2]->size(); j++)
			{
				if ((*set[setIndex1])[i] == (*set[setIndex2])[j] && !FindElement((*set[setIndex1])[i], newSet))
				{
					newSet->push_back((*set[setIndex1])[i]);
				}
			}
		}
		set.push_back(newSet);
		if (comand == 0)
		{
			cout << "Результат пересечения множеств " << alphavit[setIndex1] << " и " << alphavit[setIndex2] << " равен:";
			PrintSet(set.size());
		}
	}
}
void Set::SetAssociation(int setNumber1, int setNumber2,int comand=0)
{
	if (set.size() == 0 || set.size() == 1)
		cout << "Для данной операции необходимо хотябы 2 множества\n";
	else
	{
		int setIndex1 = setNumber1 - 1;
		int setIndex2 = setNumber2 - 1;
		vector<int>* newSet = new vector<int>;
		for (int i = 0; i < set[setIndex1]->size(); i++)
		{
			newSet->push_back((*set[setIndex1])[i]);
		}
		for (int i = 0; i < set[setIndex2]->size(); i++)
		{
			for (int j = 0; j < set[setIndex1]->size(); j++)
			{
				if (!FindElement((*set[setIndex2])[i], newSet))
				{
					newSet->push_back((*set[setIndex2])[i]);
				}
			}
		}
		set.push_back(newSet);
		if(comand==0)
		{
			cout << "Результат объединения множеств " << alphavit[setIndex1] << " и " << alphavit[setIndex2] << " равен:";
			PrintSet(set.size());
		}
	}
}
void Set::SetDifference(int setNumber1, int setNumber2, int comand=0)
{
	if (set.size() == 0 || set.size() == 1)
		cout << "Для данной операции необходимо хотя бы 2 множества\n";
	else
	{
		int setIndex1 = setNumber1 - 1;
		int setIndex2 = setNumber2 - 1;
		vector<int>* newSet = new vector<int>{};
		for (int i = 0; i < set[setIndex1]->size(); i++)
		{
			if (!FindElement((*set[setIndex1])[i], set[setIndex2]))
			{
				newSet->push_back((*set[setIndex1])[i]);
			}
		}

		set.push_back(newSet);
		if (comand == 0)
		{
			cout << "Результат разности множеств " << alphavit[setIndex1] << " и " << alphavit[setIndex2] << " равен:";
			PrintSet(set.size());
		}
	}
}
void Set::SetSymmetricalDifference(int setNumber1, int setNumber2)
{
	if (set.size() == 0 || set.size() == 1)
		cout << "Для данной операции необходимо хотябы 2 множества\n";
	else
	{
		int setIndex1 = setNumber1 - 1;
		int setIndex2 = setNumber2 - 1;
		vector<int>* newSet = new vector<int>{};

		SetAssociation(setNumber1, setNumber2, 1);
		SetIntersection(setNumber1, setNumber2, 1);
		SetDifference(set.size() - 1, set.size(), 1);
		for (int i = 0; i < (set[set.size() - 1])->size(); i++)
		{
			newSet->push_back((*set[set.size() - 1])[i]);
		}
		delete set[set.size() - 2];
		delete set[set.size() - 1];
		set.erase(set.begin() + (set.size() - 2));
		set.erase(set.begin() + (set.size() - 1));
		set.push_back(newSet);
		cout << "Результат симметрической разности множеств " << alphavit[setIndex1] << " и " << alphavit[setIndex2] << " равен:";
		PrintSet(set.size());
	}
	//* - +
}
void Set::SetAddition(int setNumber)
{
	if (set.size() == 0)
		cout << "Ни одно множество ещё не создано\n";
	else
	{
		vector<int>* newSet = new vector<int>{};
		int setIndex = setNumber - 1;
		for (int i = 0; i < universalSet.size(); i++)
		{
			if (!FindElement(universalSet[i], set[setIndex]))
				newSet->push_back(universalSet[i]);
		}
		set.push_back(newSet);
		cout << "Результат дополнения множества " << alphavit[setIndex] << " равен:";
		PrintSet(set.size());
	}
}
void Set::IsSetInSet(int setNumber1, int setNumber2)
{
	if (set.size() == 0 || set.size() == 1)
		cout << "Для данной операции необходимо хотябы 2 множества\n";
	else
	{
		int setIndex1 = setNumber1 - 1;
		int setIndex2 = setNumber2 - 1;
		bool flag = true;
		for (int i = 0; i < set[setIndex1]->size() && flag; i++)
		{
			if (!FindElement((*set[setIndex1])[i], set[setIndex2]))
				flag = false;
		}
		if (flag)
		{
			PrintSet(setNumber1);
			cout << "входит в";
			PrintSet(setNumber2);
		}
		else
		{
			PrintSet(setNumber1);
			cout << "не входит в";
			PrintSet(setNumber2);
		}
	}
}
void Set::DeleteSet()
{
	if (set.size() == 0)
		cout << "Ни одно множество ещё не создано\n";
	else
	{
		string number1;
		cout << "Введите название множества, которое необходимо удалить: ";
		CheckInput(number1);
		delete set[alphavit.find(number1)];
		set.erase(set.begin() + alphavit.find(number1));
	}
}
void Set::PrintAllSets()
{
	if (set.size() == 0)
		cout << "Ни одно множество ещё не создано\n";
	else
	{
		cout << "Универсальное множество U: "<< universalSet[0];
		for (int i = 1; i < universalSet.size(); i++)
			cout << ' ' << universalSet[i];
		for (int i = 1; i <= set.size(); i++)
			PrintSet(i);
	}
}

void Set::manageOperations(int id)
{
	if(id==8)
	{
		if (set.size() == 0 || set.size() == 1)
			cout << "Для данной операции необходимо хотябы 2 множества\n";
		else
		{
			string number1;
			cout << "Введите название множества: ";
			CheckInput(number1);
			SetAddition(alphavit.find(number1) + 1);
		}
	}
	else if (id==9) 
		{
		if (set.size() == 0)
			cout << "Ни одно множество ещё не создано\n";
		else
		{
			int element;
			cout << "Введите элемент для поиска: ";
			CheckInput(element);
			cout << "Ввеите название множества: ";
			string number;
			CheckInput(number);
			if (FindElement(element, set[alphavit.find(number)]))
				cout << "Элемент " << element << " входит в множество " << number << endl;
			else
				cout << "Элемент " << element << " не входит в множество " << number << endl;
		}
	}
	else
	{
		if (set.size() == 0 || set.size() == 1)
			cout << "Для данной операции необходимо хотябы 2 множества\n";
		else
		{
			string number1, number2;
			cout << "Введите название первого множества: ";
			CheckInput(number1);
			cout << "Введите название второго множества: ";
			CheckInput(number2);
			switch (id)
			{
			case 4:
				SetIntersection(alphavit.find(number1) + 1, alphavit.find(number2) + 1);
				break;
			case 5:
				SetAssociation(alphavit.find(number1) + 1, alphavit.find(number2) + 1);
				break;
			case 6:
				SetDifference(alphavit.find(number1) + 1, alphavit.find(number2) + 1);
				break;
			case 7:
				SetSymmetricalDifference(alphavit.find(number1) + 1, alphavit.find(number2) + 1);
				break;
			case 10:
				IsSetInSet(alphavit.find(number1) + 1, alphavit.find(number2) + 1);
				break;
			}
		}
	}
}
void Set::startMenu()
{
	bool running = true;
	while(running)
	{
		cout << "1.  Задать универсальное множество\n2.  Создать новое множество\n3.  Вывести все множества\n";
		cout << "4.  Пересечь два множества \n5.  Объединить два множества\n6.  Вычесть из одного множества другое\n";
		cout << "7.  Выполнить симметрическую разность двух множеств\n8.  Найти дополнение множества\n";
		cout << "9.  Определить входит ли элемент в множество\n10. Определить входит ли одно подмножество в другое\n";
		cout << "11. Удалить множество\n12. Выйти из программы\n";
		int command;
		CheckInput(command);
		switch (command)
		{
		case 1:
			SetUniversalSet();
			break;
		case 2:
			MadeSet();
			break;
		case 3:
			PrintAllSets();
			break;
			{
		case 4:
			manageOperations(4);
			break;
		case 5:
			manageOperations(5);
			break;
		case 6:
			manageOperations(6);
			break;
		case 7:
			manageOperations(7);
			break;
		case 8:
			manageOperations(8);
			break;
		case 9:
			manageOperations(9);
			break;
		case 10:
			manageOperations(10);
			break;
		case 11:
			DeleteSet();
			break;
		case 12:
			running = false;
			break;
			}
		}
		cout << endl << endl;
	}
}

int main() {

	Set set1(0);
	set1.startMenu();
	system("pause");
	return 0;
}
