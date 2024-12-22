using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Policy;
using AnimalLibrary;
using System.Collections.Generic;
using Lab11;
namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        //TestCollections
        [TestMethod]
        public void TestMethodTestCollectionsAdd()
        {
            //Arrange - начальные условия
            TestCollections testCollections = new TestCollections(1);
            int tReceived;
            int tExpected = 2;
            //Act - проверяемое действие
            testCollections.Add(new Mammal());
            tReceived = testCollections.Count;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestMethodTestCollectionsDelete()
        {
            //Arrange - начальные условия
            TestCollections testCollections = new TestCollections(1);
            int tReceived;
            int tExpected = 1;
            //Act - проверяемое действие
            testCollections.Add(new Mammal());
            testCollections.Delete(new Mammal());
            tReceived = testCollections.Count;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestMethodTestCollectionsFirstList1()
        {
            //Arrange - начальные условия
            TestCollections testCollections = new TestCollections(0);
            Mammal tReceived;
            Mammal tExpected = new Mammal();
            //Act - проверяемое действие
            testCollections.Add(new Mammal());
            tReceived = testCollections.List1First;           
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestMethodTestCollectionsList1Medium()
        {
            //Arrange - начальные условия
            TestCollections testCollections = new TestCollections(1);
            Mammal tReceived;
            Mammal tExpected = new Mammal();
            //Act - проверяемое действие
            testCollections.Add(new Mammal());
            testCollections.Add(new Mammal(1, 1, 1, "1", "1", "1", "1", "1"));
            tReceived = testCollections.List1Medium;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestMethodTestCollectionsList1Last()
        {
            //Arrange - начальные условия
            TestCollections testCollections = new TestCollections(2);
            Mammal tReceived;
            Mammal tExpected = new Mammal();
            //Act - проверяемое действие
            testCollections.Add(new Mammal());
            tReceived = testCollections.List1Last;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestMethodTestCollectionsList2First()
        {
            //Arrange - начальные условия
            TestCollections testCollections = new TestCollections(0);
            string tReceived;
            string tExpected = new Mammal().ToString();
            //Act - проверяемое действие
            testCollections.Add(new Mammal());
            tReceived = testCollections.List2First;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestMethodTestCollectionsList2Medium()
        {
            //Arrange - начальные условия
            TestCollections testCollections = new TestCollections(1);
            string tReceived;
            string tExpected = new Mammal().ToString();
            //Act - проверяемое действие
            testCollections.Add(new Mammal());
            testCollections.Add(new Mammal(1, 1, 1, "1", "1", "1", "1", "1"));
            tReceived = testCollections.List2Medium;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestMethodTestCollectionsList2Last()
        {
            //Arrange - начальные условия
            TestCollections testCollections = new TestCollections(2);
            string tReceived;
            string tExpected = new Mammal().ToString();
            //Act - проверяемое действие
            testCollections.Add(new Mammal());
            tReceived = testCollections.List2Last;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestMethodTestCollectionsDictionary1First()
        {
            //Arrange - начальные условия
            TestCollections testCollections = new TestCollections(0);
            Animal tReceived;
            Animal tExpected = new Animal();
            //Act - проверяемое действие
            testCollections.Add(new Mammal());
            tReceived = testCollections.Dictionary1FirstKey;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestMethodTestCollectionsDictionary1Medium()
        {
            //Arrange - начальные условия
            TestCollections testCollections = new TestCollections(1);
            Animal tReceived;
            Animal tExpected = new Animal();
            //Act - проверяемое действие
            testCollections.Add(new Mammal());
            testCollections.Add(new Mammal(1, 1, 1, "1", "1", "1", "1", "1"));
            tReceived = testCollections.Dictionary1MediumKey;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestMethodTestCollectionsDictionary1Last()
        {
            //Arrange - начальные условия
            TestCollections testCollections = new TestCollections(2);
            Animal tReceived;
            Animal tExpected = new Animal();
            //Act - проверяемое действие
            testCollections.Add(new Mammal());
            tReceived = testCollections.Dictionary1LastKey;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestMethodTestCollectionsDictionary2FirstKey()
        {
            //Arrange - начальные условия
            TestCollections testCollections = new TestCollections(0);
            string tReceived;
            string tExpected;
            //Act - проверяемое действие
            Mammal mamm = new Mammal();
            tExpected = mamm.BaseAnimal.ToString();
            testCollections.Add(mamm);
            tReceived = testCollections.Dictionary2FirstKey;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestMethodTestCollectionsDictionary2MediumKey()
        {
            //Arrange - начальные условия
            TestCollections testCollections = new TestCollections(1);
            string tReceived;
            string tExpected;
            //Act - проверяемое действие
            Mammal mamm = new Mammal();
            tExpected = mamm.BaseAnimal.ToString();
            testCollections.Add(mamm);
            //testCollections.Add(new Mammal());
            testCollections.Add(new Mammal(1, 1, 1, "1", "1", "1", "1", "1"));
            tReceived = testCollections.Dictionary2MediumKey;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestMethodTestCollectionsDictionary2LastKey()
        {
            //Arrange - начальные условия
            TestCollections testCollections = new TestCollections(2);
            string tReceived;
            string tExpected = new Animal().ToString();
            //Act - проверяемое действие
            testCollections.Add(new Mammal());
            tReceived = testCollections.Dictionary2LastKey;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestMethodTestCollectionsDictionary2FirstVal()
        {
            //Arrange - начальные условия
            TestCollections testCollections = new TestCollections(0);
            Mammal tReceived;
            Mammal tExpected = new Mammal();
            //Act - проверяемое действие
            testCollections.Add(new Mammal());
            tReceived = testCollections.Dictionary2FirstValue;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestMethodTestCollectionsDictionary2MediumVal()
        {
            //Arrange - начальные условия
            TestCollections testCollections = new TestCollections(1);
            Mammal tReceived;
            Mammal tExpected = new Mammal();
            //Act - проверяемое действие
            testCollections.Add(new Mammal());
            testCollections.Add(new Mammal(1, 1, 1, "1", "1", "1", "1", "1"));
            tReceived = testCollections.Dictionary2MediumValue;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestMethodTestCollectionsDictionary2LastVal()
        {
            //Arrange - начальные условия
            TestCollections testCollections = new TestCollections(2);
            Mammal tReceived;
            Mammal tExpected = new Mammal();
            //Act - проверяемое действие
            testCollections.Add(new Mammal());
            tReceived = testCollections.Dictionary2LastValue;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        //Animal tests
        [TestMethod]
        public void TestMethodAnimalProperties1()
        {
            //Arrange - начальные условия
            Animal aReceived = new Animal();
            Animal aExpected = new Animal(1, 1, 1, "1");
            //Act - проверяемое действие
            aReceived.Age = 1;
            aReceived.Weight = 1;
            aReceived.Height = 1;
            aReceived.Name = "1";
            //Assert - верификация результатов
            Assert.AreEqual(aExpected, aReceived);
        }

        [TestMethod]
        public void TestMethodAnimalProperties2()
        {

            string aReceived;
            string aExpected = "Запись";

            Animal an = new Animal();
            an.Note = "Запись";
            aReceived = an.Note;

            Assert.AreEqual(aExpected, aReceived);
        }

        //[TestMethod]
        //public void TestMethodAnimalProperties3()
        //{

        //    string aReceived;
        //    string aExpected = "Запись";

        //    Animal an = new Animal();
        //    an.Note = "Запись";
        //    aReceived = an.Note;

        //    Assert.AreEqual(aExpected, aReceived);
        //}

        [TestMethod]
        public void TestMethodAnimalCloneConstructor()
        {

            Animal aReceived;
            Animal aExpected = new Animal(1, 1, 1, "1");

            aReceived = new Animal(aExpected);

            Assert.AreEqual(aExpected, aReceived);
        }

        [TestMethod]
        public void TestMethodAnimalSuperficialCopy()
        {

            Animal aReceived;
            Animal aExpected = new Animal(1, 1, 1, "Клон 1");

            Animal an = new Animal(1, 1, 1, "1");
            aReceived = an.SuperficialCopy();

            Assert.AreEqual(aExpected, aReceived);
        }

        [TestMethod]
        public void TestMethodAnimalCompareTo()
        {

            int aReceived;
            int aExpected = 0;

            Animal an1 = new Animal(1, 1, 1, "1");
            Animal an2 = (Animal)an1.Clone();
            aReceived = an1.CompareTo(an2);

            Assert.AreEqual(aExpected, aReceived);
        }

        [TestMethod]
        public void TestMethodAnimalCompareToTypeExeption()
        {
            string aExpected = "Переданный параметр имеет недопустимый тип";

            Animal an1 = new Animal(1, 1, 1, "1");
            List<int> lst = new List<int> { 2 };
            var ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                an1.CompareTo(lst);
            });

            Assert.AreEqual(ex.Message, aExpected);
        }


        //Mammal tests
        [TestMethod]
        public void TestMethodMammalProperties1()
        {
            //Arrange - начальные условия
            Mammal aReceived = new Mammal();
            Mammal aExpected = new Mammal(1, 1, 1, "1", "1", "1", "1", "1");
            //Act - проверяемое действие
            aReceived.Age = 1;
            aReceived.Weight = 1;
            aReceived.Height = 1;
            aReceived.Name = "1";
            aReceived.LivingEnvironment = "1";
            aReceived.Lifestyle = "1";
            aReceived.Location = "1";
            aReceived.Specie = "1";
            //Assert - верификация результатов
            Assert.AreEqual(aExpected, aReceived);
        }

        [TestMethod]
        public void TestMethodMammalProperties2()
        {

            string aReceived;
            string aExpected = "Запись";

            Mammal an = new Mammal();
            an.Note = "Запись";
            aReceived = an.Note;

            Assert.AreEqual(aExpected, aReceived);
        }

        [TestMethod]
        public void TestMethodMammalCloneConstructor()
        {

            Mammal aReceived;
            Mammal aExpected = new Mammal(1, 1, 1, "1", "1", "1", "1", "1");

            aReceived = new Mammal(aExpected);

            Assert.AreEqual(aExpected, aReceived);
        }

        //[TestMethod]//раскоментрировать***
        //public void TestMethodMammalSuperficialCopy()
        //{

        //    Mammal aReceived;
        //    Mammal aExpected = new Mammal(1, 1, 1, "1", "1", "1", "1", "1");

        //    Mammal an = new Mammal(1, 1, 1, "1", "1", "1", "1", "1");
        //    aReceived = an.SuperficialCopy();

        //    Assert.AreEqual(aExpected, aReceived);
        //}

        [TestMethod]
        public void TestMethodMammalCompareTo()
        {

            int aReceived;
            int aExpected = 0;

            Mammal an1 = new Mammal(1, 1, 1, "1", "1", "1", "1", "1");
            Mammal an2 = (Mammal)an1.Clone();
            aReceived = an1.CompareTo(an2);

            Assert.AreEqual(aExpected, aReceived);
        }

        [TestMethod]
        public void TestMethodMammalCompareToTypeExeption()
        {
            string aExpected = "Переданный параметр имеет недопустимый тип";

            Mammal an1 = new Mammal(1, 1, 1, "1", "1", "1", "1", "1");
            List<int> lst = new List<int> { 2 };
            var ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                an1.CompareTo(lst);
            });

            Assert.AreEqual(ex.Message, aExpected);
        }


        //Artiodactyl tests
        [TestMethod]
        public void TestMethodArtiodactylProperties1()
        {
            //Arrange - начальные условия
            Artiodactyl aReceived = new Artiodactyl();
            Artiodactyl aExpected = new Artiodactyl(1, 1, 1, "1", "1", "1", "1", "1", 1, 1);
            //Act - проверяемое действие
            aReceived.Age = 1;
            aReceived.Weight = 1;
            aReceived.Height = 1;
            aReceived.Name = "1";
            aReceived.LivingEnvironment = "1";
            aReceived.Lifestyle = "1";
            aReceived.Location = "1";
            aReceived.Specie = "1";
            aReceived.HoofSize = 1;
            aReceived.HornsSize = 1;
            //Assert - верификация результатов
            Assert.AreEqual(aExpected, aReceived);
        }

        [TestMethod]
        public void TestMethodArtiodactylProperties2()
        {

            string aReceived;
            string aExpected = "Запись";

            Artiodactyl an = new Artiodactyl();
            an.Note = "Запись";
            aReceived = an.Note;

            Assert.AreEqual(aExpected, aReceived);
        }

        [TestMethod]
        public void TestMethodArtiodactylCloneConstructor()
        {

            Artiodactyl aReceived;
            Artiodactyl aExpected = new Artiodactyl(1, 1, 1, "1", "1", "1", "1", "1", 1, 1);

            aReceived = new Artiodactyl(aExpected);

            Assert.AreEqual(aExpected, aReceived);
        }

        [TestMethod]
        public void TestMethodArtiodactylSuperficialCopy()
        {

            Artiodactyl aReceived;
            Artiodactyl aExpected = new Artiodactyl(1, 1, 1, "Клон 1", "1", "1", "1", "1", 1, 1);

            Artiodactyl an = new Artiodactyl(1, 1, 1, "1", "1", "1", "1", "1", 1, 1);
            aReceived = (Artiodactyl)an.SuperficialCopy();

            Assert.AreEqual(aExpected, aReceived);
        }

        [TestMethod]
        public void TestMethodArtiodactylCompareTo()
        {

            int aReceived;
            int aExpected = 0;

            Artiodactyl an1 = new Artiodactyl(1, 1, 1, "1", "1", "1", "1", "1", 1, 1);
            Artiodactyl an2 = (Artiodactyl)an1.Clone();
            aReceived = an1.CompareTo(an2);

            Assert.AreEqual(aExpected, aReceived);
        }

        [TestMethod]
        public void TestMethodArtiodactylCompareToTypeExeption()
        {
            string aExpected = "Переданный параметр имеет недопустимый тип";

            Artiodactyl an1 = new Artiodactyl(1, 1, 1, "1", "1", "1", "1", "1", 1, 1);
            List<int> lst = new List<int> { 2 };
            var ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                an1.CompareTo(lst);
            });

            Assert.AreEqual(ex.Message, aExpected);
        }

        //Bird tests
        [TestMethod]
        public void TestMethodBirdProperties1()
        {
            //Arrange - начальные условия
            Bird aReceived = new Bird();
            Bird aExpected = new Bird(1, 1, 1, "1", 1, 1, "1");
            //Act - проверяемое действие
            aReceived.Age = 1;
            aReceived.Weight = 1;
            aReceived.Height = 1;
            aReceived.Name = "1";
            aReceived.FlightRange = 1;
            aReceived.Wingspan = 1;
            aReceived.Specie = "1";
            //Assert - верификация результатов
            Assert.AreEqual(aExpected, aReceived);
        }

        [TestMethod]
        public void TestMethodBirdProperties2()
        {

            string aReceived;
            string aExpected = "Запись";

            Bird an = new Bird();
            an.Note = "Запись";
            aReceived = an.Note;

            Assert.AreEqual(aExpected, aReceived);
        }

        [TestMethod]
        public void TestMethodBirdCloneConstructor()
        {

            Bird aReceived;
            Bird aExpected = new Bird(1, 1, 1, "1", 1, 1, "1");

            aReceived = new Bird(aExpected);

            Assert.AreEqual(aExpected, aReceived);
        }

        [TestMethod]
        public void TestMethodBirdSuperficialCopy()
        {

            Bird aReceived;
            Bird aExpected = new Bird(1, 1, 1, "Клон 1", 1, 1, "1");

            Bird an = new Bird(1, 1, 1, "1", 1, 1, "1");
            aReceived = (Bird)an.SuperficialCopy();

            Assert.AreEqual(aExpected, aReceived);
        }

        [TestMethod]
        public void TestMethodBirdCompareTo()
        {

            int aReceived;
            int aExpected = 0;

            Bird an1 = new Bird(1, 1, 1, "1", 1, 1, "1");
            Bird an2 = (Bird)an1.Clone();
            aReceived = an1.CompareTo(an2);

            Assert.AreEqual(aExpected, aReceived);
        }

        [TestMethod]
        public void TestMethodBirdCompareToTypeExeption()
        {
            string aExpected = "Переданный параметр имеет недопустимый тип";

            Bird an1 = new Bird(1, 1, 1, "1", 1, 1, "1");
            List<int> lst = new List<int> { 2 };
            var ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                an1.CompareTo(lst);
            });

            Assert.AreEqual(ex.Message, aExpected);
        }

        //Compare
        [TestMethod]
        public void TestMethodAnimLibCompare()
        {
            Animal[] aExpected = new Animal[2];
            Animal[] aReceived = new Animal[2];

            Animal an1 = new Animal(1, 1, 1, "1");
            Animal an2 = new Animal(1, 2, 1, "1");
            aExpected[0] = an1;
            aExpected[1] = an2;
            aReceived[0] = an2;
            aReceived[1] = an1;
            Array.Sort(aReceived, new SortByHeight());

            Assert.AreEqual(aExpected[0], aReceived[0]);
            Assert.AreEqual(aExpected[1], aReceived[1]);
        }

        //Note class
        [TestMethod]
        public void TestMethodNoteClassConstructors()
        {
            NoteClass aExpected = new NoteClass("запись");
            NoteClass aReceived;

            aReceived = new NoteClass(aExpected);

            Assert.AreEqual(aExpected, aReceived);
        }
    }
}
