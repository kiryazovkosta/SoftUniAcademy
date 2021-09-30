namespace ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Exclude
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            int number = int.Parse(Console.ReadLine());

            Func<int, int, bool> exclude = (n, x) => n % x != 0;
            var result = Reverse(numbers, number, exclude);
            Console.WriteLine(string.Join(" ", result));
        }

        public static IEnumerable<int> Reverse(IEnumerable<int> numbers, int number, Func<int, int, bool> func)
        {
            var result = new List<int>();
            foreach (var n in numbers.Reverse())
            {
                if (func(n, number))
                {
                    result.Add(n);
                }
            }

            return result;
        }
    }
}