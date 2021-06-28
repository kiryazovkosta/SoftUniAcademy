namespace SumAdjacentEqualNumbers
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class Numbers
    {
        private static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
            for (int i = 0; i < numbers?.Count - 1; i++)
            {
                if (Math.Abs(numbers[i] - numbers[i + 1]) < 0.00001)
                {
                    numbers[i] += numbers[i + 1];
                    numbers.RemoveAt(i + 1);
                    i = -1;
                }
            }

            Console.WriteLine(string.Join(" ", numbers ?? new List<double>(){ }));
        }
    }
}