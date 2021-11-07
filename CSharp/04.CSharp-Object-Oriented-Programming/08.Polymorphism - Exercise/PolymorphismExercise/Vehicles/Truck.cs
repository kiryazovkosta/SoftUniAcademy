namespace Vehicles
{
    using System;
    public class Truck : Vehicle
    {
        private const double ExtraFuelPerKm = 1.6;

        public Truck(double quantity, double litersPerKm) 
            : base(quantity, litersPerKm + ExtraFuelPerKm)
        {
        }

        public override void Refuel(double liters)
        {
            double realLiters = liters * 0.95;
            this.Quantity += realLiters;
        }
    }
}
