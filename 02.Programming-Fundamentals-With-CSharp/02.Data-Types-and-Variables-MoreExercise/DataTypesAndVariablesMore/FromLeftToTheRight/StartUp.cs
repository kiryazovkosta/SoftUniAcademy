namespace FromLeftToTheRight
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine() ?? throw new ArgumentException());
            for (int i = 0; i < size; i++)
            {
                string input = Console.ReadLine() ?? throw new ArgumentException();
                long[] numbers = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

                long first = numbers[0];
                long second = numbers[1];
                long number = first >= second ? Math.Abs(first) : Math.Abs(second);
                long digitsSum = 0;
                while (number > 0)
                {
                    long digit = number % 10;
                    digitsSum += digit;
                    number /= 10;
                }

                Console.WriteLine(digitsSum);
            }
        }
    }
}