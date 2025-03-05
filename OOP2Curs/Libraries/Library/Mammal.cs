using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Млекопитающее
namespace AnimalLibrary
{
    public class Mammal : Animal
    {
        string specie;
        string location;
        string livingEnvironment;
        string lifestyle; //ночной дневной образ жизни

        public Animal BaseAnimal
        {
            get
            {
                //Animal newAn = new Animal(Weight, Height, Age, Name);
                //newAn.Number = this.Number;
                //staticNumber++;
                //return newAn;
                return new Animal(Weight, Height, Age, Name/*, Number*/);//возвращает объект базового класса
            }
        }

        public string Specie
        {
            get
            {
                return specie;
            }
            set
            {
                specie = value;
            }
        }

        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }

        public string LivingEnvironment
        {
            get
            {
                return livingEnvironment;
            }
            set
            {
                livingEnvironment = value;
            }
        }

        public string Lifestyle
        {
            get
            {
                return lifestyle;
            }
            set
            {
                lifestyle = value;
            }
        }

        public Mammal(int numberKeyManage = -1) : base(numberKeyManage)
        {
            Specie = "none";
            Location = "none";
            LivingEnvironment = "none";
            Lifestyle = "none";
        }

        public Mammal(float weight, float height, int age, string name, string specie,
            string location, string livingEnvironment, string lifestyle) : base(weight, height, age, name)
        {
            Specie = specie;
            Location = location;
            LivingEnvironment = livingEnvironment;
            Lifestyle = lifestyle;
        }

        public Mammal(Mammal mammal) : base(mammal)
        {
            Specie = mammal.Specie;
            Location = mammal.Location;
            LivingEnvironment = mammal.LivingEnvironment;
            Lifestyle = mammal.Lifestyle;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Вид: {Specie}\nМесто обитания: {Location}" +
                $"\nОреал обитания: {LivingEnvironment}\nОбраз жизни: {Lifestyle}");
        }

        public override void Init()
        {
            base.Init();
            string specie = "";
            string location = "";
            string livingEnvironment = "";
            string lifestyle = "";
            External_Interactions.Input(ref specie, "Введите тип животного млекопитающего: ");
            External_Interactions.Input(ref location, "Введите географическое местоположение млекопитающего: ");
            External_Interactions.Input(ref livingEnvironment, "Введите ореал обитания млекопитающего: ");
            External_Interactions.Input(ref lifestyle, "Введите образ жизни (дневной/ночной) млекопитающего: ");//убрать может просто этот пракметр

            Specie = specie;
            Location = location;
            LivingEnvironment = livingEnvironment;
            Lifestyle = lifestyle;
        }

        public override void RandomInit()
        {
            base.RandomInit();

            List<string> arrType = new List<string>(){"Волк", "Утконос", "Белка", "Дельфин", "Кит",
                "Кот", "Собака", "Тигр", "Рысь",
                "Медведь", "Росомаха", "Ласка"};
            List<string> arrLocation = new List<string>(){"Африка", "Антарктида", "Европа",
                "Азия", "Северная Америка", "Южная Америка", "Австралия"};

            List<string> arrLifestyle = new List<string>() { "Дневной", "Ночной" };

            Specie = arrType[rand.Next(0, arrType.Count - 1)];//*****
            Location = arrLocation[rand.Next(0, arrLocation.Count - 1)]; ;
            if (Specie != "Дельфин" & Specie != "Кит")
                LivingEnvironment = "Наземно-воздушная";
            else
                LivingEnvironment = "Водная";
            Lifestyle = arrLifestyle[rand.Next(0, arrLifestyle.Count - 1)];
        }

        public override bool Equals(Object obj)
        {
            if (obj is Mammal mammal)
            {
                return (base.Equals(obj) & (Specie == mammal.Specie)
                & (Location == mammal.Location) & (LivingEnvironment == mammal.LivingEnvironment)
                & (Lifestyle == mammal.Lifestyle));
            }
            return false;
        }

        public override object Clone()
        {
            Mammal clone = new Mammal(this);
            clone.Name = $"Клон {clone.Name}";
            return clone;
        }

        public override void VirtualShow()
        {
            External_Interactions.OutInformation("Виртуалный вывод - млекопитающее");
        }

        public new void UnVirtualShow()
        {
            //Console.WriteLine("НЕ виртуалный вывод - млекопитающее");
            base.Show();
            Console.WriteLine($"Вид: {Specie}\nМесто обитания: {Location}" +
                $"\nОреал обитания: {LivingEnvironment}\nОбраз жизни: {Lifestyle}");
        }

        public override string ToString()
        {
            return base.ToString() +  $" {Specie} {Location} " +
                $"{LivingEnvironment} {Lifestyle}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Specie, Location, LivingEnvironment, Lifestyle);
        }

    }
}
