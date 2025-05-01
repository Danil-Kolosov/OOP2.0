using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCollectionLibrary;
using AnimalLibrary;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Collections;
using System.Xml.Schema;
using System.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CollectionEvent
{
    //[JsonSerializable]
    //[JsonSerializable(typeof(MyNewCollection<string, Animal>))]
    [Serializable]
    [XmlRoot("AnimalCollection")]
    //[XmlInclude(typeof(Mammal))]
    //[XmlInclude(typeof(Bird))]
    //[XmlInclude(typeof(Artiodactyl))]
    //[XmlType("Dictionary")] // Укажите тип
    //[JsonDerivedType(typeof(Animal), "animal")]
    //[JsonDerivedType(typeof(Bird), "bird")]
    //[JsonDerivedType(typeof(Mammal), "mammal")]
    //[JsonDerivedType(typeof(Artiodactyl), "artiodactyl")]
    public  class MyNewCollection<TKey, TVal> : MyCollection<TKey, TVal>, IXmlSerializable
    {
        //сделать все сеттеры публичными - больше ничего не знаю
        //[JsonInclude]
        //[JsonPropertyName("buckets")]
        //public Point<TKey, TVal>[] SerializedBuckets
        //{
        //    get => hashTable;
        //    private set => hashTable = value;
        //}


        //[JsonPropertyName("items")]
        //public Dictionary<TKey, TVal> Items
        //{
        //    get => this.ToDictionary(pair => pair.Key, pair => pair.Value);
        //    set
        //    {
        //        Clear();
        //        // Инициализация хэш-таблицы перед заполнением
        //        hashTable = new Point<TKey, TVal>[value.Count * 2];
        //        foreach (var item in value)
        //            Add(item.Key, item.Value);
        //    }
        //}

        //#region IXmlSerializable Implementation

        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();

            if (reader.MoveToAttribute("Name"))
                Name = reader.Value;
            //reader.ReadEndElement();
            reader.MoveToElement();

            // Читаем Capacity
            int capacity = int.Parse(reader.ReadElementString("Capacity"));
            hashTable = new Point<TKey, TVal>[capacity];

            // Читаем Items
            if (reader.IsStartElement("Items"))
            {
                reader.ReadStartElement("Items");

                while (reader.IsStartElement("Point"))
                {
                    reader.ReadStartElement("Point");

                    // Читаем Key
                    reader.ReadStartElement("Key");
                    TKey key = (TKey)new XmlSerializer(typeof(TKey)).Deserialize(reader);
                    reader.ReadEndElement(); // </Key>

                    // Читаем Value
                    if (reader.IsStartElement("Value"))
                    {
                        reader.ReadStartElement("Value");

                        // Основное исправление: читаем до закрывающего тега Value
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            if (reader.NodeType == XmlNodeType.Element)
                            {
                                Type animalType = null;
                                switch (reader.Name)
                                {
                                    case "Bird":
                                        animalType = typeof(Bird);
                                        break;
                                    case "Mammal":
                                        animalType = typeof(Mammal);
                                        break;
                                    case "Artiodactyl":
                                        animalType = typeof(Artiodactyl);
                                        break;
                                    case "Animal":
                                        animalType = typeof(Animal);
                                        break;
                                }                               
                                TVal value = (TVal)new XmlSerializer(animalType).Deserialize(reader);
                                this.Add(key, value);
                            }
                            else
                            {
                                reader.Read(); // Пропускаем не-элементы (комментарии, пробелы и т.д.)
                            }
                        }

                        reader.ReadEndElement(); // </Value>
                    }

                    reader.ReadEndElement(); // </Point>
                }

                reader.ReadEndElement(); // </Items>
            }

            reader.ReadEndElement(); // </AnimalCollection>





            /*// 1. Читаем открывающий тег коллекции
            reader.ReadStartElement();

            // 2. Читаем Capacity
            int capacity = int.Parse(reader.ReadElementString("Capacity"));
            hashTable = new Point<TKey, TVal>[capacity];

            // 3. Читаем Items (если есть)
            if (reader.IsStartElement("Items"))
            {
                reader.ReadStartElement("Items");

                while (reader.IsStartElement("Point"))
                {
                    reader.ReadStartElement("Point");

                    // 4. Читаем Key
                    reader.ReadStartElement("Key");
                    var keySerializer = new XmlSerializer(typeof(TKey));
                    TKey key = (TKey)keySerializer.Deserialize(reader);
                    reader.ReadEndElement(); // </Key>

                    // 5. Читаем Value (с поддержкой наследования)
                    if (reader.IsStartElement("Value"))
                    {
                        reader.ReadStartElement("Value");

                        // Определяем фактический тип
                        Type actualType = typeof(Animal);
                        if (reader.GetAttribute("xsi:type") != null)
                        {
                            string typeName = reader.GetAttribute("xsi:type");
                            if (typeName.Contains("Bird")) actualType = typeof(Bird);
                            else if (typeName.Contains("Mammal")) actualType = typeof(Mammal);
                            else if (typeName.Contains("Artiodactyl")) actualType = typeof(Artiodactyl);
                        }

                        // Десериализуем с учетом типа
                        var valueSerializer = new XmlSerializer(actualType);
                        TVal value = (TVal)valueSerializer.Deserialize(reader);

                        // Добавляем в коллекцию
                        this.Add(key, value);

                        reader.ReadEndElement(); // </Value>
                    }

                    reader.ReadEndElement(); // </Point>
                }
                reader.ReadEndElement(); // </Items>
            }

            reader.ReadEndElement(); // Закрывающий тег коллекции
            */



            /*// Пропускаем начальный элемент
            reader.ReadStartElement();

            if (reader.MoveToAttribute("Name"))
                Name = reader.Value;
            //reader.ReadEndElement();
            reader.MoveToElement();

            // Читаем Capacity
            int capacity = int.Parse(reader.ReadElementString("Capacity"));
            hashTable = new Point<TKey, TVal>[capacity];
            
            // Читаем Items если они есть
            if (reader.IsStartElement("Items"))
            {
                reader.ReadStartElement("Items");
                while (reader.IsStartElement("Point"))
                {
                    reader.ReadStartElement("Point");

                    // Читаем Key
                    reader.ReadStartElement("Key");
                    XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
                    TKey key = (TKey)keySerializer.Deserialize(reader);
                    reader.ReadEndElement(); // </Key>

                    // Читаем Value
                    if (reader.IsStartElement("Value"))
                    {
                        reader.ReadStartElement("Value");

                        // Определяем фактический тип объекта
                        Type actualType = typeof(TVal);
                        //Это нафига точно не тутт
                        if (reader.GetAttribute("xsi:type") != null)
                        {
                            string typeName = reader.GetAttribute("xsi:type");
                            if (typeName.Contains("Bird"))
                                actualType = typeof(TVal);
                            else if (typeName.Contains("Mammal"))
                                actualType = typeof(TVal);
                            else if (typeName.Contains("Artiodactyl"))
                                actualType = typeof(TVal);
                        }
                        //Это нафига точно не тутт
                        XmlSerializer valueSerializer = new XmlSerializer(actualType);
                        TVal value = (TVal)valueSerializer.Deserialize(reader);
                        reader.ReadEndElement(); // </Value>

                        // Добавляем элемент
                        this.Add(key, value);
                    }

                    reader.ReadEndElement(); // </Point>
                }
                reader.ReadEndElement(); // </Items>
            }

            reader.ReadEndElement(); // Закрывающий тег коллекции*/
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Name", Name);
            // 1. Записываем Capacity
            writer.WriteElementString("Capacity", hashTable.Length.ToString());

            // 2. Записываем Items
            writer.WriteStartElement("Items");

            foreach (var bucket in hashTable ?? Array.Empty<Point<TKey, TVal>>())
            {
                var current = bucket;
                while (current != null)
                {
                    writer.WriteStartElement("Point");

                    // Key
                    writer.WriteStartElement("Key");
                    new XmlSerializer(typeof(TKey)).Serialize(writer, current.Key);
                    writer.WriteEndElement();

                    // Value - ОСНОВНОЕ ИЗМЕНЕНИЕ
                    writer.WriteStartElement("Value");
                    if (current.Value != null)
                    {
                        var ns = new XmlSerializerNamespaces();
                        //ns.Add("", ""); // Явно отключаем пространства имён

                        new XmlSerializer(current.Value.GetType())
                            .Serialize(writer, current.Value, ns);
                    }
                    writer.WriteEndElement();

                    writer.WriteEndElement(); // </Point>
                    current = current.Next;
                }
            }

            writer.WriteEndElement(); // </Items>

            /*
            // Записываем атрибут Name
            if (!string.IsNullOrEmpty(Name))
                writer.WriteAttributeString("Name", Name);
            // Записываем Capacity
            writer.WriteElementString("Capacity", hashTable.Length.ToString());

            // Записываем Items только если есть элементы
            if (hashTable != null && hashTable.Length > 0)
            {
                writer.WriteStartElement("Items");
                foreach (var bucket in hashTable)
                {
                    var current = bucket;
                    while (current != null)
                    {
                        writer.WriteStartElement("Point");

                        // Сериализуем Key
                        writer.WriteStartElement("Key");
                        new XmlSerializer(typeof(TKey)).Serialize(writer, current.Key);
                        writer.WriteEndElement(); // </Key>
                                                  // Сериализация Value с явным указанием типа
                        writer.WriteStartElement("Value");
                        if (current.Value != null)
                        {
                            var valueType = current.Value.GetType();
                            var ns = new XmlSerializerNamespaces();
                            ns.Add("", ""); // Убираем пространства имен

                            new XmlSerializer(valueType).Serialize(writer, current.Value, ns);
                        }
                        //// Сериализуем Value с указанием фактического типа
                        //writer.WriteStartElement("Value");
                        //if (current.Value != null)
                        //{
                        //    XmlSerializer valueSerializer = new XmlSerializer(current.Value.GetType());
                        //    valueSerializer.Serialize(writer, current.Value);
                        //}
                        writer.WriteEndElement(); // </Value>

                        writer.WriteEndElement(); // </Point>
                        current = current.Next;
                    }
                }
                writer.WriteEndElement(); Ъ}может// </Items>*/
        
        }

        //#endregion

        //фигня какая-то
        //[XmlArray("Items")]
        //[XmlArrayItem("Points")]
        //public override List<Point<TKey, TVal>> ItemsForXml
        //{
        //    get => base.ItemsForXml; // Используем базовую реализацию
        //    set
        //    {
        //        // Дополнительная логика перед добавлением элементов
        //        Console.WriteLine($"Восстанавливаем коллекцию {Name}");
        //        base.ItemsForXml = value;
        //    }
        //}
        //Теперь лучше в май коллекцтион
        //[XmlArray("Items")]
        //[XmlArrayItem("PointOfStringAnimal")]
        //public List<Point<TKey, TVal>> ItemsForXml
        //{
        //    get
        //    {
        //        // Преобразуем коллекцию в список Point
        //        var list = new List<Point<TKey, TVal>>();
        //        foreach (var pair in this) // Предполагается, что MyCollection реализует IEnumerable
        //        {
        //            list.Add(new Point<TKey, TVal>(pair.Key, pair.Value));
        //        }
        //        return list;
        //    }
        //    set
        //    {
        //        this.Clear();
        //        foreach (var point in value)
        //        {
        //            this.Add(point.Key, point.Value);
        //        }
        //    }
        //}        

        [XmlElement("Name")]
        [JsonInclude]
        [JsonPropertyName("collectionName")] // Явное имя для JSON
        public string Name 
        { 
            get; 
            set; 
        }

        

        public override TVal this[TKey key]
        {
            get
            {
                return base[key];
            }
            set
            {                
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs<TVal>(Name, "Заменен", value));
                base[key] = value;
            }
        }

        public MyNewCollection() : base() 
        {
            
        }

        public MyNewCollection(int capacity):base(capacity) { CollectionCountChanged += ShowInfoEvent; CollectionReferenceChanged += ShowInfoEvent; }

        [field: NonSerialized]
        public delegate void CollectionHandler(MyNewCollection<TKey, TVal> sender, CollectionHandlerEventArgs<TVal> args);
        [field: NonSerialized]
        public event CollectionHandler CollectionCountChanged;
        [field: NonSerialized]
        public event CollectionHandler CollectionReferenceChanged;

        public void OnCollectionCountChanged(MyNewCollection<TKey,TVal> sourcer, CollectionHandlerEventArgs<TVal> args) 
        {
            CollectionCountChanged?.Invoke(sourcer, args);
        }

        public void ShowInfoEvent(MyNewCollection<TKey, TVal> sourcer, CollectionHandlerEventArgs<TVal> args)
        {
            Console.WriteLine($"Коллекция с именем {args.Name} : было {args.Type} : вот это {args.ObjectData}");
        }

        public void OnCollectionReferenceChanged(MyNewCollection<TKey, TVal> sourcer, CollectionHandlerEventArgs<TVal> args)
        {
            CollectionReferenceChanged?.Invoke(sourcer, args);
        }

        public bool Remove(int j)
        {


            return true;
        }

        public override void Add(TKey key, TVal val) 
        {            
            base.Add(key, val);
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs<TVal>(Name, "Добавлен", val));
        }

        public override void Add(KeyValuePair<TKey, TVal> pair) 
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs<TVal>(Name, "Добавлен", pair.Value));
            base.Add(pair);
        }

        public override void Add(Point<TKey, TVal> point)
        {
            if (point == null)
            { return; }
            base.Add(point);
        }

        public override bool Remove(TVal val)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs<TVal>(Name, "Удален", val));
            return base.Remove(val);
        }

        public override bool Remove(TKey key)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs<TVal>(Name, "Удален", this[key]));
            return base.Remove(key);
        }

        public override bool Remove(KeyValuePair<TKey, TVal> pair)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs<TVal>(Name, "Удален", pair.Value));
            return base.Remove(pair);
        }

        //public void Add(KeyValuePair<string, global::AnimalLibrary.Mammal> keyValuePair)
        //{
        //    throw new NotImplementedException();
        //}

        
    }
}
