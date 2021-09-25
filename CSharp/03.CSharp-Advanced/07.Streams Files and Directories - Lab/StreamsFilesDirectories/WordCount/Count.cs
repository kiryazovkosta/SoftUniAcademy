namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class Count
    {
        private static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            string pattern = @"\w+";

            foreach (var word in File.ReadAllText("words.txt")?.Split(" "))
            {
                words.Add(word.ToLower(), 0);
            }

            string line = null;
            using var reader = new StreamReader("text.txt", Encoding.UTF8);
            using var writer = new StreamWriter("output.txt", false, Encoding.UTF8);
            while ((line = reader.ReadLine()) != null)
            {
                List<string> text = Regex.Matches(line, pattern).Cast<Match>().Select(m => m.Value).ToList();
                foreach (var word in text)
                {
                    string value = word.ToLower();
                    if (words.ContainsKey(value))
                    {
                        words[value]++;
                    }
                }
            }

            foreach (var word in words.OrderByDescending(w => w.Value))
            {
                writer.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}