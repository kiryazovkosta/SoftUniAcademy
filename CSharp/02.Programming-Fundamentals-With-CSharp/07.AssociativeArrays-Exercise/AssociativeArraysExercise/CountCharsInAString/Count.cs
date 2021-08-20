namespace CountCharsInAString
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class Count
    {
        private static void Main(string[] args)
        {
            char[] symbols = Console.ReadLine()?.Replace(" ", string.Empty).ToArray() ?? new char[] { };

            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            foreach (char symbol in symbols)
            {
                if (dictionary.ContainsKey(symbol) == false)
                {
                    dictionary.Add(symbol, 0);
                }

                dictionary[symbol]++;
            }

            foreach (var symbol in dictionary)
            {
                Console.WriteLine($"{symbol.Key} -> {symbol.Value}");
            }
        }
    }
}