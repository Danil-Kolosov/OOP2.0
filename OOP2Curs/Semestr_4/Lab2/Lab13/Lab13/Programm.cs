using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionEvent;
using AnimalLibrary;
namespace Lab13
{
    class Programm
    {
        public static void Main() 
        {
            //zoo.Add("директор", new Animal(1, 1, 1, "козел"));
            //zoo["директор"] = new Animal(1, 1, 1, "бабуин");
            //zoo.Remove("директор");
            MyNewCollection<string, Animal> zoo = new MyNewCollection<string, Animal>(5);
            zoo.Name = "Зоопарк";
            MyNewCollection<string, Animal> flat = new MyNewCollection<string, Animal>(5);
            flat.Name = "Квартира";

            Journal<Animal> allEventZoo = new Journal<Animal>();
            zoo.CollectionCountChanged += (sourcer, args) => allEventZoo.Add(new JournalEntry<Animal>(args.Name, args.Type, args.ObjectData));
            zoo.CollectionReferenceChanged += (sourcer, args) => allEventZoo.Add(new JournalEntry<Animal>(args.Name, args.Type, args.ObjectData));

            Journal<Animal> eitherRefChangEvent = new Journal<Animal>();
            zoo.CollectionReferenceChanged += (sourcer, args) => eitherRefChangEvent.Add(new JournalEntry<Animal>(args.Name, args.Type, args.ObjectData));
            flat.CollectionReferenceChanged += (sourcer, args) => eitherRefChangEvent.Add(new JournalEntry<Animal>(args.Name, args.Type, args.ObjectData));


            zoo.Add("Рептилии", new Animal(13, 5, 6, "Анаконда"));
            zoo.Add("Рептилии", new Animal(50, 60, 34, "Крокодил"));
            zoo.Add("Приматы", new Animal(10, 8, 7, "Шимпанзе"));

            zoo.Remove(new Animal(13, 5, 6, "Анаконда"));
            zoo.Remove("Приматы");
            zoo["Рептилии"] = new Animal(13, 5, 6, "Хамелион");



            flat.Add("Кошки", new Animal(13, 5, 6, "Барсик"));
            flat.Add("Собаки", new Animal(50, 60, 34, "Шарик"));
            flat.Add("Черепапшки", new Animal(10, 8, 7, "Леонардо"));

            flat.Remove(new Animal(13, 5, 6, "Леонардо"));
            flat.Remove("Собаки");
            flat["Кошки"] = new Animal(13, 5, 6, "Том");

            Console.WriteLine("\n\nЖурнал подписанный на все события происходящие в зоопарке");
            allEventZoo.Print();
            Console.WriteLine("\nЖурнал подписанный на события изменения объектов через индексатор происходящие в зоопарке и квартире");
            eitherRefChangEvent.Print();            
        }
    }
}
