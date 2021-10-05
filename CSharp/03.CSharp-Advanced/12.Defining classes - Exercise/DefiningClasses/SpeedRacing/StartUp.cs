using System;

namespace DefiningClasses
{
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var cars = GetCars();

            string input = Console.ReadLine() ?? string.Empty;
            while (input != "End")
            {
                string[] data = input?.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = data[1];
                int killometers = int.Parse(data[2]);
                Car car = cars.First(c => c.Model == model);
                int distance = car.Drive(killometers);
                if (distance < 0)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }

                input = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }

        }

        private static List<Car> GetCars()
        {
            List<Car> cars = new List<Car>();
            int count = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException(nameof(count)));
            for (int i = 0; i < count; i++)
            {
                string[] data = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? new string[] { };
                string model = data[0];
                double amount = double.Parse(data[1]);
                double consumption = double.Parse(data[2]);
                Car car = new Car(model, amount, consumption);
                cars.Add(car);
            }

            return cars;
        }
    }
}
