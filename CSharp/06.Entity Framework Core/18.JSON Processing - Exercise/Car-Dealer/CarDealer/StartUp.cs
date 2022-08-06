using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO.Car;
using CarDealer.DTO.Customer;
using CarDealer.DTO.Part;
using CarDealer.DTO.Sale;
using CarDealer.DTO.Supplier;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private const string inputPath = "../../../Datasets/";
        private const string outputPath = "../../../Results/";

        [Obsolete]
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<CarDealerProfile>();
            });

            var dbContext = new CarDealerContext();
            //InitDatabase(dbContext);

            //Query 9. Import Suppliers
            var inputJson = ReadJsonFile("suppliers.json");
            var output = ImportSuppliers(dbContext, inputJson);
            Console.WriteLine(output);

            //Query 10. Import Parts
            inputJson = ReadJsonFile("parts.json");
            output = ImportParts(dbContext, inputJson);
            Console.WriteLine(output);

            //11. Import Cars
            inputJson = ReadJsonFile("cars.json");
            output = ImportCars(dbContext, inputJson);
            Console.WriteLine(output);

            //12. Import Customers
            inputJson = ReadJsonFile("customers.json");
            output = ImportCustomers(dbContext, inputJson);
            Console.WriteLine(output);

            //13. Import Sales
            inputJson = ReadJsonFile("sales.json");
            output = ImportSales(dbContext, inputJson);
            Console.WriteLine(output);

            ////14. Export Ordered Customers
            //output = GetOrderedCustomers(dbContext);
            //Console.WriteLine(output);
            //WriteToJsonFile("ordered-customers.json", output);

            ////15. Export Cars from Make Toyota
            //output = GetCarsFromMakeToyota(dbContext);
            //Console.WriteLine(output);
            //WriteToJsonFile("toyota-cars.json", output);

            ////16. Export Local Suppliers
            //output = GetLocalSuppliers(dbContext);
            //Console.WriteLine(output);
            //WriteToJsonFile("local-suppliers.json", output);

            ////17. Export Cars with Their List of Parts
            //output = GetCarsWithTheirListOfParts(dbContext);
            //Console.WriteLine(output);
            //WriteToJsonFile("cars-and-parts.json", output);

            ////18. Export Total Sales by Customer
            //output = GetTotalSalesByCustomer(dbContext);
            //Console.WriteLine(output);
            //WriteToJsonFile("customers-total-sales.json", output);

            //19. Export Sales with Applied Discount
            output = GetSalesWithAppliedDiscount(dbContext);
            Console.WriteLine(output);
            WriteToJsonFile("customers-total-sales.json", output);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var supplierDtos = JsonConvert.DeserializeObject<ICollection<ImportSupplierDto>>(inputJson);
            var suppliers = Mapper.Map<ICollection<Supplier>>(supplierDtos);
            context.AddRange(suppliers);
            var count = context.SaveChanges();
            return $"Successfully imported {count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var partDtos = JsonConvert.DeserializeObject<ICollection<ImportPartDto>>(inputJson);
            var parts = new List<Part>();
            foreach (var partDto in partDtos)
            {
                if (context.Suppliers.Any(s => s.Id  == partDto.SupplierId))
                {
                    parts.Add(Mapper.Map<Part>(partDto));
                }
            }
                
            context.Parts.AddRange(parts);
            var count = context.SaveChanges();
            return $"Successfully imported {count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carDtos = JsonConvert.DeserializeObject<ICollection<ImportCarDto>>(inputJson);

            var cars = new List<Car>();
            var carsParts = new List<PartCar>();

            foreach (var carDto in carDtos)
            {
                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelDistance
                };

                foreach (var partId in carDto.PartsId)
                {
                    var part = context.Parts.FirstOrDefault(p => p.Id == partId);
                    if (part != null)
                    {
                        carsParts.Add(new PartCar()
                        {
                            Car = car,
                            Part = part
                        });
                    }
                }
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(carsParts);
            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customersDtos = JsonConvert.DeserializeObject<ICollection<ImportCustomerDto>>(inputJson);
            var customers = Mapper.Map<ICollection<Customer>>(customersDtos);
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {context.Customers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var salesDtos = JsonConvert.DeserializeObject<ICollection<ImportSaleDto>>(inputJson);
            var sales = Mapper.Map<ICollection<Sale>>(salesDtos);
            context.Sales.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {context.Sales.Count()}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var cutomes = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ProjectTo<ExportCustomerDto>()
                .ToArray();

            return JsonConvert.SerializeObject(cutomes, Formatting.Indented);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<ExportCarDto>()
                .ToArray();
            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<ExportSupplierDto>()
                .ToArray();
            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            //var car = context.Cars.ProjectTo<ExportCarWithPartsDto>().ToArray();

            var car = context.Cars.Select(c => new ExportCarWithPartsDto()
            {
                Car = new ExportCarDataDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                },
                Parts = c.PartCars.Select(pc => new ExportPartDto()
                {
                    Name = pc.Part.Name,
                    Price = pc.Part.Price.ToString("F2")
                }).ToArray()
            });

            return JsonConvert.SerializeObject(car, Formatting.Indented);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count() > 0)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count(),
                    spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToArray();
            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales.Select(s => new
            {
                car = new
                {
                    s.Car.Make,
                    s.Car.Model,
                    s.Car.TravelledDistance
                },
                customerName = s.Customer.Name,
                Discount = s.Discount.ToString("F2"),
                price = s.Car.PartCars.Sum(pc => pc.Part.Price).ToString("F2"),
                priceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price) - (s.Car.PartCars.Sum(pc => pc.Part.Price) * (s.Discount / 100.00M))).ToString("F2")
            }).Take(10).ToArray();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }

        private static string ReadJsonFile(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), inputPath, fileName);
            string fileContent = File.ReadAllText(filePath);
            return fileContent;
        }

        private static void WriteToJsonFile(string fileName, string jsonInput)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), outputPath, fileName);
            File.WriteAllText(filePath, jsonInput);
        }

        private static void InitDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            Console.WriteLine("Database is successfully created!");
        }

        /// <summary>
        /// Executes all validation attributes in a class and returns true or false depending on validation result.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}