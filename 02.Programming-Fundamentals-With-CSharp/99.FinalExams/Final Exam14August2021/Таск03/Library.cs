namespace Таск03
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Library
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();
            ProcessWords(dict, input);

            input = Console.ReadLine();
            string[] words = input.Split(" | ");

            input = Console.ReadLine();
            string command = input.Trim();

            if (input == "Test")
            {
                MakeTest(dict, words);
            }
            else if (input == "Hand Over")
            {
                MakeHandOver(dict);
            }
        }

        private static void MakeHandOver(Dictionary<string, List<string>> dict)
        {
            var output = dict.OrderBy(w => w.Key).Select(w => w.Key).ToList();
            Console.WriteLine(string.Join(" ", output));
        }

        private static void MakeTest(Dictionary<string, List<string>> dict, string[] words)
        {
            var output = dict.OrderBy(w => w.Key).ToDictionary(d => d.Key, d => d.Value);
            foreach (var item in output)
            {
                if (words.Contains(item.Key))
                {
                    Console.WriteLine($"{item.Key}:");
                    foreach (var desc in item.Value.OrderByDescending(v => v.Length))
                    {
                        Console.WriteLine($" -{desc}");
                    }
                }
            }
        }

        private static void ProcessWords(Dictionary<string, List<string>> dict, string input)
        {
            string[] records = input.Split(" | ");
            foreach (string record in records)
            {
                string[] definition = record.Split(": ");
                string word = definition[0].Trim();
                string description = definition[1].Trim();

                if (dict.ContainsKey(word) == false)
                {
                    dict.Add(word, new List<string>());
                }

                dict[word].Add(description);
            }
        }
    }
}
