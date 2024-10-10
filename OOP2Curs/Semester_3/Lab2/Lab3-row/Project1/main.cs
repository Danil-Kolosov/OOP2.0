using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class main
    {
        static void Main() 
        {
            for (double x = 0.2; x <= 1; x += 0.08)
            {
                double y = 0.5*Math.Log(x);
                double a = (x - 1) / (x + 1);
                double b = 1;
                double recurrenceRelation = Math.Pow(((x - 1) / (x + 1)), 2);
                double sumE1, sumE2;
                double sumN = a / b;
                double e = 0.0001;
                for(int n = 0; n < 9; n++)
                {
                    b+= 2;
                    a = a * recurrenceRelation;
                    sumN += a/b;
                }

                a = (x - 1) / (x + 1);
                b = 1;
                sumE1 = a/b;
                a = a * recurrenceRelation;
                b += 2;
                sumE2 = sumE1 + a / (b);
                for (; Math.Abs(sumE2) - Math.Abs(sumE1) >= e;) 
                {
                    b += 2;
                    a = a * (recurrenceRelation);
                    sumE1 = sumE2;
                    sumE2 += a/b;
                }
                Console.WriteLine(($"X = {x}".PadRight(8) +  $"  SN = {sumN}".PadRight(29) 
                    + $"  SE = {sumE2}".PadRight(29) + $"  Y = {y}").PadRight(27));
            }
        }
    }
}
