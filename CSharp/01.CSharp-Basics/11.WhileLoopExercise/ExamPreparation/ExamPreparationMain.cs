namespace ExamPreparation
{
    using System;
    public class ExamPreparationMain
    {
        public static void Main(string[] args)
        {
            int tasksCounter = 0;
            double tasksGradesSum = 0;
            bool isFailed = false;
            int poorGradesCounter = 0;
            int maxPoorGrades = int.Parse(Console.ReadLine());
            string lastTaskName = string.Empty;
            string input = Console.ReadLine();
            while (input != "Enough")
            {
                string taskName = input;
                int taskGrade = int.Parse(Console.ReadLine());
                if (taskGrade <= 4)
                {
                    poorGradesCounter++;
                }

                if (poorGradesCounter >= maxPoorGrades)
                {
                    isFailed = true;
                    break;
                }

                lastTaskName = taskName;
                tasksCounter++;
                tasksGradesSum += taskGrade;
                input = Console.ReadLine();
            }

            if (isFailed)
            {
                Console.WriteLine($"You need a break, {poorGradesCounter} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {tasksGradesSum / tasksCounter:F2}");
                Console.WriteLine($"Number of problems: {tasksCounter}");
                Console.WriteLine($"Last problem: {lastTaskName}");
            }
        }
    }
}
