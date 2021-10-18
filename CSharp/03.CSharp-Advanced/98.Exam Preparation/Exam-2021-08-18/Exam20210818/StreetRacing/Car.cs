namespace StreetRacing
{
    using System;
    public class Car
    {
        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            Make = make;
            Model = model;
            LicensePlate = licensePlate;
            HorsePower = horsePower;
            Weight = weight;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int HorsePower { get; set; }
        public double Weight { get; set; }

        public override string ToString()
        {
            return $"Make: {this.Make}{Environment.NewLine}"
                    + $"Model: {this.Model}{Environment.NewLine}"
                    + $"License Plate: {this.LicensePlate}{Environment.NewLine}"
                    + $"Horse Power: {this.HorsePower}{Environment.NewLine}"
                    + $"Weight: {this.Weight}";
        }
    }
}