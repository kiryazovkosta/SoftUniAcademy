using System;

namespace FuelTank
{
    using System.Data.Common;

    class StartUp
    {
        static void Main(string[] args)
        {
            string fuel = Console.ReadLine()?.ToLower();
            double quantity = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            if (fuel == "diesel"
                || fuel == "gasoline"
                || fuel == "gas"
                )
            {
                if (quantity >= 25)
                {
                    Console.WriteLine($"You have enough {fuel}.");
                }
                else
                {
                    Console.WriteLine($"Fill your tank with {fuel}!"); 
                }
            }
            else
            {
                Console.WriteLine("Invalid fuel!");
            }
        }
    }
}
