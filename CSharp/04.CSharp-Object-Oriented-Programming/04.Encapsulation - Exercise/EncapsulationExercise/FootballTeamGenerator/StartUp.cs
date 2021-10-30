using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] data = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                string teamName = data[1];
                try
                {
                    TryToAddTeam(teams, command, teamName);
                    TryToAddPlayer(teams, data, command, teamName);
                    TryToRemovePlayer(teams, data, command, teamName);
                    TryToPrintRating(teams, command, teamName);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message); ;
                }

                input = Console.ReadLine();
            }
        }

        private static void TryToPrintRating(List<Team> teams, string command, string teamName)
        {
            if (command == "Rating")
            {
                Team team = teams.FirstOrDefault(t => t.Name == teamName);
                if (team != null)
                {
                    Console.WriteLine($"{team.Name} - {team.Rating}");
                }
                else
                {
                    Console.WriteLine($"Team {teamName} does not exist.");
                }
            }
        }

        private static void TryToAddTeam(List<Team> teams, string command, string teamName)
        {
            if (command == "Team")
            {
                if (teams.All(t => t.Name != teamName))
                {
                    teams.Add(new Team(teamName));
                }
            }
        }

        private static void TryToRemovePlayer(List<Team> teams, string[] data, string command, string teamName)
        {
            if (command == "Remove")
            {
                Team team = teams.FirstOrDefault(t => t.Name == teamName);
                if (team != null)
                {
                    bool isRemoved = team.RemovePlayer(data[2]);
                    if (isRemoved == false)
                    {
                        Console.WriteLine($"Player {data[2]} is not in {teamName} team.");
                    }
                }
                else
                {
                    Console.WriteLine("Team [team name] does not exist.");
                }
            }
        }

        private static void TryToAddPlayer(List<Team> teams, string[] data, string command, string teamName)
        {
            if (command == "Add")
            {
                Team team = teams.FirstOrDefault(t => t.Name == teamName);
                if (team != null)
                {
                    Player player = new Player(
                        data[2],
                        int.Parse(data[3]),
                        int.Parse(data[4]),
                        int.Parse(data[5]),
                        int.Parse(data[6]),
                        int.Parse(data[7]));
                    team.AddPlayer(player);
                }
                else
                {
                    Console.WriteLine($"Team {teamName} does not exist.");
                }
            }
        }
    }
}
