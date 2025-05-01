using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyCollectionLibrary
{
    [Serializable]
    [XmlRoot("Point")] // Указываем корневой элемент для XML
    public class Point<TKey, TVal>
    {
        TKey key;
        TVal value;

        Point<TKey, TVal> next;

        [JsonPropertyName("key")]
        [XmlElement("Key")] // Сериализуем как элемент
        public TKey Key 
        {
            get { return key; }
            set { key = value; }
        }

        [JsonPropertyName("value")]
        [XmlElement("Value")] // Сериализуем как элемент
        public TVal Value
        {
            get { return value; }
            set { this.value = value; }
        }

        [JsonPropertyName("next")]
        [XmlElement("Next")] // Сериализуем как элемент (рекурсивно)
        public Point<TKey, TVal> Next
        {
            get { return next; }
            set { next = value; }
        }

        public Point(TKey key, TVal val, int size = 1) 
        {
            value = val;
            this.key = key;
            next = null;
        }

        public Point(TKey key)
        {
            //value = default(T);
            this.key = key;
            next = null;
        }

        public Point() 
        {
            value = default(TVal);
            next = null;
            key = default(TKey);
        }

        public Point(Point<TKey, TVal> point) 
        {
            this.key = point.Key;
            this.value = point.Value;
            if (point.Next == null)
                this.next = null;
            else
                this.next = new Point<TKey, TVal>(point.Next.Key, point.Next.Value);
        }

        public override string ToString()
        {
            if (value == null) 
            {
                return (key).ToString() + " : " + "пусто";
            }
            return (key).ToString() + " : " + value.ToString();
        }

        public override bool Equals(Object obj)
        {
            if (obj is Point<TKey, TVal> point)
                return ((Equals(Key, point.Key)) & (Equals(Value, point.Value)) & (Equals(Next, point.Next)));
            return false;
        }
    }
}
