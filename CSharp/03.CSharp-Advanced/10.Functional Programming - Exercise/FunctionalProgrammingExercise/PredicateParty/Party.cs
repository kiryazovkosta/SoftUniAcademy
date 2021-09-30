namespace PredicateParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Party
    {
        public static void Main(string[] args)
        {
            var guests = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList() ?? new List<string>();

            string input = Console.ReadLine();
            while (input != "Party!")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                string criteria = data[1];
                string value = data[2];

                switch (command)
                {
                    case "Remove":
                        if (criteria == "StartsWith")
                        {
                            guests.RemoveAll(s => s.StartsWith(value));
                        }
                        else if (criteria == "EndsWith")
                        {
                            guests.RemoveAll(s => s.EndsWith(value));
                        }
                        else if (criteria == "Length")
                        {
                            guests.RemoveAll(s => s.Length == int.Parse(value));
                        }

                        break;

                    case "Double":
                        if (criteria == "StartsWith")
                        {
                            guests = ForEach(guests, s => s.StartsWith(value));
                        }
                        else if (criteria == "EndsWith")
                        {
                            guests = ForEach(guests, s => s.EndsWith(value));
                        }
                        else if (criteria == "Length")
                        {
                            guests = ForEach(guests, s => s.Length == int.Parse(value));
                        }
                        break;

                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(guests.Any()
                ? $"{string.Join(", ", guests)} are going to the party!"
                : $"Nobody is going to the party!");
        }

        private static List<string> ForEach(IEnumerable<string> guests, Func<string, bool> func)
        {
            var result = new List<string>();
            foreach (var guest in guests)
            {
                result.Add(guest);
                if (func(guest))
                {
                    result.Add(guest);
                }
            }

            return result;
        }
    }
}
