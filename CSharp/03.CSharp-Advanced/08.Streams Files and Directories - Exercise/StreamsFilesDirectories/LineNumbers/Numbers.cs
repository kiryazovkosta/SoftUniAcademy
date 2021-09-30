namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class Numbers
    {
        public static void Main(string[] args)
        {
            string inputFile = "text.txt";
            string outputFile = "output.txt";
            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }

            string[] lines = File.ReadAllLines(inputFile, Encoding.UTF8);
            using StreamWriter writer = new StreamWriter(outputFile, false, Encoding.UTF8);
            for (int i = 1; i <= lines.Length; i++)
            {
                string line = lines[i - 1];
                int lettersCount = CountLetters(line);
                int marksCount = CountPunctuationMarks(line);
                writer.WriteLine($"Line {i}: {line} ({lettersCount})({marksCount})");
            }
        }

        private static int CountLetters(string line)
        {
            int count = 0;
            foreach (var symbol in line)
            {
                if (char.IsLetter(symbol))
                {
                    count++;
                }
            }

            return count;
        }

        private static int CountPunctuationMarks(string line)
        {
            int count = 0;
            foreach (var symbol in line)
            {
                if (char.IsPunctuation(symbol))
                { 
                    count++;
                }
            }

            return count;
        }
    }
}
