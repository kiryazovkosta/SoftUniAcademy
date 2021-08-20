namespace SoftUniBarIncome
{
    #region Using

    using System;
    using System.Text.RegularExpressions;

    #endregion

    internal class SoftUniBar
    {
        private static void Main(string[] args)
        {
            var pattern = @"\%(?<name>[A-Z][a-z]+)\%[^|$%.]*\<(?<product>\w+)\>[^|$%.]*\|(?<count>[0-9]+)\|[^|$%.]*?(?<price>[0-9]+.{0,1}[0-9]+)\$";

            decimal totalIncome = 0;
            var input = Console.ReadLine();
            while (input != "end of shift")
            {
                if (!Regex.IsMatch(input, pattern))
                {
                    input = Console.ReadLine();
                    continue;
                }

                var order = Regex.Match(input, pattern);
                var name = order.Groups["name"].Value;
                var product = order.Groups["product"].Value;
                var count = int.Parse(order.Groups["count"].Value);
                var price = decimal.Parse(order.Groups["price"].Value);

                var income = count * price;
                totalIncome += income;
                Console.WriteLine($"{name}: {product} - {income:F2}");

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}