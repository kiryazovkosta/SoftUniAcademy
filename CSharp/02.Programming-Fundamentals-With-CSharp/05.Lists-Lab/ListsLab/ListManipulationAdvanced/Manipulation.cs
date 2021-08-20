namespace ListManipulationAdvanced
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class Manipulation
    {
        private static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                              ?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToList()
                          ?? new List<int>();

            string input = Console.ReadLine() ?? throw new ArgumentException(nameof(input));
            bool isChanged = false;
            while (input != "end")
            {
                string[] command = input?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? new string[] { };
                if (command.Length < 1 || command.Length > 3)
                {
                    throw new InvalidOperationException(nameof(command));
                }

                switch (command[0])
                {
                    case "Add":
                        int element = int.Parse(command[1] ?? throw new ArgumentException(nameof(element)));
                        Add(numbers, element);
                        isChanged = true;
                        break;
                    case "Remove":
                        element = int.Parse(command[1] ?? throw new ArgumentException(nameof(element)));
                        Remove(numbers, element);
                        isChanged = true;
                        break;
                    case "RemoveAt":
                        int index = int.Parse(command[1] ?? throw new ArgumentException(nameof(index)));
                        RemoveAt(numbers, index);
                        isChanged = true;
                        break;
                    case "Insert":
                        element = int.Parse(command[1] ?? throw new ArgumentException(nameof(element)));
                        index = int.Parse(command[2] ?? throw new ArgumentException(nameof(index)));
                        Insert(numbers, element, index);
                        isChanged = true;
                        break;
                    case "Contains":
                        element = int.Parse(command[1] ?? throw new ArgumentException(nameof(element)));
                        Console.WriteLine(Contains(numbers, element) ? "Yes" : "No such number") ;
                        break;
                    case "PrintEven":
                        List<int> evens = GetEvensNumbers(numbers);
                        PrintList(evens);
                        break;
                    case "PrintOdd":
                        List<int> odds = GetOddsNumbers(numbers);
                        PrintList(odds);
                        break;
                    case "GetSum":
                        long sum = GetSum(numbers);
                        Console.WriteLine(sum);
                        break;
                    case "Filter":
                        string condition = command[1];
                        int number = int.Parse(command[2] ?? throw new ArgumentException(nameof(number)));
                        List<int> filtered = Filter(numbers, condition, number);
                        PrintList(filtered);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            if (isChanged)
            {
                PrintList(numbers);
            }
        }

        private static void PrintList(List<int> evens)
        {
            Console.WriteLine(string.Join(" ", evens));
        }

        private static List<int> Filter(List<int> numbers, string condition, int number)
        {
            List<int> result = new List<int>();
            switch (condition)
            {
                case "<":
                    result = GetSmaller(numbers, number);
                    break;

                case "<=":
                    result = GetSmallerOrEqual(numbers, number);
                    break;

                case ">":
                    result = GetBigger(numbers, number);
                    break;

                case ">=":
                    result = GetBiggerOrEqual(numbers, number);
                    break;

                default:
                    break;
            }

            return result;
        }

        private static List<int> GetBiggerOrEqual(IEnumerable<int> numbers, int number)
        {
            return numbers.Where(n => n >= number).ToList();
        }

        private static List<int> GetBigger(IEnumerable<int> numbers, int number)
        {
            return numbers.Where(n => n > number).ToList();
        }

        private static List<int> GetSmallerOrEqual(IEnumerable<int> numbers, int number)
        {
            return numbers.Where(n => n <= number).ToList();
        }

        private static List<int> GetSmaller(IEnumerable<int> numbers, int number)
        {
            return numbers.Where(n => n < number).ToList();
        }

        private static long GetSum(IEnumerable<int> numbers)
        {
            return numbers.Sum();
        }

        private static List<int> GetOddsNumbers(IEnumerable<int> numbers)
        {
            return numbers.Where(n => n % 2 != 0).ToList();
        }

        private static List<int> GetEvensNumbers(IEnumerable<int> numbers)
        {
            return numbers.Where(n => n % 2 == 0).ToList();
        }

        private static bool Contains(ICollection<int> numbers, int element)
        {
            return numbers.Contains(element);
        }

        private static void Insert(List<int> numbers, int element, int index)
        {
            numbers.Insert(index, element);
        }

        private static void RemoveAt(List<int> numbers, int index)
        {
            numbers.RemoveAt(index);
        }

        private static void Remove(List<int> numbers, int element)
        {
            numbers.Remove(element);
        }

        private static void Add(List<int> numbers, int element)
        {
            numbers.Add(element);
        }
    }
}
