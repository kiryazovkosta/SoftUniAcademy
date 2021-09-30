namespace SumNumbers
{
    using System;
    using System.Linq;

    class Sum
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()?.Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray() ??
                            new int[] { };
            int count = numbers.Count();
            int sum = numbers.Sum();
            Console.WriteLine(count);
            Console.WriteLine(sum);
        }
    }
}