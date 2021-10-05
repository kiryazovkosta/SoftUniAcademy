namespace SoftUniParking
{
    using System.Collections.Generic;
    using System.Linq;

    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.Cars = new List<Car>();
            this.Capacity = capacity;
        }

        private  List<Car> Cars
        {
            get => this.cars;
            set => this.cars = value;
        }

        private int Capacity
        {
            get => this.capacity; 
            set => this.capacity = value;
        }

        public int Count => this.Cars.Count;

        public string AddCar(Car car)
        {
            if (this.Cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (this.Count >= this.Capacity)
            {
                return "Parking is full!";
            }

            this.Cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (this.Cars.All(c => c.RegistrationNumber != registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }

            this.Cars.Remove(this.Cars.Find(c => c.RegistrationNumber == registrationNumber));
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            return this.Cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                this.RemoveCar(registrationNumber);
            }
        }
    }
}
