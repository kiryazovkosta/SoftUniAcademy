using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            var xml = string.Empty;
            var output = string.Empty;

            ////9. Import Suppliers
            //xml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //output = ImportSuppliers(context, xml);
            //Console.WriteLine(output);

            ////10. Import Parts
            //xml = File.ReadAllText("../../../Datasets/parts.xml");
            //output = ImportParts(context, xml);
            //Console.WriteLine(output);

            ////11. Import Cars
            //xml = File.ReadAllText("../../../Datasets/cars.xml");
            //output = ImportCars(context, xml);
            //Console.WriteLine(output);

            ////12. Import Customers
            //xml = File.ReadAllText("../../../Datasets/customers.xml");
            //output = ImportCustomers(context, xml);
            //Console.WriteLine(output);

            ////13. Import Sales
            //xml = File.ReadAllText("../../../Datasets/sales.xml");
            //output = ImportSales(context, xml);
            //Console.WriteLine(output);

            ////14. Export Cars With Distance
            //output = GetCarsWithDistance(context);
            //Console.WriteLine(output);

            ////15. Export Cars from make BMW
            //output = GetCarsFromMakeBmw(context);
            //Console.WriteLine(output);

            //16.Export Local Suppliers
            //output = GetLocalSuppliers(context);
            //Console.WriteLine(output);

            ////17. Export Cars with Their List of Parts
            //output = GetCarsWithTheirListOfParts(context);
            //Console.WriteLine(output);

            ////18. Export Total Sales by Customer
            //output = GetTotalSalesByCustomer(context);
            //Console.WriteLine(output);

            //19. Export Sales with Applied Discount
            output = GetSalesWithAppliedDiscount(context);
            Console.WriteLine(output);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var config = new MapperConfiguration(cnf => cnf.AddProfile<CarDealerProfile>());
            var mapper = config.CreateMapper();

            var suppliersDtos = Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");
            var suppliers = mapper.Map<ICollection<Supplier>>(suppliersDtos);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var config = new MapperConfiguration(cnf => cnf.AddProfile<CarDealerProfile>());
            var mapper = config.CreateMapper();

            var partsDtos = Deserialize<ImportPartDto[]>(inputXml, "Parts");
            var parts = new List<Part>();
            foreach (var partDto in partsDtos)
            {
                if (context.Suppliers.Any(s => s.Id == partDto.SupplierId))
                {
                    parts.Add(mapper.Map<Part>(partDto));
                }
            }
            
            context.Parts.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var config = new MapperConfiguration(cnf => cnf.AddProfile<CarDealerProfile>());
            var mapper = config.CreateMapper();

            var carsDtos = Deserialize<ImportCarDto[]>(inputXml, "Cars");
            var cars = new List<Car>();
            var partCars = new List<PartCar>();
            foreach (var carDto in carsDtos)
            {
                var car = mapper.Map<Car>(carDto);
                foreach (var partId in carDto.Parts.Select(pc => pc.Id).Distinct())
                {
                    if (context.Parts.Any(p => p.Id == partId))
                    {
                        partCars.Add(new PartCar()
                        {
                            Car = car,
                            PartId = partId
                        });
                    }
                }
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(partCars);
            context.SaveChanges();
            return $"Successfully imported {context.Cars.Count()}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var config = new MapperConfiguration(cnf => cnf.AddProfile<CarDealerProfile>());
            var mapper = config.CreateMapper();

            var customersDtos = Deserialize<ImportCustomerDto[]>(inputXml, "Customers");
            var customers = mapper.Map<ICollection<Customer>>(customersDtos);
            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var config = new MapperConfiguration(cnf => cnf.AddProfile<CarDealerProfile>());
            var mapper = config.CreateMapper();

            var salesDtos = Deserialize<ImportSaleDto[]>(inputXml, "Sales");
            var sales = mapper.Map<ICollection<Sale>>(salesDtos);

            foreach (var sale in sales)
            {
                if (context.Cars.Any(c => c.Id == sale.CarId))
                {
                    context.Sales.Add(sale);
                }
            }

            context.SaveChanges();
            return $"Successfully imported {context.Sales.Count()}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var config = new MapperConfiguration(cnf => cnf.AddProfile<CarDealerProfile>());
            var mapper = config.CreateMapper();

            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarWithDistanceDto>(config)
                .ToArray();
            return Serialize(cars, "cars");
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var config = new MapperConfiguration(cnf => cnf.AddProfile<CarDealerProfile>());
            var mapper = config.CreateMapper();
            var cars = context.Cars.Where(c => c.Make == "BMW").OrderBy(c => c.Model).ThenByDescending(c => c.TravelledDistance).ProjectTo<ExportCarFromMakeBmwDto>(config).ToArray();
            return Serialize(cars, "cars");
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var config = new MapperConfiguration(cnf => cnf.AddProfile<CarDealerProfile>());
            var mapper = config.CreateMapper();

            var suppliers = context.Suppliers.Where(s => s.IsImporter == false).ProjectTo<ExportLocalSupplierDto>(config).ToArray();
            return Serialize(suppliers, "suppliers");
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var config = new MapperConfiguration(cnf => cnf.AddProfile<CarDealerProfile>());
            var mapper = config.CreateMapper();
            var cars = context.Cars.ProjectTo<ExportCarWithPartsListDto>(config).OrderByDescending(c => c.TravelledDistance).ThenBy(c => c.Model).Take(5).ToArray();
            return Serialize(cars, "cars");
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var config = new MapperConfiguration(cnf => cnf.AddProfile<CarDealerProfile>());
            var mapper = config.CreateMapper();
            var customers = context.Customers
                .Where(c => c.Sales.Count() > 0)
                .ProjectTo<ExportCustomerDto>(config)
                .OrderByDescending(c => c.SpentMoney).ToArray();
            return Serialize(customers, "customers");
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var config = new MapperConfiguration(cnf => cnf.AddProfile<CarDealerProfile>());
            var mapper = config.CreateMapper();
            var sales = context.Sales.ProjectTo<ExportSaleDto>(config).ToArray();
            return Serialize(sales, "sales");
        }

        //Helper methods
        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            T dtos = (T)xmlSerializer.Deserialize(reader);

            return dtos;
        }

        private static string Serialize<T>(T dto, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, dto, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}