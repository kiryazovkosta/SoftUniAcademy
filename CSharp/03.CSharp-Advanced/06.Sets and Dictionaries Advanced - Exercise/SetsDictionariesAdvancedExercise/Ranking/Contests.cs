namespace Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Contests
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] contest = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string name = contest[0];
                string pass = contest[1];
                contests.Add(name, pass);
                input = Console.ReadLine();
            }

            var users = new Dictionary<string, Dictionary<string, int>>();

            input = Console.ReadLine();
            while (input != "end of submissions")
            {
                string[] submission = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = submission[0];
                string password = submission[1];
                string username = submission[2];
                int points = int.Parse(submission[3]);
                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new Dictionary<string, int>());
                    }

                    if (!users[username].ContainsKey(contest))
                    {
                        users[username].Add(contest, 0);
                    }

                    if (points > users[username][contest])
                    {
                        users[username][contest] = points;
                    }
                }

                input = Console.ReadLine(); 
            }


            var maxPointsUser = users.OrderByDescending(u => u.Value.Values.Sum()).First();
            Console.WriteLine($"Best candidate is {maxPointsUser.Key} with total {maxPointsUser.Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");
            foreach (var user in users.OrderBy(u => u.Key))
            {
                Console.WriteLine(user.Key);
                foreach (var contest in user.Value.OrderByDescending(c => c.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
