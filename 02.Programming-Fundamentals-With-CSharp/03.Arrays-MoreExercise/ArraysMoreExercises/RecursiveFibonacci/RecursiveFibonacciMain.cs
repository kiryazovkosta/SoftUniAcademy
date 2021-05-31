namespace RecursiveFibonacci
{
    using System;
    using System.Numerics;

    public class RecursiveFibonacciMain
    {
        private static BigInteger[] memo;
        private static int counter = 0;

        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(number)));
            memo = new BigInteger[100];
            Console.WriteLine(GetFibonacci(number));
        }

        private static BigInteger GetFibonacci(int number)
        {
            if (number <= 2)
            {
                return 1;
            }

            if (memo[number] != 0)
            {
                return memo[number];
            }

            memo[number] = GetFibonacci(number - 1) + GetFibonacci(number - 2);
            return memo[number];
        }
    }
}