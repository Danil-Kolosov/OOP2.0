using System;
using System.Collections;

//using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using AnimalLibrary;


namespace MyCollectionLibrary
{
    public class MyCollection<T> : /*MyEnumerator<T>,*/ /*!!!IEnumerable<T>,*/ ICollection<T>, ICloneable
    {
        //T begin;
        Point<T> begin;
        //List<List<T>> hashTable;
        Point<T>[] hashTable;
        T defaultValue = default;

        //
        public MyCollection()
        {
            //hashTable = new Point<T>[0];
            //begin = null;
        }

        public MyCollection(int size)
        {
            if (size > 0)
            {
                //Point<T> item = new Point<T>();
                hashTable = new Point<T>[size];
                //for (int i = 0; i < size; i++) 
                //{
                //    hashTable[i] = new Point<T>(i);
                //}
                begin = hashTable[0];
            }
            else
                hashTable = null;
        }
        //конструкторы
        public MyCollection(MyCollection<T> e)
        {
            int size = e.hashTable.Length;
            hashTable = new Point<T>[size];

            for (int i = 0; i < size; i++)
            {
                if (e.hashTable[i] != null)
                //if (hashTable[i].Value != null)
                {
                    hashTable[i] = new Point<T>(e.hashTable[i]);
                    Point<T> curr = e.hashTable[i].Next;
                    while (curr != null)
                    {
                        hashTable[i].Next = new Point<T>(curr);
                        curr = curr.Next;
                    }
                }
            }
        }
        //еще один

        MyCollection(ref Point<T>[] oldTable)
        {
            hashTable = oldTable;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Point<T> Begin
        {
            get
            {
                if (hashTable == null)
                    return null;/*new Point(hashTable[0][0], Next(hashTable[0], 0));*//*hashTable[0][0];*/
                else
                    return begin;
            }

        }

        //public T Next(List<T>,) { }

        public IEnumerator<T> GetEnumerator()
        {
            //return new MyEnumerator<T>(this);
            int i = 0;
            while (true)
            {
                if (i == hashTable.Length)
                {
                    yield break;
                }
                else
                {
                    if (hashTable[i] != null)
                    //if (hashTable[i].Value != null)
                    {
                        Point<T> curr = hashTable[i];
                        while (curr != null)
                        {
                            yield return curr.Value;
                            curr = curr.Next;
                        }
                    }
                }
                i++;
            }
        }

        public void Add(T val)
        {
            if (val == null || hashTable == null /*|| hashTable.Length == 0*/)
            {
                throw new ArgumentNullException("Хэш-таблица не инициализирована");
                //return;
            }

            //int index = val.GetHashCode();
            Point<T> data = new Point<T>(val, hashTable.Length);
            if (hashTable[data.Key] == null)
            {
                hashTable[data.Key] = data;
                //hashTable[data.Key] = new List<T>(1);
                //hashTable[data.Key][0] = val;
                //if (hashTable.Count > data.Key + 1)
                //    data.Next = hashTable[data.Key + 1];
                //else
                //    data.Next = null; и так будет

            }
            else
            {
                //if (string.Compare(data.ToString(), (hashTable[data.Key]).ToString()) == 0)
                if (Equals(hashTable[data.Key], val))
                    return; //Хотим добавить уже добавленный элемент
                hashTable[data.Key].Next = data;
            }
            for (int i = 0; i < hashTable.Length; i++) //БЕГИН уже не нужен - использовали иименованый итератор
            {
                if (hashTable[i] != null)
                {
                    begin = hashTable[i];
                    i = hashTable.Length;
                }
            }
            //return; 
        }

        public void Print()
        {
            if (hashTable == null /*|| hashTable.Length == 0*/)
                Console.WriteLine("Хэш-таблица не инициализирована");
            else
            {
                for (int i = 0; i < hashTable.Length; i++)
                {
                    if (hashTable[i] != null)
                    {
                        Point<T> data = new Point<T>(hashTable[i]);//Point<T>(hashTable[i].Value)
                        while (data != null)
                        {
                            Console.WriteLine(data.ToString());//!!!!!!!!!!@
                            data = data.Next;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1} : пусто");
                    }
                }
            }
        }

        public void Clear()
        {
            //hashTable = null;
            //begin = null;
            for(int i = 0;i < hashTable.Length; i++) 
            {
                hashTable[i] = null;
            }
        }

        public void Delete() 
        {
            this.Clear();
            hashTable = null;
        }


        public bool Remove(T val)
        {
            int a = 0;
            if (hashTable == null /*|| hashTable.Length == 0*/)
                throw new ArgumentNullException("Хэш таблица пуста");
            if (val == null)
                throw new ArgumentNullException("Переданный параметр является null");
            int index = (Math.Abs(val.GetHashCode()) % hashTable.Length);
            //return false;            
            if (hashTable[index] == null)
                return false;//пусто же стало a net
            if (hashTable[index].Next == null)
            {
                hashTable[index] = null;
                return true;
            }
            else
            {
                if (Equals(hashTable[index].Value, val))
                {
                    hashTable[index] = hashTable[index].Next;
                    return true;
                }
                Point<T> curr = hashTable[index];
                Point<T> beforeCurr = hashTable[index];
                int step = 0;
                while (curr != null)
                {

                    if (Equals(curr.Value, val))
                    {
                        if (step > 0)
                            beforeCurr.Next = curr.Next;
                        else
                            hashTable[index] = hashTable[index].Next;
                        return true;
                    }
                    else
                    {
                        if (step > 0)
                        {
                            beforeCurr = curr;
                        }
                        curr = curr.Next;
                    }
                    step++;
                }
                return false;
            }
        }

        public bool Contains(T val)
        {
            if (hashTable == null /*|| hashTable.Length == 0*/)
                throw new ArgumentNullException("Хэш таблица не инициализирована");
            //if (hashTable == null)
            //   return false;
            int index = (Math.Abs(val.GetHashCode()) % hashTable.Length);
            if (hashTable[index] == null)
                return false;
            if (hashTable[index].Next == null)
            {
                return Equals(hashTable[index].Value, val);
            }
            else
            {
                Point<T> curr = hashTable[index];
                while (curr != null)
                {
                    if (Equals(curr.Value, val))
                        return true;
                    else
                        curr = curr.Next;
                }
                return false;

            }
            //return true;


            //Point<T> current = new Point<T>(hashTable[0].Value);
            /*for(int i = 0; i < hashTable.Length; i++) 
            {
                Point<T> current = new Point<T>(hashTable[i].Value);

                while (current != null) 
                {
                    if((hashTable[i].Value).Equals(current.Value))
                        return i;
                    current = current.Next;
                }
            }
            return -1;*/
            //while(current)
        }

        public int Count { get { if (hashTable == null) return 0; else return hashTable.Length; } }

        public bool IsReadOnly { get { return false; } }

        public void CopyTo(T[] array, int firstCopyedIIndex = 0)
        {
            if (hashTable == null)
                throw new ArgumentNullException("Хэш таблица не инициализирована");
            if (firstCopyedIIndex < 0)
                throw new ArgumentOutOfRangeException("Индекс начала копирования не может быть отрицательным");
            if (Count > array.Length - firstCopyedIIndex)
                throw new ArgumentOutOfRangeException("Новый массив имеет меньше элементов, чем копируемая хэш таблица");

            for (int i = 0; i < Count; i++)
            {
                array[i + firstCopyedIIndex] = hashTable[i].Value;
            }
        }

        //public bool IsSynchronized { get { return false; }}



        //public bool ContainsKey(in) { } там же индексы чего там искать ключи

        public object Clone()
        {
            int size = hashTable.Length;
            Point<T>[] newTable = new Point<T>[size];
            for (int i = 0; i < size; i++)
            {
                if (hashTable[i] != null)
                //if (hashTable[i].Value != null)
                {
                    newTable[i] = new Point<T>(hashTable[i]);
                    Point<T> curr = hashTable[i].Next;
                    while (curr != null)
                    {
                        newTable[i].Next = new Point<T>(curr);
                        curr = curr.Next;
                    }
                }
            }
            return (MyCollection<T>)(new MyCollection<T>(ref newTable));
        }

        public MyCollection<T> DeepCloning()
        {            
            return (MyCollection<T>)(this.Clone());
        }

        public MyCollection<T> Copyng(/*Point<T>[] oldTable*/)
        {

            return (MyCollection<T>)this.MemberwiseClone();//new MyCollection<T>(ref hashTable);
            //Point<T>[] oldTable = this.hashTable;
            //int size = hashTable.Length;
            ////Point<T>[] newTable = new Point<T>[size];
            //MyCollection<T> newTable = new MyCollection<T>(size);
            //for (int i = 0; i < size; i++)
            //{
            //    if (hashTable[i] != null)
            //        if (hashTable[i].Value != null)
            //            newTable.Add(hashTable[i].Value);
            //}
            //return newTable;
        }

        //public void Resize() { }
    }


}
