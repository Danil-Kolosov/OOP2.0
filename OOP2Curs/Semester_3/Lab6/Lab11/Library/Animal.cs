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
        protected int number;
        protected static int staticNumber = 0;
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
        public int Number 
        {
            get { return number; }
            set { number = value; }
        }

        public Animal()
        {
            Weight = 0;
            Height = 0;
            Age = 0;
            Name = "none";
            Number = staticNumber;
            staticNumber++;
        }

        public Animal(float weight, float height, int age, string name, int number)
        {
            Weight = weight;
            Height = height;
            Age = age;
            Name = name;
            Number = number;
        }

        public Animal(Animal man)
        {
            Weight = man.weight;
            Height = man.height;
            Age = man.age;
            Name = man.name;
            Number = man.number;
            note = new NoteClass(man.Note);
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
            Animal clone = new Animal(this);
            clone.Name = $"Клон {clone.Name}";
            return clone;
        }

        public virtual Animal SuperficialCopy() //поверхностное копирование
        {
            Animal copy = (Animal)this.MemberwiseClone();
            copy.Name = $"Клон {copy.Name}";
            return copy;
        }

        public virtual void VirtualShow()
        {
            External_Interactions.OutInformation("Виртуалный вывод - животное");
        }

        public void UnVirtualShow()
        {
            //Console.WriteLine("НЕ виртуалный вывод - животное");
            Console.WriteLine("\n\nХарактеристики объекта: ");
            Console.WriteLine($"Имя: {name} Вес: {weight} Рост: {height} Возраст: {age}\nЗаметки по животному: {Note}");
        }

        public override string ToString()
        {
            return $"Имя: {name} Вес: {weight} Рост: {height} Возраст: {age} \nЗаметки по животному: {Note}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(weight, height, age, name, number);
        }
    }
}
