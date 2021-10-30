namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                var persons = GetPeoplesFromConsole();
                var products = GetProductsFromConsole();
                Bought(persons, products);
                PrintPersons(persons);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void PrintPersons(IList<Person> persons)
        {
            foreach (var person in persons)
            {
                string productsNames =
                    person.Products.Count() == 0 ?
                        "Nothing bought" :
                        string.Join(", ", person.Products.Select(p => p.Name));

                Console.WriteLine($"{person.Name} - {productsNames}");
            }
        }

        private static void Bought(IList<Person> persons, IList<Product> products)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] data = input.Split(" ");
                string personName = data[0].Trim();
                string productName = data[1].Trim();

                Person person = persons.First(p => p.Name == personName);
                Product product = products.First(p => p.Name == productName);
                if (person.AddProduct(product))
                {
                    Console.WriteLine($"{personName} bought {productName}");
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }

                input = Console.ReadLine();
            }
        }

        private static IList<Product> GetProductsFromConsole()
        {
            var products = new List<Product>();
            string[] productsDatas = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            foreach (var productData in productsDatas)
            {
                var product = productData.Split("=", StringSplitOptions.RemoveEmptyEntries);
                products.Add(new Product(product[0], double.Parse(product[1])));
            }

            return products;
        }

        private static IList<Person> GetPeoplesFromConsole()
        {
            var persons = new List<Person>();
            string[] peoplesDatas = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            foreach (var peopleData in peoplesDatas)
            {
                var people = peopleData.Split("=", StringSplitOptions.RemoveEmptyEntries);
                persons.Add(new Person(people[0], double.Parse(people[1])));
            }

            return persons;
        }
    }
}
