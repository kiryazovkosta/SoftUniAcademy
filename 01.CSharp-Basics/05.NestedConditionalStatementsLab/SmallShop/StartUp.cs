namespace SmallShop
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            if (product == "coffee")
            {
                if (city == "Sofia")
                {
                    Console.WriteLine(quantity * 0.5);
                }
                else if (city == "Plovdiv")
                {
                    Console.WriteLine(quantity * 0.4);
                }
                else if (city == "Varna")
                {
                    Console.WriteLine(quantity * 0.45);
                }
            }
            else if (product == "water")
            {
                if (city == "Sofia")
                {
                    Console.WriteLine(quantity * 0.8);
                }
                else if (city == "Plovdiv")
                {
                    Console.WriteLine(quantity * 0.7);
                }
                else if (city == "Varna")
                {
                    Console.WriteLine(quantity * 0.7);
                }
            }
            else if (product == "beer")
            {
                if (city == "Sofia")
                {
                    Console.WriteLine(quantity * 1.2);
                }
                else if (city == "Plovdiv")
                {
                    Console.WriteLine(quantity * 1.15);
                }
                else if (city == "Varna")
                {
                    Console.WriteLine(quantity * 1.1);
                }
            }
            else if (product == "sweets")
            {
                if (city == "Sofia")
                {
                    Console.WriteLine(quantity * 1.45);
                }
                else if (city == "Plovdiv")
                {
                    Console.WriteLine(quantity * 1.3);
                }
                else if (city == "Varna")
                {
                    Console.WriteLine(quantity * 1.35);
                }
            }
            else if (product == "peanuts")
            {
                if (city == "Sofia")
                {
                    Console.WriteLine(quantity * 1.6);
                }
                else if (city == "Plovdiv")
                {
                    Console.WriteLine(quantity * 1.5);
                }
                else if (city == "Varna")
                {
                    Console.WriteLine(quantity * 1.55);
                }
            }
        }
    }
}
