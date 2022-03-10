using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsMarks
{
    public class Mark
    {
        public DateTime Date { get; set; }
        public string Estimation { get; set; }
        public Student Student { get; set; }

        public Mark(DateTime date, string estimation, Student student)
        {
            Date = date;
            Estimation = estimation;
            Student = student;
        }
    }
}
