using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary;

namespace CollectionsQuery
{
    public class CollectionDictionaryZoo
    {
        //Dictionary<string, Queue> CollectionDictionaryZoo = new Dictionary<string, Queue>();
        public static void CollectionQuery()
        {
            Dictionary<string, Queue> collectionDictionaryZoo = new Dictionary<string, Queue>(4);

            for (int i = 0; i < 4; i++) 
            {
                string key = i.ToString();
                Queue section = new Queue();
                collectionDictionaryZoo.Add(key, new Queue(3));
                //for (int j = 0; j < 3; j++) 
                //{
                Animal anim = new Animal();
                anim.RandomInit();
                Mammal mammal = new Mammal();
                mammal.RandomInit();
                Artiodactyl artiodactyl = new Artiodactyl();
                artiodactyl.RandomInit();
                Bird bird = new Bird();
                bird.RandomInit();

                Console.WriteLine($"Секция {i}");
                bird.Show();
                artiodactyl.Show();
                mammal.Show();
                anim.Show();

                section.Enqueue(anim);
                section.Enqueue(mammal);
                section.Enqueue(artiodactyl);
                section.Enqueue(bird);

                collectionDictionaryZoo[key] = section; 
                
                //}
            }

            //linq запросы
            Console.WriteLine("Вывести животных с весом больше 50 кг отсортировано по возрастанию возраста");
            var q1 = from section in collectionDictionaryZoo.Values
                     from animal in section.ToArray()
                     where animal is Animal && ((Animal)animal).Weight > 50
                     group animal by ((Animal)animal).Age;                    
            foreach(Animal animal in q1)
                Console.WriteLine(animal);
            //расширения запросы
        }
    }
}
