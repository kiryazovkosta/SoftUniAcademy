namespace Ranking
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    internal class FinalRanking
    {
        private static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] data = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = data[0];
                string password = data[1];
                contests.Add(contest, password);
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "end of submissions")
            {
                string[] data = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = data[0];
                string password = data[1];
                string username = data[2];
                int points = int.Parse(data[3]);

                if (!contests.ContainsKey(contest) || contests[contest] != password)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (users.ContainsKey(username) == false)
                {
                    users.Add(username, new Dictionary<string, int>());
                }

                if (users[username].ContainsKey(contest) == false)
                {
                    users[username].Add(contest, points);
                }
                else if (users[username][contest] < points )
                {
                    users[username][contest] = points;
                }

                input = Console.ReadLine();
            }

            int totalPoints = int.MinValue;
            string maxUserName = string.Empty;
            foreach (var user in users)
            {
                int currentPoints = user.Value.Values.Sum();
                if (currentPoints <= totalPoints) continue;
                totalPoints = currentPoints;
                maxUserName = user.Key;
            }
            Console.WriteLine($"Best candidate is {maxUserName} with total {totalPoints} points.");
            Console.WriteLine("Ranking: ");
            foreach (var user in users.OrderBy(u => u.Key))
            {
                Console.WriteLine(user.Key);
                foreach (var course in user.Value.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"#  {course.Key} -> {course.Value}");
                }
            }
        }
    }
}