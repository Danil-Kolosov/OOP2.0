using AnimalLibrary;
using MyCollectionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class Programm
    {
        public static void Main() 
        {
            System.Collections.Hashtable h;
            Console.WriteLine("Создаем пустую коллекцию и вывeдeм ее");
            MyCollection<string, Animal> zoo = new MyCollection<string, Animal>();
            //zoo.Remove(new Animal());
            //zoo.Contains(new Animal());
            zoo.Print();

            Console.WriteLine("\nСоздаем пустую коллекцию из 3 элементов и вывeдeм ее");
            zoo = new MyCollection<string, Animal>(3);
            zoo.Print();
             
            Console.WriteLine("\nДобавляем в хэш таблицу 4 случайно проинициолизированныx объектa животныx и снова вывeдeм");
            Animal bobik = new Animal();
            bobik.RandomInit();
            zoo.Add("bobik 1", bobik);  
            Animal champ = new Animal();
            champ.RandomInit();
            zoo.Add("champ 1", champ);
            Animal champ2 = new Animal();
            champ2.RandomInit();
            zoo.Add("champ 2", champ2);
            Animal champ3 = new Animal();
            champ3.RandomInit();
            zoo.Add("champ 3", champ3);
            zoo.Print();

            Console.WriteLine("\nСозд                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           адим 2 коллекцию на основе предыдущей используя конструктор");
            MyCollection<string, Animal> constructZoo = new MyCollection<string, Animal>(zoo);
            constructZoo.Print();

            Console.WriteLine("\nПри удалении элемента из 2 коллекции, в 1 коллекции он останется");
            constructZoo.Remove(bobik);
            constructZoo.Print();
            Console.WriteLine();
            zoo.Print();

            Console.WriteLine("\nОсуществим поиск удаленного элемента в обех колллекциях с помощью метода Contains");
            if(zoo.ContainsValue(bobik))
                Console.WriteLine("В 1 коллекции объект нашелся");
            else
                Console.WriteLine("В 1 кол                    лекции объект НЕ нашелся");

            if (constructZoo.ContainsValue(bobik))
                Console.WriteLine("Вo 2 коллекции объект нашелся");
            else
                Console.WriteLine("Вo 2 коллекции объект НЕ нашелся");


            Console.WriteLine("\nСоздадим 3 колекцию на основе 1 методом глубокого клонирования");
            MyCollection<string, Animal> deepClonZoo = zoo.DeepCloning();
            deepClonZoo.Print();
            Console.WriteLine("Удалим только что созданную коллекцию с помощью метода Delete");
            deepClonZoo.Delete();
            deepClonZoo.Print();
            Console.WriteLine("Исходная коллекция останется без изменения");
            zoo.Print();

            Console.WriteLine("\nСоздадим 4 коллекцию на основе 1 методом поверхностного копирования");
            MyCollection<string, Animal> copyingZoo = zoo.Copyng();
            copyingZoo.Print();
            Console.WriteLine("Удалим все ее элемнты с помощью метода Clear");
            copyingZoo.Clear();
            copyingZoo.Print();
            Console.WriteLine("Элементы исходной коллекции тоже удалились");
            zoo.Print();

            Console.WriteLine("\nИмея коллекцию:");
            constructZoo.Print();
            Console.WriteLine("С помощью цикла foreach выведем хранящиеся в ней объекты:");
            foreach (KeyValuePair<string, Animal> a in constructZoo) 
            { 
                Console.WriteLine(a.Value); 
            }     
        }

        private void OldMain() 
        {
            //MyCollection<Animal> list = new MyCollection<Animal>(2);
            //list.Add(new Animal());
            //list.Add(new Animal(1, 1, 1, "Тэд", 6));
            //list.Add(new Animal(2, 2, 2, "Стив", 2));
            //list.Print();
            //MyCollection<Animal> nullList = new MyCollection<Animal>();
            //nullList.Print();
            //Console.WriteLine(list.Contains(new Animal()));

            //MyCollection<Animal> realList = new MyCollection<Animal>(3);
            //Animal bobik = new Animal();
            //bobik.RandomInit();
            //realList.Add(bobik);
            //Animal bobik2 = new Animal();
            //bobik2.RandomInit();
            //realList.Add(bobik2);
            //Animal bobik3 = new Animal();
            //bobik3.RandomInit();
            //realList.Add(bobik3);

            //realList.Print();
            //foreach (Animal item in realList) { item.Show(); }

            //realList.Remove(bobik);
            //realList.Print();

            //MyCollection<Animal> copyHash = realList.Copyng();
            //copyHash.Print();

            //Console.WriteLine("Удалили из клона");
            //copyHash.Remove(bobik2);
            //copyHash.Print();
            //realList.Print();

            //Console.WriteLine("Глубоко скопированная колекция");
            //MyCollection<Animal> deepClone = realList.DeepCloning();
            //deepClone.Print();

            //Console.WriteLine("Удалили из глубокого клонирования");
            //deepClone.Remove(bobik3);
            //deepClone.Print();
            //realList.Print();


            //Console.WriteLine("Конструктор копирования");
            //MyCollection<Animal> copyConstruct = new MyCollection<Animal>(realList);
            //copyConstruct.Print();


            //Console.WriteLine("Удалили из скопированного конструктором");
            //copyConstruct.Remove(bobik3); проверкку прошло
            //realList.Print();             работает
        }
    }
}
