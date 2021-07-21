namespace MOBAChallenger
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    internal class Challenger
    {
        private static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> playersPool = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "Season end")
            {
                if (input.Contains("->"))
                {
                    string[] data = input.Split("->", StringSplitOptions.RemoveEmptyEntries);
                    string player = data[0].Trim();
                    string position = data[1].Trim();
                    int skill = int.Parse(data[2].Trim());

                    if (playersPool.ContainsKey(player) == false)
                    {
                        playersPool.Add(player, new Dictionary<string, int>());
                    }

                    if (playersPool[player].ContainsKey(position) == false)
                    {
                        playersPool[player].Add(position, skill);
                    }
                    else
                    {
                        if (playersPool[player][position] < skill)
                        {
                            playersPool[player][position] = skill;
                        }
                    }

                }
                else
                {
                    string[] players = input.Split(" vs ", StringSplitOptions.RemoveEmptyEntries);
                    string playerOne = players[0].Trim();
                    string playerTwo = players[1].Trim();

                    bool playerOneExists = playersPool.ContainsKey(playerOne);
                    bool playerTwoExists = playersPool.ContainsKey(playerTwo);

                    if (playerOneExists && playerTwoExists)
                    {
                        var playerOnePositions = playersPool[playerOne];
                        var playerTwoPositions = playersPool[playerTwo];

                        var playerOneSkills = playerOnePositions.Values.Sum();
                        var playerTwoSkills = playerTwoPositions.Values.Sum();

                        bool haveCommonSkills = playerOnePositions.Keys.ToList().Any(x => playerTwoPositions.Keys.ToList().Any(y => y == x));
                        if (haveCommonSkills)
                        {
                            if (playerOneSkills > playerTwoSkills)
                            {
                                playersPool.Remove(playerTwo);
                            }
                            else if (playerOneSkills < playerTwoSkills)
                            {
                                playersPool.Remove(playerOne);
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var player in playersPool.OrderByDescending(p => p.Value.Values.Sum()).ThenBy(p => p.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");
                foreach (var skill in player.Value.OrderByDescending(s => s.Value).ThenBy(s => s.Key))
                {
                    Console.WriteLine($"- {skill.Key} <::> {skill.Value}");
                }

            }
        }
    }
}