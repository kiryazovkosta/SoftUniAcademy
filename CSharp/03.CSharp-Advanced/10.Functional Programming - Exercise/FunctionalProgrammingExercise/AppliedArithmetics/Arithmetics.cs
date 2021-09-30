namespace AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Arithmetics
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()?.Split(" ").Select(int.Parse);

            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = ForEach(numbers, n => n + 1);
                        break;

                    case "multiply":
                        numbers = ForEach(numbers, n => n * 2);
                        break;

                    case "subtract":
                        numbers = ForEach(numbers, n => n - 1);
                        break;

                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;

                    default:
                        break;
                }

                command = Console.ReadLine();
            }


        }

        private static IEnumerable<int> ForEach(IEnumerable<int> numbers, Func<int, int> func)
        {
            var result = new List<int>();
            foreach (var number in numbers)
            {
                result.Add(func(number));
            }

            return result;
        }
    }
}