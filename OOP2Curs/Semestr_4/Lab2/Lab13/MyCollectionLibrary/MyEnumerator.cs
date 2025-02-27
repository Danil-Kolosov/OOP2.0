//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyCollectionLibrary
//{
//    internal class MyEnumerator<TKey, TVal> : IEnumerator<TVal>
//    {
//        Point<TKey, TVal> begin, current;//сомоделать надо

//        object IEnumerator.Current
//        {
//            get { return Current; }
//        }

//        public MyEnumerator(MyCollection<TKey, TVal> e)
//        {
//            begin = e.Begin;
//            current = e.Begin;
//        }

//        //public MyEnumerator(Point<T> e)
//        //{
//        //    begin = e;
//        //    current = e;
//        //}

//        public TVal Current
//        {
//            get { return current.Value; }
//        }

//        public bool MoveNext()
//        {
//            if (current.Next == null)
//            { 
//                Reset();
//                return false;
//            }
//            else
//            {
//                current = current.Next;
//                return true;
//            }
//        }

//        public void Reset()
//        {
//            current = this.begin;
//        }

//        public void Dispose() {/*ничего не делает в данный момент, прямо как я*/ }


//    }
//}
