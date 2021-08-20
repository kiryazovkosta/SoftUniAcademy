using System;

namespace BikeRace
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int juniors = int.Parse(Console.ReadLine());
            int seniors = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();

            double juniorsPrice = 0;
            double seniorsPrice = 0;
            if (type == "trail")
            {
                juniorsPrice = 5.50;
                seniorsPrice = 7.00;
            }
            else if (type == "cross-country")
            {
                if (juniors + seniors >= 50)
                {
                    juniorsPrice = 8.00 - (8.00 * 0.25);
                    seniorsPrice = 9.50 - (9.50 * 0.25);
                }
                else
                {
                    juniorsPrice = 8.00;
                    seniorsPrice = 9.50;
                }
            }
            else if (type == "downhill")
            {
                juniorsPrice = 12.25;
                seniorsPrice = 13.75;
            }
            else if (type == "road")
            {
                juniorsPrice = 20.00;
                seniorsPrice = 21.50;
            }

            double total = juniors * juniorsPrice + seniors * seniorsPrice;
            double tax = total - total * 0.05;
            Console.WriteLine($"{tax:F2}");
        }
    }
}
