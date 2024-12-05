using AnimalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    internal class SharkNewClassIInit:IInit
    {
        private int numberOfTeeth;
        private static Random rand = new Random();

        public int NumberOfTeeth 
        {
            get 
            {
                return numberOfTeeth;
            }
            set 
            {
                if(value > 0)
                    numberOfTeeth = value;
                else 
                    numberOfTeeth = 1;
            } 
        }

        public SharkNewClassIInit() 
        {
            numberOfTeeth = 0;
        }

        public SharkNewClassIInit(SharkNewClassIInit shark)
        {
            NumberOfTeeth = shark.NumberOfTeeth;
        }

        public void Show() 
        {
            Console.WriteLine($"\n\nКоличество зубов у этой акулы = {NumberOfTeeth}");
        }

        public SharkNewClassIInit(int numberOfTeeth)
        {
            NumberOfTeeth = numberOfTeeth;
        }

        public void Init() 
        {
            int numb;
            Console.WriteLine("Введите количестов зубов у акулы: ");
            while (!(int.TryParse((Console.ReadLine()), out numb)) || numb < 0) 
            {
                Console.WriteLine("Введены не корректные данные, повторите");
            }
        }
        public void RandomInit() 
        {
            NumberOfTeeth = rand.Next(1, 1000);
        }
    }
}
