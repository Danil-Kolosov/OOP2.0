using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLibrary
{
    internal class External_Interactions
    {
        public static void Input(ref int data, int minValue = -100000, int maxValue = 100000, string introductoryMessage = "")
        {
            Console.OutputEncoding = Encoding.Unicode;
            if (introductoryMessage != "")
            {
                OutInformation(introductoryMessage);
            }
            if (!(int.TryParse((Console.ReadLine()), out data)) || data < minValue || data > maxValue)
            {
                Input(ref data, minValue, maxValue, "Введены не корректные данные, повторите");
            }
        }

        public static void Input(ref float data, int minValue = -1000, int maxValue = 1000, string introductoryMessage = "")
        {
            Console.OutputEncoding = Encoding.Unicode;
            if (introductoryMessage != "")
            {
                OutInformation(introductoryMessage);
            }
            if (!(float.TryParse((Console.ReadLine()), out data)) || data < minValue || data > maxValue)
            {
                Input(ref data, minValue, maxValue, "Введены не корректные данные, повторите");
            }
        }
        public static void Input(ref string data, string introductoryMessage = "")
        {
            Console.OutputEncoding = Encoding.Unicode;
            if (introductoryMessage != "")
            {
                OutInformation(introductoryMessage);
            }
            data = Console.ReadLine();
        }

        public static void OutInformation(string information)
        {
            Console.WriteLine(information);
        }
    }
}
