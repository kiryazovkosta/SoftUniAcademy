namespace Journey
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = string.Empty;
            string tripType = string.Empty;
            double costs = 0.0;

            if (budget <= 100 )
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    tripType = "Camp";
                    costs = budget * 0.3;
                }
                else if (season == "winter")
                {
                    tripType = "Hotel";
                    costs = budget * 0.7;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    tripType = "Camp";
                    costs = budget * 0.4;
                }
                else if (season == "winter")
                {
                    tripType = "Hotel";
                    costs = budget * 0.8;
                }
            }
            else
            {
                destination = "Europe";
                tripType = "Hotel";
                costs = budget * 0.9;
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{tripType} - {costs:F2}");
        }
    }
}
