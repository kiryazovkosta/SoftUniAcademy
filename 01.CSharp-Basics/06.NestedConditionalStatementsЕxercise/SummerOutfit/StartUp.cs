namespace SummerOutfit
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string period = Console.ReadLine();

            string outfit = string.Empty;
            string shoes = string.Empty;

            if (degrees >= 10 && degrees <= 18)
            {
                if (period == "Morning")
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }
                else if (period == "Afternoon" || period == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            else if (degrees > 18 && degrees <= 24)
            {
                if (period == "Morning")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
                else if (period == "Afternoon")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (period == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }
            else
            {
                if (period == "Morning")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
                else if (period == "Afternoon")
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }
                else if (period == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }

            Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
        }
    }
}
