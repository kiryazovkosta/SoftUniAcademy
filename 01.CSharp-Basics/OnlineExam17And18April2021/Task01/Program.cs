namespace Task01
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            int papper = int.Parse(Console.ReadLine());
            int plat = int.Parse(Console.ReadLine());
            double guel = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double papperPrice = papper * 5.8;
            double platPrice = plat * 7.2;
            double guelPrice = guel * 1.2;
            double total = papperPrice + platPrice + guelPrice;
            if (discount > 0)
            {
                total -= (total * (discount / 100.0));
            }
            Console.WriteLine($"{total:F3}");
        }
    }
}
