namespace Grades
{
    using System;
    class StartUp
    {
        public static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            double gradesSum = 0.0;
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            for (int i = 0; i < students; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                gradesSum += grade;
                if (grade >= 2.00 && grade <= 2.99)
                {
                    p1++;
                }
                else if (grade >= 3.00 && grade <= 3.99)
                {
                    p2++;
                }
                else if (grade >= 4.00 && grade <= 4.99)
                {
                    p3++;
                }
                else if (grade >= 5.00)
                {
                    p4++;
                }
            }

            Console.WriteLine($"Top students: {(p4*1.0/students)*100.0:F2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {(p3 * 1.0 / students) * 100.0:F2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {(p2 * 1.0 / students) * 100.0:F2}%");
            Console.WriteLine($"Fail: {(p1 * 1.0 / students) * 100.0:F2}%");
            Console.WriteLine($"Average: {gradesSum/students:F2}");
        }
    }
}
