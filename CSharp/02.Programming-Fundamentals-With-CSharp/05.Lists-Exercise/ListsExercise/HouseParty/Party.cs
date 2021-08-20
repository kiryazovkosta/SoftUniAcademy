namespace HouseParty
{
    #region Using

    using System;
    using System.Collections.Generic;

    #endregion

    public class Party
    {
        private static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(count)));

            List<string> guests = new List<string>();
            for (int i = 0; i < count; i++)
            {
                string[] command = Console.ReadLine()?.Split(" ", 2, StringSplitOptions.RemoveEmptyEntries);
                string name = command[0];
                string operation = command[1];

                if (operation == "is going!")
                {
                    if (guests.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guests.Add(name);
                    }
                }
                else if (operation == "is not going!")
                {
                    if (guests.Contains(name))
                    {
                        guests.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }

            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}