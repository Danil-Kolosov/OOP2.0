using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary;


namespace Lab11
{
    public class TestCollections
    {
        private List<Mammal> list1 = new List<Mammal>();
        private List<string> list2 = new List<string>();
        private Dictionary<Animal, Mammal> dictionary1 = new Dictionary<Animal, Mammal>();
        private Dictionary<string, Mammal> dictionary2 = new Dictionary<string, Mammal>();
        //Коллекция_1<TValue> ; 
        //Коллекция_1<string> ; 
        //Коллекция_2<TKey, TValue> ; 
        //Коллекция_2<string, TValue>.
        //Dictionary<Person, Student> col2 = new Dictionary<Person, Student>();
        //Dictionary<string, Student> col2 = new Dictionary<string, Student>();

        public int Count {  get { return list1.Count; } }

        public Mammal List1First 
        {
            get 
            {
                return list1[0];
            }
        }

        public Mammal List1Medium
        {
            get
            {
                return list1[(list1.Count / 2)];
            }
        }

        public Mammal List1Last
        {
            get
            {
                return list1.Last();
            }
        }

        public string List2First
        {
            get
            {
                return list2[0];
            }
        }

        public string List2Medium
        {
            get
            {
                return list2[(list2.Count / 2)];
            }
        }

        public string List2Last
        {
            get
            {
                return list2.Last();
            }
        }

        public Animal Dictionary1FirstKey
        {
            get
            {
                return list1[0].BaseAnimal;
            }
        }

        public Animal Dictionary1MediumKey
        {
            get
            {
                return list1[(list1.Count / 2)].BaseAnimal;
            }
        }

        public Animal Dictionary1LastKey
        {
            get
            {
                return list1[list1.Count - 1].BaseAnimal;
            }
        }

        public string Dictionary2FirstKey
        {
            get
            {
                return list1[0].BaseAnimal.ToString();
            }
        }

        public string Dictionary2MediumKey
        {
            get
            {
                return list1[(list1.Count / 2)].BaseAnimal.ToString();
            }
        }

        public string Dictionary2LastKey
        {
            get
            {
                return list1[list1.Count - 1].BaseAnimal.ToString();
            }
        }

        public Mammal Dictionary2FirstValue
        {
            get
            {
                return list1[0];
            }
        }

        public Mammal Dictionary2MediumValue
        {
            get
            {
                return list1[(list1.Count / 2)];
            }
        }

        public Mammal Dictionary2LastValue
        {
            get
            {
                return list1[list1.Count - 1];
            }
        }


        public TestCollections(int size = 1000) 
        {
            for(int i = 0; i < size; i++)
            {
                //Animal man = new Mammal();
                Mammal man = new Mammal(1);
                man.RandomInit();
                list1.Add(man);
                list2.Add(man.ToString());
                Animal tMan = man.BaseAnimal;
                dictionary1.Add(man.BaseAnimal, man);
                dictionary2.Add(man.ToString(), man);
            }
        }

        public void Add(Mammal man) 
        {
            list1.Add(man);
            list2.Add(man.ToString());
            dictionary1.Add(man.BaseAnimal, man);
            dictionary2.Add(man.ToString(), man);
        }

        public void Delete(Mammal man)
        {
            list1.Remove(man);
            list2.Remove(man.ToString());
            dictionary1.Remove(man.BaseAnimal);
            dictionary2.Remove(man.ToString());
        }     

        //public void Searching()
        //{
        //    Console.WriteLine("Ищем первый элемент в list с типом - Mammal" + SearchingTimeList1(new Mammal(List1First)));
        //    Console.WriteLine("Ищем средний элемент в list с типом - Mammal" + SearchingTimeList1(new Mammal(List1Medium)));
        //    Console.WriteLine("Ищем последний элемент в list с типом - Mammal" + SearchingTimeList1(new Mammal(List1Last)));
        //    Console.WriteLine("Ищем не существующий элемент в list с типом - Mammal" + SearchingTimeList1(new Mammal()));

        //    Console.WriteLine();

        //    Console.WriteLine("Ищем первый элемент в list с типом - string" + SearchingTimeList2(List2First));
        //    Console.WriteLine("Ищем средний элемент в list с типом - string" + SearchingTimeList2(List2Medium));
        //    Console.WriteLine("Ищем последний элемент в list с типом - string" + SearchingTimeList2(List2Last));
        //    Console.WriteLine("Ищем не существующий элемент в list с типом - string" + SearchingTimeList2((new Mammal()).ToString()));

        //    Console.WriteLine();

        //    //В словарях используется функция получения хэш кода - без ее переопределения работать не будет
        //    //Потому что славарь на самомо деле - хэш таблица с навешаными функциями
        //    Console.WriteLine("Ищем с помощью ContainsKey");            
        //    Console.WriteLine("Ищем первый элемент в dictionary с ключом - Animal" + SearchingTimeDictionary1(new Animal(Dictionary1FirstKey)));
        //    Console.WriteLine("Ищем средний элемент в dictionary с ключом - Animal" + SearchingTimeDictionary1(new Animal(Dictionary1MediumKey)));
        //    Console.WriteLine("Ищем последний элемент в dictionary с ключом - Animal" + SearchingTimeDictionary1(new Animal(Dictionary1LastKey)));
        //    Console.WriteLine("Ищем не существующий элемент в list с типом - string" + SearchingTimeDictionary1(new Animal()));

        //    Console.WriteLine();

        //    Console.WriteLine("Ищем первый элемент в dictionary с ключом - string" + SearchingTimeDictionary2Key(Dictionary2FirstKey)); //для поиска по ключу: dictionary2[list2[0]].ToString()
        //    Console.WriteLine("Ищем средний элемент в dictionary с ключом - string" + SearchingTimeDictionary2Key(Dictionary2MediumKey));//для поиска по ключу: dictionary2[list2[(list2.Count / 2) - 1]].ToString()
        //    Console.WriteLine("Ищем последний элемент в dictionary с ключом - string" + SearchingTimeDictionary2Key(Dictionary2LastKey)); //для поиска по ключу: dictionary2[list2[list2.Count - 1]].ToString()
        //    Console.WriteLine("Ищем не существующий элемент в list с типом - string" + SearchingTimeDictionary2Key("neturrrrrrrerr"));

        //    Console.WriteLine();

        //    Console.WriteLine("Ищем с помощью ContainsValue");
        //    Console.WriteLine("Ищем первый элемент в dictionary с ключом - string" + SearchingTimeDictionary2Val(new Mammal(Dictionary2FirstValue))); //для поиска по ключу: dictionary2[list2[0]].ToString()
        //    Console.WriteLine("Ищем средний элемент в dictionary с ключом - string" + SearchingTimeDictionary2Val(new Mammal(Dictionary2MediumValue)));//для поиска по ключу: dictionary2[list2[(list2.Count / 2) - 1]].ToString()
        //    Console.WriteLine("Ищем последний элемент в dictionary с ключом - string" + SearchingTimeDictionary2Val(new Mammal(Dictionary2LastValue))); //для поиска по ключу: dictionary2[list2[list2.Count - 1]].ToString()
        //    Console.WriteLine("Ищем не существующий элемент в list с типом - string" + SearchingTimeDictionary2Val(new Mammal()));
        //}

        public string SearchingTimeList1(Mammal val) 
        {           
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            bool isFound = list1.Contains(val);
            stopWatch.Stop();
            string result = "\n";
            result += isFound ? $"Элемент найден за время {stopWatch.Elapsed.Ticks}" : $"Элемент не найден, затраченное время: {stopWatch.Elapsed.Ticks}";
            return result;
        }

        public string SearchingTimeList2(string val)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            bool isFound = list2.Contains(val);
            stopWatch.Stop();
            string result = "\n";
            result += isFound ? $"Элемент найден за время {stopWatch.Elapsed.Ticks}" : $"Элемент не найден, затраченное время: {stopWatch.Elapsed.Ticks}";
            return result;
        }

        public string SearchingTimeDictionary1(Animal key)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            bool isFound = dictionary1.ContainsKey(key);
            stopWatch.Stop();
            string result = "\n";
            result += isFound ? $"Элемент найден за время {stopWatch.Elapsed.Ticks}" : $"Элемент не найден, затраченное время: {stopWatch.Elapsed.Ticks}";
            return result;
        }

        public string SearchingTimeDictionary2Val(Mammal key)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            bool isFound = dictionary2.ContainsValue(key);
            stopWatch.Stop();
            string result = "\n";
            result += isFound ? $"Элемент найден за время {stopWatch.Elapsed.Ticks}" : $"Элемент не найден, затраченное время: {stopWatch.Elapsed.Ticks}";
            return result;
        }

        public string SearchingTimeDictionary2Key(string key) 
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            bool isFound = dictionary2.ContainsKey(key);
            stopWatch.Stop();
            string result = "\n";
            result += isFound ? $"Элемент найден за время {stopWatch.Elapsed.Ticks}" : $"Элемент не найден, затраченное время: {stopWatch.Elapsed.Ticks}";
            return result;
        }
    }
}
