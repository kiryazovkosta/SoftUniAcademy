namespace VehiclesExtension
{
    using System;
    public class Car : Vehicle
    {
        private const double defaultAdditionalConsumption = 0.9;

        public Car(double quantity, double consumption, double tankCapacity) 
            : base(quantity, consumption, tankCapacity)
        {
        }

        protected override double AdditionalConsumption => defaultAdditionalConsumption;
    }
}
