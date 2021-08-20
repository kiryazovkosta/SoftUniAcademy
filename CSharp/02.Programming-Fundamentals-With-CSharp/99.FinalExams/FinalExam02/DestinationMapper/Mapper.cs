namespace DestinationMapper
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Mapper
    {
        static void Main(string[] args)
        {
            string pattern = @"(=|\/{1})(?<city>[A-Z][A-Za-z]{2,})\1";
            string input = Console.ReadLine();

            MatchCollection places = Regex.Matches(input, pattern);
            List<string> destinations = new List<string>();
            foreach (Match place in places)
            {
                destinations.Add(place.Groups["city"].Value);
            }

            Console.Write($"Destinations:");
            if (destinations.Count > 0)
            {
                Console.WriteLine($" {string.Join(", ", destinations)}");
            }
            else
            {
                Console.WriteLine();
            }

            int points = 0;
            foreach (var destination in destinations)
            {
                points += destination.Length;
            }

            Console.WriteLine($"Travel Points: {points}");
        }
    }
}