namespace GodzillaVsKong
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            double decorPricePercentage = 0.1;
            double dressDiscountPercentage = 0.1;
            int largeExtrasNumber = 150;

            double budget = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int extrasNumber = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double dressPrice = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            double decorPrice = budget * decorPricePercentage;
            double extrasDressPrice = extrasNumber * dressPrice;
            if (extrasNumber > largeExtrasNumber)
            {
                extrasDressPrice = extrasDressPrice - (extrasDressPrice * dressDiscountPercentage);
            }

            double costs = decorPrice + extrasDressPrice;

            if (costs > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {costs-budget:f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget-costs:F2} leva left.");
            }
        }
    }
}
