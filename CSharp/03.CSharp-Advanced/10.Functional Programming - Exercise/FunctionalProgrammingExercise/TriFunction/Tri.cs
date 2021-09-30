namespace TriFunction
{
    using System;
    using System.Collections.Generic;

    public class Tri
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = First(names, length, BiggerLength);
            Console.WriteLine(name);
        }

        private static bool BiggerLength(string name, int length)
        {
            int sum = 0;
            for (int i = 0; i < name.Length; i++)
            {
                int value = (int) name[i];
                sum += value;
            }

            return sum >= length;
        }

        private static string First(IEnumerable<string> names, int length, Func<string, int, bool> predicate)
        {
            string name = null;
            foreach (var n in names)
            {
                if (predicate(n, length))
                {
                    name = n;
                    break;
                }
            }

            return name;
        }
    }
}