using System;
using System.Collections.Generic;
using System.Linq;
using AnimalLibrary;
using MyCollectionLibrary;

namespace Lab14
{
    class Programm
    {
        public static void Main() 
        {
            Dictionary<string, Queue<Animal>> collectionDictionaryZoo = new Dictionary<string, Queue<Animal>>(4);

            for (int i = 0; i < 4; i++)
            {
                string key = i.ToString();
                Queue<Animal> section = new Queue<Animal>();
                collectionDictionaryZoo.Add(key, new Queue<Animal>(3));
                //for (int j = 0; j < 3; j++) 
                //{
                Animal anim = new Animal(1,1,1,"Повторюшка");
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
            Console.WriteLine();

            //запросы
            Console.WriteLine("Вывести животных с весом больше 50 кг отсортировано по возрастанию возраста");
            Console.WriteLine("Linq");
            var whereOrderByQ = (from section in collectionDictionaryZoo.Values
                                 from animal in section.ToArray()
                                 where animal is Animal && animal.Weight > 50
                                 orderby animal.Age
                                 select animal);
            
            foreach (var item in whereOrderByQ)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            Console.WriteLine("Методами расширения");
            var whereOrderByQExtension = collectionDictionaryZoo.Values
            .SelectMany(queue => queue)
            .Where(animalE => animalE.Weight > 50)
            .OrderBy(person => person.Age)
            .ToList();
            foreach (var item in whereOrderByQExtension)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }




            //
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Вывести животных первой и последней секций без повторений");
            var UnionQ = (from animalQ in collectionDictionaryZoo.Values.First() //                                                         where !((animal is Mammal)|| (animal is Artiodactyl) || (animal is Bird)) 
                     select animalQ)
                     .Concat
                     (
                     from animalQ in collectionDictionaryZoo.Values.Last()
                     select animalQ
                     ).Distinct();                                                                                                  //+.Concat перед distinct с тем же from полностью

            foreach (var item in UnionQ)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Методами расширения");
            var UnionQExtension = collectionDictionaryZoo.Values.Last()
            .Union(collectionDictionaryZoo.Values.First());

            foreach (var item in UnionQExtension)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }


            //
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Самое долго живущее животное в зоопарке");
            var MaxAgeQ = (from section in collectionDictionaryZoo.Values
                           from animal in section.ToArray()
                           orderby animal.Age
                           select animal).Last();            
            Console.WriteLine(MaxAgeQ);
            Console.WriteLine();


            //
            Console.WriteLine();
            Console.WriteLine("Методами расширений");
            var MaxAgeQExtension = collectionDictionaryZoo.Values
            .SelectMany(queue => queue)
            .Where(animalE => animalE.Age == (
                collectionDictionaryZoo.Values
                .SelectMany(queue => queue).Select(age => animalE.Age).Max())
            );
            Console.WriteLine(MaxAgeQ);
            Console.WriteLine();

            //
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Сгруппировать млекопитающих по образу жизни");
            var mammalsLivivngEnvironment = (from section in collectionDictionaryZoo.Values
                              from animalQ in section.ToArray()
                              where animalQ is Mammal
                              group animalQ by ((Mammal)animalQ).LivingEnvironment /*into birdGroup
                              from birds in birdGroup
                              select birds*/
                              );
            foreach (var item in mammalsLivivngEnvironment)
            {
                Console.WriteLine($"Естественный ареал обитания: {item.Key}");
                foreach (Mammal mam in item)
                    Console.WriteLine($"Имя: {mam.Name} Вид: {mam.Specie}");
                Console.WriteLine();
            }


            //
            Console.WriteLine();
            Console.WriteLine("Методами расширений");
            var BirdsNamesExtension = collectionDictionaryZoo.Values
            .SelectMany(queue => queue)
            .Where(ani => ani is Mammal)
            .GroupBy(ani => ((Mammal)ani).LivingEnvironment)
            ;

            foreach (var item in BirdsNamesExtension)
            {
                Console.WriteLine($"Естественный ареал обитания: {item.Key}");
                foreach(Mammal mam in item)
                    Console.WriteLine($"Имя: {mam.Name} Вид: {mam.Specie}");
                Console.WriteLine();
            }



            //
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Сколько корма каждому животному нужно");
            var FoodSuply = (from section in collectionDictionaryZoo.Values
                             from animalQ in section.ToArray()
                             let averageFoodKG = animalQ.Weight * 0.105
                             select new
                             {
                                 animalQ,
                                 averageFoodKG
                             }
                              );
            foreach (var item in FoodSuply)
            {
                Console.WriteLine($"Для {item.animalQ.Name} в среднем необходимо {item.averageFoodKG} кг пищи в день");
                Console.WriteLine();
            }

            //
            Console.WriteLine();
            Console.WriteLine("Методами расширений");
            var FoodSuplyExtension = collectionDictionaryZoo.Values
            .SelectMany(queue => queue)
            .Select(animalQ => new 
            {
                animalQ.Name,
                averageFoodKG = animalQ.Weight * 0.105
            });

            foreach (var item in FoodSuplyExtension)
            {
                Console.WriteLine($"Для {item.Name} в среднем необходимо {item.averageFoodKG} кг пищи в день");
                Console.WriteLine();
            }

            //
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Сколько корма каждому животному нужно + по средам обитания");
            var FoodSuplyLivingEnvironment = (from livEn in mammalsLivivngEnvironment
                                              from anim in livEn
                                              join foodS in FoodSuply on anim.Name equals foodS.animalQ.Name
                                              select new
                                              {
                                                  Name = anim.Name,
                                                  LivingEnvironment = livEn.Key,
                                                  Food = foodS.averageFoodKG
                                              }
                                               );
            foreach (var item in FoodSuplyLivingEnvironment)
            {
                Console.WriteLine($"Для {item.Name} живущего в {item.LivingEnvironment} среде, в среднем необходимо {item.Food} кг пищи в день");
                Console.WriteLine();
            }

            //
            Console.WriteLine();
            Console.WriteLine("Методами расширений");
            //как ЭТО РАБОТАЕТ
            var FoodSuplyLivingEnvironmentExtension = mammalsLivivngEnvironment
                //в элементах mammalsLivivngEnvironment храниться два поля - string среда обитания и Animal животное,
                //их принимаем и на их основе создаем анонимный объект
                .SelectMany(livEn => livEn, (livEn, anim) => new { livEn, anim }) // Разворачиваем коллекцию и создаем анонимный объект
                .Join(FoodSuply, // Вторая последовательность
                    combiner => combiner.anim.Name, // Ключ из первой последовательности
            
                    foodS => foodS.animalQ.Name, // Ключ из второй последовательности
                    (combined, foodS) => new // Результат объединения
                    {
                        Name = combined.anim.Name,
                        LivingEnvironment = combined.livEn.Key,
                        Food = foodS.averageFoodKG
                    });

            foreach (var item in FoodSuplyLivingEnvironmentExtension)
            {
                Console.WriteLine($"Для {item.Name} живущего в {item.LivingEnvironment} среде, в среднем необходимо {item.Food} " +
                    $"кг пищи в день");
                Console.WriteLine();
            }



            Console.WriteLine("\n\n\nСоздадим объект зоопарк MyNewCollection");
            MyCollection<string, Animal> zoo = new MyCollection<string, Animal>(3)
            {
                { "Рептилии", new Animal(13, 5, 6, "Анаконда") },
                { "Рептилии", new Animal(50, 3, 34, "Крокодил") },
                { "Приматы", new Animal(10, 8, 7, "Шимпанзе") }
            };
            foreach(KeyValuePair<string, Animal> pair in zoo)
                Console.WriteLine($"{pair.Key} {pair.Value}");


            Console.WriteLine("\nС помощью метода расширения этой коллекции SelectionOnCondition выведем список " +
                "всех рептилий в зоопарке");
            var allReptilies = zoo.SelectionOnCondition(item => item.Key == "Рептилии");
            foreach(var item in allReptilies) 
            {
                Console.WriteLine($"{item.Key} {item.Value.ToString()}");
            }

            Console.WriteLine("\nТеперь найдем среднее и максимальное значения возраста всех животных");

            double averageAge = zoo.MyAggregate(item => item.Value.Age, (a, b) => a + b, true);
            double maxAge = zoo.MyAggregate(item => item.Value.Age, (a,b) => (a > b) ? a : b);
            Console.WriteLine($"\nСрeдний возраст равен {averageAge}, при этом максимальный - {maxAge}");

            Console.WriteLine("\nОтсортируем по уменьшению роста");
     
            var zooOrderByHeight = zoo
            .Order(item => item.Value.Height, true);
            foreach (var item in zooOrderByHeight)
                if (item.Value != null)
                {
                    Console.WriteLine($"\n{item.Key}");
                    item.Value.Show(); 
                }
        }
    }
}