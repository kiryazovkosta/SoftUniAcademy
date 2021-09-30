using System;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int a = 0;
            string x = "string";

            Func<int, long> operation = Square;
            PrintResult(5, Square);
            PrintResult(5, Pow2);
        }

        static void PrintResult(int x, Func<int, long> func)
        {
            var result = func(x);
            Console.WriteLine( "==========================================");
            Console.WriteLine($"            Result: {result}              ");
            Console.WriteLine( "==========================================");
        }

        static long Square(int number)
        {
            return number * number;
        }

        static long Pow2(int number)
        {
            return (long)Math.Pow(number, 2);
        }
    }
}
