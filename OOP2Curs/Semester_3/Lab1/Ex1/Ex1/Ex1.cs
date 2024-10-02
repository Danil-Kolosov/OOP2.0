using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    internal class Ex1
    {
        static int m;
        static int n;
        static int errorValueM = 1;

        static double x;
        static int errorValueX = 0;
        static int numberOfRepeats = 1;

        static void Main() 
        {
            ProcessingFirstNumber();
            ProcessingSecondNumber();
            ProcessingThirdNumber();
            ProcessingFourthNumber();  
        }

        static void ProcessingFirstNumber() 
        {
                AskToInputFromFirstToThird(1);
                InputFromFirstToThird(1);
                AskToInputFromFirstToThird(2);
                InputFromFirstToThird(2);
                OutputFirst();
        }

        static void ProcessingSecondNumber()
        {
            //AskToInputFromFirstToThird(1);
            //InputFromFirstToThird(1);
            //AskToInputFromFirstToThird(2);
            //InputFromFirstToThird(2);
            OutputSecond();
        }

        static void ProcessingThirdNumber()
        {
            //AskToInputFromFirstToThird(1);
            //InputFromFirstToThird(1);
            //AskToInputFromFirstToThird(2);
            //InputFromFirstToThird(2);
            OutputThird();
        }

        static void AskToInputFromFirstToThird(int step = 1) 
        {
            if(step == 1)
                Console.WriteLine("Введите n");
            else
                Console.WriteLine("Введите m, не равное 1");
        }

        static bool IsErrorValue(int step) 
        {
            if (step == 1)
                return m == errorValueM;
            else
                return x == errorValueX;
        }
        static void InputFromFirstToThird(int step = 1) 
        {
            if (step == 1)
            { 
                if (!(int.TryParse((Console.ReadLine()), out n)))
                    AskAgainFromFirstToThird(1);
            }
            else
            {
                if (!(int.TryParse((Console.ReadLine()), out m)))
                {
                    AskAgainFromFirstToThird(2);
                }
                else
                     if (IsErrorValue(1))
                        AskAgainFromFirstToThird(2);
            }
        }

        static void AskAgainFromFirstToThird(int step) 
        {
            Console.WriteLine("Введены не корректные данные, повторите ввод");
            AskToInputFromFirstToThird(step);
            InputFromFirstToThird(step);
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

        static void ProcessingFourthNumber() 
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
            Console.WriteLine("Введите сколько раз будет вводиться x");
        }

        static void InputNumberOfRepeats() 
        {
            if (!(int.TryParse((Console.ReadLine()), out numberOfRepeats)))
            {
                Console.WriteLine("Введены не корректные данные, повторите ввод");
                InputNumberOfRepeats();
            }
            else
                if (numberOfRepeats <= 0) 
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
                if (IsErrorValue(2))
                    AskAgainFourth();
        }

        static void AskAgainFourth() 
        {
            Console.WriteLine("Введены не корректные данные, повторите ввод");
            InputFourth();
        }

        static void OutputFourth() 
        {
            Console.WriteLine("x = " + x);
            Console.WriteLine("(e^x + tg(x))^1/3 + 1/x = " + (Math.Pow(Math.Abs(Math.Exp(x) + Math.Tan(x)), 1.0/3.0)
                *(int)((Math.Abs(Math.Exp(x) + Math.Tan(x)))/(Math.Exp(x) + Math.Tan(x))) + 1.0/x));
            Console.WriteLine((int)((Math.Abs(Math.Exp(x) + Math.Tan(x))) / (Math.Exp(x) + Math.Tan(x))));
            
        }

    }
}
