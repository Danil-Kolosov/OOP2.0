using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Птица
namespace AnimalLibrary
{
    public class Bird:Animal
    {
        int wingspan; //размах крыльев
        int flightRange; //дальность полета
        string specie;//вид

        public int Wingspan
        {
            get
            {
                return wingspan;
            }
            set
            {
                if (value > 0)
                {
                    wingspan = value;
                }
            }
        }

        public int FlightRange
        {
            get
            {
                return flightRange;
            }
            set
            {
                if (value > 0)
                {
                    flightRange = value;
                }
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

        public Bird() : base() 
        {
            wingspan = 0;
            flightRange = 0;
            specie = "none";
        }

        public Bird(float weight, float height, int age, string name, int wingspan, int flightRange, string specie) : base(weight, height, age, name)
        {
            Wingspan = wingspan;
            FlightRange = flightRange;
            Specie = specie;
        }

        public Bird(Bird bird):base(bird)
        {
            Wingspan = bird.Wingspan;
            FlightRange = bird.FlightRange;
            Specie = bird.Specie;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Размах крыльев: {Wingspan}\nДальность полета: {FlightRange}\nВид: {Specie}");
        }

        public override void Init()
        {
            base.Init();

            int wingspan = 0;
            int flightRange = 0;
            string spec = "";
            External_Interactions.Input(ref wingspan, 1, 10, "Введите размах крыльев птицы: ");
            External_Interactions.Input(ref flightRange, 1, 5000,"Введите дальность полета птицы: ");
            External_Interactions.Input(ref spec, "Введите вид птицы: ");


            Wingspan = wingspan;
            FlightRange = flightRange;
            Specie = spec;
        }

        public override void RandomInit()
        {
            base.RandomInit();

            List<string> arrSpecies = new List<string>(){ "Аист", "Буревестник", "Беркут", "Воробей", 
                "Ворона", "Голубь", "Грач", "Гусь", "Дятел", "Дрозд", "Жаворонок", "Журавль", 
                "Зимородок", "Иволга", "Индюк", "Курица", "Колибри", "Кукушка", "Ласточка", 
                "Лебедь", "Малиновка"};

            Specie = arrSpecies[rand.Next(0, arrSpecies.Count - 1)];
            Wingspan = rand.Next(1, 10);
            FlightRange = rand.Next(1, 5000);
        }

        public override bool Equals(Object obj)
        {
            if (obj is Bird bird)
            {
                return (base.Equals(obj) & (Wingspan == bird.Wingspan)
                    & (FlightRange == bird.FlightRange) & (Specie == bird.Specie));
            }
            return false;
        }

        public override object Clone()
        {
            Bird clone = new Bird(this);
            clone.Name = $"Клон {clone.Name}";
            return clone;
        }

        public override void VirtualShow()
        {
            External_Interactions.OutInformation("Виртуалный вывод - птица");
        }

        public new void UnVirtualShow()
        {
            External_Interactions.OutInformation("НЕ виртуалный вывод - птица");
        }
    }
}