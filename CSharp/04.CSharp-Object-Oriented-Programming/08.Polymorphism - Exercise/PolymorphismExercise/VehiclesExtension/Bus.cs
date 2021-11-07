namespace VehiclesExtension
{
    using System;
    public class Bus : Vehicle
    {
        private const double TurnOnAirConditionerAdditionalConsumption = 1.4;
        private const double TurnOffAirConditionerAdditionalConsumption = 0;

        private bool isAirConditionerOn;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            isAirConditionerOn = true;
        }

        protected override double AdditionalConsumption => 
            isAirConditionerOn == true ? 
                TurnOnAirConditionerAdditionalConsumption : TurnOffAirConditionerAdditionalConsumption;

        public void TurnOffAirConditioner()
        {
            this.isAirConditionerOn = false;
        }

        public void TurnOnAirConditioner()
        {
            this.isAirConditionerOn = true;
        }
    }
}
