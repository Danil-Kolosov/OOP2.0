using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionEvent
{
    public class CollectionHandlerEventArgs<TVal> : System.EventArgs
    {
        public string Name {  get; set; }

        public string Type { get; set; }

        public TVal ObjectData {  get; set; }

        public override string ToString() 
        {
            return ObjectData.ToString();
        }

        public CollectionHandlerEventArgs() { }

        public CollectionHandlerEventArgs(string name, string type, TVal item) 
        {
            Name = name;
            Type = type;
            ObjectData = item;
        }
    }
}
