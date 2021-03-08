using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int confectioners = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int cakes = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int waffles = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int pancakes = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            double cakePriceForDay = cakes * 45;
            double wafflesPricePerDay = waffles * 5.80;
            double pancakePricePerDay = pancakes * 3.20;

            double totalPriceOfDay = (cakePriceForDay + wafflesPricePerDay + pancakePricePerDay) * confectioners;
            double totalPriceForPeriod = totalPriceOfDay * days;
            double totalPrice = totalPriceForPeriod - (totalPriceForPeriod / 8.0);
            Console.WriteLine(totalPrice);
        }
    }
}
