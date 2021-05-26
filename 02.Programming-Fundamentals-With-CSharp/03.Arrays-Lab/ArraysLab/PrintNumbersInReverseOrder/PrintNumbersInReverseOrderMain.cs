namespace PrintNumbersInReverseOrder
{
    using System;
    public class PrintNumbersInReverseOrderMain
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(size)));

            int[] numbers = new int[size];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(numbers)));
            }

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
    }
}