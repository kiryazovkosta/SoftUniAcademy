using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 1, 3, 5, 7, 2, 4, 5, 6, 7, 8, 3, 5, 6, 3, 5, 6, 7, 4, 2, 0, 9, 8 };

            var selected = numbers.Where(Bigger).Where(Even);
            Console.WriteLine(string.Join(" ", selected));

            var bigger = numbers.Where(Bigger);
            Console.WriteLine(string.Join(" ", bigger));

            Func<int, bool> func = (x) => x % 2 == 0;
            Print(func);
        }

        private static bool Even(int n)
        {
            return n % 2 == 0;
        }

        private static bool Bigger(int n)
        {
            return n > 5;
        }

        private static void Print(Func<int, bool> print)
        {
            Console.WriteLine(print);
        }

    }
}
