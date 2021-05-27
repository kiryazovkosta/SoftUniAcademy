namespace ZigZagArrays
{
    using System;
    using System.Linq;

    public class ZigZagArraysMain
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(size)));
            int[] first = new int[size];
            int[] second = new int[size];
            for (int i = 1; i <= size; i++)
            {
                int index = i - 1;
                int[] numbers = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                                    .ToArray() ?? new int[] { };
                if (i % 2 == 0)
                {
                    first[index] = numbers[1];
                    second[index] = numbers[0];
                }
                else
                {
                    first[index] = numbers[0];
                    second[index] = numbers[1];
                }
            }

            Console.WriteLine(string.Join(" ", first));
            Console.WriteLine(string.Join(" ", second));
        }
    }
}
