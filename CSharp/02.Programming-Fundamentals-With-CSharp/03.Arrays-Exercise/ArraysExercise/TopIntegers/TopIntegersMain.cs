namespace TopIntegers
{
    using System;
    using System.Linq;

    public class TopIntegersMain
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                                .ToArray() ?? new int[] { };
            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                bool isTop = true;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int current = numbers[j];
                    if (number <= current)
                    {
                        isTop = false;
                        break;
                    }
                }

                if (isTop)
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}
