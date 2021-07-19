namespace CountRealNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Numbers
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse)
                .ToArray();

            SortedDictionary<double, int> dict = new SortedDictionary<double, int>();
            foreach (double number in numbers)
            {
                if (!dict.ContainsKey(number))
                {
                    dict.Add(number, 0);
                }

                dict[number]++;
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
