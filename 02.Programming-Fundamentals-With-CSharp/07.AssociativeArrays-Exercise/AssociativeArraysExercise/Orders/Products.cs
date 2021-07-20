namespace Orders
{
    #region Using

    using System;
    using System.Collections.Generic;

    #endregion

    internal class Products
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var products = new Dictionary<string, Product>();

            while (input != "buy")
            {
                var productData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var name = productData[0];
                var price = double.Parse(productData[1]);
                var quantity = long.Parse(productData[2]);
                var product = new Product(name, price, quantity);
                if (products.ContainsKey(product.Name))
                {
                    products[name].Price = price;
                    products[name].Quantity += quantity;
                }
                else
                {
                    products.Add(name, product);
                }

                input = Console.ReadLine();
            }

            foreach (var product in products.Values)
            {
                Console.WriteLine($"{product.Name} -> {product.Quantity * product.Price:F2}");
            }
        }
    }

    public class Product
    {
        public Product(string name, double price, long quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public long Quantity { get; set; }
    }
}