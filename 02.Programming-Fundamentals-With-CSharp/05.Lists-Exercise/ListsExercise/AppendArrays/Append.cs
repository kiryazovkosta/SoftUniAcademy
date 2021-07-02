namespace AppendArrays
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class Append
    {
        private static void Main(string[] args)
        {
            List<int> result = new List<int>();
            string[] arrays = Console.ReadLine()?.Split("|", StringSplitOptions.RemoveEmptyEntries);
            for (int i = arrays.Length - 1; i >= 0; i--)
            {
                List<int> numbers = arrays[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToList();
                result.AddRange(numbers);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}