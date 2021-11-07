namespace Vehicles
{
    using System;
    public class Car : Vehicle
    {
        private const double ExtraFuelPerKm = 0.9;

        public Car(double quantity, double litersPerKm) 
            : base(quantity, litersPerKm + ExtraFuelPerKm)
        {
        }
    }
}
