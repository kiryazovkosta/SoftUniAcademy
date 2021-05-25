namespace DecryptingMessage
{
    using System;
    public class DecryptingMessageMain
    {
        public static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(key)));
            int symbolsNumber = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(symbolsNumber)));
            string output = string.Empty;
            for (int i = 1; i <= symbolsNumber; i++)
            {
                char symbol = char.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(symbol)));
                int digit = (int)symbol + key;
                output += (char)digit;
            }

            Console.WriteLine(output);
        }
    }
}