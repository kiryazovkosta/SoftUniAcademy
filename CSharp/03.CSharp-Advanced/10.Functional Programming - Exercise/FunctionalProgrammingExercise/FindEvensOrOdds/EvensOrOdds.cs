namespace FindEvensOrOdds
{
    using System;
    using System.Linq;

    public class EvensOrOdds
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            string type = Console.ReadLine();
            int begin = range[0];
            int end = range[1];

            Predicate<int> find = null;
            if (type == "even")
            {
                find = n => n % 2 == 0;
            }
            else
            {
                find = n => n % 2 != 0;
            }

            PrintInRange(begin, end, find);
        }

        private static void PrintInRange(int begin, int end, Predicate<int> find)
        {
            for (int i = begin; i <= end; i++)
            {
                if (find(i))
                {
                    Console.Write($"{i} ");
                }
            }

            Console.WriteLine();
        }
    }
}
