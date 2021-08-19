namespace MirrorWords
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Mirror
    {
        static void Main(string[] args)
        {
            string pattern = @"(@|#{1})(?<first>[A-Za-z]{3,})\1\1(?<second>[A-Za-z]{3,})\1";

            string text = Console.ReadLine();

            MatchCollection matches = Regex.Matches(text, pattern);
            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");

                List<WordPair> mirrorWords = new List<WordPair>();
                foreach (Match pair in matches)
                {
                    string first = pair.Groups["first"].Value;
                    string second = pair.Groups["second"].Value;
                    if (first.Length != second.Length)
                    {
                        continue;
                    }

                    StringBuilder reverse = new StringBuilder(); 
                    for (int i = second.Length - 1; i >= 0; i--)
                    {
                        reverse.Append(second[i]);
                    }

                    if (first == reverse.ToString())
                    {
                        mirrorWords.Add(new WordPair() {First = first, Second = second});
                    }
                }

                if (mirrorWords.Count > 0)
                {
                    Console.WriteLine($"The mirror words are:");
                    Console.WriteLine(string.Join(", ", mirrorWords));
                }
                else
                {
                    Console.WriteLine($"No mirror words!");
                }
            }
            else
            {
                Console.WriteLine($"No word pairs found!");
                Console.WriteLine($"No mirror words!");
            }
        }
    }

    public class WordPair
    {
        public string First { get; set; }
        public string Second { get; set; }

        public override string ToString()
        {
            return $"{this.First} <=> {this.Second}";
        }
    }
}
