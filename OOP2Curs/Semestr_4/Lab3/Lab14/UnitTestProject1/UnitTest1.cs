using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCollectionLibrary;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //Test new Extensions methods

        [TestMethod]
        public void TestExtensionSelectionOnCondition()
        {
            //Arrange - начальные условия
            MyCollection<string, int> testCollections = new MyCollection<string, int>(2)
            {
                { "1", 1 },
                { "2", 2 }
            };
            //; //IEnumerable<KeyValuePair<string, int>>
            KeyValuePair<string, int> tExpected = new KeyValuePair<string, int>("1", 1);
            //Act - проверяемое действие
            var query = testCollections.SelectionOnCondition(item => item.Value == 1);
            foreach(var tReceived in query)
                //Assert - верификация результатов
                Assert.AreEqual(tExpected, tReceived);
        }
        

        [TestMethod]
        public void TestExtensionMyAggregate()
        {
            //Arrange - начальные условия
            MyCollection<string, int> testCollections = new MyCollection<string, int>(2)
            {
                { "1", 1 },
                { "2", 2 }
            };
            int tExpected = 2;
            //Act - проверяемое действие
            int tReceived = (int)testCollections.MyAggregate(item => item.Value,(a, b) => (a>b)?a:b);            
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }

        [TestMethod]
        public void TestExtensionOrder()
        {
            //Arrange - начальные условия
            MyCollection<string, int> testCollections = new MyCollection<string, int>(2)
            {
                { "1", 1 },
                { "2", 2 }
            };
            KeyValuePair<string, int>[] tExpected = new KeyValuePair<string, int>[2] 
            {
                new KeyValuePair<string, int>("2", 2),
                new KeyValuePair<string, int>("1", 1)
            };
            //Act - проверяемое действие
            var query = testCollections.Order(item => item.Value, true);
            KeyValuePair<string, int>[] tReceived = new KeyValuePair<string, int>[2];
            int i = 0;
            foreach(var item in query)
            { 
                tReceived[i] = item;
                i++;
            }
            //Assert - верификация результатов
            Assert.AreEqual(tExpected.SequenceEqual(tReceived), true);            
        }

        [TestMethod]
        public void TestExtensionMyAggregateAverage()
        {
            //Arrange - начальные условия
            MyCollection<string, int> testCollections = new MyCollection<string, int>(2)
            {
                { "1", 1 },
                { "2", 2 }
            };
            double tExpected = 1.5;
            //Act - проверяемое действие
            double tReceived = testCollections.MyAggregate(item => item.Value, (a, b) => a + b, true);
            //Assert - верификация результатов
            Assert.AreEqual(tExpected, tReceived);
        }
    }
}
