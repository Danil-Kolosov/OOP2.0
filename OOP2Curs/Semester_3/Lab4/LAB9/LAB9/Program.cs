using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneySpace;
using ArraySpace;
using InterfaceSpace;
using System.Security.Policy;

namespace Lab9
{
    public class Programm
    {
        public static void Main()
        {
            try
            {
                bool programmRuningKey = true;
                do
                {
                    UserInterface.OutInformation("1. Первая часть");
                    UserInterface.OutInformation("2. Вторая часть");
                    UserInterface.OutInformation("3. Третья часть");
                    UserInterface.OutInformation("4. Выход");
                    int commandID = 0;
                    UserInterface.Input(ref commandID);
                    switch (commandID)
                    {
                        case 1:

                            Part1();
                            break;
                        case 2:
                            Part2();
                            break;
                        case 3:
                            Part3();
                            break;
                        case 4:
                            programmRuningKey = false;
                            break;
                        default:
                            UserInterface.OutInformation("Введены не корректные данные");
                            break;
                    }
                } while (programmRuningKey);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Part1()
        {
            Money m1 = new Money();
            m1.Show();
            m1.Rubles = 5;
            m1.Show();
            m1.Kopeks = 5;
            m1.Show();

            Money m2 = new Money(1, 50);
            m2.Show();

            Money m3 = new Money(1, 150);
            m3.Show();
            Console.WriteLine("Сумма атрибутов 3 объекта = " + m3.Sum());

            Console.WriteLine("\n\nВычитание  статической функцией: ");
            Console.WriteLine("Вычитаем из 2 объекта 5 копеек ");
            Money.SubtractingKopeksStatic(m2, 5);
            m2.Show();
            Console.WriteLine("\nВычитаем из 2 объекта 50 копеек ");
            Money.SubtractingKopeksStatic(m2, 50);
            m2.Show();
            Console.WriteLine("\nВычитаем из 2 объекта 500 копеек ");
            Money.SubtractingKopeksStatic(m2, 500);
            m2.Show();

            Console.WriteLine("\n\nВычитание методом класса: ");
            Console.WriteLine("Вычитаем из 3 объекта 5 копеек ");
            m3.SubtractingKopeks(5);
            m3.Show();
            Console.WriteLine("\nВычитаем из 3 объекта 50 копеек ");
            m3.SubtractingKopeks(50);
            m3.Show();
            Console.WriteLine("\nВычитаем из 3 объекта 500 копеек ");
            m3.SubtractingKopeks(500);
            m3.Show();

            m1 = null;
            m2 = null;
            m3 = null;
        }

        public static void Part2()
        {
            if(Money.CounterObjects == 3)
            {
                //Унарные операции
                Money m1 = new Money(5, 5);
                m1.Show();
                Console.WriteLine("\nВычитаем из 4 объекта с помощью -- ");
                m1--;
                m1.Show();

                Money m2 = new Money(0, 0);
                m2.Show();
                Console.WriteLine("\nВычитаем из 5 объекта с помощью -- ");
                m2--;
                m2.Show();

                Money m3 = new Money(0, 99);
                m3.Show();
                Console.WriteLine("\nПрибавляем к 6 объекту копейку с помощью ++ ");
                m3++;
                m3.Show();

                //Операции приведения типа
                Console.WriteLine("Получаем количество копеек 4 объекта с помощью явного приведения к типу int " + (int)m1);
                Console.WriteLine("Получаем количество копеек 5 объекта с помощью явного приведения к типу int " + (int)m2);
                Console.WriteLine("Получаем знаачение банкрот/не банерот  6 объекта с помощью неявного приведения к типу bool " + (bool)m3);
                Console.WriteLine("Получаем знаачение банкрот/не банерот  5 объекта с помощью неявного приведения к типу bool " + (bool)m2);

                //Бинарные операции
                Console.WriteLine("\nПолучаем 7 объект прибалением к 5 объекту 250 копеек (копейки слева) ");
                Money m4 = m2 + 250;
                m4.Show();

                Console.WriteLine("\nПолучаем 8 объект прибалением к 5 объекту 250 копеек (копейки справа)");
                Money m5 = 250 + m2;
                m5.Show();

                Console.WriteLine("\nСколько копек прибавить к 5 объекту:");
                int kop = 0;
                UserInterface.Input(ref kop);
                Money m = kop + m2;
                m.Show();

                Console.WriteLine("\nПолучаем 10 объект вычитанием из 5 объекта 4 ");
                Money m6 = m2 - m1;
                m6.Show();

                Console.WriteLine("\nПолучаем 11 объект вычитанием из 4 объекта 6");
                Money m7 = m1 - m3;
                m7.Show();
            }
            else 
            { 
                Console.WriteLine("Нужно выбирать части по порядку"); 
            }
        }

        public static void Part3()
        {
            if (Money.CounterObjects == 11)
            {

                Console.WriteLine("Автоматически созданный массив из 5 элементов: ");
                MoneyArray moneyArray1 = new MoneyArray("autoMade", 5);
                moneyArray1.Show();

                Console.WriteLine("Ручное создание массива");
                MoneyArray moneyArray2 = new MoneyArray("handMade");
                moneyArray2.Show();


                Console.WriteLine("\n\nСоздадим автоматически массив из 5 элементов и найдём для него среднее арифметическое");
                MoneyArray moneyArray = new MoneyArray("autoMade", 5);
                double arithmeticMean = moneyArray.ArithmeticMean();
                double arithmeticMeanRub = moneyArray.ArithmeticMeanRub();
                double arithmeticMeanKop = moneyArray.ArithmeticMeanKop();
                moneyArray.Show();
                Console.WriteLine("Среднее арифметическое всех рублей и копеек месте взятых (в рублях): " + arithmeticMean);
                Console.WriteLine("Среднее арифметическое всех рублей: " + arithmeticMeanRub);
                Console.WriteLine("Среднее арифметическое всех копеек: " + arithmeticMeanKop);
                int indexToShow = 0;
                UserInterface.Input(ref indexToShow, 1, moneyArray.Size(), "Введите номер элемента массива, котрый необходимо вывести:");
                moneyArray[indexToShow - 1].Show();

                Console.WriteLine($"\nБыло создано объектов класса Money: {Money.CounterObjects}");
                Console.WriteLine($"\nБыло создано объектов класса MoneyArray: {MoneyArray.CounterObjects}\n\n");
            }
            else
            {
                Console.WriteLine("Нужно выбирать части по порядку");
            }
            }
    }
}
