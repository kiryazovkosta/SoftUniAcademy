namespace MaximumAndMinimumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class MInMax
    {
        private static void Main(string[] args)
        {
            var numbers = new Stack<int>();
            var queryCount = int.Parse(Console.ReadLine());
            for (var i = 0; i < queryCount; i++)
            {
                var query = Console.ReadLine()
                                ?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray() ?? new int[] { };
                if (query[0] == 1)
                {
                    var number = query[1];
                    numbers.Push(number);
                }
                else if (query[0] == 2)
                {
                    if (numbers.Count > 0)
                    {
                        numbers.Pop();
                    }
                }
                else if (query[0] == 3)
                {
                    if (numbers.Count > 0)
                    {
                        Console.WriteLine(numbers.Max());
                    }
                }
                else if (query[0] == 4)
                {
                    if (numbers.Count > 0)
                    {
                        Console.WriteLine(numbers.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}