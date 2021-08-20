namespace FishingBoat
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermansNumber = int.Parse(Console.ReadLine());

            double price = 0.0;
            if (season == "Spring")
            {
                price = 3000.0;
            }
            else if (season == "Summer" || season == "Autumn")
            {
                price = 4200.0;
            }
            else if (season == "Winter")
            {
                price = 2600.0;
            }

            if (fishermansNumber <= 6)
            {
                price -= price * 0.1;
            }
            else if (fishermansNumber >= 12)
            {
                price -= price * 0.25;
            }
            else
            {
                price -= price * 0.15;
            }

            if (fishermansNumber % 2 == 0 && season != "Autumn")
            {
                price -= price * 0.05;
            }

            if (budget >= price)
            {
                Console.WriteLine($"Yes! You have {budget-price:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {price-budget:F2} leva.");
            }
        }
    }
}
