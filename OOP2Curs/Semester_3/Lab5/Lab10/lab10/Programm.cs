using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary;

namespace lab10
{
    public class Programm
    {
        public static void Main()
        {
            Console.InputEncoding = System.Text.Encoding.GetEncoding("utf-16");

            Console.WriteLine("Создадим переменную типа Animal и будем присваивать ссылки на все объекты иерархии\nПри этом вызовем виртуальные функции: ");
            Animal virtShow = new Animal();
            virtShow.RandomInit();
            Console.WriteLine("\nЖивотное");
            virtShow.Show();
            virtShow = new Mammal();
            virtShow.RandomInit();
            Console.WriteLine("\nМлекопитающее");
            virtShow.Show();
            virtShow = new Artiodactyl();
            virtShow.RandomInit();
            Console.WriteLine("\nПарнокопытное");
            virtShow.Show();
            virtShow = new Bird();
            virtShow.RandomInit();
            Console.WriteLine("\nПтица");
            virtShow.Show();
            Console.WriteLine("\nТеперь будем вызывать невиртуальные методы");
            virtShow = new Animal();
            virtShow.RandomInit();
            Console.WriteLine("\nЖивотное");
            virtShow.UnVirtualShow();
            virtShow = new Mammal();
            virtShow.RandomInit();
            Console.WriteLine("\nМлекопитающее");
            virtShow.UnVirtualShow();
            virtShow = new Artiodactyl();
            virtShow.RandomInit();
            Console.WriteLine("\nПарнокопытное");
            virtShow.UnVirtualShow();
            virtShow = new Bird();
            virtShow.RandomInit();
            Console.WriteLine("\nПтица");
            virtShow.UnVirtualShow();

            Console.WriteLine("\nНажмите Enter для продолжения");
            Console.ReadLine();


            Console.WriteLine("\n\nСоздадим массив из объектов иерархии и реализуем на нем запросы");

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

            Console.WriteLine("Введите возраст животного, который будет использоваться в бинарном поиске:");//автоматом выбирать один из массива, другой пустой - показать - нашлол не ншло
            int ageSearch = 0;

            while (!(int.TryParse((Console.ReadLine()), out ageSearch)) || ageSearch <= 0) 
            {
                Console.WriteLine("Нужно ввести целое число");
            }
            animalToSearch.Age = ageSearch;
            //поиск в отсортированом массиве бинарно
            //Animal animalToSearch = zoo[2];
            if (Array.BinarySearch(zoo, animalToSearch) >= 0)
                Console.WriteLine($"Элемент с такими полями находится под номером {1 + Array.BinarySearch(zoo, animalToSearch)}");
            else
                Console.WriteLine($"Элемент с такими полями не найден");

            animalToSearch.Show();

            Console.WriteLine("\nНажмите Enter для продолжения");
            Console.ReadLine();

            //Массив с типом — именем интерфейса на C# будет содержать объекты, реализующие этот интерфейс
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
        }
    }
}