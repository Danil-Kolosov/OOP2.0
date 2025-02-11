using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollectionLibrary
{
    public class Point<T>
    {
        int key;
        T value;

        Point<T> next;
        Point<T> eNext;

        public int Key 
        {
            get { return key; }
        }

        public T Value
        {
            get { return value; }
        }

        public Point<T> Next 
        {
            get { return next; }
            set { next = value; }
        }
        public Point(T val, int size) 
        {
            value = val;
            key = Math.Abs(val.GetHashCode()) % size;
            next = null;
        }

        public Point(int key)
        {
            //value = default(T);
            this.key = key;
            next = null;
        }

        public Point() 
        {
            value = default(T);
            next = null;
            key = 0;
        }

        public Point(Point<T> point) 
        {
            this.key = point.Key;
            this.value = point.Value;
            this.next = point.Next;
        }

        public override string ToString()  //!!!! надо все таки
        {
            if (value == null) 
            {
                return (key + 1).ToString() + " : " + "пусто";
            }
            return (key + 1).ToString() + " : " + value.ToString();
        }

    }
}
