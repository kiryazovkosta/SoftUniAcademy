namespace ForceBook
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    internal class Book
    {
        private static void Main(string[] args)
        {
            Dictionary<string, List<string>> sides = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();
            while (input != "Lumpawaroo")
            {
                if (input.Contains('|'))
                {
                    string[] data = input.Split("|", StringSplitOptions.RemoveEmptyEntries);
                    string forceSide = data[0].Trim();
                    string forceUser = data[1].Trim();
                    if (sides.ContainsKey(forceSide) == false)
                    {
                        sides.Add(forceSide, new List<string>());
                    }

                    bool exists = sides.Values.Any(u => u.Contains(forceUser));
                    if (exists == false)
                    {
                        sides[forceSide].Add(forceUser);
                    }
                }
                else if (input.Contains("->"))
                {
                    string[] data = input.Split("->", StringSplitOptions.RemoveEmptyEntries);
                    string forceSide = data[1].Trim();
                    string forceUser = data[0].Trim();
                    if (sides.ContainsKey(forceSide) == false)
                    {
                        sides.Add(forceSide, new List<string>());
                    }

                    if (sides[forceSide].Contains(forceUser) == false)
                    {
                        sides[forceSide].Add(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }

                    foreach (var side in sides.Where(s => s.Key != forceSide && s.Value.Contains(forceUser)))
                    {
                        sides[side.Key].Remove(forceUser);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var side in sides.Where(s => s.Value.Count > 0).OrderByDescending(s => s.Value.Count).ThenBy(s => s.Key))
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                foreach (var user in side.Value.OrderBy(u => u))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}