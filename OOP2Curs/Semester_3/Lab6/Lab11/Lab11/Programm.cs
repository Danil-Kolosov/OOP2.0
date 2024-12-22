using AnimalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    internal class Programm
    {
        public static void Main() 
        {
            TestCollections testCollections = new TestCollections(1000);
            testCollections.Add(new AnimalLibrary.Mammal());
            testCollections.Delete(new AnimalLibrary.Mammal());
            //testCollections.Searching();
            Searching(testCollections);

        }
        public static void Searching(TestCollections testCollections)
        {
            Console.WriteLine("Ищем первый элемент в list с типом - Mammal" 
                + testCollections.SearchingTimeList1(new Mammal(testCollections.List1First)));
            Console.WriteLine("Ищем средний элемент в list с типом - Mammal" 
                + testCollections.SearchingTimeList1(new Mammal(testCollections.List1Medium)));
            Console.WriteLine("Ищем последний элемент в list с типом - Mammal" 
                + testCollections.SearchingTimeList1(new Mammal(testCollections.List1Last)));
            Console.WriteLine("Ищем не существующий элемент в list с типом - Mammal" 
                + testCollections.SearchingTimeList1(new Mammal()));

            Console.WriteLine();

            Console.WriteLine("Ищем первый элемент в list с типом - string" 
                + testCollections.SearchingTimeList2(testCollections.List2First));
            Console.WriteLine("Ищем средний элемент в list с типом - string" 
                + testCollections.SearchingTimeList2(testCollections.List2Medium));
            Console.WriteLine("Ищем последний элемент в list с типом - string" 
                + testCollections.SearchingTimeList2(testCollections.List2Last));
            Console.WriteLine("Ищем не существующий элемент в list с типом - string" 
                + testCollections.SearchingTimeList2((new Mammal()).ToString()));

            Console.WriteLine();

            Console.WriteLine("Ищем с помощью ContainsKey");
            //В словарях используется функция получения хэш кода - без ее переопределения работать не будет
            //Потому что славарь на самомо деле - хэш таблица с навешаными функциями
            Console.WriteLine("Ищем первый элемент в dictionary с ключом - Animal" 
                + testCollections.SearchingTimeDictionary1(new Animal(testCollections.Dictionary1FirstKey)));
            Console.WriteLine("Ищем средний элемент в dictionary с ключом - Animal" 
                + testCollections.SearchingTimeDictionary1(new Animal(testCollections.Dictionary1MediumKey)));
            Console.WriteLine("Ищем последний элемент в dictionary с ключом - Animal" 
                + testCollections.SearchingTimeDictionary1(new Animal(testCollections.Dictionary1LastKey)));
            Console.WriteLine("Ищем не существующий элемент в list с типом - string" 
                + testCollections.SearchingTimeDictionary1(new Animal()));

            Console.WriteLine();

            Console.WriteLine("Ищем первый элемент в dictionary с ключом - string" 
                + testCollections.SearchingTimeDictionary2Key(testCollections.Dictionary2FirstKey)); //для поиска по ключу: dictionary2[list2[0]].ToString()
            Console.WriteLine("Ищем средний элемент в dictionary с ключом - string" 
                + testCollections.SearchingTimeDictionary2Key(testCollections.Dictionary2MediumKey));//для поиска по ключу: dictionary2[list2[(list2.Count / 2) - 1]].ToString()
            Console.WriteLine("Ищем последний элемент в dictionary с ключом - string" 
                + testCollections.SearchingTimeDictionary2Key(testCollections.Dictionary2LastKey)); //для поиска по ключу: dictionary2[list2[list2.Count - 1]].ToString()
            Console.WriteLine("Ищем не существующий элемент в list с типом - string" 
                + testCollections.SearchingTimeDictionary2Key("neturrrrrrrerr"));

            Console.WriteLine();

            Console.WriteLine("Ищем с помощью ContainsValue");
            Console.WriteLine("Ищем первый элемент в dictionary с ключом - string" 
                + testCollections.SearchingTimeDictionary2Val(new Mammal(testCollections.Dictionary2FirstValue)));
            Console.WriteLine("Ищем средний элемент в dictionary с ключом - string" 
                + testCollections.SearchingTimeDictionary2Val(new Mammal(testCollections.Dictionary2MediumValue)));
            Console.WriteLine("Ищем последний элемент в dictionary с ключом - string" 
                + testCollections.SearchingTimeDictionary2Val(new Mammal(testCollections.Dictionary2LastValue)));
            Console.WriteLine("Ищем не существующий элемент в list с типом - string" 
                + testCollections.SearchingTimeDictionary2Val(new Mammal()));
        }
    }
}
