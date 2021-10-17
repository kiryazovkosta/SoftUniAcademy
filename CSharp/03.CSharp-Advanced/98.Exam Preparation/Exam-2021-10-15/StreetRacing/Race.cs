using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            this.Participants = new List<Car>();
        }

        public List<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public int Count => this.Participants.Count;

        public void Add(Car car)
        {
            if (!this.Participants.Any(c => c.LicensePlate == car.LicensePlate) 
                && this.Count + 1 <= this.Capacity 
                && this.MaxHorsePower >= car.HorsePower)
            {
                this.Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            bool success = false;
            var car = this.Participants.FirstOrDefault(c => c.LicensePlate == licensePlate);
            if (car != null)
            {
                success = this.Participants.Remove(car);
            }

            return success;
        }

        public Car FindParticipant(string licensePlate)
        {
            Car car = this.Participants.FirstOrDefault(c => c.LicensePlate == licensePlate);
            return car;
        }

        public Car GetMostPowerfulCar()
        {
            Car car = this.Participants.OrderByDescending(x => x.HorsePower).FirstOrDefault();
            return car;
        }

        public string Report()
        {
            StringBuilder race = new StringBuilder();
            race.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");
            foreach (var car in this.Participants)
            {
                race.AppendLine(car.ToString());
            }

            return race.ToString();
        }
    }
}
