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
    [Serializable]
    [XmlRoot("AnimalCollection")]
    public  class MyNewCollection<TKey, TVal> : MyCollection<TKey, TVal>, IXmlSerializable
    {
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

                        // Читаем до закрывающего тега Value
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

                    // Value
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
        }
  
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
    }
}
