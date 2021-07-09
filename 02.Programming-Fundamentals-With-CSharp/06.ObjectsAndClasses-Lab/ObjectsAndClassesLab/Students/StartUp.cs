namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var students = new List<Student>();
            bool continueReading = true;
            do
            {
                string userInput = Console.ReadLine() ?? throw new ArgumentNullException();
                if (userInput.Equals("end"))
                {
                    continueReading = false;
                }
                else
                {
                    var studentData = userInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    students.Add(new Student()
                    {
                        FirstName = studentData[0],
                        LastName = studentData[1],
                        Age = int.Parse(studentData[2]),
                        City = studentData[3]
                    });
                }

            } while (continueReading);

            string city = Console.ReadLine() ?? throw new ArgumentNullException();
            foreach (var student in students)
            {
                if (student.City == city)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
}