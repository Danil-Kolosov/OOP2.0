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

        public MoneyArray()
        {
            Arr = null;
        }

        public MoneyArray(int size)
        {
            Arr = new Money[size];
        }

        public MoneyArray(int size, string auto)
        {
            var rand = new Random();
            Arr = new Money[size];
            for (int i = 0; i < size; i++)
            {
                Arr[i] = new Money(rand.Next(0, 25), rand.Next(0, 99));                             //************!!??
            }
        }

        public MoneyArray(string handMake)
        {
            int size = 0;
            int elementRub = 0;
            int elementKop = 0;
            InterfaceSpace.UserInterface.Input(ref size, 0, 20, "Введите размер коллекции (минимум - 0; максимум - 20)");
            var rand = new Random();
            Arr = new Money[size];
            for (int i = 0; i < size; i++)
            {

                InterfaceSpace.UserInterface.Input(ref elementRub, 0, 25, "Введите количество рублей (мнимум - 0, максимум - 25)");
                InterfaceSpace.UserInterface.Input(ref elementKop, 0, 99, "Введите количество копеек (мнимум - 0, максимум - 99)");
                Arr[i] = new Money(elementRub, elementKop);                             //************!!?'
            }
        }

        public Money this[int index]////////////при ввводе индекса просто сделать проверку
        {
            get
            {
                if (index < Arr.Length & index >= 0)//****
                    return Arr[index];//****
                else
                    throw new ArgumentOutOfRangeException("Выход за границы массива");

            }
            set
            {
                if (index < Arr.Length & index >= 0)//*******
                    Arr[index] = value;//********
                else
                    throw new ArgumentOutOfRangeException("Выход за границы массива");

            }
        }


        public Money[] Arr
        {
            get
            {
                return arr;
            }
            set
            {
                arr = value;
            }
        }

        public Money CreateRandomElement(Random rand)
        {
            Money m = new Money(rand.Next(0, 25), rand.Next(0, 99));
            return m;
        }

        public void Show()
        {
            if (Arr.Length != 0)
            {
                Console.WriteLine("Элементы массива:");
                for (int i = 0; i < Arr.Length; i++)
                {
                    //можно ещё подпись добавить номер эл но и так
                    Arr[i].Show();
                }
            }
            else
            {
                Console.WriteLine("Массив пустой");
            }
        }
        public int Size()
        {
            return Arr.Length;
        }


        public double ArithmeticMean ()
        {
            int sum = 0;
            for (int i = 0; i < Arr.Length; i++)
            {
                sum += Arr[i].Sum;
            }
            return ((double)sum / Arr.Length / 100);
        }

        public double ArithmeticMeanRub()
        {
            int sumRub = 0;
            for (int i = 0; i < Arr.Length; i++)
            {
                sumRub += Arr[i].Rubles;
            }
            return ((double)sumRub / Arr.Length);
        }

        public double ArithmeticMeanKop()
        {
            int sumKop = 0;
            for (int i = 0; i < Arr.Length; i++)
            {
                sumKop += Arr[i].Kopeks;
            }
            return ((double)sumKop / Arr.Length);
        }

    }
}
