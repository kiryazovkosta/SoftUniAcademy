// ------------------------------------------------------------------------------------------------
//  <copyright file="JudgeSystem.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace Judge
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    internal class JudgeSystem
    {
        private static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contests = new Dictionary<string, Dictionary<string, int>>();
            SortedDictionary<string, Dictionary<string, int>> users = new SortedDictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "no more time")
            {
                string[] data = input?.Split(" -> ", StringSplitOptions.RemoveEmptyEntries) ?? new string[]{ };
                string username = data[0];
                string contest = data[1];
                int points = int.Parse(data[2]);

                // Contests
                GetContestData(contests, contest, username, points);

                // Users
                GetUserData(users, username, contest, points);

                input = Console.ReadLine();
            }

            foreach (var contest in contests)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
                int counter = 0;
                foreach (var user in contest.Value.OrderByDescending(u => u.Value).ThenBy(u => u.Key))
                {
                    counter++;
                    Console.WriteLine($"{counter}. {user.Key} <::> {user.Value}");
                }
            }

            PrintUsers(users);
        }

        private static void PrintUsers(SortedDictionary<string, Dictionary<string, int>> users)
        {
            Console.WriteLine("Individual standings: ");
            int counter = 0;
            foreach (var user in users.OrderByDescending(u => u.Value.Values.Sum()).ThenBy(u => u.Key))
            {
                counter++;
                Console.WriteLine($"{counter}. {user.Key} -> {user.Value.Values.Sum()}");
            }
        }

        private static void GetContestData(Dictionary<string, Dictionary<string, int>> contests, string contest, string username, int points)
        {
            if (contests.ContainsKey(contest) == false)
            {
                contests.Add(contest, new Dictionary<string, int>());
            }

            if (contests[contest].ContainsKey(username) == false)
            {
                contests[contest].Add(username, points);
            }
            else
            {
                if (contests[contest][username] < points)
                {
                    contests[contest][username] = points;
                }
            }
        }

        private static void GetUserData(SortedDictionary<string, Dictionary<string, int>> users, string username, string contest, int points)
        {
            if (users.ContainsKey(username) == false)
            {
                users.Add(username, new Dictionary<string, int>());
            }

            if (users[username].ContainsKey(contest) == false)
            {
                users[username].Add(contest, points);
            }
            else
            {
                if (users[username][contest] < points)
                {
                    users[username][contest] = points;
                }
            }
        }
    }
}