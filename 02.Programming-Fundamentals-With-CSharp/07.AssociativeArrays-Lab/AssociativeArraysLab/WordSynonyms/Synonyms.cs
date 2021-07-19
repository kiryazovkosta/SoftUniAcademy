namespace WordSynonyms
{
    #region Using

    using System;
    using System.Collections.Generic;

    #endregion

    internal class Synonyms
    {
        private static void Main(string[] args)
        {
            Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();

            int size = int.Parse(Console.ReadLine());
            for (int i = 0; i < size; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (words.ContainsKey(word) == false)
                {
                    words.Add(word, new List<string>());
                }

                words[word].Add(synonym);
            }

            foreach (var word in words)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
            }
        }
    }
}