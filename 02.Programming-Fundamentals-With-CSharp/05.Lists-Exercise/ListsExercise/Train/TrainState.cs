namespace Train
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TrainState
    {
        private static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                ?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList()
                ??
                new List<int>();
            int capacity = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(capacity)));

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] command = input?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? new string[]{ };
                if (command[0] == "Add")
                {
                    int passengers = int.Parse(command[1] ?? throw new ArgumentException(nameof(passengers)));
                    wagons.Add(passengers);
                }
                else
                {
                    int passengers = int.Parse(command[0] ?? throw new ArgumentException(nameof(passengers)));
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + passengers <= capacity)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}