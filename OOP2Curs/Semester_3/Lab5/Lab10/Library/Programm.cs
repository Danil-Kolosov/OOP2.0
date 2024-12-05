using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLibrary
{
    internal class Programm
    {
        public static void Main() 
        {
           Artiodactyl ar1 = new Artiodactyl();
           Artiodactyl ar2 = new Artiodactyl();
            ar2.Init();
            Console.WriteLine(ar1.Equals(ar2));
            Mammal mamm = new Mammal();
            Animal ar3 = (Animal)mamm.Clone();
            ar3.Show();
            Animal ar4 = (Animal)ar1.Clone();
            ar4.Show();
        }
    }
}
