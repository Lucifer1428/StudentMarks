using StudentsMarks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MarksTestApp
{
    public partial class MainWindow : Window
    {
        MarkFunctions markFunctions = new MarkFunctions();
        List<Student> students = new List<Student>();
        List<Mark> marks = new List<Mark>();
        public MainWindow()
        {
            InitializeComponent();
            students.Add(new Student("Герасимова Елена Артуровна", "102", new DateTime(2021, 09, 01)));
            students.Add(new Student("Лопатина Валерия Кирилловна", "102", new DateTime(2021, 09, 01)));
            students.Add(new Student("Смирнов Пётр Романович", "102", new DateTime(2021, 09, 01)));
            students.Add(new Student("Козлова Елизавета Руслановна", "102", new DateTime(2021, 09, 01)));
            students.Add(new Student("Денисов Егор Григорьевич", "102", new DateTime(2021, 09, 01)));

            students.Add(new Student("Ковалев Максим Ильич", "202", new DateTime(2020, 09, 01)));
            students.Add(new Student("Галкина Амелия Данииловна", "202", new DateTime(2020, 09, 01)));
            students.Add(new Student("Николаева Аделина Михайловна", "202", new DateTime(2020, 09, 01)));
            students.Add(new Student("Андреев Вячеслав Тимофеевич", "202", new DateTime(2020, 09, 01)));
            students.Add(new Student("Дементьева Елизавета Савельевна", "202", new DateTime(2020, 09, 01)));
            studentsDG.ItemsSource = students;
        }

        private void GenerateMarks_Click(object sender, RoutedEventArgs e)
        {
            this.marks = markFunctions.GetMarks(DateTime.Now, this.students);
            marksDG.ItemsSource = this.marks;
            List<Mark> marks2 = new List<Mark>();
            marks2 = this.marks.Where(m => m.Estimation == "2" || m.Estimation == "3" || m.Estimation == "4" || m.Estimation == "5").ToList();
            marksDG2.ItemsSource = marks2;
            string[] marks = new string[marks2.Count];
            for (int i = 0; i < marks2.Count; i++)
            {
                marks[i] = marks2[i].Estimation;
            }
            DG2label.Content = "Список оценок, среднее значение = " + markFunctions.MinAVG(marks);
            CountTruancy.Content = "Количество прогулов = " + markFunctions.GetCountTruancy(this.marks);
            CountDisease.Content = "Количество пропусков по болезни = " + markFunctions.GetCountDisease(this.marks);
            List<string> students = new List<string>();
            for (int i = 0; i < this.students.Count; i++)
            {
                students.Add(markFunctions.GetStudNumber(this.students[i].EntryYear.Year, Convert.ToInt32(this.students[i].Group), this.students[i].FIO));
            }
            studentsDG2.ItemsSource = students;
        }
    }
}
