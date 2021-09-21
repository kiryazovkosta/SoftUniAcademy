namespace BasicQueueOperations
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class BasicQueue
    {
        private static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            int n = parameters[0];
            int s = parameters[1];
            int x = parameters[2];

            Queue<int> numbers = new Queue<int>();
            int[] values = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray() ?? new int[] { };
            foreach (var value in values)
            {
                numbers.Enqueue(value);
            }

            for (int i = 0; i < s; i++)
            {
                numbers.Dequeue();
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