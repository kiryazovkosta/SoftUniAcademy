namespace TheVLogger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class VLogger
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string input = Console.ReadLine();
            while (input != "Statistics")
            {
                string[] data = input.Split(" ");
                string vlogger = data[0];
                string command = data[1];
                string member = data[2];
                if (command == "joined")
                {
                    if (!vloggers.ContainsKey(vlogger))
                    {
                        vloggers.Add(vlogger, new Dictionary<string, HashSet<string>>());
                        vloggers[vlogger].Add("followers", new HashSet<string>());
                        vloggers[vlogger].Add("followings", new HashSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    if (vloggers.ContainsKey(vlogger) && vloggers.ContainsKey(member) && vlogger != member)
                    {
                        vloggers[vlogger]["followings"].Add(member);
                        vloggers[member]["followers"].Add(vlogger);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            int rowCounter = 1;
            foreach (var vlogger in vloggers.OrderByDescending(v => v.Value["followers"].Count).ThenBy(v => v.Value["followings"].Count))
            {
                Console.WriteLine($"{rowCounter}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["followings"].Count} following");
                if (rowCounter == 1)
                {
                    foreach (var member in vlogger.Value["followers"].OrderBy(f => f))
                    {
                        Console.WriteLine($"*  {member}");
                    }
                }
                
                rowCounter++;
            }
        }
    }
}