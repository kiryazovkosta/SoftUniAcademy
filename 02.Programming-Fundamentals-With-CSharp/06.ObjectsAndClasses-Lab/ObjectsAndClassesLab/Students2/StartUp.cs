namespace Students2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var students = ReadStudentsFromConsole();
            var searchForCity = Console.ReadLine() ?? throw new ArgumentNullException();
            PrintStudentsFromCity(students, searchForCity);
        }

        private static void PrintStudentsFromCity(IEnumerable<Student> students, string searchForCity)
        {
            foreach (var student in students)
            {
                if (student.City == searchForCity)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }

        private static IEnumerable<Student> ReadStudentsFromConsole()
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
                    var firstName = studentData[0];
                    var lastName = studentData[1];
                    var age = int.Parse(studentData[2]);
                    var city = studentData[3];

                    var student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
                    if (student == null)
                    {
                        students.Add(new Student()
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Age = age,
                            City = city,
                        });
                    }
                    else
                    {
                        student.Age = age;
                        student.City = city;
                    }
                }
            } while (continueReading);

            return students;
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