using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    internal class Ex3
    {

        static float fResult;
        static double dResult;

        static double a = 1000;
        static double b = 0.0001;

        static void Main()
        {
            GetFloatResult();
            OutFloatResult();
            GetDoubleResult();
            OutDoubleResult();
        }

        static void GetFloatResult() 
        {
            fResult = (float)((Math.Pow((a+b),4)-(Math.Pow(a,4)+6*Math.Pow(a,2)*Math.Pow(b,2)+4*a*Math.Pow(b,3)))/(Math.Pow(b,4)+4*Math.Pow(a,3)*b));
        }

        static void GetDoubleResult()
        {
            dResult = ((Math.Pow((a + b), 4) - (Math.Pow(a, 4) + 6 * Math.Pow(a, 2) * Math.Pow(b, 2) + 4 * a * Math.Pow(b, 3))) / (Math.Pow(b, 4) + 4 * Math.Pow(a, 3) * b));
        }

        static void OutFloatResult() 
        {
            Console.WriteLine("Результат записаный в перемeнную float = " + fResult);
        }

        static void OutDoubleResult()
        {
            Console.WriteLine("Результат записаный в перемeнную double = " + dResult);
        }

    }
}
