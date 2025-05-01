using MyCollectionLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Text.Json.Serialization;


namespace MyCollectionLibrary
{
    [Serializable]
    
    //[XmlRoot("AnimalCollection")]
    public class MyCollection<TKey, TVal> : ICollection, ICloneable, IDictionary<TKey, TVal>, IEnumerable<KeyValuePair<TKey, TVal>>
    {
        //Point<TKey, TVal> begin;
        protected Point<TKey, TVal>[] hashTable;
        [JsonInclude]
        [JsonPropertyName("hashTable")]
        public Point<TKey, TVal>[] Hashtable 
        {
            get 
            {
                return hashTable;
            }
            set 
            {
                hashTable = value;
            }
        }
        //protected int defaultCapacity = 10;
        //otected int count = 0;
        public bool IsSynchronized { get { return hashTable.IsSynchronized; } } //является ли коллекция потокобезопасной - чтобы одновременно к 1 ячейке несколько не обратились

        public object SyncRoot { get { return hashTable.SyncRoot; } } //объект с помощью которого можно синхронизировать доступ к коллекции


        public virtual TVal this[TKey key]
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

        [JsonPropertyName("values")]
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
            set 
            {
                int i = 0;
                foreach(var item in value) 
                {

                    hashTable[i].Value = item;
                    i++;
                }
            }

        }

        [JsonPropertyName("keys")]
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
            set 
            {
                int i = 0;
                foreach (var item in value)
                {

                    hashTable[i].Key = item;
                    i++;
                }
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
        [JsonInclude]
        [JsonPropertyName("capacity")]
        [XmlElement("Capacity")] // Добавляем сохранение размера
        public int Count
        {
            get
            {
                if (hashTable == null)
                    return 0;
                else
                    return hashTable.Length;
            }
            set 
            {
                hashTable = new Point<TKey, TVal>[value];
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

        public IEnumerator<KeyValuePair<TKey, TVal>> GetEnumerator()
        {
            //Как вариант
            //for (int i = 0; i < hashTable.Length; i++)
            //{
            //    if (hashTable[i] != null)
            //    {
            //        Point<TKey, TVal> curr = hashTable[i];
            //        while (curr != null)
            //        {
            //            yield return new KeyValuePair<TKey, TVal>(curr.Key, curr.Value);
            //            curr = curr.Next;
            //        }
            //    }
            //}

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
                            KeyValuePair<TKey, TVal> pair = new KeyValuePair<TKey, TVal>(curr.Key, curr.Value);
                            yield return pair;
                            curr = curr.Next;
                        }
                    }
                }
                i++;
            }
        }

        public virtual void Add(TKey key, TVal val)
        {
            if (val == null || hashTable == null)
            {
                throw new ArgumentNullException("Хэш-таблица не инициализирована");
            }

            Point<TKey, TVal> data = new Point<TKey, TVal>(key, val, hashTable.Length);
            if (hashTable[Math.Abs(data.Key.GetHashCode()) % hashTable.Length] == null)
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

        public virtual void Add(KeyValuePair<TKey, TVal> pair)
        {
            TKey key = pair.Key;
            TVal val = pair.Value;
            if (key == null || val == null)
                throw new ArgumentNullException("Переданы пустые параметры");
            this.Add(key, val); //если обращать от нью коллекциоон то вызывает потом от зис - в зис то это нью кллекцион
        }

        public virtual void Add(Point<TKey, TVal> point) 
        {
            int index = Math.Abs(point.Key.GetHashCode()) % hashTable.Length;
            if (hashTable[index] == null)
                hashTable[index] = point;
            else
                throw new ArgumentException("Такой ситуации возникать не должно");
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
            for (int i = 0; i < hashTable.Length; i++)
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

        public virtual bool Remove(TVal val)
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

        public virtual bool Remove(KeyValuePair<TKey, TVal> pair)
        {
            return (Remove(pair.Value));
        }

        public virtual bool Remove(TKey key)
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
            if (!ContainsKey(key))
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

        public void CopyTo(KeyValuePair<TKey, TVal>[] array, int firstCopyedIIndex = 0)
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

        //public List<KeyValuePair<TKey, TVal>> GetAllItems()
        //{
        //    List<KeyValuePair<TKey, TVal>> items = new List<KeyValuePair<TKey, TVal>>(1);

        //    foreach (var item in this) 
        //    {
        //        //проблема на моменте append - итем правильный, но отчего не добавялется в итемс
        //        //кароче все тип топ просто аппенд не так работает как я снасчала опять решил
        //        items.Add(new KeyValuePair<TKey, TVal>(item.Key, item.Value));
        //    }
        //    return items;
        //}

        public List<KeyValuePair<string, string>> GetPrintString()
        {
            //List<List<string>> printStr = new List<List<string>>();
            List<KeyValuePair<string, string>> printStr = new List<KeyValuePair<string, string>>();
            if (hashTable == null)
            {
                printStr.Add(new KeyValuePair<string, string>("null", "Хэш-таблица не инициализирована"));
                //printStr.Add(new List<string> { "Хэш-таблица не инициализирована" });
            }
            else
            {
                for (int i = 0; i < hashTable.Length; i++)
                {
                    if (hashTable[i] != null)
                    {
                        Point<TKey, TVal> data = hashTable[i]/*new Point<TKey, TVal>(hashTable[i])*/;//проблема в копировании - копирует только 1 детя - остальные не копируются - обрезаются
                        while (data != null)
                        {
                            printStr.Add(new KeyValuePair<string, string>($"{i + 1}", $"{data.ToString()}"));
                            //printStr.Add(new List<string> {$"{i + 1}",
                            //   $"{data.ToString()}"});
                            data = data.Next;
                        }
                    }
                    else
                    {
                        printStr.Add(new KeyValuePair<string, string>($"{i + 1}", $"ключ не задан : значение не задано"));
                        //printStr.Add(new List<string> {$"{i + 1}",
                        //       $"ключ не задан : значение не задано"});
                    }
                }
            }
            return printStr;
        }


        //Для сериализации без делегатов/событий
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // 1. Сохраняем количество элементов
            info.AddValue("Count", GetPrintString().Count);

            // 2. Сохраняем каждый элемент (ключ + значение)
            int i = 0;
            foreach (var item in this)
            {
                info.AddValue($"Key_{i}", item.Key);
                info.AddValue($"Value_{i}", item.Value);
                i++;
            }
        }

        protected MyCollection(SerializationInfo info, StreamingContext context)
        {
            // 1. Восстанавливаем количество элементов
            int count = info.GetInt32("Count");

            // 2. Восстанавливаем элементы
            for (int i = 0; i < count; i++)
            {
                var key = (TKey)info.GetValue($"Key_{i}", typeof(TKey));
                var value = (TVal)info.GetValue($"Value_{i}", typeof(TVal));
                this.Add(key, value);
            }

            // События НЕ восстанавливаются — они остаются null
        }



        //Это если без руччной xml сериализации необходимо для выписывания/записывания
        //public Point<TKey, TVal> this[int index]
        //{
        //    get
        //    {
        //        // Реализация зависит от вашего MyCollection<TKey, TVal>
        //        // Например, если у вас есть List<KeyValuePair<TKey, TVal>> внутри:
        //        //может нулл пердусмотреть
        //        return hashTable[index];
        //    }
        //    set
        //    {
        //        // Если нужно обновление по индексу
        //        throw new NotSupportedException("Изменение по индексу не поддерживается.");
        //    }
        //}

        //public void WriteXml(XmlWriter writer)
        //{
        //    // 1. Записываем размер таблицы
        //    writer.WriteElementString("Capacity", hashTable.Length.ToString());

        //    // 2. Записываем элементы
        //    writer.WriteStartElement("Items");
        //    foreach (var bucket in hashTable ?? Array.Empty<Point<TKey, TVal>>())
        //    {
        //        var current = bucket;
        //        while (current != null)
        //        {
        //            writer.WriteStartElement("Point");

        //            // Сериализуем Key
        //            writer.WriteStartElement("Key");
        //            new XmlSerializer(typeof(TKey)).Serialize(writer, current.Key);
        //            writer.WriteEndElement();

        //            // Сериализуем Value
        //            if (current.Value != null)
        //            {
        //                writer.WriteStartElement("Value");
        //                new XmlSerializer(current.Value.GetType()).Serialize(writer, current.Value);
        //                writer.WriteEndElement();
        //            }

        //            writer.WriteEndElement(); // </Point>
        //            current = current.Next;
        //        }
        //    }
        //    writer.WriteEndElement(); // </Items>
        //}

        //public void ReadXml(XmlReader reader)
        //{
        //    // Пропускаем начальный элемент
        //    reader.ReadStartElement();

        //    // 1. Читаем Capacity
        //    reader.ReadStartElement("Capacity");
        //    int capacity = reader.ReadContentAsInt();
        //    reader.ReadEndElement();

        //    hashTable = new Point<TKey, TVal>[capacity];

        //    // 2. Читаем Items
        //    reader.ReadStartElement("Items");
        //    while (reader.IsStartElement("Point"))
        //    {
        //        reader.ReadStartElement("Point");

        //        // Читаем Key
        //        reader.ReadStartElement("Key");
        //        var keySerializer = new XmlSerializer(typeof(TKey));
        //        TKey key = (TKey)keySerializer.Deserialize(reader);
        //        reader.ReadEndElement(); // </Key>

        //        // Читаем Value (если есть)
        //        TVal value = default;
        //        if (reader.IsStartElement("Value"))
        //        {
        //            reader.ReadStartElement("Value");
        //            var valueSerializer = new XmlSerializer(typeof(TVal));
        //            value = (TVal)valueSerializer.Deserialize(reader);
        //            reader.ReadEndElement(); // </Value>
        //        }

        //        // Добавляем в таблицу
        //        int index = Math.Abs(key.GetHashCode()) % capacity;
        //        var newPoint = new Point<TKey, TVal>(key, value);

        //        if (hashTable[index] == null)
        //            hashTable[index] = newPoint;
        //        else
        //        {
        //            var current = hashTable[index];
        //            while (current.Next != null) current = current.Next;
        //            current.Next = newPoint;
        //        }

        //        reader.ReadEndElement(); // </Point>
        //    }
        //    reader.ReadEndElement(); // </Items>
        //    reader.ReadEndElement(); // </AnimalCollection>
        //}

        //public XmlSchema GetSchema() => null;



        //#region IXmlSerializable Implementation

        //public virtual void WriteXml(XmlWriter writer)
        //{
            
        //}

        //#endregion
    }
}

//[XmlElement("TableSize")]  // Сохраняем размер таблицы
//public virtual int TableSize { get; set; }

//[XmlArray("Items")]
//[XmlArrayItem("Point")]
//public virtual List<Point<TKey, TVal>> ItemsForXml
//{
//    get
//    {
//        TableSize = hashTable.Length;
//        var list = new List<Point<TKey, TVal>>();

//        if (hashTable != null)
//        {
//            foreach (var bucket in hashTable)
//            {
//                var current = bucket;
//                while (current != null)
//                {
//                    list.Add(new Point<TKey, TVal>(current.Key, current.Value));
//                    current = current.Next;
//                }
//            }
//        }
//        return list;
//    }
//    set
//    {
//        hashTable = new Point<TKey, TVal>[TableSize];

//        foreach (var point in value)
//        {
//            Add(point.Key, point.Value); // Используем существующий метод Add
//        }
//    }
//}