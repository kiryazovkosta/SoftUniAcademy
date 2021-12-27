using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private ICollection<Racer> data;

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Racer racer)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            return this.data.Remove(this.data.FirstOrDefault(r => r.Name == name));
        }

        public Racer GetOldestRacer()
        {
            return this.data.OrderByDescending(r => r.Age).FirstOrDefault();
        }

        public Racer GetRacer(string name)
        {
            return this.data.FirstOrDefault(r => r.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return this.data.OrderByDescending(r => r.Car.Speed).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {this.Name}:");
            foreach (Racer racer in this.data)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
