namespace TriangleOfNumbers
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(number)));
            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write($"{i} ");
                }

                Console.WriteLine();
            }
        }
    }
}
