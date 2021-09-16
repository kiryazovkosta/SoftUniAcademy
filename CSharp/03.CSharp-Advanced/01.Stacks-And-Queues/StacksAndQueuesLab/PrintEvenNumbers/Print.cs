namespace PrintEvenNumbers
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class Print
    {
        private static void Main(string[] args)
        {
            var data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            var numbers = new Queue<int>();
            foreach (var record in data)
            {
                numbers.Enqueue(record);
            }

            var even = new List<int>();
            while (numbers.Count > 0)
            {
                var number = numbers.Dequeue();
                if (number % 2 == 0)
                {
                    even.Add(number);
                }
            }

            Console.WriteLine(string.Join(", ", even));
        }
    }
}