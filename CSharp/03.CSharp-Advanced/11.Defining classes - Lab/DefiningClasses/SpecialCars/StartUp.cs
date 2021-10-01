namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string input = Console.ReadLine() ?? string.Empty;
            while (input != "No more tires")
            {
                List<Tire> tiresList = new List<Tire>();
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < data.Length - 1; i+=2)
                {
                    Tire tire = new Tire(int.Parse(data[i]), double.Parse(data[i + 1]));
                    tiresList.Add(tire);
                }

                tires.Add(tiresList.ToArray());
                input = Console.ReadLine() ?? string.Empty;
            }

            input = Console.ReadLine() ?? string.Empty;
            while (input != "Engines done")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(data[0]);
                double capacity = double.Parse(data[1]);
                engines.Add(new Engine(horsePower, capacity));
                input = Console.ReadLine() ?? string.Empty;
            }

            input = Console.ReadLine() ?? string.Empty;
            while (input != "Show special")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string make = data[0];
                string model = data[1];
                int year = int.Parse(data[2]);
                double fuelQuantity = double.Parse(data[3]);
                double fuelConsumption = double.Parse(data[4]);
                int engineIndex = int.Parse(data[5]);
                int tiresIndex = int.Parse(data[6]);
                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]));
                input = Console.ReadLine() ?? string.Empty;
            }

            foreach (var car in cars.Where(c => c.Year >= 2017 && c.Engine.HorsePower > 330 && c.Tires.Sum(t => t.Pressure) > 9 && c.Tires.Sum(t => t.Pressure) < 10))
            {
                //if (car.Year >= 2017 && car.Engine.HorsePower > 330 && car.Tires.Sum(t => t.Pressure) > 9 && car.Tires.Sum(t => t.Pressure) < 10)
                {
                    car.Drive(20);
                    Console.WriteLine(car.WhoAmI());
                }
            }
        }
    }
}
