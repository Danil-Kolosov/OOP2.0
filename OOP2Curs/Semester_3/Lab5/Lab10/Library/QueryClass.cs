using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLibrary
{
    public class Query
    {
        //Наименование птиц в зоопарке
        //Сколько собак в зоопарке
        //В какое время суток бодрствует Рич
        public static void BirdsNameQuery(Animal[] zoo)
        {
            Console.WriteLine("Список имен птиц в зоопарке:");
            foreach (Animal an in zoo)
            {
                if (an is Bird)
                    Console.WriteLine(an.Name);
            }
        }

        public static void DogsNumberQuery(Animal[] zoo)
        {
            int dogsNumber = 0;
            //for (int i = 0; i < zoo.Length; i++) 
            //{
            //    if (zoo[i] is Mammal)
            //        {Mammal mamm = (Mammal)zoo[i];
            //        if (mamm.Specie == "Собака")
            //            dogsNumber++;
            //    }
            //}
            foreach (Animal an in zoo)
            {
                if (an is Mammal)
                {
                    Mammal mamm = (Mammal) an;
                    if (mamm.Specie == "Собака")
                        dogsNumber++;
                }
            }
            Console.WriteLine($"Количество собак в зоопарке: {dogsNumber}");
        }

        public static void GetLifeStyleByName(Animal[] zoo, string nickname = "Рич")
        {
            foreach (Animal an in zoo)
            {
                if (an is Mammal || an is Artiodactyl)
                {
                    Mammal mamm = (Mammal)an;
                    if (mamm.Name == nickname)
                    {
                        if (mamm.Lifestyle == "Дневной")
                        {
                            Console.WriteLine($"{mamm.Specie} {nickname} бодрствует днем");
                            return;
                        }
                        else 
                        {
                            Console.WriteLine($"{mamm.Specie} {nickname} бодрствует ночью");
                            return;
                        }                            
                    }
                }
            }
            Console.WriteLine($"Животное с именем {nickname} отсутсвует в зоопарке, или не имеет поля о времени бодрствования");
        }
    }
}
