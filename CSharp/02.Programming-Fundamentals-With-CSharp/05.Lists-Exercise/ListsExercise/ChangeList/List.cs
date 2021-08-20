namespace ChangeList
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
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string operation = command[0];
                int element = int.Parse(command[1] ?? throw new ArgumentException(nameof(element)));
                if (operation == "Delete")
                {
                    numbers.RemoveAll( n => n == element);
                }
                else if (operation == "Insert")
                {
                    int position = int.Parse(command[2] ?? throw new ArgumentException(nameof(position)));
                    numbers.Insert(position, element);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}