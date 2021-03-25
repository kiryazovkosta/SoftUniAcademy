namespace CarToGo
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double bouget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            if (bouget <= 100)
            {
                Console.WriteLine("Economy class");
                if (season == "Summer")
                {
                    Console.WriteLine($"Cabrio - {bouget*0.35:F2}");
                }
                else if (season == "Winter")
                {
                    Console.WriteLine($"Jeep - {bouget * 0.65:F2}");
                }
            }
            else if (bouget <= 500)
            {
                Console.WriteLine("Compact class");
                if (season == "Summer")
                {
                    Console.WriteLine($"Cabrio - {bouget * 0.45:F2}");
                }
                else if (season == "Winter")
                {
                    Console.WriteLine($"Jeep - {bouget * 0.8:F2}");
                }
            }
            else
            {
                Console.WriteLine("Luxury class");
                Console.WriteLine($"Jeep - {bouget*0.9:F2}");
            }
        }
    }
}
