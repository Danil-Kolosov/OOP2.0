using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySpace
{
#pragma warning disable CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    public class Money
#pragma warning restore CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    {
        private static int counterObjects = 0;
        private int rubles;
        private int kopeks;

        public int Rubles
        {
            get
            {
                return rubles; // возвращаем значение свойства
            }
            set
            {
                if (value > 0)
                {
                    rubles = value; // устанавливаем новое значение свойства 
                }
                else
                {
                    rubles = 0;
                }
            }
        }

        public int Kopeks
        {
            get
            {
                return kopeks; // возвращаем значение свойства
            }
            set                 // устанавливаем новое значение свойства 
            {
                if(value>=100)
                {
                    Rubles = value / 100;
                    kopeks = value % 100;
                }
                else 
                {
                    if (value >= 0)
                        kopeks = value;
                    else
                    {
                        rubles = 0;
                        kopeks = 0;
                    }
                }
            }
        }

        public static int CounterObjects
        {
            get
            {
                return counterObjects;
            }
            set 
            {
                if (value > 0)
                {
                    counterObjects = value;
                }
            }
        }

        public Money()
        {
            counterObjects++;
            Console.WriteLine("Создался объект № " + counterObjects);
            Rubles = 0;
            Kopeks = 0;
        }
        public Money(int rubles, int kopeks)
        {
            counterObjects++;
            Console.WriteLine("Создался объект № " + counterObjects);
            Rubles = rubles;
            Kopeks = kopeks;
        }       

        public int Sum()
        {
            return Rubles * 100 + Kopeks;
        }      

        public void Show()
        {
            Console.WriteLine($"{rubles} руб.  {kopeks} коп.");
        }

        public static Money SubtractingKopeksStatic(Money m, int kopeksSubstract)
        {
            m.Kopeks = m.Sum() - kopeksSubstract;
            return m;
        }

        public Money SubtractingKopeks(int kopeksSubstract)
        {
            this.Kopeks = this.Sum() - kopeksSubstract;
            return this;

        }

        //Перегрузка унарных операций
        public static Money operator --(Money m)
        {
            m.Kopeks = m.Sum() - 1;
            return m;
        }

        public static Money operator ++(Money m)
        {
            m.Kopeks++;
            return m;
        }

        /// <summary>
        /// Явное преобразование
        /// </summary>
        public static explicit operator int(Money m)
        {
            return m.Kopeks;
        }

        /// <summary>
        /// Неявное преобразование
        /// </summary>
        public static implicit operator bool(Money m)
        {
            return (m.Sum() == 0);
        }

        //Перегрузка бинарных операций
        public static Money operator +(Money m, int kop) //в задании операция -, но копейки прибавляются - не понятно, сделаем +
        {
            Money temp = new Money();
            temp.Kopeks = m.Sum() + kop;
            return temp;
        }

        public static Money operator +(int kop, Money m) //в задании операция -, но копейки прибавляются - не понятно, сделаем +
        {
            Money temp = new Money();
            temp.Kopeks = m.Sum() + kop;
            return temp;
        }

        public static Money operator -(Money m1, Money m2)
        {
            Money temp = new Money();
            temp.Kopeks = m1.Sum()-m2.Sum();
            return temp;
        }

        public override bool Equals(Object obj)
        {
            if (obj is Money money)
                return ((Rubles == money.Rubles) & (Kopeks == money.Kopeks));
            return false;
        }
    }
}
