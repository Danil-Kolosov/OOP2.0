using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CollectionEvent;
using MyCollectionLibrary;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //TestEventCollections and Journals
        [TestMethod]
        public void TestCount()
        {

            //Arrange - начальные условия
            MyNewCollection<string, int> testCollections = new MyNewCollection<string, int>(0);
            int tReceived;
            int tExpected = 0;
            //Act - проверяемое действие
            tReceived = testCollections.Count;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);

        }


        [TestMethod]
        public void TestJournalAdd()
        {

            //Arrange - начальные условия
            MyNewCollection<string, int> zoo = new MyNewCollection<string, int>(5);
            zoo.Name = "Зоопарк";
            string tReceived;
            string tExpected = "Имя коллекции:Зоопарк\nТип операции:Добавлен\nОбъект: 6\nИмя коллекции:Зоопарк\nТип операции:Добавлен\nОбъект: 2\nИмя коллекции:Зоопарк\nТип операции:Добавлен\nОбъект: 2\n";
            //Act - проверяемое действие
            Journal<int> journal = new Journal<int>();
            zoo.CollectionCountChanged += (sourcer, args) => journal.Add(new JournalEntry<int>(args.Name, args.Type, args.ObjectData));
            zoo.CollectionReferenceChanged += (sourcer, args) => journal.Add(new JournalEntry<int>(args.Name, args.Type, args.ObjectData));

            Journal<int> eitherRefChangEvent = new Journal<int>();
            zoo.CollectionReferenceChanged += (sourcer, args) => eitherRefChangEvent.Add(new JournalEntry<int>(args.Name, args.Type, args.ObjectData));

            zoo.Add("шесть", 6);
            zoo.Add(new KeyValuePair<string, int>("два", 2));

            tReceived = journal.ToString();
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestJournalRemove()
        {

            //Arrange - начальные условия
            MyNewCollection<string, int> zoo = new MyNewCollection<string, int>(5);
            zoo.Name = "Зоопарк";
            string tReceived;
            string tExpected = "Имя коллекции:Зоопарк\nТип операции:Добавлен\nОбъект: 6\nИмя коллекции:Зоопарк\n" +
                "Тип операции:Добавлен\nОбъект: 2\nИмя коллекции:Зоопарк\nТип операции:Добавлен\nОбъект: 2\n" +
                "Имя коллекции:Зоопарк\nТип операции:Добавлен\nОбъект: 3\nИмя коллекции:Зоопарк\nТип операции:Добавлен\n" +
                "Объект: 3\nИмя коллекции:Зоопарк\nТип операции:Добавлен\nОбъект: 4\nИмя коллекции:Зоопарк\n" +
                "Тип операции:Добавлен\nОбъект: 4\nИмя коллекции:Зоопарк\nТип операции:Удален\nОбъект: 6\n" +
                "Имя коллекции:Зоопарк\nТип операции:Удален\nОбъект: 3\nИмя коллекции:Зоопарк\nТип операции:Удален\n" +
                "Объект: 3\nИмя коллекции:Зоопарк\nТип операции:Заменен\nОбъект: 5\n";
            //Act - проверяемое действие
            Journal<int> journal = new Journal<int>();
            zoo.CollectionCountChanged += (sourcer, args) => journal.Add(new JournalEntry<int>(args.Name, args.Type, args.ObjectData));
            zoo.CollectionReferenceChanged += (sourcer, args) => journal.Add(new JournalEntry<int>(args.Name, args.Type, args.ObjectData));

            Journal<int> eitherRefChangEvent = new Journal<int>();
            zoo.CollectionReferenceChanged += (sourcer, args) => eitherRefChangEvent.Add(new JournalEntry<int>(args.Name, args.Type, args.ObjectData));

            zoo.Add("шесть", 6);
            zoo.Add(new KeyValuePair<string, int>("два", 2));
            zoo.Add(new KeyValuePair<string, int>("три", 3));
            zoo.Add(new KeyValuePair<string, int>("четыре", 4));
            zoo.Remove("шесть");
            zoo.Remove(2);
            zoo.Remove(new KeyValuePair<string, int>("три", 3));
            zoo["четыре"] = 5;

            tReceived = journal.ToString();
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }        
    }
}
