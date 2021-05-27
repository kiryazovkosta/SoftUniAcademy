namespace MagicSum
{
    using System;
    using System.Linq;

    public class MagicSumMain
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                ?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray()
                            ?? new int[] { };
            int pattern = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(pattern)));
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == pattern)
                    {
                        Console.WriteLine($"{numbers[i]} {numbers[j]}");
                    }
                }
            }
        }
    }
}
