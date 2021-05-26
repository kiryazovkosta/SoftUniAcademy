namespace EvenAndOddSubtraction
{
    using System;
    using System.Linq;

    public class EvenAndOddSubtractionMain
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                ?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray()
                            ?? new int[] { };

            long evenSum = 0;
            long oddSum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                if (number % 2 == 0)
                {
                    evenSum += number;
                }
                else
                {
                    oddSum += number;
                }
            }

            Console.WriteLine(evenSum - oddSum);
        }
    }
}
