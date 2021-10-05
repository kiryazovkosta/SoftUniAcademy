namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            int n = int.Parse(Console.ReadLine() ?? throw new ArgumentException());
            while (n > 0)
            {
                string[] data = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? new string[] { };
                string model = data[0];
                int power = int.Parse(data[1]);
                Engine engine = new Engine(model, power);
                if (data.Length > 2)
                {
                    int value;
                    if (int.TryParse(data[2], out value))
                    {
                        engine.Displacement = value;
                    }
                    else
                    {
                        engine.Efficiency = data[2];
                    }
                }

                if (data.Length > 3)
                {
                    engine.Efficiency = data[3];
                }

                engines.Add(engine);
                n--;
            }

            List<Car> cars = new List<Car>();
            int m = int.Parse(Console.ReadLine() ?? throw new ArgumentException());

            for (int i = 0; i < m; i++)
            {
                string[] data = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? new string[] { };
                string model = data[0];
                Engine engine = engines.First(e => e.Model == data[1]);
                Car car = new Car(model, engine);
                if (data.Length > 2)
                {
                    int value;
                    if (int.TryParse(data[2], out value))
                    {
                       car.Weight = value;
                    }
                    else
                    {
                        car.Color = data[2];
                    }
                }

                if (data.Length > 3)
                {
                    car.Color = data[3];
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
