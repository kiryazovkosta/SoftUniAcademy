namespace PrintingTriangle
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException(nameof(number)));
            PrintTriangle(number);
        }

        private static void PrintTriangle(int number)
        {
            PrintTop(number);
            PrintBottom(number);
        }

        private static void PrintBottom(int number)
        {
            for (int i = number - 1; i >= 1; i--)
            {
                PrintRow(i);
            }
        }

        private static void PrintTop(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                PrintRow(i);
            }
        }

        private static void PrintRow(int i)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write($"{j} ");
            }

            Console.WriteLine();
        }
    }
}
