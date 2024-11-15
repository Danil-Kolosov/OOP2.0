using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySpace
{
    public class Money
    {
        private static int counterObjects = 0;
        private int rubles;
        private int kopeks;

        public Money()
        {
            counterObjects++;
            Console.WriteLine("Создался объект № " + counterObjects);
            Rubles = 0;
            Kopeks = 0;
            //this.rubles = 0;
            //this.kopeks = 0;

        }
        public Money(int rubles, int kopeks)
        {
            counterObjects++;
            Console.WriteLine("Создался объект № " + counterObjects);
            Rubles = rubles;
            Kopeks = kopeks;
            //this.rubles = rubles;
            //this.kopeks = kopeks;

        }

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
                if (value < 100)
                {
                    kopeks = value;
                }
                else
                {
                    if (value > 0)
                    {
                        int rub = Rubles;
                        rub += GetRubles(value);
                        kopeks = value - GetRubles(value) * 100;
                        rubles = rub;
                    }
                    else
                    {
                        kopeks = 0;
                    }
                }

            }
        }

        public int Sum
        {
            get
            {
                return Rubles * 100 + Kopeks;
            }

        }

        public static int CounterObjects
        {
            get
            {
                return counterObjects;
            }

        }

        public void Normalisation(int sum)
        {

            this.Rubles = GetRubles(sum);
            this.Kopeks = sum - GetRubles(sum) * 100;
        }

        public static int GetRubles(int sum)
        {
            return sum / 100;
        }

        public void Show()
        {
            Console.WriteLine($"{rubles} руб.  {kopeks} коп.");
        }

        public static Money SubtractingKopeksStatic(Money m, int kopeksSubstract) //void->Money
        {
            int sum = m.Sum;
            if (sum >= kopeksSubstract)
            {
                sum -= kopeksSubstract;
                m.Rubles = GetRubles(sum);
                m.Kopeks = sum - GetRubles(sum) * 100;
            }
            else
            {
                sum -= kopeksSubstract;
                m.Rubles = 0;
                m.Kopeks = 0;

                Console.WriteLine($"Обнаружена задолженость {GetRubles(sum * -1)} руб., {sum * -1 - GetRubles(sum * -1) * 100} коп. оформлен кредит на эту сумму с 1000% годовых ");
            }
            return m;
        }

        public Money SubtractingKopeks(int kopeksSubstract)
        {
            Money m = this;
            m = SubtractingKopeksStatic(this, kopeksSubstract);
            return m;
        }

        //Перегрузка унарных операций
        public static Money operator --(Money m)
        {
            SubtractingKopeksStatic(m, 1);
            return m;
        }

        public static Money operator ++(Money m)
        {
            m.kopeks++;
            int sum = m.Sum;
            m.Normalisation(sum);
            return m;
        }

        /// <summary>
        /// Явное преобразование
        /// </summary>
        public static explicit operator int(Money m)
        {
            return m.kopeks;
        }

        /// <summary>
        /// Неявное преобразование
        /// </summary>
        public static implicit operator bool(Money m)
        {
            return (m.Sum == 0);
        }

        //Перегрузка бинарных операций
        public static Money operator +(Money m, int kop) //в задании операция -, но копейки прибавляются - не понятно, сделаем +
        {
            Money temp = new Money();
            temp.rubles = m.rubles;
            temp.kopeks = m.kopeks + kop;
            int sum = temp.Sum;
            temp.Normalisation(sum);
            return temp;
        }

        public static Money operator +(int kop, Money m) //в задании операция -, но копейки прибавляются - не понятно, сделаем +
        {
            Money temp = new Money();
            temp.rubles = m.rubles;
            temp.kopeks = m.kopeks + kop;
            int sum = temp.Sum;
            temp.Normalisation(sum);
            return temp;
        }

        public static Money operator -(Money m1, Money m2)
        {
            Money temp = new Money();
            temp.rubles = m1.rubles;
            temp.kopeks = m1.kopeks;
            int sum2 = m2.Sum;
            temp.SubtractingKopeks(sum2);
            //temp.Normalisation(temp.Sum);
            return temp;
        }

        public override bool Equals(Object obj)
        {
            if (obj is Money money)
                return ((rubles == money.rubles) & (kopeks == money.kopeks));
            return false;
        }



    }
}
