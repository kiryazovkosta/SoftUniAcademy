namespace AddVAT
{
    using System;
    using System.Linq;

    public class Vat
    {
        public static void Main(string[] args)
        {
            decimal[] numbersWithAddedVat = Console.ReadLine()
                ?.Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => decimal.Parse(n) * 1.20M)
                .ToArray() ?? new decimal[] { };
            foreach (var number in numbersWithAddedVat)
            {
                Console.WriteLine($"{number:F2}");
            }
        }
    }
}