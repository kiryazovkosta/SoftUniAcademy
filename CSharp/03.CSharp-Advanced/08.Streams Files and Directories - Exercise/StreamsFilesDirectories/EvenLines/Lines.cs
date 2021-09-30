namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class Lines
    {
        static void Main(string[] args)
        {
            List<char> replacedSymbols = new List<char>() { '-', ',', '.', '!', '?' };
            char pattern = '@';
            StringBuilder text = new StringBuilder();

            using StreamReader reader = new StreamReader("text.txt", Encoding.UTF8);
            using StreamWriter writer = new StreamWriter("output.txt", false, Encoding.UTF8);

            int lineCounter = 0;
            string line = reader.ReadLine();
            while (line != null)
            {
                if (lineCounter % 2 == 0)
                {
                    Stack<string> words = new Stack<string>(
                        line.Split(" ", StringSplitOptions.RemoveEmptyEntries));
                    while(words.Count > 0)
                    {
                        string word = words.Pop();
                        for (int k = 0; k < word.Length; k++)
                        {
                            char symbol = word[k];
                            if (replacedSymbols.Contains(symbol))
                            {
                                symbol = pattern;
                            }

                            text.Append($"{symbol}");
                        }

                        text.Append(" ");
                    }

                    writer.WriteLine(text.ToString().TrimEnd());
                    text.Clear();
                }

                lineCounter++;
                line = reader.ReadLine();
            }
        }
    }
}
