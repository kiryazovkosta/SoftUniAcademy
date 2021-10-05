using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = int.MinValue;
            this.Efficiency = "n/a";
        }

        public string Model
        {
            get => this.model;
            private set => this.model = value;
        }

        public int Power
        {
            get => this.power;
            private set => this.power = value;
        }

        public int Displacement
        {
            get => this.displacement;
            set => this.displacement = value;
        }

        public string Efficiency
        {
            get => this.efficiency;
            set => this.efficiency = value;
        }

        public override string ToString()
        {
            return $"{this.Model}:\n"
                   + $"    Power: {this.Power}\n"
                   + $"    Displacement: {this.GetDisplacementAsString()}\n"
                   + $"    Efficiency: {this.GetEfficiencyAsString()}";
        }

        private string GetDisplacementAsString()
        {
            return this.Displacement >= 0 ? this.Displacement.ToString() : "n/a";
        }

        private string GetEfficiencyAsString()
        {
            return string.IsNullOrWhiteSpace(this.Efficiency) ? "n/a" : this.Efficiency;
        }
    }
}