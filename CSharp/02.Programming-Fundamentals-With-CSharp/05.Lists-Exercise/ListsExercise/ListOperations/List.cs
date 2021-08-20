namespace ListOperations
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class List
    {
        private static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                    ?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList()
                                ??
                                new List<int>();
            string input = Console.ReadLine() ?? string.Empty;
            while (input != "End")
            {
                string[] command = input?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? new string[]{ };
                string operation = command[0] ?? string.Empty;
                if (operation == "Add")
                {
                    int number = int.Parse(command[1] ?? throw new ArgumentException(nameof(number)));
                    numbers.Add(number);
                }
                else if (operation == "Insert")
                {
                    int number = int.Parse(command[1] ?? throw new ArgumentException(nameof(number)));
                    int index = int.Parse(command[2] ?? throw new ArgumentException(nameof(index)));
                    if (index < 0 || index > numbers.Count - 1)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(index, number);
                    }
                }
                else if (operation == "Remove")
                {
                    int index = int.Parse(command[1] ?? throw new ArgumentException(nameof(index)));
                    if (index < 0 || index > numbers.Count - 1)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(index);
                    }
                }
                else if (operation == "Shift")
                {
                    string direction = command[1];
                    int count = int.Parse(command[2] ?? throw new ArgumentException(nameof(count)));
                    if (direction == "left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int first = numbers.First();
                            for (int j = 0; j < numbers.Count - 1; j++)
                            {
                                numbers[j] = numbers[j + 1];
                            }

                            numbers[^1] = first;
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int last = numbers.Last();
                            for (int j = numbers.Count - 1; j > 0; j--)
                            {
                                numbers[j] = numbers[j - 1];
                            }

                            numbers[0] = last;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}