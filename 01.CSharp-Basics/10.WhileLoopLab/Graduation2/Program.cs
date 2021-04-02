using System;

namespace Graduation2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double totalGrades = 0;
            int failedGrades = 0;
            int cls = 0;
            bool isFinished = true;
            while (cls < 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade <= 4.00)
                {
                    failedGrades++;
                }

                if (failedGrades > 1)
                {
                    Console.WriteLine($"{name} has been excluded at {cls} grade");
                    isFinished = false;
                    break;
                }
                
                totalGrades += grade;
                cls++;
            }

            if (isFinished)
            {
                Console.WriteLine($"{name} graduated. Average grade: {totalGrades/cls:F2}");
            }
        }
    }
}
