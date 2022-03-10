using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsMarks
{
    public class MarkFunctions
    {
        public List<Mark> GetMarks(DateTime now, List<Student> students)
        {
            string[] estimations = { "Прогул", "Отсутствие", "Болезнь", "2", "3", "4", "5" };
            var marks = new List<Mark>();
            foreach (var student in students)
            {
                for (int i = 0; i < 10; i++)
                {
                    Random random = new Random();
                    string estimation = estimations[random.Next(0, 7)];
                    marks.Add(new Mark(now.AddDays(i), estimation, student));
                }
            }
            return marks;
        }

        public double MinAVG(string[] marks)
        {
            double sum = 0;
            foreach (var mark in marks)
            {
                if (mark == null)
                {
                    return Math.Round(sum / marks.Count());
                }
                sum += int.Parse(mark);
            }
            return Math.Round(sum / marks.Count());
        }

        public int GetCountTruancy(List<Mark> marks)
        {
            int count = 0;
            foreach (var mark in marks)
            {
                if (mark.Estimation == "Прогул")
                {
                    count++;
                }
            }
            return count;
        }

        public int GetCountDisease(List<Mark> marks)
        {
            int count = 0;
            foreach (var mark in marks)
            {
                if (mark.Estimation == "Болезнь")
                {
                    count++;
                }
            }
            return count;
        }

        public string GetStudNumber(int year, int group, string fio)
        {
            return year + "." + group + "." + fio;
        }
    }
}
