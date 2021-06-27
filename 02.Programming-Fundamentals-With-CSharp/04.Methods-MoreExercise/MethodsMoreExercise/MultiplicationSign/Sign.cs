using System;

namespace MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(a)));
            int b = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(b)));
            int c = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(c)));

            int result = GetSign(GetSign(a, b), c);
            Console.WriteLine(PrintSign(result));
        }

        private static int GetSign(int a, int b)
        {
            if (a == 0 || b == 0)
            {
                return 0;
            }
            else if ((a > 0 && b > 0) || (a < 0 && b < 0))
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        private static string PrintSign(int number)
        {
            if (number > 0)
            {
                return "positive";
            }
            else if (number < 0)
            {
                return "negative";
            }
            else
            {
                return "zero";
            }
        }
    }
}
