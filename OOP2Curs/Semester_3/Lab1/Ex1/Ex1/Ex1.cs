using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Ex1
{
    internal class Ex1
    {
        static int m;
        static int n;

        static double x;
        static int errorValueX = 0;
        static int numberOfRepeats = 1;

        static void Main() 
        {
            GetFirstNumber();
            GetSecondNumber();
            GetThirdNumber();
            GetFourthNumber();  
        }

        static void GetFirstNumber() 
        {
                AskToInputFromFirstToThird(1);
                InputFromFirstToThird(1);
                AskToInputFromFirstToThird(2);
                InputFromFirstToThird(2, true, 1);
                OutputFirst();
        }

        static void GetSecondNumber()
        {
            AskToInputFromFirstToThird(1);
            InputFromFirstToThird(1);
            AskToInputFromFirstToThird(2);
            InputFromFirstToThird(2);
            OutputSecond();
        }

        static void GetThirdNumber()
        {
            AskToInputFromFirstToThird(1);
            InputFromFirstToThird(1);
            AskToInputFromFirstToThird(2);
            InputFromFirstToThird(2);
            OutputThird();
        }

        static void AskToInputFromFirstToThird(int step = 1) 
        {
            if(step == 1)
                Console.WriteLine("Введите n");
            else
                Console.WriteLine("Введите m, не равное 1");
        }

        static void InputFromFirstToThird(int step = 1, bool isErrorValue = false, int errorValue = 0) 
        {
            if (step == 1)
            { 
                if (!(int.TryParse((Console.ReadLine()), out n)))
                    AskAgainFromFirstToThird(1);
            }
            else
            {
                if (isErrorValue)
                {
                    if (!(int.TryParse((Console.ReadLine()), out m)))
                        AskAgainFromFirstToThird(2);
                    else
                        if (m == errorValue)
                        AskAgainFromFirstToThird(2);
                }
                else
                     if (!(int.TryParse((Console.ReadLine()), out m)))
                    AskAgainFromFirstToThird(2);
            }
        }

        static void AskAgainFromFirstToThird(int step) 
        {
            Console.WriteLine("Введены не корректные данные, повторите ввод");
            AskToInputFromFirstToThird(step);
            InputFromFirstToThird(step, true, 1);
        }

        static void OutputFirst() 
        {
            Console.WriteLine("n = " + n + " m = " + m);
            //int x = (n++/--m)        ++;
            int x = (n++ / --m);
            x++;
            Console.WriteLine("(n++ / --m)++ = " + x); //сначала вычтется потом умножится и потом прибавиться
        }

        static void OutputSecond() 
        {
            // ++m<n     —
            Console.WriteLine("n = " + n + " m = " + m);
            Console.WriteLine("++m < n-- = " + (++m < n--)); //сначала прибавиться  потомсравниться потом вычтеся
        }

        static void OutputThird()
        {
            Console.WriteLine("n = " + n + " m = " + m);
            Console.WriteLine("--m > ++n = " + (--m > ++n)); //сначала вычтется и прибавиться потом сравниться
        }

        static void GetFourthNumber() 
        {
            AskInputNumberOfRepeats();
            InputNumberOfRepeats();
            for (int i = 0; i < numberOfRepeats; i++)
            {
                AskToInputFourth();
                InputFourth();
                OutputFourth();
            }
        }

        static void AskInputNumberOfRepeats() 
        {
            Console.WriteLine("Введите сколько различных значений будет принимать x");
        }

        static void InputNumberOfRepeats() 
        {
            if (!(int.TryParse((Console.ReadLine()), out numberOfRepeats)))
            {
                Console.WriteLine("Введены не корректные данные, повторите ввод");
                InputNumberOfRepeats();
            }
            else
                if (x < 0) 
                {
                    Console.WriteLine("Введены не корректные данные, повторите ввод");
                    InputNumberOfRepeats();
                }
        }

        static void AskToInputFourth() 
        {
            Console.WriteLine("Введите x, отличный от нуля");
        }

        static void InputFourth() 
        {
            if (!(double.TryParse((Console.ReadLine()), out x)))
                AskAgainFourth();
            else
                if (x == errorValueX)
                    AskAgainFourth();
        }

        static void AskAgainFourth() 
        {
            Console.WriteLine("Введены не корректные данные, повторите ввод");
            AskToInputFourth();
            InputFourth();
        }

        static void OutputFourth() 
        {
            Console.WriteLine("x = " + x);
            Console.WriteLine("(e^x + tg(x))^1/3 + 1/x = " + (double)(Math.Pow(Math.Exp(x) + Math.Tan(x), 1/3) + 1/x));
        }

    }
}
