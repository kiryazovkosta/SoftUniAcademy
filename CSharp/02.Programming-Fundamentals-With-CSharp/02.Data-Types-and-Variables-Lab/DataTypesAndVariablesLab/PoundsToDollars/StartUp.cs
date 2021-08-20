namespace PoundsToDollars
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            decimal pounds = decimal.Parse(
                Console.ReadLine() 
                ?? throw new ArgumentException(nameof(pounds)));
            decimal dollars = pounds * 1.31M;
            Console.WriteLine($"{dollars:F3}");
        }
    }
}
