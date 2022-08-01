using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        [System.Obsolete]
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<ProductShopProfile>();
            });

            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            var xml = string.Empty;
            var output = string.Empty;

            ////1. Import Users
            //xml = File.ReadAllText("../../../Datasets/users.xml");
            //output = ImportUsers(context, xml);
            //System.Console.WriteLine(output);

            ////2. Import Products
            //xml = File.ReadAllText("../../../Datasets/products.xml");
            //output = ImportProducts(context, xml);
            //System.Console.WriteLine(output);

            ////3. Import Categories
            //xml = File.ReadAllText("../../../Datasets/categories.xml");
            //output = ImportCategories(context, xml);
            //System.Console.WriteLine(output);

            ////4. Import Categories and Products
            //xml = File.ReadAllText("../../../Datasets/categories-products.xml");
            //output = ImportCategoryProducts(context, xml);
            //System.Console.WriteLine(output);

            ////5.Export Products In Range
            //output = GetProductsInRange(context);
            //System.Console.WriteLine(output);

            ////6. Export Sold Products
            //output = GetSoldProducts(context);
            //System.Console.WriteLine(output);

            ////7. Export Categories By Products Count
            //output = GetSoldProducts(context);
            //System.Console.WriteLine(output);

            //8. Export Users and Products
            output = GetUsersWithProducts(context);
           Console.WriteLine(output);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var usersDto = Deserialize<ImportUserDto[]>(inputXml, "Users");
            var users = Mapper.Map<ICollection<User>>(usersDto);
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var productsDtos = Deserialize<ImportProductDto[]>(inputXml, "Products");
            var products = new List<Product>();
            foreach (var productDto in productsDtos)
            {
                products.Add(new Product
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    BuyerId = productDto.BuyerId,
                    SellerId = productDto.SellerId
                });
            }

            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var categoriesDtos = Deserialize<ImportCategoryDto[]>(inputXml, "Categories");
            var categories = new List<Category>();
            foreach (var cDto in categoriesDtos)
            {
                if (!string.IsNullOrWhiteSpace(cDto.Name))
                {
                    categories.Add(new Category { Name = cDto.Name });
                }
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var categoryProductsDtos = Deserialize<CategoryProductDto[]>(inputXml, "CategoryProducts");
            var categoryProducts = new List<CategoryProduct>();
            foreach (var cDto in categoryProductsDtos)
            {
                if (context.Categories.Any(c => c.Id == cDto.CategoryId) 
                    && context.Products.Any(p => p.Id == cDto.ProductId))
                {
                    categoryProducts.Add(new CategoryProduct
                    {
                        CategoryId = cDto.CategoryId,
                        ProductId = cDto.ProductId
                    });
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ExportProductDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.BuyerId.HasValue ? p.Buyer.FirstName + " " + p.Buyer.LastName : null,
                })
                .ToArray();

            return Serialize<ExportProductDto[]>(products, "Products");
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users.Where(u => u.ProductsSold.Count() > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportUserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(p => new ExportSoldProductDto
                    {
                        Name = p.Name,
                        //Price = p.Price.ToString("0.#########################"),
                        Price = p.Price
                    }).ToArray()
                }).ToArray();

            return Serialize(users, "Users");
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new ExportCategoryDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            return Serialize(categories, "Categories");
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = new ExportUsersWithCountDto()
            {
                Count = context.Users.Count(u => u.ProductsSold.Count() > 0), 
                Users = context.Users.Where(u => u.ProductsSold.Count() > 0)
                    .Select(u => new ExportUserWithSoldProductsDto()
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Age = u.Age, 
                        SoldProducts = new ExportSoldProductsDto()
                        {
                            Count = u.ProductsSold.Count(), 
                            Products = new ExportSoldProductListDto()
                                {
                                    Products = u.ProductsSold.
                                        OrderByDescending(p => p.Price)
                                        .Select(p => new ExportSoldProductDto()
                                        {
                                            Name = p.Name,
                                            Price = p.Price
                                        })
                                        .ToArray()
                                }
                        }
                    })
                    .OrderByDescending(u => u.SoldProducts.Count)
                    .Take(10)
                    .ToArray()
            };

            return Serialize(users, "Users");
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