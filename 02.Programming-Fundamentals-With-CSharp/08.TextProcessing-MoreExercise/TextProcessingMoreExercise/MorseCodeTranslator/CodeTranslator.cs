namespace MorseCodeTranslator
{
    #region Using

    using System;
    using System.Text;

    #endregion

    internal class CodeTranslator
    {
        private static void Main(string[] args)
        {
            StringBuilder output = new StringBuilder();
            string[] words = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                string[] symbols = word.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (var symbol in symbols)
                {
                    char letter = GetLetter(symbol);
                    output.Append(letter);
                }

                output.Append(" ");
            }

            Console.WriteLine(output.ToString());
        }

        private static char GetLetter(string symbol)
        {
            char letter = symbol switch
            {
                ".-" => 'A',
                "-..." => 'B',
                "-.-." => 'C',
                "-.." => 'D',
                "." => 'E',
                "..-." => 'F',
                "--." => 'G',
                "...." => 'H',
                ".." => 'I',
                ".---" => 'J',
                "-.-" => 'K',
                ".-.." => 'L',
                "--" => 'M',
                "-." => 'N',
                "---" => 'O',
                ".--." => 'P',
                "--.-" => 'Q',
                ".-." => 'R',
                "..." => 'S',
                "-" => 'T',
                "..-" => 'U',
                "...-" => 'V',
                ".--" => 'W',
                "-..-" => 'X',
                "-.--" => 'Y',
                "--.." => 'z',
                _ => throw new ArgumentException(nameof(symbol)),
            };

            return letter;
        }
    }
}