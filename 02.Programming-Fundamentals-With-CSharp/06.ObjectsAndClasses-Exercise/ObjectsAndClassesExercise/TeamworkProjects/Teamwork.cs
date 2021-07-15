namespace TeamworkProjects
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Team
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }

        public Team()
        {
            this.Members = new List<string>();
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(this.Name);
            output.AppendLine($"- {this.Creator}");
            foreach (var member in this.Members)
            {
                output.AppendLine($"-- {member}");
            }

            return output.ToString();
        }
    }

    #endregion

    internal class Teamwork
    {
        public static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var teams = new List<Team>();

            for (var i = 0; i < count; i++)
            {
                var teamData = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);
                string userName = teamData[0];
                string teamName = teamData[1];
                if (TeamExists(teams, teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (CreatorExists(teams, userName))
                {
                    Console.WriteLine($"{userName} cannot create another team!");
                }

                teams.Add(new Team() {Name = teamName, Creator = userName});
                Console.WriteLine($"Team {teamName} has been created by {userName}!");
            }

            string input = Console.ReadLine();
            while (input != "end of assignment")
            {
                string[] memberData = input.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string userName = memberData[0];
                string teamName = memberData[1];
                if (!TeamExists(teams, teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    input = Console.ReadLine();
                    continue;
                }

                if (IsMember(teams, userName) || CreatorExists(teams, userName))
                {
                    Console.WriteLine($"Member {userName} cannot join team {teamName}!");
                    input = Console.ReadLine();
                    continue;
                }

                int teamIndex = IndexOf(teams, teamName);
                teams[teamIndex].Members.Add(userName);

                input = Console.ReadLine();
            }

            var disbandTeams = teams.Where(t => t.Members.Count == 0).OrderBy(t => t.Name).ToList();
            var validTeams = teams.Where(t => t.Members.Count > 0).OrderByDescending(t => t.Members.Count).ThenBy(t => t.Name).ToList();

            foreach (var team in validTeams)
            {
                Console.Write(team);
            }

            Console.WriteLine("Teams to disband:");
            foreach (var team in disbandTeams)
            {
                Console.WriteLine(team.Name);
            }
        }

        private static bool TeamExists(List<Team> teams, string name)
        {
            return teams.Any(t => t.Name == name);
        }

        private static bool CreatorExists(List<Team> teams, string name)
        {
            return teams.Any(t => t.Creator == name);
        }

        private static bool IsMember(List<Team> teams, string name)
        {
            return teams.Any(t => t.Members.Contains(name));
        }

        private static int IndexOf(List<Team> teams, string name)
        {
            int index = -1;
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Name == name)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}