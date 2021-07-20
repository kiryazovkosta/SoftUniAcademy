namespace WordFilter
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    internal class Filter
    {
        private static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                                     ?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                     .Where(w => w.Length % 2 == 0)
                                     .ToList()
                                 ??
                                 new List<string>();
            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}