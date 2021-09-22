namespace SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Elements
    {
        static void Main(string[] args)
        {
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();
            HashSet<int> result = new HashSet<int>();

            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = sizes[0];
            int m = sizes[1];
            for (int i = 0; i < n + m; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (i < n)
                {
                    first.Add(number);
                }
                else
                {
                    second.Add(number);
                }
            }

            foreach (var number in first)
            {
                if (second.Contains(number))
                {
                    result.Add(number);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
