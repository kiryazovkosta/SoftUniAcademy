using System;

namespace AddAndSubtract
{
    public class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(a)));
            int b = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(b)));
            int c = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(c)));

            Console.WriteLine(Subtract(Sum(a, b), c));
        }

        private static int Sum(int a, int b)
        {
            return a + b;
        }

        private static int Subtract(int a, int b)
        {
            return a - b;
        }
    }
}
