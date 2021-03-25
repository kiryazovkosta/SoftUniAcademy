using System;

namespace Vacation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string type = string.Empty;
            string place = "Alaska";
            double discount = 0;

            if (budget <= 1000)
            {
                type = "Camp";
                if (season == "Summer")
                {
                    discount = 0.65;
                }
                else if (season == "Winter")
                {
                    discount = 0.45;
                }
            }
            else if (budget > 1000 && budget <= 3000)
            {
                type = "Hut";
                if (season == "Summer")
                {
                    discount = 0.8;
                }
                else if (season == "Winter")
                {
                    discount = 0.6;
                }
            }
            else
            {
                type = "Hotel";
                discount = 0.9;
            }

            if (season == "Winter")
            {
                place = "Morocco";
            }

            Console.WriteLine($"{place} - {type} - {budget*discount:F2}");
        }
    }
}
