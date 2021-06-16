namespace Orders
{
    #region Using

    using System;

    #endregion

    public class Program
    {
        private static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException(nameof(quantity)));

            double price = CalculatePrice(product, quantity);
            Console.WriteLine($"{price:F2}");
        }

        private static double CalculatePrice(string product, int quantity)
        {
            var singlePrice = GetProductPrice(product);
            var price = singlePrice * quantity;
            return price;
        }

        private static double GetProductPrice(string product)
        {
            double singlePrice = product switch
            {
                "coffee" => 1.50,
                "water" => 1.00,
                "coke" => 1.40,
                "snacks" => 2.00,
                _ => throw new ArgumentException(nameof(product))
            };
            return singlePrice;
        }
    }
}