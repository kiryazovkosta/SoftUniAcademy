namespace ListOfProducts
{
    #region Using

    using System;
    using System.Collections.Generic;

    #endregion

    public class Products
    {
        private static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(count)));

            List<string> products = new List<string>();
            for (int i = 0; i < count; i++)
            {
                products.Add(Console.ReadLine());
            }

            products.Sort();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1}.{products[i]}");
            }
        }
    }
}