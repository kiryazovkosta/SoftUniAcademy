using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }

        public string Model
        {
            get => this.model;
            set => this.model = value;
        }

        public double FuelAmount
        {
            get => this.fuelAmount;
            set => this.fuelAmount = value;
        }

        public double FuelConsumptionPerKilometer
        {
            get => this.fuelConsumptionPerKilometer;
            set => this.fuelConsumptionPerKilometer = value;
        }

        public double TravelledDistance
        {
            get => this.travelledDistance;
            set => this.travelledDistance = value;
        }

        public int Drive(int killometers)
        {
            int distance = -1;
            double consumption = killometers * this.FuelConsumptionPerKilometer;
            if (this.FuelAmount >= (killometers * this.FuelConsumptionPerKilometer))
            {
                distance = killometers;
                this.FuelAmount -= consumption;
                this.TravelledDistance += killometers;
            }

            return distance;
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:F2} {this.TravelledDistance}";
        }
    }
}
