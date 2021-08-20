namespace VegetableMarket
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            double vPrice = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double fPrice = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int vegetables = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int fruits = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            double vTotal = vPrice * vegetables;
            double fTotal = fPrice * fruits;
            double totalPriceInLv = vTotal + fTotal;
            double totalPriceInEuro = totalPriceInLv / 1.94;
            Console.WriteLine($"{totalPriceInEuro:F2}");
        }
    }
}
