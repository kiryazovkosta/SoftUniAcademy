using System;

namespace FruitMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberryPrice = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double bannanas = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double oranges = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double raspberries = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double strawberries = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            double raspberryPrice = strawberryPrice / 2;
            double orangePrice = raspberryPrice - (raspberryPrice * 0.4);
            double bannanaPrice = raspberryPrice - (raspberryPrice * 0.8);

            double strawberriesPrice = strawberryPrice * strawberries;
            double raspberriesPrice = raspberryPrice * raspberries;
            double orangesPrice = orangePrice * oranges;
            double bannanasPrice = bannanaPrice * bannanas;

            double totalPrice = strawberriesPrice + raspberriesPrice + orangesPrice + bannanasPrice;
            Console.WriteLine(totalPrice);
        }
    }
}
