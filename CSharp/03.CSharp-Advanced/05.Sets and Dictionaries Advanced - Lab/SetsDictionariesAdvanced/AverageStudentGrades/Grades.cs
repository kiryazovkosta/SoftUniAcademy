namespace AverageStudentGrades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Grades
    {
        static void Main(string[] args)
        {
            var students = new Dictionary<string, List<decimal>>();
            int studentCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < studentCount; i++)
            {
                string[] studentData = Console.ReadLine().Split(" ");
                string name = studentData[0];
                decimal grade = decimal.Parse(studentData[1]);
                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<decimal>());
                }

                students[name].Add(grade);
            }

            foreach (var student in students)
            {
                var grades = new StringBuilder();
                foreach (var grade in student.Value)
                {
                    grades.AppendFormat($"{grade:F2} ");
                }

                Console.WriteLine($"{student.Key} -> {grades}(avg: {student.Value.Average():F2})");
            }
        }
    }
}
