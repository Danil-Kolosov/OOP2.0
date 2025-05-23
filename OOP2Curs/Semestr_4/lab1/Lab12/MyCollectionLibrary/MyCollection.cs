﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace MyCollectionLibrary
{
    public class MyCollection<TKey, TVal> : ICollection, ICloneable, IDictionary<TKey, TVal>, IEnumerable<KeyValuePair<TKey, TVal>>
    {
        //Point<TKey, TVal> begin;
        Point<TKey, TVal>[] hashTable;      

        public bool IsSynchronized { get{ return hashTable.IsSynchronized; }} //является ли коллекция потокобезопасной - чтобы одновременно к 1 ячейке несколько не обратились

        public object SyncRoot { get { return hashTable.SyncRoot; } } //объект с помощью которого можно синхронизировать доступ к коллекции

        public TVal this[TKey key]
        {
            get
            {
                if (hashTable == null)
                    throw new ArgumentNullException("Хэш таблица не инициализирована");
                if (!this.ContainsKey(key))
                    throw new KeyNotFoundException("Данный ключ отсутсвует в хэш-таблице");
                return hashTable[Math.Abs(key.GetHashCode()) % hashTable.Length].Value;
            }
            set 
            {
                if (hashTable == null)
                    throw new ArgumentNullException("Хэш таблица не инициализирована");
                if (!this.ContainsKey(key))
                    throw new KeyNotFoundException("Данный ключ отсутсвует в хэш-таблице");
                hashTable[Math.Abs(key.GetHashCode()) % hashTable.Length].Value = value;
            }
        }

        public ICollection<TVal> Values 
        {
            get 
            {
                List<TVal> valList = new List<TVal>();
                for (int i = 0; i < Count; i++) 
                {
                    if (hashTable[i] != null)
                        valList.Add(hashTable[i].Value);
                }
                return valList;
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                List<TKey> keyList = new List<TKey>();
                for (int i = 0; i < Count; i++)
                {
                    if (hashTable[i] != null)
                        keyList.Add(hashTable[i].Key);
                }
                return keyList;
            }
        }

        //public Point<TKey, TVal> Begin
        //{
        //    get
        //    {
        //        if (hashTable == null)
        //            return null;
        //        else
        //            return begin;
        //    }
        //}

        public int Count 
        { 
            get 
            { 
                if (hashTable == null) 
                    return 0; 
                else 
                    return hashTable.Length; 
            }
        }

        public bool IsReadOnly { get { return false; } }

        public MyCollection()
        {
            hashTable = null;
            //begin = null;
        }

        public MyCollection(int size)
        {
            if (size > 0)
            {
                hashTable = new Point<TKey, TVal>[size];
                //begin = hashTable[0];
            }
            else
                hashTable = null;
        }

        public MyCollection(MyCollection<TKey, TVal> e)
        {
            int size = e.hashTable.Length;
            hashTable = new Point<TKey, TVal>[size];

            for (int i = 0; i < size; i++)
            {
                if (e.hashTable[i] != null)
                {
                    hashTable[i] = new Point<TKey, TVal>(e.hashTable[i]);
                    Point<TKey, TVal> curr = e.hashTable[i].Next;
                    while (curr != null)
                    {
                        hashTable[i].Next = new Point<TKey, TVal>(curr);
                        curr = curr.Next;
                    }
                }
            }
            //begin = hashTable[0];
        }

        MyCollection(ref Point<TKey, TVal>[] oldTable)
        {
            hashTable = oldTable;
            //begin = hashTable[0];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<KeyValuePair<TKey,TVal>> GetEnumerator()
        {
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
                    {
                        Point<TKey, TVal> curr = hashTable[i];
                        while (curr != null)
                        {
                            KeyValuePair<TKey, TVal> pair = new KeyValuePair<TKey, TVal> (curr.Key, curr.Value);
                            yield return  pair;
                            curr = curr.Next;
                        }
                    }
                }
                i++;
            }
        }        

        public void Add(TKey key ,TVal val)
        {
            if (val == null || hashTable == null)
            {
                throw new ArgumentNullException("Хэш-таблица не инициализирована");
            }

            Point<TKey, TVal> data = new Point<TKey, TVal>(key, val, hashTable.Length);
            if (hashTable[Math.Abs(data.Key.GetHashCode())%hashTable.Length] == null)
            {
                hashTable[Math.Abs(data.Key.GetHashCode()) % hashTable.Length] = data;
            }
            else
            {
                Point<TKey, TVal> cur = hashTable[Math.Abs(data.Key.GetHashCode()) % hashTable.Length];
                while (cur.Next != null) 
                {
                    if (Equals(cur.Value, val))
                        return; //Хотим добавить уже добавленный элемент
                    cur = cur.Next;
                }
                cur.Next = data;                                  
            }
            //for (int i = 0; i < hashTable.Length; i++) //БЕГИН уже не нужен - использовали иименованый итератор
            //{
            //    if (hashTable[i] != null)
            //    {
            //        begin = hashTable[i];
            //        i = hashTable.Length;
            //    }
            //}
        }

        public void Add(KeyValuePair<TKey,TVal> pair)
        {
            TKey key = pair.Key;
            TVal val = pair.Value;
            if(key == null || val == null)
                throw new ArgumentNullException("Переданы пустые параметры");
            this.Add(key, val);
        }

        public void Print()
        {
            if (hashTable == null)
                Console.WriteLine("Хэш-таблица не инициализирована");
            else
            {
                for (int i = 0; i < hashTable.Length; i++)
                {
                    if (hashTable[i] != null)
                    {
                        Point<TKey, TVal> data = new Point<TKey, TVal>(hashTable[i]);
                        while (data != null)
                        {
                            Console.WriteLine($"{i + 1} : " + data.ToString());
                            data = data.Next;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1} : ключ не задан : значение не задано");
                    }
                }
            }
        }

        public void Clear()
        {
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

        public bool RemoveAmongNexts(TVal val, int i) 
        {
            if (Equals(hashTable[i].Value, val))
            {
                hashTable[i] = hashTable[i].Next;
                return true;
            }
            Point<TKey, TVal> curr = hashTable[i];
            Point<TKey, TVal> beforeCurr = hashTable[i];
            int step = 0;
            while (curr != null)
            {
                if (Equals(curr.Value, val))
                {
                    if (step > 0)
                        beforeCurr.Next = curr.Next;
                    else
                        hashTable[i] = hashTable[i].Next;
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

        public bool Remove(TVal val)
        {
            if (hashTable == null)
                throw new ArgumentNullException("Хэш таблица пуста");
            if (val == null)
                throw new ArgumentNullException("Переданный параметр является null");

            for (int i = 0; i < hashTable.Length; i++)
            {
                if (hashTable[i] != null)
                {
                    if (Equals(hashTable[i].Value, val))
                    {
                        if (hashTable[i].Next == null)
                        {
                            hashTable[i] = null;
                            return true;
                        }
                        else
                        {
                            if (this.RemoveAmongNexts(val, i))
                                return true;                            
                        }
                        return true;
                    }
                    else
                    {
                        if (hashTable[i].Next != null)
                            if (this.RemoveAmongNexts(val, i))
                                return true;
                    }
                }
            }
            return false;
        }

        public bool Remove(KeyValuePair<TKey, TVal> pair)
        {
            return (Remove(pair.Value));
        }

        public bool Remove(TKey key) 
        {
            if (hashTable == null)
                throw new ArgumentNullException("Хэш таблица пуста");
            if (key == null)
                throw new ArgumentNullException("Переданный параметр является null");
            int index = (Math.Abs(key.GetHashCode()) % hashTable.Length);         
            if (hashTable[index] == null)
                return false;
            if (hashTable[index].Next == null)
            {
                hashTable[index] = null;
                return true;
            }
            else
            {
                if (Equals(hashTable[index].Key, key))
                {
                    hashTable[index] = hashTable[index].Next;
                    return true;
                }
                Point<TKey, TVal> curr = hashTable[index];
                Point<TKey, TVal> beforeCurr = hashTable[index];
                int step = 0;
                while (curr != null)
                {

                    if (Equals(curr.Key, key))
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

        public bool TryGetValue(TKey key, out TVal val) 
        {
            if(!ContainsKey(key))
            { 
                val = default(TVal);
                return false; 
            }

            int index = (Math.Abs(key.GetHashCode()) % hashTable.Length); 
            val = hashTable[index].Value;
            return true;

        }

        public bool Contains(KeyValuePair<TKey, TVal> pair)
        {
            if (hashTable == null)
                throw new ArgumentNullException("Хэш таблица не инициализирована");
            int index = (Math.Abs(pair.Key.GetHashCode()) % hashTable.Length);
            if (hashTable[index] == null)
                return false;
            if (hashTable[index].Next == null)
            {
                return Equals(hashTable[index].Value, pair.Value);
            }
            else
            {
                Point<TKey, TVal> curr = hashTable[index];
                while (curr != null)
                {
                    if (Equals(curr.Value, pair.Value))
                        return true;
                    else
                        curr = curr.Next;
                }
                return false;
            }
        }

        public bool ContainsKey(TKey key) 
        {
            if (hashTable == null)
                throw new ArgumentNullException("Хэш таблица не инициализирована");

            int index = (Math.Abs(key.GetHashCode()) % hashTable.Length);
            if (hashTable[index] == null)
                return false;
            if (hashTable[index].Next == null)
            {
                return Equals(hashTable[index].Key, key);
            }
            else
            {
                Point<TKey, TVal> curr = hashTable[index];
                while (curr != null)
                {
                    if (Equals(curr.Key, key))
                        return true;
                    else
                        curr = curr.Next;
                }
                return false;
            }
        }

        public bool ContainsValue(TVal val) 
        {
            for (int i = 0; i < hashTable.Length; i++) 
            {
                if (hashTable[i] != null)
                    if (Equals(hashTable[i].Value, val))
                        return true;
            }
            return false;
        }
        
        public void CopyTo(Array array, int firstCopyedIIndex = 0)
        {
            if (hashTable == null)
                throw new ArgumentNullException("Хэш таблица не инициализирована");
            if (firstCopyedIIndex < 0)
                throw new ArgumentOutOfRangeException("Индекс начала копирования не может быть отрицательным");
            if (Count > array.Length - firstCopyedIIndex)
                throw new ArgumentOutOfRangeException("Новый массив имеет меньше элементов, чем копируемая хэш таблица");

            for (int i = 0; i < Count; i++)
            {
                array.SetValue(hashTable[i].Value, i + firstCopyedIIndex);
            }
        }

        public void CopyTo(KeyValuePair<TKey,TVal>[] array, int firstCopyedIIndex = 0)
        {
            if (hashTable == null)
                throw new ArgumentNullException("Хэш таблица не инициализирована");
            if (firstCopyedIIndex < 0)
                throw new ArgumentOutOfRangeException("Индекс начала копирования не может быть отрицательным");
            if (Count > array.Length - firstCopyedIIndex)
                throw new ArgumentOutOfRangeException("Новый массив имеет меньше элементов, чем копируемая хэш таблица");
            
            for (int i = 0; i < Count; i++)
            {
                KeyValuePair<TKey, TVal> pair = new KeyValuePair<TKey, TVal>(array[i].Key, array[i].Value);
                array[i + firstCopyedIIndex] = pair;
            }
        }

        public object Clone()
        {
            int size = hashTable.Length;
            Point<TKey, TVal>[] newTable = new Point<TKey, TVal>[size];
            for (int i = 0; i < size; i++)
            {
                if (hashTable[i] != null)
                {
                    newTable[i] = new Point<TKey, TVal>(hashTable[i]);
                    Point<TKey, TVal> curr = hashTable[i].Next;
                    Point<TKey, TVal> currNew = newTable[i];
                    while (curr != null)
                    {
                        currNew.Next = new Point<TKey, TVal>(curr);
                        curr = curr.Next;
                        currNew = currNew.Next;
                    }
                }
            }
            return (MyCollection<TKey, TVal>)(new MyCollection<TKey, TVal>(ref newTable));
        }

        public MyCollection<TKey, TVal> DeepCloning()
        {
            return (MyCollection<TKey, TVal>)(this.Clone());
        }

        public MyCollection<TKey, TVal> Copyng()
        {
            return (MyCollection<TKey, TVal>)this.MemberwiseClone();          
        }

        public override bool Equals(Object obj)
        {
            if (obj is MyCollection<TKey, TVal> collection)
            {
                if (hashTable == null & collection.hashTable == null)
                    return true;
                if (hashTable.Length == collection.Count)
                {
                    for (int i = 0; i < hashTable.Length; i++)
                    {
                        if (!Equals(hashTable[i], collection.hashTable[i]))
                            return false;
                    }
                    return true;
                }
            }
            return false;            
        }
    }
}
