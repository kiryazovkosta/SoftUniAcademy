namespace SoftUniExamResults
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    internal class ExamResults
    {
        private static void Main(string[] args)
        {
            Dictionary<string, int> studentsByPoints = new Dictionary<string, int>();
            Dictionary<string, int> coursesBySubmission = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "exam finished")
            {
                string[] data = input?.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string username = data[0];
                if (data[1] == "banned")
                {
                    studentsByPoints.Remove(username);
                    input = Console.ReadLine();
                    continue;
                }

                string language = data[1];
                int points = int.Parse(data[2]);

                if (studentsByPoints.ContainsKey(username) == false)
                {
                    studentsByPoints.Add(username, points);
                    if (coursesBySubmission.ContainsKey(language) == false)
                    {
                        coursesBySubmission.Add(language, 0);
                    }

                    coursesBySubmission[language]++;
                }
                else
                {
                    if (studentsByPoints[username] <= points)
                    {
                        studentsByPoints[username] = points;
                    }

                    coursesBySubmission[language] += 1;
                }

                input = Console.ReadLine();
            }

            if (studentsByPoints.Count > 0)
            {
                Console.WriteLine($"Results:");
                foreach (var student in studentsByPoints.OrderByDescending(s => s.Value).ThenBy(s => s.Key))
                {
                    Console.WriteLine($"{student.Key} | {student.Value}");
                }
            }

            if (coursesBySubmission.Count > 0)
            {
                Console.WriteLine($"Submissions:");
                foreach (var course in coursesBySubmission.OrderByDescending(c => c.Value).ThenBy(c => c.Key))
                {
                    Console.WriteLine($"{course.Key} - {course.Value}");
                }
            }
        }
    }
}