using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using System.IO;

namespace CollectionEvent
{
    public class Journal<T>
    {
        private List<JournalEntry<T>> journal;

        //public string filePath;

        public Journal() 
        {
            journal = new List<JournalEntry<T>>();
        }

        public void Add(JournalEntry<T> entry)
        {
            journal.Add(entry);
            //if (!File.Exists(filePath))
            //{
            //    File.WriteAllText(filePath, "Журнал событий:\n"); //Перезаписываеем или осздаем новый
            //}
            //File.AppendAllText(filePath, entry.ToString()); //Добавляем в конец ил новый создаем
        }

        public void Print()
        {
            foreach (JournalEntry<T> item in journal)
            {
                Console.WriteLine(item.ToString());
            }
        }


        public override string ToString()
        {
            string information = "";
            foreach (JournalEntry<T> item in journal)
            {
                information += (item.ToString() + "\n");
            }
            return information;
        }
    }
}
