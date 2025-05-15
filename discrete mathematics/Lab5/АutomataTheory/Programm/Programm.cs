using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using АutomataTheory;
using UI;
namespace Programm
{
    class Programm
    {
        public static void Main() 
        {
            KurumaMashine dedoosi = new KurumaMashine();
            string word = "";
            while (word != "0")
            {
                External_Interactions.Input(ref word, "Введите слово (для выхода из программы введите 0):");
                if(word != "0")
                    Console.WriteLine(dedoosi.ProcessWord(word));   
            }         
        }
    }
}
