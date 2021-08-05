namespace Furniture
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    #endregion

    internal class Furnitures
    {
        private static void Main(string[] args)
        {
            var furnitures = new List<string>();
            decimal totalMoney = 0;

            var pattern = @">>(?<name>[A-z]+)<<(?<price>[0-9]*[.]?[0-9]+)!(?<quantity>[0-9]+)";

            var input = Console.ReadLine() ?? string.Empty;
            while (input != "Purchase")
            {
                if (!Regex.IsMatch(input, pattern))
                {
                    input = Console.ReadLine();
                    continue;
                }

                var furniture = Regex.Match(input, pattern);
                var name = furniture.Groups["name"].Value;
                var price = decimal.Parse(furniture.Groups["price"].Value);
                var quantity = int.Parse(furniture.Groups["quantity"].Value);

                furnitures.Add(name);
                totalMoney += (quantity * price);

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            foreach (var furniture in furnitures)
            {
                Console.WriteLine(furniture);
            }

            Console.WriteLine($"Total money spend: {totalMoney:F2}");
        }
    }
}