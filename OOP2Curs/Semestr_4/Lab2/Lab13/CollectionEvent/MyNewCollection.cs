using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCollectionLibrary;

namespace CollectionEvent
{
    public class MyNewCollection<TKey, TVal> : MyCollection<TKey, TVal>
    {
        public string Name { get; set; }
        
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

        public MyNewCollection(int capacity):base(capacity) { /*CollectionCountChanged += ShowInfoEvent; CollectionReferenceChanged += ShowInfoEvent;*/ }

        public delegate void CollectionHandler(MyNewCollection<TKey, TVal> sender, CollectionHandlerEventArgs<TVal> args);
        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;

        public void OnCollectionCountChanged(MyNewCollection<TKey,TVal> sourcer, CollectionHandlerEventArgs<TVal> args) 
        {
            CollectionCountChanged?.Invoke(sourcer, args);
        }

        //public void ShowInfoEvent(MyNewCollection<TKey, TVal> sourcer, CollectionHandlerEventArgs<TVal> args)
        //{
        //    Console.WriteLine($"Коллекция с именем {args.Name}  было {args.Type} вот это {args.ObjectData}");
        //}

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
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs<TVal>(Name, "Добавлен", val));
            base.Add(key, val);
        }

        public override void Add(KeyValuePair<TKey, TVal> pair) 
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs<TVal>(Name, "Добавлен", pair.Value));
            base.Add(pair);
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
