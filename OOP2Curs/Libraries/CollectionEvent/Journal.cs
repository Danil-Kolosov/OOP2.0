using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CollectionEvent
{
    public class Journal<T>
    {
        private List<JournalEntry<T>> journal;

        public Journal() 
        {
            journal = new List<JournalEntry<T>>();
        }

        public void Add(JournalEntry<T> entry)
        {
            journal.Add(entry);
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
                information += item.ToString();
            }
            return information;
        }
    }
}
