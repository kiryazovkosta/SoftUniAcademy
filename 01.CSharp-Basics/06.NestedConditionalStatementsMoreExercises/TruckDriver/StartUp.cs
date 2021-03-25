namespace TruckDriver
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double distance = double.Parse(Console.ReadLine());
            double pricePerKilometer = 0;
            if (distance <= 5000)
            {
                if (season == "Spring" || season == "Autumn")
                {
                    pricePerKilometer = 0.75;
                }
                else if (season == "Summer")
                {
                    pricePerKilometer = 0.9;
                }
                else if (season == "Winter")
                {
                    pricePerKilometer = 1.05;
                }
            }
            else if (distance > 5000 && distance <= 10000)
            {
                if (season == "Spring" || season == "Autumn")
                {
                    pricePerKilometer = 0.95;
                }
                else if (season == "Summer")
                {
                    pricePerKilometer = 1.1;
                }
                else if (season == "Winter")
                {
                    pricePerKilometer = 1.25;
                }
            }
            else if (distance > 10000 && distance <= 20000)
            {
                pricePerKilometer = 1.45;
            }

            double price = (distance * pricePerKilometer) * 4;
            price = price - (price * 0.1);
            Console.WriteLine($"{price:F2}");
        }
    }
}
