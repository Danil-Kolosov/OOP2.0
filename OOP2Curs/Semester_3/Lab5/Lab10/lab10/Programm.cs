using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AnimalLib;
using AnimalLibrary;

namespace lab10
{
    public class Programm : IInit
    {
        public static void Main()
        {
            Console.InputEncoding = System.Text.Encoding.GetEncoding("utf-16");

            Console.WriteLine("Создадим массив из объектов иерархии и реализуем на нем запросы");

            Animal[] zoo = new Animal[6];
            zoo[0] = new Animal();
            zoo[1] = new Mammal();
            zoo[2] = new Artiodactyl();
            zoo[3] = new Bird();
            zoo[4] = new Artiodactyl();
            zoo[5] = new Bird();

            for (int i = 0; i < zoo.Length; i++)
            {
                zoo[i].RandomInit();
                zoo[i].Show();
            }

            Console.WriteLine("\nЗапрос на имена всех птиц");
            //Animal.BirdsNameQuery(zoo);
            Query.BirdsNameQuery(zoo);

            Console.WriteLine("\nЗапрос на количество собак");
            //Animal.DogsNumberQuery(zoo);
            Query.DogsNumberQuery(zoo);

            Console.WriteLine("\nЗапрос на время бодрствования (день/ночь) по имени животного\nВведите имя для запроса");          
            //Animal.GetLifeStyleByName(zoo, Console.ReadLine());
            Query.GetLifeStyleByName(zoo, Console.ReadLine());

            Console.WriteLine("\nНажмите Enter для продолжения");
            Console.ReadLine();

            Console.WriteLine("\n\nПосле сортировки IComparable по возростанию возроста:");
            Array.Sort(zoo);
            foreach (Animal an in zoo)
                an.Show();

            Console.WriteLine("\n\nПосле сортировки ICompare по возростанию роста:");
            Array.Sort(zoo, new SortByHeight());
            foreach (Animal an in zoo)
                an.Show();

            Console.WriteLine("\nНажмите Enter для продолжения");
            Console.ReadLine();

            //бинарный поиск
            Console.WriteLine("Ищем в массиве:");
            Array.Sort(zoo);
            foreach (Animal an in zoo)
                an.Show();
            Animal animalToSearch = new Animal();
            //добавить выбор ищем animal или другого
            Console.WriteLine("Введите возраст животного, который будет использоваться в бинарном поиске:");//автоматом выбирать один из массива, другой пустой - показать - нашлол не ншло
            int ageSearch = 0;
            while (!(int.TryParse((Console.ReadLine()), out ageSearch)) || ageSearch <= 0) 
            {
                Console.WriteLine("Нужно ввести целое число");
            }
            animalToSearch.Age = ageSearch;
             // поиск в отсортированом массиве бинарно
            //Animal animalToSearch = zoo[2];
            if (Array.BinarySearch(zoo, animalToSearch) >= 0)
                Console.WriteLine($"Элемент с такими полями находится под номером {1 + Array.BinarySearch(zoo, animalToSearch)}");
            else
                Console.WriteLine($"Элемент с такими полями не найден");

            animalToSearch.Show();

            Console.WriteLine("\nНажмите Enter для продолжения");
            Console.ReadLine();

            //List<IInit> arr = new List<IInit>();//Массив с типом — именем интерфейса на C# будет содержать объекты, реализующие этот интерфейс
            IInit[] arrIInit = new IInit[5];

            Console.WriteLine("\n\nИллюстрация работы методов Init RandomInit объектов иерархии классов и нового класса - акулы: ");
            Animal nullAnimal = new Animal();
            nullAnimal.Init();
            arrIInit[0] = nullAnimal;
            Console.WriteLine("Получаем массив: ");
            ((Animal)arrIInit[0]).Show();

            nullAnimal = new Mammal();
            nullAnimal.RandomInit();
            arrIInit[1] = nullAnimal;
            ((Mammal)arrIInit[1]).Show();

            nullAnimal = new Artiodactyl();
            nullAnimal.RandomInit();
            arrIInit[2] = nullAnimal;
            ((Artiodactyl)arrIInit[2]).Show();

            nullAnimal = new Bird();
            nullAnimal.RandomInit();
            arrIInit[3] = nullAnimal;
            ((Bird)arrIInit[3]).Show();

            SharkNewClassIInit shark = new SharkNewClassIInit();
            shark.RandomInit();
            arrIInit[4] = shark;
            ((SharkNewClassIInit)arrIInit[4]).Show();

            Console.WriteLine("\nНажмите Enter для продолжения");
            Console.ReadLine();

            Console.WriteLine("\n\nИллюстрация разницы поверхностного и глубокого клонирований: ");
            Console.WriteLine("На основе объекта Mammal");
            Mammal mammal = new Mammal();          
            mammal.RandomInit();
            mammal.Show();
            Console.WriteLine("\nПоверхностным клонированием получаем");
            Mammal mammalSuperficialCopying = (Mammal)mammal.SuperficialCopy();
            mammalSuperficialCopying.Show();
            Console.WriteLine("\nИзменяем значение атрибутa ссылочного типа Note с 'none' на 'Любит, когда ему чешут спинку'");
            mammal.Note = "Любит, когда ему чешут спинку";
            mammalSuperficialCopying.Show();
            Console.WriteLine("Значение атрибута none объекта первоисточника также изменилось:");
            mammal.Show();
            Console.WriteLine("\nКопируя с помощью глубокого клонирования такого не произойдет");

            Mammal mammalDeepСopying = (Mammal)mammal.Clone();
            Console.WriteLine("У склонированного объекта задаем note как 'Любит, когда ему чешут за ухом'");
            mammalDeepСopying.Note = "Любит, когда ему чешут за ухом";
            mammalDeepСopying.Show();
            Console.WriteLine("\nУ исходного объекта остается 'Любит, когда ему чешут спинку'");
            mammal.Show();



            //Реализовать клонирование и тесты осталось + алекватыное представление кода
            //   +запросы + ссылки для копирования

            //for (int i = 0; i < arrIInit.Length; i++) 
            //{
            //    var typ = arrIInit[i].GetType();
            //    var new_object = Convert.ChangeType(arrIInit[i], arrIInit[i].GetType());
            //    new_object.
            //    var f = ((typ.GetTyp)(arrIInit[i])).Show();


            //}

            //Mammal nullMammal = new Mammal();
            //nullAnimal.RandomInit();
            //arrIInit[1] = nullAnimal;
            //((Mammal)arrIInit[]).Show();

            //Artiodactyl nullArtiodactyl = new Artiodactyl();
            //nullAnimal.RandomInit();
            //arrIInit[2] = nullAnimal;
            //((Artiodactyl)arrIInit[0]).Show();

            //Bird nullBird = new Bird();
            //nullAnimal.RandomInit();
            //arrIInit[3] = nullAnimal;
            //((Bird)arrIInit[0]).Show();

            //SharkNewClassIInit shark = new SharkNewClassIInit();
            //shark.RandomInit();
            //arrIInit[4] = shark;
            //((SharkNewClassIInit)arrIInit[0]).Show();
        }
        public void Init() { }
        public void RandomInit() { }
        public void Temp() 
        {
            //Artiodactyl ar1 = new Artiodactyl();
            //Artiodactyl ar2 = new Artiodactyl();
            //ar2.Init();
            //Console.WriteLine(ar1.Equals(ar2));
            //Mammal mamm = new Mammal();
            //Animal ar3 = (Animal)mamm.Clone();
            //ar3.Show();
            //Animal ar4 = (Animal)ar1.Clone();
            //ar4.Show();

            //Animal nullAnimal = new Animal();
            //arr.Add(nullAnimal);
            //arr.Add(nullAnimal);
            //arr.Add(nullAnimal);
            //arr[0].RandomInit();
            //arr[1].RandomInit();
            //arr[2].RandomInit();



            //задания 5 и 6
            //List<IInit> arr = new List<IInit>();//Массив с типом — именем интерфейса на C# будет содержать объекты, реализующие этот интерфейс
            //for (int i = 0; i < 5; i++) 
            //{
            //    Animal nullAnimal = new Animal();
            //    nullAnimal.RandomInit();
            //    arr.Add(nullAnimal);
            //    ((Animal)arr[i]).Show();
            //}

            //сортируем compare и sortByHeight
            Animal[] arr = new Animal[5];
            for (int i = 0; i < 5; i++)
            {
                Animal nullAnimal = new Animal();
                nullAnimal.RandomInit();
                arr[i] = nullAnimal;
                //arr.Add(nullAnimal);
                ((Animal)arr[i]).Show();
                Console.WriteLine(i);
            }
            Array.Sort(arr, new SortByHeight());
            //arr.Sort(arr, new Animal());
            for (int i = 0; i < 5; i++)
            {
                ((Animal)arr[i]).Show();
            }
        }
    }
}