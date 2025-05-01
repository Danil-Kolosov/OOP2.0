using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CollectionEvent
{
    [Serializable]
    public class CollectionHandlerEventArgs<TVal> : System.EventArgs
    {
        //[XmlElement]
        public string Name {  get; set; }

        //[XmlElement]
        public string Type { get; set; }

        //[XmlElement]
        public TVal ObjectData {  get; set; }

        //public override string ToString() 
        //{
        //    return ObjectData.ToString();
        //}

        public CollectionHandlerEventArgs() { }

        public CollectionHandlerEventArgs(string name, string type, TVal item) 
        {
            Name = name;
            Type = type;
            ObjectData = item;
        }
    }
}
