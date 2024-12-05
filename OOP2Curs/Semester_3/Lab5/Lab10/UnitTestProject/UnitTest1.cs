using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Policy;
using AnimalLibrary;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
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
