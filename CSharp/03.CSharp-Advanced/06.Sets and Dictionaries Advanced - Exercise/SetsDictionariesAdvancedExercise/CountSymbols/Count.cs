namespace CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Count
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];
                if (!symbols.ContainsKey(symbol))
                {
                    symbols.Add(symbol, 0);
                }

                symbols[symbol]++;
            }

            foreach (var symbol in symbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
