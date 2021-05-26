namespace RoundingNumbers
{
    using System;
    using System.Linq;

    public class RoundingNumbersMain
    {
        public static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                                   ?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(double.Parse)
                                   .ToArray()
                               ?? new double[] { };
            for (int i = 0; i < numbers.Length; i++)
            {
                double roundedNumber = Math.Round(numbers[i], MidpointRounding.AwayFromZero);
                Console.WriteLine($"{Convert.ToDecimal(numbers[i])} => {Convert.ToDecimal(roundedNumber)}");
            }
        }
    }
}
