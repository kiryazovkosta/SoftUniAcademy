namespace PeriodicTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Table
    {
        public static void Main(string[] args)
        {
            HashSet<string> elements = new HashSet<string>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] records = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (var record in records)
                {
                    if (!elements.Contains(record))
                    {
                        elements.Add(record);
                    }
                }
            }

            foreach (var element in elements.OrderBy(e => e))
            {
                Console.Write($"{element} ");
            }
        }
    }
}