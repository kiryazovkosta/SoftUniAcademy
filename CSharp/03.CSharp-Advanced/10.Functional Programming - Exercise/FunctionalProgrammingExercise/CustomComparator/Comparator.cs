namespace CustomComparator
{
    using System;
    using System.Linq;

    public class Comparator
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray() ?? new int[] { };
            Array.Sort(numbers, Check);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static int Check(int a, int b)
        {
            if (a % 2 != 0 && b % 2 == 0)
            {
                return 1;
            }
            else if (a % 2 == 0 && b % 2 != 0)
            {
                return -1;
            }

            return a.CompareTo(b);
        }
    }
}