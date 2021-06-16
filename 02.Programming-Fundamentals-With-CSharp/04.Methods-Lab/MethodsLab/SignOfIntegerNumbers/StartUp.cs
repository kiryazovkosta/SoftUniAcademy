namespace SignOfIntegerNumbers
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(number)));
            string sign = GetSign(number);
            Console.WriteLine($"The number {number} is {sign}.");
        }

        public static string GetSign(int number)
        {
            if (number > 0)
            {
                return "positive";
            }
            else if (number < 0)
            {
                return "negative";
            }

            return "zero";
        }
    }
}
