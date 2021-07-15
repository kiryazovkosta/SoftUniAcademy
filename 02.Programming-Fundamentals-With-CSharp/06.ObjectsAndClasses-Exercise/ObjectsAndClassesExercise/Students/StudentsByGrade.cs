namespace Students
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class StudentsByGrade
    {
        private static void Main(string[] args)
        {
            var students = new List<Student>();
            var studentsCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < studentsCount; i++)
            {
                var studentData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var student = new Student(studentData[0], studentData[1], double.Parse(studentData[2]));
                students.Add(student);
            }

            students = students.OrderByDescending(s => s.Grade).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, students));
        }
    }

    public class Student
    {
        private string firstName;
        private double grade;
        private string lastName;

        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName
        {
            get => this.firstName;
            set => this.firstName = value;
        }

        public string LastName
        {
            get => this.lastName;
            set => this.lastName = value;
        }

        public double Grade
        {
            get => this.grade;
            set => this.grade = value;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:F2}";
        }
    }
}