namespace CountSameValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Count
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();

            Dictionary<double, int> count = new Dictionary<double, int>();
            foreach (double number in numbers)
            {
                if (!count.ContainsKey(number))
                {
                    count.Add(number, 0);
                }

                count[number]++;
            }

            foreach (var number in count)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}