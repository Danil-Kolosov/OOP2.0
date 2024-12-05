using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Млекопитающее
namespace AnimalLibrary
{
    public class Mammal:Animal
    {
        string specie;
        string location;
        string livingEnvironment;
        //молоком кормит детей вскармливание
        //
        string lifestyle; //ночной дневной образ жизни
        //int maxAge;    ограничение по возрасту много волокиты будет, не стоит
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

        public Mammal():base()
        {
            Specie = "none";
            Location = "none";
            LivingEnvironment = "none";
            Lifestyle = "none";
        }

        public Mammal(float weight, float height, int age, string name, string specie, 
            string location, string livingEnvironment, string lifestyle):base(weight, height, age, name)
        {
            Specie = specie;
            Location = location;
            LivingEnvironment = livingEnvironment;
            Lifestyle = lifestyle;
        }

        public Mammal(Mammal mammal):base(mammal)//сделать через базовый класс
        {
            Specie = mammal.Specie;
            Location = mammal.Location;
            LivingEnvironment = mammal.LivingEnvironment;
            Lifestyle = mammal.Lifestyle;

            //Weight = mammal.Weight;//тут
            //Height = mammal.Height;
            //Age = mammal.Age;
            //Name = mammal.Name;//по сюда
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Вид: {Specie}\nМесто обитания: {Location}" +
                $"\nОреал обитания: {LivingEnvironment}\nОбраз жизни: {Lifestyle}");
        }

        //public override string ToString() { return $"{Specie} {Location} {LivingEnvironment} {Lifestyle}"; }
        //public  enum Geogreph { a= }; в перечисления можно только цифры:-(((
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
            //Console.Write("dsaaa", Geogreph.a);
            Specie = specie;
            Location = location;
            LivingEnvironment = livingEnvironment;
            Lifestyle = lifestyle;
        }

        public override void RandomInit()
        {
            base.RandomInit();

            //var rand = new Random();
            List<string> arrType = new List<string>(){"Волк", "Утконос", "Белка", "Дельфин", "Кит", 
                "Кот", "Собака", "Тигр", "Рысь",
                "Медведь", "Росомаха", "Ласка"};
            List<string> arrLocation = new List<string>(){"Африка", "Антарктида", "Европа",
                "Азия", "Северная Америка", "Южная Америка", "Австралия"};

            List<string> arrLifestyle = new List<string>(){"Дневной", "Ночной"};

            //Weight = rand.Next(1, 100);
            //Height = rand.Next(1, 7);
            //Age = rand.Next(1, 85);

            Specie = arrType[rand.Next(0, arrType.Count-1)];//*****
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
                //sMammal mamm = this;
                //bool x = ((Animal)mammal).Equals(mamm);
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

        //public new Mammal SuperficialCopy() //поверхностное копирование
        //{
        //    return (Mammal)this.MemberwiseClone();
        //}

    }
}
