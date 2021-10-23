namespace Task01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var vowels = new Queue<char>(Console.ReadLine().Split(" ").Select(char.Parse));
            var consonants = new Stack<char>(Console.ReadLine().Split(" ").Select(char.Parse));

            Dictionary<string, List<char>> words = new Dictionary<string, List<char>>
            {
                { "pear", new List<char>() },
                { "flour", new List<char>() },
                { "pork", new List<char>() },
                { "olive", new List<char>() }
            };

            while (consonants.Count > 0)
            {
                char vowel = vowels.Dequeue();
                char consonant = consonants.Pop();
                foreach (var word in words)
                {
                    if (word.Key.Contains(vowel) && !words[word.Key].Contains(vowel))
                    {
                        words[word.Key].Add(vowel);
                    }

                    if (word.Key.Contains(consonant) && !words[word.Key].Contains(consonant))
                    {
                        words[word.Key].Add(consonant);
                    }
                }

                vowels.Enqueue(vowel);
            }

            var complite = words.Where(w => w.Value.Count == w.Key.Length).Select(v => v.Key).ToList();
            Console.WriteLine($"Words found: {complite.Count()}");
            Console.WriteLine(string.Join(Environment.NewLine, complite));
        }
    }
}