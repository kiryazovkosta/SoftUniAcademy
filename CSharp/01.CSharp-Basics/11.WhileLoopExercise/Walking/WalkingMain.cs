namespace Walking
{
    using System;
    public class WalkingMain
    {
        public static void Main(string[] args)
        {
            int totalSteps = 0;
            string input = Console.ReadLine();
            while (input != "Going home")
            {
                int steps = int.Parse(input);
                totalSteps += steps;
                if (totalSteps >= 10000)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            if (input == "Going home")
            {
                int extraSteps = int.Parse(Console.ReadLine());
                totalSteps += extraSteps;
            }

            if (totalSteps >= 10000)
            {
                Console.WriteLine($"Goal reached! Good job!{Environment.NewLine}{totalSteps - 10000} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{10000 - totalSteps} more steps to reach goal.");
            }
        }
    }
}
