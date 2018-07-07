using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.AverageGrades
{
    class Student
    {
        public string Name { get; set; }
        public IEnumerable<double> Grades { get; set; } 
        public double AverageGrade => Grades.Average(); 
        
        class AverageGrades
        {
            static void Main(string[] args)
            {

                int n = int.Parse(Console.ReadLine());

                List<Student> students = new List<Student>();

                for (int i = 0; i < n; i++)
                {
                    string[] input = Console.ReadLine()
                        .Split(' ')
                        .ToArray();

                    string name = input.First();

                    var grades = input 
                        .Skip(1)
                        .Select(double.Parse)
                        .ToList();

                    Student student = new Student()
                    {
                        Name = name,
                        Grades = grades
                    };

                        students.Add(student);
                }

                PrintStudents(students);
            }

            private static void PrintStudents(List<Student> students)
            {

                students = students
                    .Where(a => a.AverageGrade >= 5)
                    .OrderBy(b => b.Name).ThenByDescending(a => a.AverageGrade).ToList();

                foreach (var student in students)
                {
                    Console.WriteLine($"{student.Name} -> {student.AverageGrade:F2}");
                }
            }
        }
    }
}