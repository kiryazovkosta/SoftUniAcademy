using System;

namespace FlowerShop
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int magnolias = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int hyacinths = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int roses = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int cacti = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double gitfPrice = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            double totalSum = (magnolias * 3.25)
                              + (hyacinths * 4)
                              + (roses * 3.5)
                              + (cacti * 8);
            totalSum = totalSum - (totalSum * 0.05);
            if (gitfPrice > totalSum)
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(gitfPrice-totalSum)} leva.");
            }
            else
            {
                Console.WriteLine($"She is left with {Math.Floor(totalSum-gitfPrice)} leva.");
            }
        }
    }
}
