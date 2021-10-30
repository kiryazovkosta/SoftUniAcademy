using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name 
        { 
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        public int Endurance 
        { 
            get => endurance;
            private set
            {
                this.ValidateStat(value, nameof(this.Endurance));
                endurance = value;
            }
        }

        public int Sprint 
        { 
            get => sprint;
            private set
            {
                this.ValidateStat(value, nameof(this.Sprint));
                this.sprint = value;
            }
        }
        public int Dribble 
        { 
            get => dribble;
            private set
            {
                this.ValidateStat(value, nameof(this.Dribble));
                this.dribble = value;
            }
        }
        public int Passing 
        { 
            get => passing;
            private set
            {
                this.ValidateStat(value, nameof(this.Passing));
                this.passing = value;
            }
        }
        public int Shooting 
        { 
            get => shooting;
            private set
            {
                this.ValidateStat(value, nameof(this.Shooting));
                this.shooting = value;
            }
        }

        public int Stats => this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting;

        private void ValidateStat(int value, string param)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{param} should be between 0 and 100.");
            }
        }

    }
}
