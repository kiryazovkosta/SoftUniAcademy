namespace ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Predicates
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var numbers = new List<int>();
            for (int i = 1; i <= number; i++)
            {
                numbers.Add(i);
            }

            var dividers = Console.ReadLine()?.Split(" ").Select(int.Parse).ToArray();

            Func<int, int[], bool> divide = (n, d) => d.All(b => n % b == 0);
            var result = new List<int>();
            foreach (var n in numbers)
            {
                if (divide(n, dividers))
                {
                    result.Add(n);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}