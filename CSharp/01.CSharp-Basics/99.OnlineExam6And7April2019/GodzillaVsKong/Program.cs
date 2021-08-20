using System;

namespace GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int peoples = int.Parse(Console.ReadLine());
            double dressPrice = double.Parse(Console.ReadLine());

            double dekor = budget * 0.1;
            double peopleDress = peoples * dressPrice;
            if (peoples > 150)
            {
                peopleDress -= (peopleDress * 0.1);
            }
            double totalSum = dekor + peopleDress;
            if (budget >= totalSum)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget-totalSum:F2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {totalSum-budget:F2} leva more.");
            }

        }
    }
}
