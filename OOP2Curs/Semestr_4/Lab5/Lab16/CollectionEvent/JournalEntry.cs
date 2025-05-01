using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionEvent
{
    public class JournalEntry<TVal>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string ObjectData { get; set; }

        public JournalEntry(string name, string type, TVal objec) 
        {
            Name = name;
            Type = type;
            ObjectData = objec.ToString();
        }

        public override string ToString()
        {
            string information = "";
            information += $"Имя коллекции:{Name}\n";
            information += $"Тип операции:{Type}\n";
            if (ObjectData != null)
                information += $"Объект: {ObjectData}\n";
            else
                information += $"Объект: пустой\n";
            return information;
        }
    }
}
