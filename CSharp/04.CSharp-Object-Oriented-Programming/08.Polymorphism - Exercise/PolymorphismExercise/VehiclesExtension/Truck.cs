namespace VehiclesExtension
{
    using System;
    public class Truck : Vehicle
    {
        private const double DefaultAdditionalConsumption = 1.6;
        private const double TankRefuelingCoefficients = 0.05;

        public Truck(double quantity, double consumption, double tankCapacity)
            : base(quantity, consumption, tankCapacity)
        {
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters);
            this.FuelQuantity -= (liters * TankRefuelingCoefficients);
        }

        protected override double AdditionalConsumption => DefaultAdditionalConsumption;
    }
}
