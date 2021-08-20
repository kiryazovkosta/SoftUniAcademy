namespace Courses
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    internal class CoursesInfo
    {
        private static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] data = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string course = data[0];
                string student = data[1];

                if (courses.ContainsKey(course) == false)
                {
                    courses.Add(course, new List<string>());
                }

                courses[course].Add(student);
                input = Console.ReadLine();
            }

            foreach (var course in courses.OrderByDescending(c => c.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var student in course.Value.OrderBy(s => s))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}