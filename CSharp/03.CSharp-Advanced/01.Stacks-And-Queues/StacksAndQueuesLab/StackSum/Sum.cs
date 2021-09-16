namespace StackSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Sum
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine() ?? string.Empty;
            Stack<int> numbers = new Stack<int>();
            int[] records = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            foreach (var record in records)
            {
                numbers.Push(record);
            }

            input = Console.ReadLine().ToLower();
            while (input != "end")
            {
                string[] operation = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = operation[0];
                if (command == "add")
                {
                    int first = int.Parse(operation[1]);
                    int second = int.Parse(operation[2]);
                    numbers.Push(first);
                    numbers.Push(second);
                } 
                else if (command == "remove")
                {
                    int count = int.Parse(operation[1]);
                    if (count <= numbers.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }

                input = Console.ReadLine().ToLower();
            }

            long sum = 0;
            while (numbers.Count > 0)
            {
                sum += numbers.Pop();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}