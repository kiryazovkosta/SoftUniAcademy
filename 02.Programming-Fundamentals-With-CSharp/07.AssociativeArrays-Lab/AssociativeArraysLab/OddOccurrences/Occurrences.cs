namespace OddOccurrences
{
    #region Using

    using System;
    using System.Collections.Generic;

    #endregion

    public class Occurrences
    {
        public static void Main(string[] args)
        {
            string[] words = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> counts = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].ToLower();
                if (!counts.ContainsKey(word))
                {
                    counts.Add(word, 0);
                }

                counts[word]++;
            }

            foreach (var count in counts)
            {
                if (count.Value % 2 != 0)
                {
                    Console.Write($"{count.Key} ");
                }
            }
        }
    }
}