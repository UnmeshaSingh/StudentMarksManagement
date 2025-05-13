using System;
using System.Collections.Generic;

namespace StudentMarksSystem
{
    class Student
    {
        public string Name { get; set; }
        public int RollNo { get; set; }
        public List<int> Marks { get; set; } = new List<int>();
        public int Total => CalculateTotal();
        public double Average => Marks.Count > 0 ? (double)Total / Marks.Count : 0;
        public string Grade => CalculateGrade();

        private int CalculateTotal()
        {
            int sum = 0;
            foreach (var mark in Marks)
                sum += mark;
            return sum;
        }

        private string CalculateGrade()
        {
            double avg = Average;
            if (avg >= 90) return "A";
            else if (avg >= 75) return "B";
            else if (avg >= 60) return "C";
            else if (avg >= 40) return "D";
            else return "F";
        }

        public void DisplayReport()
        {
            Console.WriteLine("\n--- Student Report ---");
            Console.WriteLine($"Name      : {Name}");
            Console.WriteLine($"Roll No   : {RollNo}");
            Console.WriteLine($"Marks     : {string.Join(", ", Marks)}");
            Console.WriteLine($"Total     : {Total}");
            Console.WriteLine($"Average   : {Average:F2}");
            Console.WriteLine($"Grade     : {Grade}");
            Console.WriteLine("------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Student Marks Management System");
            Console.Write("Enter the number of subjects: ");
            int subjectCount = Convert.ToInt32(Console.ReadLine());

            Student student = new Student();

            Console.Write("Enter student name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter roll number: ");
            student.RollNo = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < subjectCount; i++)
            {
                Console.Write($"Enter marks for Subject {i + 1}: ");
                int mark = Convert.ToInt32(Console.ReadLine());
                student.Marks.Add(mark);
            }

            student.DisplayReport();
        }
    }
}
