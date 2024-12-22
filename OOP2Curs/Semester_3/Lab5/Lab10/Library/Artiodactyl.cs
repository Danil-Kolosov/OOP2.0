using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Парнокопытное
namespace AnimalLibrary
{
    public class Artiodactyl : Mammal
    {
        int hoofSize;  //размер копыт
        int hornsSize; //размер рогов
        public int HoofSize
        {
            get
            {
                return hoofSize;
            }
            set
            {
                if (value > 0)
                {
                    hoofSize = value;
                }
            }
        }

        public int HornsSize
        {
            get
            {
                return hornsSize;
            }
            set
            {
                if (value > 0)
                {
                    hornsSize = value;
                }
            }
        }

        public Artiodactyl():base() 
        {
            hoofSize = 0;
            hornsSize = 0;
            Specie = "none";
        }

        public Artiodactyl(float weight, float height, int age, string name, string specie, 
            string location, string livingEnvironment, string lifestyle, int hoofSize, int hornSize)
            :base(weight, height, age, name, specie, location, livingEnvironment, lifestyle) 
        {
            HoofSize = hoofSize;
            HornsSize = hornSize;
        }

        public Artiodactyl(Artiodactyl art) : base(art) 
        {
            HoofSize = art.HoofSize;
            HornsSize = art.HornsSize;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Размер копыт: {HoofSize} Размер рогов: {HornsSize}");
        }

        public override void Init()
        {
            base.Init();
            int hoofS = 0;
            int hornS = 0;
            External_Interactions.Input(ref hoofS, 1, 100, "Введите размер копыт парнокопытного: ");
            External_Interactions.Input(ref hornS, 1, 100, "Введите размер рогов парнокопытного: ");
            HoofSize = hoofS;
            HornsSize = hornS;
        }

        public override void RandomInit()
        {
            base.RandomInit();

            List<string> arrSpec = new List<string>(){"Антилопа ", "Баран", "Бегемот", "Бизон", "Жираф",};
            HoofSize = rand.Next(1, 10);
            HornsSize = rand.Next(1, 10);
            Specie = arrSpec[rand.Next(0, arrSpec.Count - 1)];
        }

        public override bool Equals(Object obj)
        {
            if (obj is Artiodactyl art)
            {
                if (obj is Mammal mam)
                    return (base.Equals(obj) & (HoofSize == art.HoofSize)
                        & (HornsSize == art.HornsSize));
            }
            return false;
        }

        public override object Clone()
        {
            Artiodactyl clone = new Artiodactyl(this);
            clone.Name = $"Клон {clone.Name}";
            return clone;
        }

        public override void VirtualShow()
        {
            External_Interactions.OutInformation("Виртуалный вывод - парнокопытное");
        }

        public new void UnVirtualShow()
        {
            //Console.WriteLine("НЕ виртуалный вывод - парнокопытное");
            base.Show();
            Console.WriteLine($"Размер копыт: {HoofSize} Размер рогов: {HornsSize}");
        }

        public override string ToString()
        {
            return base.ToString() + $"\nРазмер копыт: {HoofSize} Размер рогов: {HornsSize}";
        }
    }
}
