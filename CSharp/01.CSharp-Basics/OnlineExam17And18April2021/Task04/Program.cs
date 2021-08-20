namespace Task04
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double totalDistance = 0;
            double prevDistance = 0;
            for (int i = 0; i <= days; i++)
            {
                if (i == 0)
                {
                    totalDistance += distance;
                    prevDistance = distance;
                }
                else
                {
                    int percentages = int.Parse(Console.ReadLine());
                    double dayDistance = prevDistance + (prevDistance * (percentages / 100.0));
                    totalDistance += dayDistance;
                    prevDistance = dayDistance;
                }


            }

            if (totalDistance >= 1000)
            {
                Console.WriteLine($"You've done a great job running {Math.Ceiling(totalDistance-1000)} more kilometers!");
            }
            else
            {
                Console.WriteLine($"Sorry Mrs. Ivanova, you need to run {Math.Ceiling(1000-totalDistance)} more kilometers");
            }
        }
    }
}
