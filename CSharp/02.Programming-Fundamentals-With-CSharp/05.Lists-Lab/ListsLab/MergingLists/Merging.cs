namespace MergingLists
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    internal class Merging
    {
        private static void Main(string[] args)
        {
            List<int> first = Console.ReadLine()
                                ?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToList()
                                ?? new List<int>();
            List<int> second = Console.ReadLine()
                                  ?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToList()
                              ?? new List<int>();

            int maxCount = first.Count >= second.Count ? first.Count : second.Count;

            List<int> result = new List<int>();
            for (int i = 0; i < maxCount; i++)
            {
                if (i < first.Count)
                {
                    result.Add(first[i]);
                }

                if (i < second.Count)
                {
                    result.Add(second[i]);
                }
            }

            Console.WriteLine(string.Join(" ", result));

        }
    }
}