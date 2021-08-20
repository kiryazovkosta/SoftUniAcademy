namespace NeedForSpeed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int carsNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsNumber; i++)
            {
                string[] carData = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                cars.Add(carData[0], new Car() {Mileage = int.Parse(carData[1]), Fuel = int.Parse(carData[2])});
            }

            string input = Console.ReadLine();
            while (input != "Stop")
            {
                string[] data = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string command = data[0].Trim();
                switch (command)
                {
                    case "Drive":
                        string car = data[1].Trim();
                        int distance = int.Parse(data[2].Trim());
                        int fuel = int.Parse(data[3].Trim());
                        if (cars[car].Fuel >= fuel)
                        {
                            cars[car].Fuel -= fuel;
                            cars[car].Mileage += distance;
                            Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                            if (cars[car].Mileage >= 100000)
                            {
                                Console.WriteLine($"Time to sell the {car}!");
                                cars.Remove(car);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }
                        break;

                    case "Refuel":
                        car = data[1].Trim();
                        fuel = int.Parse(data[2].Trim());
                        if (cars[car].Fuel + fuel > 75)
                        {
                            fuel = 75 - cars[car].Fuel;
                        }

                        cars[car].Fuel += fuel;
                        Console.WriteLine($"{car} refueled with {fuel} liters");
                        break;

                    case "Revert":
                        car = data[1].Trim();
                        int kilometers = int.Parse(data[2].Trim());
                        cars[car].Mileage -= kilometers;
                        if (cars[car].Mileage < 10000)
                        {
                            cars[car].Mileage = 10000;
                        }
                        else
                        {
                            Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                        }
                        
                        break;

                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, Car> car in cars.OrderByDescending(c => c.Value.Mileage).ThenBy(c => c.Key))
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }
    }

    public class Car
    {
        public int Mileage { get; set; }

        public int Fuel { get; set; }
    }
}
