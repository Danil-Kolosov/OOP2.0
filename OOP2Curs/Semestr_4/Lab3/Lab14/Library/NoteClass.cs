using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLibrary
{
    [Serializable]
    public class NoteClass
    {
        private string note;

        public string Note 
        {
            get 
            {
                return note;
            }
            set 
            {
                note = value;
            }
        }

        public NoteClass()
        {
            Note = "none";
        }

        public NoteClass(string nt)
        {
            Note = nt;
        }

        public NoteClass(NoteClass nt)
        {
            Note = nt.Note;
        }

        public override bool Equals(Object obj)
        {
            if (obj is NoteClass nt)
            {
                return Note == nt.Note;           
            }
            return false;
        }
    }
}
