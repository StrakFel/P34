using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_7._2
{
    public class Student
    { 
        public string Name { get; set; }
        public int Age { get; set; }
        public string Faculty { get; set; }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Имя: {Name}");
            Console.WriteLine($"Лет: {Age}");
            Console.WriteLine($"Факультет: {Faculty}");
        }
    }

    public class ITStudent : Student
    {
        public string ProgrammingLanguage { get; set; }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Основной язык программирования: {ProgrammingLanguage}");
        }
    }
    public class MedicineStudent : Student 
    { 
        public string Specialization { get; set; }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Специализация: {Specialization}");
        }
    }

    public class University
    {
        private List<Student> students = new List<Student>();
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public void ShowStudentsByFaculty(string faculty)
        {
            bool found = false;

            foreach (Student student in students)
            {
                if (student.Faculty == faculty)
                {
                    student.ShowInfo();
                    Console.WriteLine();
                    found = true;
                }
            }
            if (!found) Console.WriteLine($"Нет студентов в факультете {faculty}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            University university = new University();

            ITStudent itStudent_1 = new ITStudent
            {
                Name = "Андрей",
                Age = 18,
                Faculty = "Компьютерные науки",
                ProgrammingLanguage = "C#"
            };
            ITStudent itStudent_2 = new ITStudent
            {
                Name = "Александр",
                Age = 19,
                Faculty = "Компьютерные науки",
                ProgrammingLanguage = "Python"
            };
            ITStudent itStudent_3 = new ITStudent
            {
                Name = "Роман",
                Age = 21,
                Faculty = "Разработка игр",
                ProgrammingLanguage = "C++"
            };

            MedicineStudent medicineStudent_1 = new MedicineStudent
            {
                Name = "Мария",
                Age = 20,
                Faculty = "Общая медицина",
                Specialization = "педиатр"
            };
            MedicineStudent medicineStudent_2 = new MedicineStudent
            {
                Name = "Алена",
                Age = 19,
                Faculty = "Общая медицина",
                Specialization = "хирург"

            };
            MedicineStudent medicineStudent_3 = new MedicineStudent
            {
                Name = "Иван",
                Age = 21,
                Faculty = "Психиатрия",
                Specialization = "психиатр"
            };

            university.AddStudent(itStudent_1);
            university.AddStudent(itStudent_2);
            university.AddStudent(itStudent_3);
            university.AddStudent(medicineStudent_1);
            university.AddStudent(medicineStudent_2);
            university.AddStudent(medicineStudent_3);

            university.ShowStudentsByFaculty("Компьютерные науки");
            university.ShowStudentsByFaculty("Общая медицина");
        }
    }
}
