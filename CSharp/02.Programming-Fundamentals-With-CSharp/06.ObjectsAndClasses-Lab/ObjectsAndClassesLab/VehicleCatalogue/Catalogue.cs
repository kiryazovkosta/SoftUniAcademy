namespace VehicleCatalogue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Weight { get; set; }
    }

    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }

    public class Catalog
    {
        public ICollection<Truck> Trucks;
        public ICollection<Car> Cars;

        public Catalog()
        {
            this.Trucks = new List<Truck>();
            this.Cars = new List<Car>();
        }
    }

    public class Catalogue
    {
        static void Main(string[] args)
        {
            var catalog = PopulateVehicleCatalog();
            PrintVehicleCatalog(catalog);
        }

        private static Catalog PopulateVehicleCatalog()
        {
            var catalog = new Catalog();
            var input = Console.ReadLine() ?? throw new ArgumentNullException();
            while (input != "end")
            {
                var data = input.Split("/", StringSplitOptions.RemoveEmptyEntries);
                var type = data[0];
                var brand = data[1];
                var model = data[2];
                var parameter = int.Parse(data[3]);
                if (type.ToLower() == "truck")
                {
                    catalog.Trucks.Add(new Truck()
                    {
                        Brand = brand,
                        Model = model,
                        Weight = parameter,
                    });
                }
                else
                {
                    catalog.Cars.Add(new Car()
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = parameter,
                    });
                }

                input = Console.ReadLine() ?? throw new ArgumentNullException();
            }

            return catalog;
        }

        private static void PrintVehicleCatalog(Catalog catalog)
        {
            if (catalog.Cars.Any())
            {
                Console.WriteLine($"Cars:");
                foreach (var car in catalog.Cars.OrderBy(c => c.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (catalog.Trucks.Any())
            {
                Console.WriteLine("Trucks:");
                foreach (var truck in catalog.Trucks.OrderBy(t => t.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
}