namespace GaussTrick
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class Trick
    {
        private static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                ?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList()
                ?? new List<int>();

            List<int> result = new List<int>();
            for (int i = 0, j = numbers.Count - 1; i < numbers.Count / 2; i++, j--)
            {
                int value = numbers[i] + numbers[j];
                result.Add(value);
            }

            if (numbers.Count % 2 == 1)
            {
                int value = numbers[numbers.Count / 2];
                result.Add(value);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}