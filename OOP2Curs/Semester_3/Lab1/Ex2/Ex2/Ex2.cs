using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    internal class Ex2
    {
        static bool isInChart = false;
        static double x;
        static double y;
        static bool stopProgrammKey = true;
        static string key;

        static void Main()
        {
            while(stopProgrammKey)
            {
                switch (key)
                {
                    case "0":
                        StopProgramm();
                        break;
                    default:
                        {
                            AskToInputX();
                            InputX();
                            AskToInputY();
                            InputY();
                            IndetifyPoint();
                            OutData();
                            AskToStopProgramm();
                            InputStopProgrammKey();
                            break;
                        }

                }
            }
        }

        static void StopProgramm() 
        {
            stopProgrammKey = false;
        }

        static void AskToStopProgramm() 
        {
            Console.WriteLine("Чтобы выйти из программы введите 0, иначе - введите любой символ");
        }

        static void InputStopProgrammKey() 
        {
            key = Console.ReadLine();
        }

        static void IndetifyPosition()
        {

            IndetifyPoint();
            OutData();
        }

        static void IndetifyPoint()
        {
            if ((Math.Pow(x, 2) + Math.Pow(y, 2) <= 1) && (y >= -x - 1)) //y=kx+b  b=-1 k=-1
                isInChart = true;
        }

        static void OutData()
        {
            Console.WriteLine("Полученный результат: " + isInChart);
            if (isInChart)
                Console.WriteLine("Точка принадлежит заштрихованной области");
            else
                Console.WriteLine("Точка не принадлежит заштрихованной области");
            isInChart = false;
        }
        static void AskToInputX()
        {
            Console.WriteLine("Введите абсциссу точки (значение екоординаты Х)");
        }

        static void AskToInputY()
        {
            Console.WriteLine("Введите ординаты точки (значение екоординаты Y)");
        }

        static void InputX()
        {
            if (!(double.TryParse((Console.ReadLine()), out x)))
                AskToInputXAgain();
        }

        static void AskToInputXAgain()
        {
            Console.WriteLine("Введены не корректные данные, повторите ввод");
            InputX();
        }

        static void InputY()
        {
            if (!(double.TryParse((Console.ReadLine()), out y)))
                AskToInputYAgain();
        }

        static void AskToInputYAgain()
        {
            Console.WriteLine("Введены не корректные данные, повторите ввод");
            InputY();
        }
    }
}
