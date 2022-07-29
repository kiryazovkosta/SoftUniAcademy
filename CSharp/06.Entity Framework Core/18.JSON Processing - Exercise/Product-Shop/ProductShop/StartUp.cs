

namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Newtonsoft.Json;
    using ProductShop.Data;
    using ProductShop.Dtos.Category;
    using ProductShop.Dtos.CategoryProduct;
    using ProductShop.Dtos.Product;
    using ProductShop.Dtos.User;
    using ProductShop.Models;

    public class StartUp
    {
        private const string inputPath = "../../../Datasets/";
        private const string outputPath = "../../../Results/";

        [Obsolete]
        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<ProductShopProfile>();
            });

            ProductShopContext dbContext = new ProductShopContext();
            // InitDatabase(dbContext);

            //// Query 1. Import Users
            //string inputJson = ReadJsonFile("users.json");
            //var output = ImportUsers(dbContext, inputJson);
            //Console.WriteLine(output);

            //// Query 2. Import Products
            //string inputJson = ReadJsonFile("products.json");
            //var output = ImportProducts(dbContext, inputJson);
            //Console.WriteLine(output);

            //// Query 3. Import Categories
            //string inputJson = ReadJsonFile("categories.json");
            //var output = ImportCategories(dbContext, inputJson);
            //Console.WriteLine(output);

            //// Query 4. Import Categories and Products
            //string inputJson = ReadJsonFile("categories-products.json");
            //var output = ImportCategoryProducts(dbContext, inputJson);
            //Console.WriteLine(output);

            //// Query 5. Export Products in Range
            //var output = GetProductsInRange(dbContext);
            //Console.WriteLine(output);
            //WriteToJsonFile("products-in-range.json", output);

            //// 06. Export Sold Products
            //var output = GetSoldProducts(dbContext);
            //Console.WriteLine(output);
            //WriteToJsonFile("users-sold-products.json", output);

            //// 07.Export Categories By Products Count
            //var output = GetCategoriesByProductsCount(dbContext);
            //Console.WriteLine(output);

            //// 08. Export Users and Products
            //var output = GetUsersWithProducts(dbContext);
            //Console.WriteLine(output);

        }

        /// <summary>
        /// Import the users from the provided file users.json.
        /// Your method should return a string with the message $"Successfully imported {Users.Count}";
        /// </summary>
        /// <param name="context"></param>
        /// <param name="inputJson"></param>
        /// <returns></returns>
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var userDtos = JsonConvert.DeserializeObject<ICollection<ImportUserDto>>(inputJson);
            var users = Mapper.Map<ICollection<User>>(userDtos);
            context.AddRange(users);
            var count = context.SaveChanges();
            return $"Successfully imported {count}";
        }

        /// <summary>
        /// Import the users from the provided file products.json.
        /// Your method should return a string with the message $"Successfully imported {Products.Count}";
        /// </summary>
        /// <param name="context"></param>
        /// <param name="inputJson"></param>
        /// <returns></returns>
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var productDtos = JsonConvert.DeserializeObject<IEnumerable<ImportProductDto>>(inputJson);
            var products = new List<Product>();
            foreach (var productDto in productDtos)
            {
                if (IsValid(productDto))
                {
                    products.Add(Mapper.Map<Product>(productDto));
                }
            }

            context.Products.AddRange(products);
            var count = context.SaveChanges();
            return $"Successfully imported {count}";
        }

        /// <summary>
        /// Import the users from the provided file categories.json. 
        /// Some of the names will be null, so you don't have to add them to the database. Just skip the record and continue.
        /// Your method should return a string with the message $"Successfully imported {Categories.Count}";
        /// </summary>
        /// <param name="context"></param>
        /// <param name="inputJson"></param>
        /// <returns></returns>
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categoriesDto = JsonConvert.DeserializeObject<IEnumerable<ImportCategoryDto>>(inputJson);
            var categories = new List<Category>();
            foreach (var categoryDto in categoriesDto)
            {
                if (IsValid(categoryDto))
                {
                    categories.Add(Mapper.Map<Category>(categoryDto));
                }
            }

            context.Categories.AddRange(categories);
            var count = context.SaveChanges();
            return $"Successfully imported {count}";
        }

        /// <summary>
        /// Import the users from the provided file categories-products.json. 
        /// Your method should return a string with the message $"Successfully imported {CategoryProducts.Count}";
        /// </summary>
        /// <param name="context"></param>
        /// <param name="inputJson"></param>
        /// <returns></returns>
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProductsDtos = JsonConvert.DeserializeObject<ICollection<ImportCategoryProductDto>>(inputJson);
            var categoryProducts = new List<CategoryProduct>();
            foreach (var cpDto in categoryProductsDtos)
            {
                if (IsValid(cpDto))
                {
                    categoryProducts.Add(Mapper.Map<CategoryProduct>(cpDto));
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            var count = context.SaveChanges();
            return $"Successfully imported {count}";
        }

        /// <summary>
        /// Get all products in a specified price range:  500 to 1000 (inclusive). 
        /// Order them by price (from lowest to highest). Select only the product name, price and the full name of the seller. 
        /// Export the result to JSON.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ProjectTo<ExportProductDto>()
                .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);   
        }

        /// <summary>
        /// Get all users who have at least 1 sold item with a buyer. 
        /// Order them by the last name, then by the first name. 
        /// Select the person's first and last name. 
        /// For each of the sold products (products with buyers), select the product's name, price and the buyer's first and last name.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<ExportUsersWithSoldProductDto>()
                .ToArray();

            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        /// <summary>
        /// Get all categories. Order them in descending order by the category's products count. 
        /// For each category select its name, the number of products, 
        /// the average price of those products (rounded to the second digit after the decimal separator) 
        /// and the total revenue (total price sum and rounded to the second digit after the decimal separator) 
        /// of those products (regardless if they have a buyer or not).
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count())
                .ProjectTo<ViewCategodyDataDto>()
                .ToArray();

            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }

        /// <summary>
        /// Get all users who have at least 1 sold product with a buyer. 
        /// Order them in descending order by the number of sold products with a buyer. 
        /// Select only their first and last name, age and for each product - name and price. Ignore all null values.
        /// Export the results to JSON.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = new UsersAllListDto() {
                Users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .OrderByDescending(u => u.ProductsSold.Count(p => p.BuyerId.HasValue))
                .Select(u => new UserListDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsListDto()
                    {
                        Products = u.ProductsSold.Where(p => p.BuyerId.HasValue).Select(p => new SoldProductDto()
                        {
                            Name = p.Name,
                            Price = p.Price,
                        }).ToArray(),
                    }
                })
                .ToArray()
            };

            return JsonConvert.SerializeObject(
                users, 
                Formatting.Indented, 
                new JsonSerializerSettings 
                { 
                    NullValueHandling = NullValueHandling.Ignore
                });
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

        private static void InitDatabase(ProductShopContext context)
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