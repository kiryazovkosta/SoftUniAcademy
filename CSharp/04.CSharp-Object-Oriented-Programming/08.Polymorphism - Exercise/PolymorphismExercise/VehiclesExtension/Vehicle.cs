using System;

namespace VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {

            this.tankCapacity = tankCapacity;

            if (fuelQuantity <= this.TankCapacity)
            {
                this.FuelQuantity = fuelQuantity;
            }
            else
            {
                this.FuelQuantity = 0;
            }

            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        { 
            get => this.fuelQuantity; 
            protected set => this.fuelQuantity = value; 
        }

        private double FuelConsumption
        { 
            get => this.fuelConsumption; 
            set => this.fuelConsumption = value; 
        }

        private double TankCapacity
        {
            get => this.tankCapacity;
            set => this.tankCapacity = value;
        }

        protected abstract double AdditionalConsumption { get; }

        public virtual string Drive(double distance)
        {
            double distanceQuantity = distance * (this.FuelConsumption + this.AdditionalConsumption);
            if (this.FuelQuantity >= distanceQuantity)
            {
                this.FuelQuantity -= distanceQuantity;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (fuel + this.FuelQuantity > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
