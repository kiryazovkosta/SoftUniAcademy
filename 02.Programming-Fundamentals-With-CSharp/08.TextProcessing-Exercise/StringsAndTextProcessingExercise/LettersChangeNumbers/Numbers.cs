namespace LettersChangeNumbers
{
    using System;

    public enum Position
    {
        First = 1,
        Second = 2
    };

    public class Numbers
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double totalSum = 0;
            foreach (string word in words)
            {
                char first = word[0];
                double number = double.Parse(word.Substring(1, word.Length - 2));
                char last = word[word.Length - 1];

                double value = ProcessLeter(first, number, Position.First);
                double numberSum = ProcessLeter(last, value, Position.Second);
                totalSum += numberSum;
            }

            Console.WriteLine($"{totalSum:F2}");
        }

        private static double ProcessLeter(char symbol, double number, Position position)
        {
            int value = char.ToUpper(symbol) - 64;
            if (position == Position.First)
            {
                if (char.IsUpper(symbol))
                {
                    return number / value;
                }
                else
                {
                    return number * value;
                }
            }
            else
            {
                if (char.IsUpper(symbol))
                {
                    return number - value;
                }
                else
                {
                    return number + value;
                }
            }
        }
    }
}
