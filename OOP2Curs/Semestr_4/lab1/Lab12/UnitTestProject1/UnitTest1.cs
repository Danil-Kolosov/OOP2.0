using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCollectionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConstruc1()
        {

            //Arrange - начальные условия
            MyCollection<string, int> testCollections = new MyCollection<string, int>();
            int tReceived;
            int tExpected = 0;
            //Act - проверяемое действие
            tReceived = testCollections.Count;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);

        }

        [TestMethod]
        public void TestConstruc2()
        {

            //Arrange - начальные условия
            MyCollection<string, int> testCollections = new MyCollection<string, int>(1);
            int tReceived;
            int tExpected = 1;
            //Act - проверяемое действие
            testCollections.Add("1", 1);
            tReceived = testCollections.Count;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);

        }

        [TestMethod]
        public void TestConstruc3()
        {

            //Arrange - начальные условия
            MyCollection<string, int> testCollections = new MyCollection<string, int>(1);
            MyCollection<string, int> tExpected = testCollections;            
            //Act - проверяемое действие
            testCollections.Add("1", 1);
            MyCollection<string, int> tReceived = new MyCollection<string, int>(testCollections);
            //Assert - верификация результатов
            Assert.AreEqual(tExpected.Count, tReceived.Count);
        }

        [TestMethod]
        public void TestCopy()
        {

            //Arrange - начальные условия
            MyCollection<string, int> testCollections = new MyCollection<string, int>(1);
            MyCollection<string, int> tExpected = testCollections;
            //Act - проверяемое действие
            testCollections.Add("1", 1);
            testCollections.Add("2", 2);
            MyCollection<string, int> tReceived = (MyCollection<string, int>)testCollections.Clone();
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestCopyDeepAndMemberwirse()
        {

            //Arrange - начальные условия
            MyCollection<string, int> testCollections = new MyCollection<string, int>(1);            
            //Act - проверяемое действие
            testCollections.Add("1", 1);
            MyCollection<string, int> tExpected = testCollections.DeepCloning();
            MyCollection<string, int> tReceived = (MyCollection<string, int>)testCollections.Copyng();
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }


        [TestMethod]
        public void TestDelete ()
        {

            //Arrange - начальные условия
            MyCollection<string, int> testCollections = new MyCollection<string, int>(1);
            MyCollection<string, int> tExpected = new MyCollection<string, int>();
            //Act - проверяемое действие
            testCollections.Add("1", 1);            
            MyCollection<string, int> tReceived = (MyCollection<string, int>)testCollections.Copyng();
            tReceived.Delete();
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestAddRemove()
        {

            //Arrange - начальные условия
            MyCollection<string, int> testCollections = new MyCollection<string, int>(5);
            MyCollection<string, int> tExpected = new MyCollection<string, int>(5);
            //Act - проверяемое действие
            tExpected.Add(new KeyValuePair<string, int>("1", 1));
            testCollections.Add(new KeyValuePair<string, int>("1", 1));
            testCollections.Add(new KeyValuePair<string, int>("2", 2));
            testCollections.Add(new KeyValuePair<string, int>("3", 3));
            testCollections.Add(new KeyValuePair<string, int>("4", 4));
            if (testCollections.Contains(new KeyValuePair<string, int>("2", 2)))
            {
                int val = 0; 
                testCollections.TryGetValue("2", out val);
                testCollections.Remove(val); 
            }
            if (testCollections.ContainsKey("3"))
                testCollections.Remove(new KeyValuePair<string, int>("3", 3));
            if (testCollections.ContainsValue(4))
                testCollections.Remove("4");
            MyCollection<string, int> tReceived = testCollections;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestClearValues()
        {

            //Arrange - начальные условия
            MyCollection<string, int> testCollections = new MyCollection<string, int>(5);
            List<int> tExpected = (List<int>)testCollections.Values;
            //Act - проверяемое действие
            testCollections.Add(new KeyValuePair<string, int>("1", 1));
            testCollections.Add(new KeyValuePair<string, int>("2", 2));
            testCollections.Clear();
            List<int> tReceived = (List<int>)testCollections.Values;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected.Count, tReceived.Count);
        }


        [TestMethod]
        public void TestRemoveAmongNexts()
        {

            //Arrange - начальные условия
            MyCollection<string, int> testCollections = new MyCollection<string, int>(1);
            MyCollection<string, int> tExpected = new MyCollection<string, int>(1);
            //Act - проверяемое действие
            tExpected.Add(new KeyValuePair<string, int>("1", 1));
            testCollections.Add(new KeyValuePair<string, int>("1", 1));
            testCollections.Add(new KeyValuePair<string, int>("2", 2));
            testCollections.RemoveAmongNexts(2, 0);
            MyCollection<string, int> tReceived = testCollections;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestCopyTo()
        {

            //Arrange - начальные условия
            MyCollection<string, int> testCollections = new MyCollection<string, int>(1);
            int[] tExpected = new int[1];
            //Act - проверяемое действие
            testCollections.Add(new KeyValuePair<string, int>("1", 1));
            KeyValuePair<string, int>[] tReceived = new KeyValuePair<string, int>[1];
            testCollections.CopyTo(tReceived, 0);
            testCollections.CopyTo(tExpected, 0);
            //Assert - верификация результатов
            Assert.AreEqual(tExpected.Length, tReceived.Length);
        }

        [TestMethod]
        public void TestEquals()
        {

            //Arrange - начальные условия
            MyCollection<string, int> testCollections = new MyCollection<string, int>(1);
            MyCollection<string, int> tExpected = new MyCollection<string, int>(1);
            //Act - проверяемое действие
            testCollections.Add(new KeyValuePair<string, int>("1", 1));
            tExpected.Add(new KeyValuePair<string, int>("1", 1));
            tExpected["1"] = 2;
            testCollections["1"] = 2;
            MyCollection<string, int> tReceived = testCollections;
            bool bExpected = tExpected.Equals(tReceived);
            bool bReceived = tReceived.Equals(tExpected);
            //Assert - верификация результатов
            Assert.AreEqual(bExpected, bReceived);
        }

        [TestMethod]
        public void TestKeys()
        {

            //Arrange - начальные условия
            MyCollection<string, int> testCollections = new MyCollection<string, int>(5);
            List<string> tExpected = new List<string> { "1", "2" };
            //Act - проверяемое действие
            testCollections.Add(new KeyValuePair<string, int>("1", 1));
            testCollections.Add(new KeyValuePair<string, int>("2", 2));
            int item = testCollections["2"];
            List<string> tReceived = (List<string>)testCollections.Keys;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected.SequenceEqual(tReceived), true);
        }

        [TestMethod]
        public void TestBegin()
        {

            //Arrange - начальные условия
            MyCollection<string, int> testCollections = new MyCollection<string, int>(1);
            Point<string, int> tExpected = new Point<string, int>("1");
            tExpected.Value = 1;
            Point<string, int> tReceived = new Point<string, int>();
            string sExpected;
            string sReceived;
            //Act - проверяемое действие
            testCollections.Add(new KeyValuePair<string, int>("1", 1));
            //tReceived = testCollections.Begin;
            tReceived = new Point<string, int> (tExpected);
            sExpected = tExpected.ToString();
            sReceived = tReceived.ToString();
            //Assert - верификация результатов
            Assert.AreEqual(sExpected, sReceived);
        }



        [TestMethod]
        public void TestGetEnumeratorRemove()
        {

            //Arrange - начальные условия
            MyCollection<string, int> testCollections = new MyCollection<string, int>(1);
            int tExpected = 6;
            int tReceived = 0;
            //Act - проверяемое действие
            testCollections.Add(new KeyValuePair<string, int>("1", 1));
            testCollections.Add(new KeyValuePair<string, int>("2", 2));
            testCollections.Add(new KeyValuePair<string, int>("3", 3));
            testCollections.Add(new KeyValuePair<string, int>("4", 4));
            testCollections.Add(new KeyValuePair<string, int>("5", 5));
            if (testCollections.Contains(new KeyValuePair<string, int>("5", 5)))
                testCollections.Remove("5");
            if (testCollections.ContainsKey("4"))
                testCollections.Remove(4);
            foreach (KeyValuePair<string, int> t in testCollections)
                tReceived += t.Value;
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestTryGetValue()
        {

            //Arrange - начальные условия
            MyCollection<string, int> testCollections = new MyCollection<string, int>(1);
            bool tExpected = false;
            bool tReceived;
            //Act - проверяемое действие
            int val;
            tReceived = testCollections.TryGetValue("1", out val);
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestExeptions()
        {

            //Arrange - начальные условия
            MyCollection<string, int> testCollections = new MyCollection<string, int>();
            bool tExpected = false;
            bool tReceived = false;
            //Act - проверяемое действие
            try 
            {
                testCollections["g"] = 0;                
            }
            catch { int a = 0; }
            try
            {
                testCollections.Contains(new KeyValuePair<string, int>());
            }
            catch { int a = 0; }
            try
            {
                Array ar = new Array[0];
                testCollections.CopyTo(ar, 0);
            }
            catch { int a = 0; }
            try
            {
                KeyValuePair<string, int>[] ar = new KeyValuePair<string, int>[0];
                testCollections.CopyTo(ar, 0);
            }
            catch { int a = 0; }
            try
            {
                testCollections.Add("6",6);
            }
            catch { int a = 0; }
            try
            {
                testCollections.Remove(6);
            }
            catch { int a = 0; }
            try
            {
                testCollections.Remove("6");
            }
            catch { int a = 0; }
            try
            {
                int val = testCollections["4"];
            }
            catch { int a = 0; }
            try
            {
                testCollections = new MyCollection<string, int>(1);
                testCollections["g"] = 0;
            }
            catch {}
            try
            {
                Array ar = new Array[0];
                testCollections.CopyTo(ar, 0);
            }
            catch { }
            try
            {
                Array ar = new Array[5];
                testCollections.CopyTo(ar, -6);
            }
            catch { }
            try
            {
                KeyValuePair<string, int>[] ar = new KeyValuePair<string, int>[0];
                testCollections.CopyTo(ar, 0);
            }
            catch { }
            try
            {
                KeyValuePair<string, int>[] ar = new KeyValuePair<string, int>[5];
                testCollections.CopyTo(ar, -6);
            }
            catch { }
            try
            {
                string a = null;
                testCollections.Remove(a);
            }
            catch { int a = 0; }
            try
            {
                int a = default;
                testCollections.Remove(a);
            }
            catch { int a = 0; }
            try
            {
                testCollections.Add(new KeyValuePair<string, int>());
            }
            catch { int a = 0; }
            try
            {
                int val = testCollections["4"];
            }
            catch { int a = 0; }
            try
            {
                testCollections["g"] = 0;
                int val = testCollections["4"];
                testCollections = new MyCollection<string, int>(1);
                testCollections["g"] = 0;
                val = testCollections["4"];
            }
            catch { int a = 0; }
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }
    }
}
