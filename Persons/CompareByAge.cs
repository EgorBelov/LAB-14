using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramLAB_14
{
    public class CompareByAge : IComparer<Person>
    {
        public int Compare(Person a, Person b)
        {
            if (a.Age > b.Age) return 1;
            if (a.Age < b.Age) return -1;
            return 0;
        }
       
    }
}
