using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


namespace AnimalLibrary
{
    public class Animal : IInit, IComparable<Object>, ICloneable
    {
        protected float weight;
        protected float height;
        protected int age;
        protected string name;
        protected static Random rand = new Random();
        protected NoteClass note = new NoteClass();

        public float Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value > 0)
                {
                    weight = value;
                }
            }
        }

        public float Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value > 0)
                {
                    height = value;
                }
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 0)
                {
                    age = value;
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Note 
        {
            get 
            {
                return note.Note;
            }
            set 
            {
                note.Note = value;
            }
        }

        public Animal()
        {
            Weight = 0;
            Height = 0;
            Age = 0;
            Name = "none";
        }

        public Animal(float weight, float height, int age, string name)
        {
            Weight = weight;
            Height = height;
            Age = age;
            Name = name;
        }

        public Animal(Animal man)
        {
            Weight = man.weight;
            Height = man.height;
            Age = man.age;
            Name = man.name;
        }

        public virtual void Show()
        {
            Console.WriteLine("\n\nХарактеристики объекта: ");
            Console.WriteLine($"Имя: {name} Вес: {weight} Рост: {height} Возраст: {age}\nЗаметки по животному: {Note}");
        }

        public virtual void Init()
        {
            float w = 0;
            float h = 0;
            int a = 0;
            string n = "";
            External_Interactions.Input(ref w, 1, 1000, "Введите вес животного: ");
            External_Interactions.Input(ref h, 1, 1000, "Введите рост животного: ");
            External_Interactions.Input(ref a, 1, 1000, "Введите возраст животного: ");
            External_Interactions.Input(ref n, "Введите кличку животного: ");
            Weight = w;
            Height = h;
            Age = a;
            Name = n;
        }

        public virtual void RandomInit()
        {
            //var rand = new Random();
            Weight = rand.Next(1, 100);
            Height = rand.Next(1, 7);
            Age = rand.Next(1, 85);
            List<string> arrName = new List<string>(){"Рекс", "Джеси", "Хатико", "Дик",
                "Лорд", "Альма", "Рич", "Барон", "Вольт", "Каспер", "Лаки", "Грай",
                "Чарли", "Рей", "Макс", "Буч", "Багира", "Альфа", "Тайсон", "Боня",
                "Бим", "Татошка", "Джесси", "Герда", "Риччи", "Гром", "Алекс"};
            Name = arrName[rand.Next(0, arrName.Count - 1)];
        }

        public override bool Equals(Object obj)
        {
            if (obj is Animal animal)
                return ((Weight == animal.Weight) & (Height == animal.Height)
                    & (Age == animal.Age) & (Name == animal.Name));
            return false;
        }

        public int CompareTo(object obj)
        {
            if (obj is Animal animal)
            {
                return Age.CompareTo(animal.Age);
                //if (this.Equals(animal))
                //    return 0;
                //if (Age > animal.Age)
                //    return 1;
                //else
                //    return -1;
            }
            else 
            {
                throw new ArgumentException("Переданный параметр имеет недопустимый тип");
            }             
        }

        public virtual object Clone() 
        {
            Animal clone =  new Animal(this);
            clone.Name = $"Клон {clone.Name}";
            return clone;
        }

        public virtual Animal SuperficialCopy() //поверхностное копирование
        {
            this.Name = $"Клон {this.Name}";
            return (Animal)this.MemberwiseClone();
        }


        //запросы

        //Наименование птиц в зоопарке
        //Сколько собак в зоопарке
        //В какое время суток бодрствует Рич
        //public static void BirdsNameQuery(Animal[] zoo)
        //{
        //    Console.WriteLine("Список имен птиц в зоопарке:");
        //    foreach (Animal an in zoo)
        //    {
        //        if (an is Bird)
        //            Console.WriteLine(an.Name);
        //    }
        //}

        //public static void DogsNumberQuery(Animal[] zoo)
        //{
        //    int dogsNumber = 0;
        //    foreach (Animal an in zoo)
        //    {
        //        if (an is Mammal)
        //        {
        //            Mammal mamm = (Mammal)an;
        //            if (mamm.Specie == "Собака")
        //                dogsNumber++;
        //        }
        //    }
        //    Console.WriteLine($"Количество собак в зоопарке: {dogsNumber}");
        //}

        //public static void GetLifeStyleByName(Animal[] zoo, string nickname = "Рич")
        //{
        //    foreach (Animal an in zoo)
        //    {
        //        if (an is Mammal || an is Artiodactyl)
        //        {
        //            Mammal mamm = (Mammal)an;
        //            if (mamm.Name == "Рич")
        //            {
        //                if (mamm.Lifestyle == "Дневной")
        //                    Console.WriteLine($"{mamm.Specie} {nickname} бодрствует днем");
        //                else
        //                    Console.WriteLine($"{mamm.Specie} {nickname} бодрствует ночью");
        //            }
        //        }
        //    }
        //    Console.WriteLine($"Животное с именем {nickname} отсутсвует, или не имеет поля о времени бодрствования");
        //}
    }
}
