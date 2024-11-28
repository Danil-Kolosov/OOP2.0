using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneySpace;
using InterfaceSpace;

namespace ArraySpace
{
    public class MoneyArray
    {
        private Money[] arr;
        private static int counterObjects = 0;

        //public Money[] Arr
        //{
        //    get
        //    {
        //        return arr;
        //    }
        //    set
        //    {
        //        if(value is Money[] money)
        //            arr = money;
        //    }
        //}

        public int Length => arr.Length;

        public static int CounterObjects
        {
            get
            {
                return counterObjects;
            }
            set
            {
                if (value > 0)
                {
                    counterObjects = value;
                }
            }
        }

        public Money this[int index]
        {
            get
            {
                if (index < arr.Length & index >= 0)
                    return arr[index];
                else
                    throw new ArgumentOutOfRangeException("Выход за границы массива");
            }
            set
            {
                if (index < arr.Length & index >= 0)
                    arr[index] = value;
                else
                    throw new ArgumentOutOfRangeException("Выход за границы массива");

            }
        }

        public MoneyArray()
        {
            arr = null;
        }

        public MoneyArray(int size)
        {
            CounterObjects++;
            arr = new Money[size];
        }  

        public MoneyArray(string madeType, int size = -1)
        {
            CounterObjects++;
            if(size == -1)
                arr = CreateArray(madeType);
            else
                arr = CreateArray(madeType, size);
        }

        public Money[] CreateArray(string madeType, int size = -1)
        {
            switch (madeType)
            {
                case "autoMade":
                    {
                        var rand = new Random();
                        if (size == -1)
                            size = rand.Next(3, 10);                      
                        Money[] arrayTemp = new Money[size];
                        for (int i = 0; i < size; i++)
                        {
                            arrayTemp[i] = new Money(rand.Next(0, 25), rand.Next(0, 99));
                        }
                        return arrayTemp;
                    }
                case "handMade": 
                    {
                        size = 0;
                        int elementRub = 0;
                        int elementKop = 0;
                        InterfaceSpace.UserInterface.Input(ref size, 0, 20, "Введите размер коллекции (минимум - 0; максимум - 20)");
                        Money[] arrayTemp = new Money[size];
                        for (int i = 0; i < size; i++)
                        {
                            InterfaceSpace.UserInterface.Input(ref elementRub, 0, 100000, "Введите количество рублей (мнимум - 0)");
                            InterfaceSpace.UserInterface.Input(ref elementKop, 0, 100000, "Введите количество копеек (мнимум - 0)");
                            arrayTemp[i] = new Money(0, elementRub * 100 + elementKop);
                        }
                        return arrayTemp;
                    }
                default:
                    {
                        throw new Exception("Не удалось создать масcив");
                    }
            }
        }

        public Money CreateRandomElement(Random rand)
        {
            Money m = new Money(rand.Next(0, 25), rand.Next(0, 99));
            return m;
        }

        public void Show()
        {
            if (arr.Length != 0 || arr == null)
            {
                Console.WriteLine("Элементы массива:");
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i].Show();
                }
            }
            else
            {
                Console.WriteLine("Массив пустой");
            }
        }

        public int Size()
        {
            return arr.Length;
        }

        public double ArithmeticMean ()
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i].Sum();
            }
            return ((double)sum / arr.Length / 100);
        }

        public double ArithmeticMeanRub()
        {
            int sumRub = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sumRub += arr[i].Rubles;
            }
            return ((double)sumRub / arr.Length);
        }

        public double ArithmeticMeanKop()
        {
            int sumKop = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sumKop += arr[i].Kopeks;
            }
            return ((double)sumKop / arr.Length);
        }
    }
}
