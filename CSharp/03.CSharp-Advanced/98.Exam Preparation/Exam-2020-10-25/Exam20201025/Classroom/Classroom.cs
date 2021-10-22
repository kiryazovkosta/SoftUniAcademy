using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            students = new List<Student>();
        }

        public int Capacity { get; set; }
        public int Count => students.Count;

        public string RegisterStudent(Student student)
        {
            if (this.Capacity > this.Count)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            
            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
            if (student != null)
            {
                students.Remove(student);
                return $"Dismissed student {firstName} {lastName}";
            }

            return "Student not found";
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            var student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
            return student;
        }

        public string GetSubjectInfo(string subject)
        {
            var enrolledStudents = students.Where(s => s.Subject == subject).ToList();
            if (enrolledStudents.Count == 0)
            {
                return "No students enrolled for the subject";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");
            foreach (var student in students.Where(s => s.Subject == subject))
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }

            return sb.ToString().Trim();
        }
    }
}
