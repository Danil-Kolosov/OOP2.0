using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLibrary
{
    public class SortByHeight: IComparer<Animal>
    {
        public int Compare(Animal obj1, Animal obj2) 
        {
            if (obj1 is Animal & obj2 is Animal)
            {
                Animal animal1 = (Animal)obj1;
                Animal animal2 = (Animal)obj2;
                return (int)(animal1.Height - animal2.Height);
            }
            else
                throw new ArgumentException("Переданные параметры имеют неверный тип");
        }
    }
}
