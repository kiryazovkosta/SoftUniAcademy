namespace SumEvenNumbers
{
    using System;
    using System.Linq;

    public class SumEvenNumbersMain
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                ?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray()
                            ?? new int[] { };
            long sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    sum += numbers[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
