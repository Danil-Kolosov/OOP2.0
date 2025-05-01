using AnimalLibrary;
using CollectionEvent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
namespace CollectionProcessing
{
    class SerializeXML
    {
        public static void SerializeToXml<T>(T obj, string filePath)
        {
            //XmlSerializer serializer = new XmlSerializer(typeof(T));
            //using (TextWriter writer = new StreamWriter(filePath))
            //{
            //    serializer.Serialize(writer, obj);
            //}

            var serializer = new XmlSerializer(typeof(T));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, obj);
            }

            //using (var writer = XmlWriter.Create("zoo.xml"))
            //{
            //    var serializer = new XmlSerializer(typeof(MyNewCollection<string, Animal>));
            //    serializer.Serialize(writer, obj);
            //}
        }

        public static T DeserializeFromXml<T>(string filePath)
        {
            //XmlSerializer serializer = new XmlSerializer(typeof(T));
            //using (TextReader reader = new StreamReader(filePath))
            //{
            //    return (T)serializer.Deserialize(reader);
            //}


            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StreamReader(filePath))
            {
                return (T)serializer.Deserialize(reader);
            }

            //using (var reader = XmlReader.Create("zoo.xml"))
            //{
            //    var serializer = new XmlSerializer(typeof(T/*MyNewCollection<string, Animal>*/));
            //    var loaded = (MyNewCollection<string, Animal>)serializer.Deserialize(reader);
            //}
        }
    }
}
