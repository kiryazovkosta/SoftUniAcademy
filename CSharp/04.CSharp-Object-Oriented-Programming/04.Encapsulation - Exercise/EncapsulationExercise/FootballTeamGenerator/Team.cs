using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        //public IReadOnlyCollection<Player> Players => this.players.AsReadOnly();

        public int Rating
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }

                int totalScores = this.players.Sum(p => p.Stats);
                double count = this.players.Count * 5.0;
                return (int)Math.Round(totalScores / count);
            }
        }
       

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public bool RemovePlayer(string playerName)
        {
            return this.players.Remove(this.players.FirstOrDefault(p => p.Name == playerName));
        }
    }
}
