using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsMarks
{
    public class Student
    {
        public string FIO { get; set; }
        public string Group { get; set; }
        public DateTime EntryYear { get; set; }

        public Student(string fIO, string group, DateTime entryYear)
        {
            FIO = fIO;
            Group = group;
            EntryYear = entryYear;
        }
    }
}
