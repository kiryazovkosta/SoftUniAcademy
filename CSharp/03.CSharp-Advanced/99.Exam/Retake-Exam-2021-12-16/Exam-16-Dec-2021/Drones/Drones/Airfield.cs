using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones;

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.drones = new List<Drone>();
        }

        public IReadOnlyCollection<Drone> Drones =>  this.drones.AsReadOnly();
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public int Count => this.drones.Count;

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand))
            {
                return "Invalid drone.";
            }

            if (drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }

            if (this.drones.Count == this.Capacity)
            {
                return "Airfield is full.";
            }

            this.drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            return this.drones.Remove(this.drones.FirstOrDefault(d => d.Name == name));
        }

        public int RemoveDroneByBrand(string brand)
        {
            return this.drones.RemoveAll(d => d.Brand == brand);
        }

        public Drone FlyDrone(string name)
        {
            Drone drone = this.Drones.FirstOrDefault(d => d.Name == name);
            if (drone != null)
            {
                drone.Available = false;
            }

            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            foreach (var drone in this.Drones.Where(d => d.Range >= range).ToList())
            {
                drone.Available = false;
            }

            return this.Drones.Where(d => d.Range >= range && d.Available == false).ToList();
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Drones available at { this.Name}:");
            foreach (var drone in this.Drones.Where(d => d.Available == true))
            {
                output.AppendLine(drone.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
