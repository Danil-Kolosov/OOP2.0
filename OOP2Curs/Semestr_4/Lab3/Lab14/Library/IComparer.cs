using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLibrary
{
    internal interface IComparer
    {
        int Compare(object obj1, object obj2);
    }
}
