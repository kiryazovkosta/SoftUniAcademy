namespace EmojiDetector
{
    #region Using

    using System;
    using System.Text.RegularExpressions;

    #endregion

    internal class Detector
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var emojiPattern = @"([*]{2}|[:]{2})(?<name>[A-Z][a-z]{2,})\1";
            var digitPattern = @"[0-9]";

            long coolThresholdSum = 1;
            var digits = Regex.Matches(input, digitPattern);
            foreach (Match digit in digits)
            {
                coolThresholdSum *= int.Parse(digit.Value);
            }

            Console.WriteLine($"Cool threshold: {coolThresholdSum}");

            var emojis = Regex.Matches(input, emojiPattern);
            Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");
            foreach (Match emoji in emojis)
            {
                var name = emoji.Groups["name"].Value;
                var currentCoolness = 0;
                foreach (var symbol in name)
                {
                    currentCoolness += symbol;
                }

                if (currentCoolness >= coolThresholdSum)
                {
                    Console.WriteLine(emoji.Value);
                }
            }
        }
    }
}