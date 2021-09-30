namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Count
    {
        public static void Main(string[] args)
        {
            var separators = new char[] { '-', ',', '.', '!', '?', ' ' };
            using var wordsReader = File.OpenText("words.txt");
            Dictionary<string, int> words = new Dictionary<string, int>();
            while (wordsReader.EndOfStream)
            {
                words.Add(wordsReader.ReadLine(), 0);
            }

            using var textReader = File.OpenText("text.txt");
            while (textReader.EndOfStream)
            {
                var sentence = wordsReader.ReadLine()
                    .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.ToLower());
                foreach (var word in sentence)
                {
                    if (words.ContainsKey(word))
                    {
                        words[word]++;
                    }
                }
            }

            bool areValid = true;
            using var output = new StreamWriter("actualResult.txt", false, Encoding.UTF8);
            using var expected = File.OpenText("expectedResult.txt");

            foreach (var word in words.OrderByDescending(w => w.Value))
            {
                string line = $"{word.Key} - {word.Value}";
                if (expected.EndOfStream)
                {
                    if (expected.ReadLine().Trim() != line)
                    {
                        areValid = false;
                    }
                }

                output.WriteLine(line);
            }

            Console.WriteLine($"Files are identical: {areValid}");
        }
    }
}
