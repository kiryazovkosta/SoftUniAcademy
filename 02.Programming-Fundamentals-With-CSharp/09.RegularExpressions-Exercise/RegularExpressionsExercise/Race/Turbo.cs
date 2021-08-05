namespace Race
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    #endregion

    internal class Turbo
    {
        private static void Main(string[] args)
        {
            var participants = new Dictionary<string, int>();

            string lettersPattern = @"[A-Za-z]";
            string digitsPattern = @"[0-9]";

            var racers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var racer in racers)
            {
                participants.Add(racer, 0);
            }

            string input = Console.ReadLine();
            while (input != "end of race")
            {

                string name = string.Join(string.Empty, Regex.Matches(input, lettersPattern).Cast<Match>().Select(l => l.Value));
                if (!participants.ContainsKey(name))
                {
                    input = Console.ReadLine();
                    continue;
                }

                int distance = Regex.Matches(input, digitsPattern).Cast<Match>().Select(l => l.Value).Select(int.Parse).Sum();
                participants[name] += distance;

                input = Console.ReadLine();
            }

            var top = participants.OrderByDescending(p => p.Value).Take(3).Select(y => y.Key).ToArray();
            Console.WriteLine($"1st place: {top[0]}");
            Console.WriteLine($"2nd place: {top[1]}");
            Console.WriteLine($"3rd place: {top[2]}");
        }
    }
}