namespace ListManipulationBasics
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
            while (input != "end")
            {
                string[] command = input?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? new string[] { };
                if (command.Length < 2 || command.Length > 3)
                {
                    throw new InvalidOperationException(nameof(command));
                }
                switch (command[0])
                {
                    case "Add":
                        int element = int.Parse(command[1] ?? throw new ArgumentException(nameof(element)));
                        Add(numbers, element);
                        break;
                    case "Remove":
                        element = int.Parse(command[1] ?? throw new ArgumentException(nameof(element)));
                        Remove(numbers, element);
                        break;
                    case "RemoveAt":
                        int index = int.Parse(command[1] ?? throw new ArgumentException(nameof(index)));
                        RemoveAt(numbers, index);
                        break;
                    case "Insert":
                        element = int.Parse(command[1] ?? throw new ArgumentException(nameof(element)));
                        index = int.Parse(command[2] ?? throw new ArgumentException(nameof(index)));
                        Insert(numbers, element, index);
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
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