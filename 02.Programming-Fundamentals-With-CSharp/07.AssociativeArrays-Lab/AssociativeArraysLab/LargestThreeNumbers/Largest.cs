namespace LargestThreeNumbers
{
    #region Using

    using System;
    using System.Linq;

    #endregion

    public class Largest
    {
        private static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .OrderByDescending(n => n).Take(3).ToArray() ?? new int[]{ };

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}