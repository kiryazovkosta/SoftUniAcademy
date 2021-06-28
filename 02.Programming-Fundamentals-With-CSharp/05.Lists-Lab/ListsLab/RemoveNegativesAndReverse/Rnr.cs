namespace RemoveNegativesAndReverse
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class Rnr
    {
        private static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                              ?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToList()
                          ?? new List<int>();

            numbers.RemoveAll(n => n < 0);
            numbers.Reverse();

            if (numbers.Count > 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}