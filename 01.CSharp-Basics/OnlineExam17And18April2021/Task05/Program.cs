namespace Task05
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            int bestGoals = int.MinValue;
            string bestName = string.Empty;

            string input = Console.ReadLine();
            while (input != "END")
            {
                string name = input;
                int goals = int.Parse(Console.ReadLine());
                if (goals > bestGoals)
                {
                    bestName = name;
                    bestGoals = goals;
                }

                if (goals >= 10)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{bestName} is the best player!");
            if (bestGoals >= 3)
            {
                Console.WriteLine($"He has scored {bestGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {bestGoals} goals.");
            }
        }
    }
}
