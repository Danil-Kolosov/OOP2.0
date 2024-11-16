using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab9;
using MoneySpace;
using ArraySpace;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodSubtractingKopeksStatic1()
        {
            //Arrange - начальные условия
            Money mReceived = new Money(5, 5);
            Money mExpected = new Money(0, 0);
            //Act - проверяемое действие
            Money.SubtractingKopeksStatic(mReceived, 600);
            //Assert - верификация результатов
            Assert.AreEqual(mReceived, mExpected);
        }

        [TestMethod]
        public void TestMethodSubtractingKopeksStatic2()
        {
            Money mReceived = new Money(5, 5);
            Money mExpected = new Money(4, 45);

            Money.SubtractingKopeksStatic(mReceived, 60);

            Assert.AreEqual(mReceived, mExpected);
        }

        [TestMethod]
        public void TestMethodSubtractingKopeks1()
        {
            Money mReceived = new Money(5, 5);
            Money mExpected = new Money(0, 0);

            mReceived.SubtractingKopeks(600);

            Assert.AreEqual(mReceived, mExpected);
        }

        [TestMethod]
        public void TestMethodSubtractingKopeks2()
        {
            Money mReceived = new Money(5, 5);
            Money mExpected = new Money(4, 45);

            mReceived.SubtractingKopeks(60);

            Assert.AreEqual(mReceived, mExpected);
        }

        [TestMethod]
        public void TestMethodDicrement1()
        {
            Money mReceived = new Money(5, 5);
            Money mExpected = new Money(5, 4);

            mReceived--;

            Assert.AreEqual(mReceived, mExpected);
        }

        [TestMethod]
        public void TestMethodDicrement2()
        {
            Money mReceived = new Money(0, 0);
            Money mExpected = new Money(0, 0);

            mReceived--;

            Assert.AreEqual(mReceived, mExpected);
        }

        [TestMethod]
        public void TestMethodIncrement1()
        {
            Money mReceived = new Money(0, 99);
            Money mExpected = new Money(1, 0);

            mReceived++;

            Assert.AreEqual(mReceived, mExpected);
        }

        [TestMethod]
        public void TestMethodIncrement2()
        {
            Money mReceived = new Money(0, 9);
            Money mExpected = new Money(0, 10);

            mReceived++;

            Assert.AreEqual(mReceived, mExpected);
        }

        [TestMethod]
        public void TestMethodInt()
        {
            Money money = new Money(0, 9);
            int expected = 9;
            int received;

            received = (int)money;

            Assert.AreEqual(received, expected);
        }

        [TestMethod]
        public void TestMethodBool1()
        {
            Money money = new Money(0, 9);
            bool expected = false;
            bool received;

            received = money;

            Assert.AreEqual(received, expected);
        }

        [TestMethod]
        public void TestMethodBool2()
        {
            Money money = new Money(0, 0);
            bool expected = true;
            bool received;

            received = money;

            Assert.AreEqual(received, expected);
        }

        [TestMethod]
        public void TestMethodPlus1_1()
        {
            Money mReceived = new Money(0, 0);
            Money mExpected = new Money(0, 5);


            mReceived = mReceived + 5;

            Assert.AreEqual(mReceived, mExpected);
        }

        [TestMethod]
        public void TestMethodPlus1_2()
        {
            Money mReceived = new Money(0, 0);
            Money mExpected = new Money(0, 0);


            mReceived = mReceived + (-400);

            Assert.AreEqual(mReceived, mExpected);
        }

        [TestMethod]
        public void TestMethodPlus2_1()
        {
            Money mReceived = new Money(0, 0);
            Money mExpected = new Money(0, 5);


            mReceived = 5 + mReceived;

            Assert.AreEqual(mReceived, mExpected);
        }

        [TestMethod]
        public void TestMethodPlus2_2()
        {
            Money mReceived = new Money(0, 0);
            Money mExpected = new Money(0, 0);

            mReceived = (-400) + mReceived;

            Assert.AreEqual(mReceived, mExpected);
        }

        [TestMethod]
        public void TestMethodMinus1()
        {
            Money mReceived = new Money(0, 0);
            Money mSubscribe = new Money(5, 0);
            Money mExpected = new Money(0, 0);

            mReceived = mReceived - mSubscribe;

            Assert.AreEqual(mReceived, mExpected);
        }

        [TestMethod]
        public void TestMethodMinus2()
        {
            Money mReceived = new Money(10, 0);
            Money mSubscribe = new Money(5, 5);
            Money mExpected = new Money(4, 95);

            mReceived = mReceived - mSubscribe;

            Assert.AreEqual(mReceived, mExpected);
        }

        //Тесты класса массива
        [TestMethod]
        public void TestMethodArithMean()
        {
            MoneyArray moneyArray = new MoneyArray(3);
            moneyArray[0] = new Money(1, 13);
            moneyArray[1] = new Money(2, 5);
            moneyArray[2] = new Money(3, 24);
            double received = 0;
            double expected = 2.14;

            received = moneyArray.ArithmeticMean();

            Assert.AreEqual(received, expected);
        }

        [TestMethod]
        public void TestMethodArithMeanRub()
        {
            MoneyArray moneyArray = new MoneyArray(3);
            moneyArray[0] = new Money(1, 13);
            moneyArray[1] = new Money(2, 5);
            moneyArray[2] = new Money(3, 24);
            double received = 0;
            double expected = 2;

            received = moneyArray.ArithmeticMeanRub();

            Assert.AreEqual(received, expected);
        }

        [TestMethod]
        public void TestMethodArithMeanKop()
        {
            MoneyArray moneyArray = new MoneyArray(3);
            moneyArray[0] = new Money(1, 13);
            moneyArray[1] = new Money(2, 5);
            moneyArray[2] = new Money(3, 24);
            double received = 0;
            double expected = 14;

            received = moneyArray.ArithmeticMeanKop();

            Assert.AreEqual(received, expected);
        }

        [TestMethod]
        public void TestMethodAoutoMadeArr()
        {
            MoneyArray moneyArray = new MoneyArray();
            moneyArray = new MoneyArray("autoMade");
            int sumKop = 0;
            for (int i = 0; i < moneyArray.Size(); i++)
            {
                sumKop = sumKop + (int)moneyArray[i];
            }

            int expected = sumKop;

            int received = (int)(moneyArray.ArithmeticMeanKop() * moneyArray.Size());

            Assert.AreEqual(received, expected);
        }

        [TestMethod]
        public void TestMethodThrowExeption1()
        {
            MoneyArray moneyArray = new MoneyArray(1);
            var rand = new Random();
            Money money = moneyArray.CreateRandomElement(rand);
            string expected = "Заданный аргумент находится вне диапазона допустимых значений.\r\nИмя параметра: Выход за границы массива";
            Money received = moneyArray[0];

            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                moneyArray[20] = money;
            });

            Assert.AreEqual(ex.Message, expected);
        }

        [TestMethod]
        public void TestMethodThrowExeption2()
        {
            MoneyArray moneyArray = new MoneyArray(1);
            var rand = new Random();
            Money money = moneyArray.CreateRandomElement(rand);
            string expected = "Заданный аргумент находится вне диапазона допустимых значений.\r\nИмя параметра: Выход за границы массива";

            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                money = moneyArray[-20];
            });

            Assert.AreEqual(ex.Message, expected);
        }
    }
}
