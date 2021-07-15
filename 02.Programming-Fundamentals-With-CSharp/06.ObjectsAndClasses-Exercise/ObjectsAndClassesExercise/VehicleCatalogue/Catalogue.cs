namespace VehicleCatalogue
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class Catalogue
    {
        public static void Main()
        {
            var vehicles = GetVehicles();
            ShowVehiclesFromCatalogue(vehicles);
            Console.WriteLine($"Cars have average horsepower of: {GetAverageHousePowerByType(vehicles, "car"):F2}.");
            Console.WriteLine(
                $"Trucks have average horsepower of: {GetAverageHousePowerByType(vehicles, "truck"):F2}.");
        }

        private static double GetAverageHousePowerByType(IList<Vehicle> vehicles, string type)
        {
            if (vehicles.Any(v => v.Type == type))
            {
                return vehicles.Where(v => v.Type == type).Average(v => v.Horsepower);
            }

            return 0;
        }

        private static void ShowVehiclesFromCatalogue(IList<Vehicle> vehicles)
        {
            while (true)
            {
                var input = Console.ReadLine() ?? string.Empty;
                if (input == "Close the Catalogue")
                {
                    break;
                }

                var vehicle = FindVehicle(vehicles, input);
                if (vehicle != null)
                {
                    Console.WriteLine(vehicle.ToString());
                }
            }
        }

        private static Vehicle FindVehicle(IList<Vehicle> vehicles, string input)
        {
            return vehicles.FirstOrDefault(v => v.Model == input);
        }

        private static IList<Vehicle> GetVehicles()
        {
            var vehicles = new List<Vehicle>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var vehicleData = input?.Split(" ") ?? new string[] { };
                if (vehicleData.Length == 4)
                {
                    var type = vehicleData[0];
                    var model = vehicleData[1];
                    var color = vehicleData[2];
                    var horsepower = int.Parse(vehicleData[3]);
                    vehicles.Add(
                        new Vehicle(type, model, color, horsepower)
                    );
                }
            }

            return vehicles;
        }
    }

    public class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsepower)
        {
            Type = type;
            Model = model;
            Color = color;
            Horsepower = horsepower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }

        public override string ToString()
        {
            return
                $"Type: {Type.First().ToString().ToUpper()}{Type.Substring(1)}{Environment.NewLine}"
                + $"Model: {Model}{Environment.NewLine}"
                + $"Color: {Color}{Environment.NewLine}"
                + $"Horsepower: {Horsepower}";
        }
    }
}