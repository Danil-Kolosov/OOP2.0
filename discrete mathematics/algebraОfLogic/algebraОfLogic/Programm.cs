using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algebraОfLogic
{
    internal class Programm
    {
        public static void Main() 
        {
            int commandKey = 0;            
            bool isWorking = true;
            while (isWorking)
            {
                Console.WriteLine("1. Задать значения результатов функции\n2. Вывести СДНФ\n3. Вывести СКНФ\n4. Вывести МДНФ\n5. Выход");
                Logica.Input(ref commandKey, 1, 5);
                Console.WriteLine("\n");
                switch (commandKey)
                {
                    case 1:
                        Logica.InputData();
                        break;
                    case 2:
                        Logica.OutSDNF();
                        break;
                    case 3:
                        Logica.OutSKNF();
                        break;
                    case 4:
                        Logica.OutMDNF();
                        break;
                    case 5:
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("\nВведена не существующая команда\n");
                        break;
                }
                Console.WriteLine("\n\n");
            }
        }
    }
}
