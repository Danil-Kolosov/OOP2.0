using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSpace
{
    public class UserInterface
    {
        public static void Input(ref int data, int minValue = -100000, int maxValue = 100000, string introductoryMessage = "")
        {
            if (introductoryMessage != "")
            {
                OutInformation(introductoryMessage);
            }
            if (!(int.TryParse((Console.ReadLine()), out data)) || data < minValue || data > maxValue)
            {
                Input(ref data, minValue, maxValue, "Введены не корректные данные, повторите");
            }
        }

        public static void OutInformation(string information)
        {
            Console.WriteLine(information);
        }
    }
}
