using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;

        private ICollection<IEquipment> equipments;
        private ICollection<IAthlete> athletes;

        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.equipments = new List<IEquipment>();
            this.athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight => this.equipments.Sum(e => e.Weight);

        public ICollection<IEquipment> Equipment => this.equipments;

        public ICollection<IAthlete> Athletes => this.athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Athletes.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            this.athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipments.Add(equipment);
        }

        public void Exercise()
        {
            foreach (IAthlete athlete in this.athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            string athletesList = this.athletes.Any() ? string.Join(", ", this.Athletes.Select(a => a.FullName)) : "No athletes";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            sb.AppendLine($"Athletes: {athletesList}");
            sb.AppendLine($"Equipment total count: {this.Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {this.EquipmentWeight:F2} grams");
            return sb.ToString().TrimEnd();
        }
    }
}
