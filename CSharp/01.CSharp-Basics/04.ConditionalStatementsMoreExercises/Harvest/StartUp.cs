namespace Harvest
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            int vineyard = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double grapesPerSquareMeter = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int requiredWineLiters = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int workersNumber = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            double totalGrapes = vineyard * grapesPerSquareMeter;
            double wine = (totalGrapes * 0.4) / 2.5;
            if (wine >= requiredWineLiters)
            {
                double totalWine = Math.Floor(wine);
                Console.WriteLine($"Good harvest this year! Total wine: {totalWine} liters.");
                double wineLeft = Math.Ceiling(wine - requiredWineLiters);
                double wineForWorker = Math.Ceiling(wineLeft / workersNumber);
                Console.WriteLine($"{wineLeft} liters left -> {wineForWorker} liters per person.");
            }
            else
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(requiredWineLiters-wine)} liters wine needed.");
            }
        }
    }
}
