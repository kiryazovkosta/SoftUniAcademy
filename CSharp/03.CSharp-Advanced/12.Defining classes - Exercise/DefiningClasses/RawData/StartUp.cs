namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < size; i++)
            {
                string[] data = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? new string[] { };
                string model = data[0];
                int engineSpeed = int.Parse(data[1]); 
                int enginePower = int.Parse(data[2]);
                int cargoWeight = int.Parse(data[3]);
                CargoType cargoType = data[4] == "fragile" ? CargoType.Fragile : CargoType.Flammable;
                double tire1Pressure = double.Parse(data[5]);
                int tire1Age = int.Parse(data[6]);
                double tire2Pressure = double.Parse(data[7]);
                int tire2Age = int.Parse(data[8]);
                double tire3Pressure = double.Parse(data[9]);
                int tire3Age = int.Parse(data[10]);
                double tire4Pressure = double.Parse(data[11]);
                int tire4Age  = int.Parse(data[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                Tire[] tires = new Tire[4]
                {
                    new Tire(tire1Age, tire1Pressure),
                    new Tire(tire2Age, tire2Pressure),
                    new Tire(tire3Age, tire3Pressure),
                    new Tire(tire4Age, tire4Pressure),
                };

                cars.Add(new Car(model, engine, cargo, tires));
            }

            CargoType type = Console.ReadLine() == "fragile" ? CargoType.Fragile : CargoType.Flammable;
            List<Car> result = 
                type == CargoType.Fragile ? 
                    cars.Where(c => c.Cargo.Type == CargoType.Fragile && c.Tires.Any(t => t.Pressure < 1)).ToList() 
                    : cars.Where(c => c.Cargo.Type == CargoType.Flammable && c.Engine.Power > 250).ToList();

            foreach (var car in result)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
