namespace BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class BasicStack
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            int n = parameters[0];
            int s = parameters[1];
            int x = parameters[2];

            Stack<int> numbers = new Stack<int>();
            int[] values = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray() ?? new int[]{ };
            foreach (var value in values)
            {
                numbers.Push(value);
            }

            for (int i = 0; i < s; i++)
            {
                numbers.Pop();
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (numbers.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(numbers.Min());
                }
            }

        }
    }
}