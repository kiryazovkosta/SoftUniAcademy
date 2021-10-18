namespace StreetRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
            this.Participants = new List<Car>();
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public List<Car> Participants;

        public int Count => this.Participants.Count;

        public void Add(Car car)
        {
            if (this.Participants.All(c => c.LicensePlate != car.LicensePlate) 
                &&  this.Count + 1 <= this.Capacity 
                && this.MaxHorsePower >= car.HorsePower)
            {
                this.Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            bool success = false;
            Car car = this.Participants.FirstOrDefault(c => c.LicensePlate == licensePlate);
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
            return this.Participants.OrderByDescending(c => c.HorsePower).FirstOrDefault();
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
