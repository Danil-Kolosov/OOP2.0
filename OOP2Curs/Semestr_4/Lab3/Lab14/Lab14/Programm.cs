using System;
using System.Collections.Generic;
using System.Linq;
using AnimalLibrary;
using MyCollectionLibrary;
using System.Diagnostics; //Для замера времени

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
                Animal anim = new Animal(1, 1, 1, "Повторюшка");
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
            Stopwatch stopwatch = new Stopwatch();

            Stopwatch timer_no_extension = new Stopwatch();
            Stopwatch timer_extension = new Stopwatch();


            List<Animal> tempList = (collectionDictionaryZoo.Values).SelectMany(section => section).ToList();
            int n = tempList.Count();
            //var query2 = (from section in collectionDictionaryZoo.Values
            //              from animal in section
            //              where animal is Animal && animal.Weight > 50
            //              select animal);
            var query2 = collectionDictionaryZoo.Values.SelectMany(section => section).Where(animal => animal is Animal && animal.Weight > 50);
            timer_no_extension.Start();
            for (int i = 0; i < n; ++i)
            {
                Animal animal = tempList[i];
                if (animal.Weight > 50)
                {
                    animal.ToString();
                }
            }
            timer_no_extension.Stop();

            timer_extension.Start();
            foreach (var item in query2)
            {
                item.ToString();
            }
            timer_extension.Stop();

            stopwatch.Start();
            foreach (var item in whereOrderByQ)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            stopwatch.Stop();
            Console.WriteLine($"Время {stopwatch.ElapsedMilliseconds} мс");

            Console.WriteLine("Методами расширения");

            stopwatch.Reset();
            stopwatch.Start();
            var whereOrderByQExtension = collectionDictionaryZoo.Values
            .SelectMany(queue => queue)
            .Where(animalE => animalE.Weight > 50)
            .OrderBy(person => person.Age)
            .ToList();
            stopwatch.Stop();
            Console.WriteLine($"Время {(double)stopwatch.ElapsedTicks / Stopwatch.Frequency * 1000} мс");
            //Console.WriteLine($"Время {stopwatch.Elapsed} мс");
            stopwatch.Reset();
            stopwatch.Start();
            foreach (var item in whereOrderByQExtension)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            stopwatch.Stop();
            Console.WriteLine($"Время {(double)stopwatch.ElapsedTicks / Stopwatch.Frequency * 1000} мс");



            //
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Вывести животных первой и последней секций без повторений");

            var UnionQ = (from animalQ in collectionDictionaryZoo.Values.SelectMany(animal => animal) //                                                         where !((animal is Mammal)|| (animal is Artiodactyl) || (animal is Bird)) 
                          select animalQ)
                     .Concat
                     (
                     from animalQ in collectionDictionaryZoo.Values.SelectMany(animal => animal)
                     select animalQ
                     ).Distinct();
            stopwatch.Reset();
            stopwatch.Start();
            foreach (var item in UnionQ)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            stopwatch.Stop();
            Console.WriteLine($"Время {stopwatch.ElapsedMilliseconds} мс");

            Console.WriteLine();
            Console.WriteLine("Методами расширения");
            var unionQExtension = collectionDictionaryZoo.Values.SelectMany(animal => animal)
            .Union(collectionDictionaryZoo.Values.SelectMany(animal => animal));

            stopwatch.Reset();
            stopwatch.Start();
            foreach (var item in unionQExtension)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            stopwatch.Stop();
            Console.WriteLine($"Время {stopwatch.ElapsedMilliseconds} мс");


            //
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Самое долго живущее животное в зоопарке");

            stopwatch.Reset();
            stopwatch.Start();
            var MaxAgeQ = (from section in collectionDictionaryZoo.Values
                           from animal in section.ToArray()
                           select animal).Max();
            stopwatch.Stop();
            Console.WriteLine($"Время {(double)stopwatch.ElapsedTicks / Stopwatch.Frequency * 1000} мс");
            Console.WriteLine($"{MaxAgeQ}\nВозраст: {MaxAgeQ.Age}");
            Console.WriteLine();


            //
            Console.WriteLine();
            Console.WriteLine("Методами расширений");

            stopwatch.Reset();
            stopwatch.Start();
            var MaxAgeQExtension = collectionDictionaryZoo.Values
            .SelectMany(queue => queue)
            .Max(age => age);
            stopwatch.Stop();
            Console.WriteLine($"Время {(double)stopwatch.ElapsedTicks / Stopwatch.Frequency * 1000} мс");
            Console.WriteLine($"{MaxAgeQExtension}\nВозраст: {MaxAgeQ.Age}");
            Console.WriteLine();

            //
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Сгруппировать млекопитающих по образу жизни");

            stopwatch.Reset();
            stopwatch.Start();
            var mammalsLivivngEnvironment = (from section in collectionDictionaryZoo.Values
                                             from animalQ in section.ToArray()
                                             where animalQ is Mammal
                                             group animalQ by ((Mammal)animalQ).LivingEnvironment /*into birdGroup
                              from birds in birdGroup
                              select birds*/
                              );
            stopwatch.Stop();
            foreach (var item in mammalsLivivngEnvironment)
            {
                Console.WriteLine($"Естественный ареал обитания: {item.Key}");
                foreach (Mammal mam in item)
                    Console.WriteLine($"Имя: {mam.Name} Вид: {mam.Specie}");
                Console.WriteLine();
            }
            Console.WriteLine($"Время {(double)stopwatch.ElapsedTicks / Stopwatch.Frequency * 1000} мс");


            //
            Console.WriteLine();
            Console.WriteLine("Методами расширений");
            var BirdsNamesExtension = collectionDictionaryZoo.Values
            .SelectMany(queue => queue)
            .Where(ani => ani is Mammal)
            .GroupBy(ani => ((Mammal)ani).LivingEnvironment);

            stopwatch.Reset();
            stopwatch.Start();
            foreach (var item in BirdsNamesExtension)
            {
                Console.WriteLine($"Естественный ареал обитания: {item.Key}");
                foreach (Mammal mam in item)
                    Console.WriteLine($"Имя: {mam.Name} Вид: {mam.Specie}");
                Console.WriteLine();
            }
            stopwatch.Stop();
            Console.WriteLine($"Время {(double)stopwatch.ElapsedTicks / Stopwatch.Frequency * 1000} мс");


            //
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Сколько корма каждому животному нужно");
            var FoodSuply = from section in collectionDictionaryZoo.Values
                            from animalQ in section.ToArray()
                            let averageFoodKG = animalQ.Weight * 0.105
                            select new
                            {
                                animalQ,
                                averageFoodKG
                            };
            stopwatch.Reset();
            stopwatch.Start();
            foreach (var item in FoodSuply)
            {
                Console.WriteLine($"Для {item.animalQ.Name} в среднем необходимо {item.averageFoodKG} кг пищи в день");
                Console.WriteLine();
            }
            stopwatch.Stop();
            Console.WriteLine($"Время {(double)stopwatch.ElapsedTicks / Stopwatch.Frequency * 1000} мс");

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
            stopwatch.Reset();
            stopwatch.Start();
            foreach (var item in FoodSuplyExtension)
            {
                Console.WriteLine($"Для {item.Name} в среднем необходимо {item.averageFoodKG} кг пищи в день");
                Console.WriteLine();
            }
            stopwatch.Stop();
            Console.WriteLine($"Время {(double)stopwatch.ElapsedTicks / Stopwatch.Frequency * 1000} мс");


            //
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Сколько корма каждому животному нужно + по средам обитания");
            var FoodSuplyLivingEnvironment = from livEn in mammalsLivivngEnvironment
                                             from anim in livEn
                                             join foodS in FoodSuply on anim.Name equals foodS.animalQ.Name
                                             select new
                                             {
                                                 anim.Name,
                                                 LivingEnvironment = livEn.Key,
                                                 Food = foodS.averageFoodKG
                                             };
            stopwatch.Reset();
            stopwatch.Start();
            foreach (var item in FoodSuplyLivingEnvironment)
            {
                Console.WriteLine($"Для {item.Name} живущего в {item.LivingEnvironment} среде, в среднем необходимо {item.Food} кг пищи в день");
                Console.WriteLine();
            }
            stopwatch.Stop();
            Console.WriteLine($"Время {(double)stopwatch.ElapsedTicks / Stopwatch.Frequency * 1000} мс");



            //
            Console.WriteLine();
            Console.WriteLine("Методами расширений");
            //как ЭТО РАБОТАЕТ
            var FoodSuplyLivingEnvironmentExtension = mammalsLivivngEnvironment
                //в элементах mammalsLivivngEnvironment храниться два поля - string среда обитания и Animal животное,
                //их принимаем и на их основе создаем анонимный объект
                .SelectMany(livEn => livEn, (livEn2, anim) => new { livEn2, anim }) // Разворачиваем коллекцию и создаем анонимный объект
                .Join(FoodSuply, // Вторая последовательность
                    combiner => combiner.anim.Name, // Ключ из первой последовательности

                    foodS => foodS.animalQ.Name, // Ключ из второй последовательности
                    (combined, foodS) => new // Результат объединения
                    {
                        combined.anim.Name,
                        LivingEnvironment = combined.livEn2.Key,
                        Food = foodS.averageFoodKG
                    });
            stopwatch.Reset();
            stopwatch.Start();
            foreach (var item in FoodSuplyLivingEnvironmentExtension)
            {
                Console.WriteLine($"Для {item.Name} живущего в {item.LivingEnvironment} среде, в среднем необходимо {item.Food} " +
                    $"кг пищи в день");
                Console.WriteLine();
            }
            stopwatch.Stop();
            Console.WriteLine($"Время {(double)stopwatch.ElapsedTicks / Stopwatch.Frequency * 1000} мс");


            Console.WriteLine("\n\n\nСоздадим объект зоопарк MyNewCollection");
            MyCollection<string, Animal> zoo = new MyCollection<string, Animal>(3)
            {
                { "Рептилии", new Animal(13, 5, 6, "Анаконда") },
                { "Рептилии", new Animal(50, 3, 34, "Крокодил") },
                { "Приматы", new Animal(10, 8, 7, "Шимпанзе") }
            };
            foreach (KeyValuePair<string, Animal> pair in zoo)
                Console.WriteLine($"{pair.Key} {pair.Value}");


            Console.WriteLine("\nС помощью метода расширения этой коллекции SelectionOnCondition выведем список " +
                "всех рептилий в зоопарке");
            var allReptilies = zoo.SelectionOnCondition(item => item.Key == "Рептилии");
            stopwatch.Reset();
            stopwatch.Start();
            foreach (var item in allReptilies)
            {
                Console.WriteLine($"{item.Key} {item.Value.ToString()}");
            }
            stopwatch.Stop();
            Console.WriteLine($"Время {(double)stopwatch.ElapsedTicks / Stopwatch.Frequency * 1000} мс");



            Console.WriteLine("\nТеперь найдем среднее и максимальное значения возраста всех животных");
            stopwatch.Reset();
            stopwatch.Start();
            double averageAge = 0;
            //double.TryParse(zoo.MyAggregate(item => item.Value.Age, (a, b) => a + b, true).ToString(), out averageAge);
            averageAge = zoo.MyAggregate(item => item.Value.Age, (a, b) => a + b, true);
            stopwatch.Stop();
            Console.WriteLine($"Время нахождения среднего возраста: {(double)stopwatch.ElapsedTicks / Stopwatch.Frequency * 1000} мс");

            stopwatch.Reset();
            stopwatch.Start();
            double maxAge = zoo.MyAggregate(item => item.Value.Age, (a, b) => (a > b) ? a : b);
            stopwatch.Stop();
            Console.WriteLine($"Время нахождения максимального возраста: {(double)stopwatch.ElapsedTicks / Stopwatch.Frequency * 1000} мс");

            Console.WriteLine($"\nСрeдний возраст равен {averageAge}, при этом максимальный - {maxAge}");

            Console.WriteLine("\nОтсортируем по уменьшению роста");

            var zooOrderByHeight = zoo
            .Order(item => item.Value.Height, true);
            stopwatch.Reset();
            stopwatch.Start();
            foreach (var item in zooOrderByHeight)
                if (item.Value != null)
                {
                    Console.WriteLine($"\n{item.Key}");
                    item.Value.Show();
                }
            stopwatch.Stop();
            Console.WriteLine($"Время группировки: {(double)stopwatch.ElapsedTicks / Stopwatch.Frequency * 1000} мс");

            Console.WriteLine("\n\nElapsed ticks ( 1 - no_extension | 2 - extension):");
            Console.WriteLine($"Elapsed ticks: {timer_no_extension.Elapsed.Ticks}");
            Console.WriteLine($"Elapsed ticks: {timer_extension.Elapsed.Ticks}");
        }

    }
}