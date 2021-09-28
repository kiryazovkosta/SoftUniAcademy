namespace SortEvenNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EventNumbers
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()?.Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray() ?? new int[] { };

            var evenNumbers = SortEven(numbers);
            Console.WriteLine(string.Join(", ", evenNumbers));
        }

        private static List<int> SortEven(int[] numbers)
        {
            var evenNumbers = numbers.Where(n => n % 2 == 0).OrderBy(n => n).ToList() ?? new List<int>();
            return evenNumbers;
        }
    }
}