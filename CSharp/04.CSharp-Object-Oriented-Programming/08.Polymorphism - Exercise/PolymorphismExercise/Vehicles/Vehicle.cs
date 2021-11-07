namespace Vehicles
{
    public class Vehicle
    {
        private double quantity;
        private double litersPerKm;

        protected Vehicle(double quantity, double litersPerKm)
        {
            Quantity = quantity;
            LitersPerKm = litersPerKm;
        }

        public double Quantity 
        { 
            get => this.quantity; 
            protected set => this.quantity = value; 
        }

        public double LitersPerKm 
        { 
            get => this.litersPerKm; 
            protected set => this.litersPerKm = value; 
        }

        public string Drive(double distance)
        {
            if (this.Quantity >= distance * this.LitersPerKm)
            {
                this.Quantity -= (distance * this.LitersPerKm);
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public virtual void Refuel(double liters)
        {
            this.Quantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Quantity:F2}";
        }
    }
}
