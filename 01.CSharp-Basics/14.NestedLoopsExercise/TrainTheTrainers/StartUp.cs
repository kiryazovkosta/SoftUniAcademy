namespace TrainTheTrainers
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int jury = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int counter = 0;
            double t = 0;
            while (input != "Finish")
            {
                counter++;
                string title = input;
                double gradesSum = 0;
                for (int i = 0; i < jury; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    gradesSum += grade;
                }

                double g = gradesSum / jury;
                Console.WriteLine($"{title} - {g:F2}.");
                input = Console.ReadLine();
                t += g;
            }

            Console.WriteLine($"Student's final assessment is {t/counter:F2}.");
        }
    }
}
