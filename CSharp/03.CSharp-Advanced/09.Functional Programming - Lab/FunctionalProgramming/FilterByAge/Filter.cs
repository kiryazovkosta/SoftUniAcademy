namespace FilterByAge
{
    using System;
    using System.Collections.Generic;

    public class Filter
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, int> persons = new Dictionary<string, int>();
            for (int i = 0; i < count; i++)
            {
                string[] personData = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = personData[0];
                int ages = int.Parse(personData[1]);
                persons.Add(name, ages);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(condition, age);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            PrintFilteredPersons(persons, tester, printer);
        }

        private static void PrintFilteredPersons(
            Dictionary<string, int> persons, 
            Func<int, bool> tester, 
            Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in persons)
            {
                if (tester(person.Value))
                {
                    printer(person);
                }
            }
        }

        private static Func<int, bool> CreateTester(string condition, int age)
        {
            if (condition == "older")
            {
                return n => n >= age;
            }
            else if (condition == "younger")
            {
                return n => n < age;
            }
            else
            {
                return null;
            }
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            if (format == "name age")
            {
                return pair => Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
            else if (format == "name")
            {
                return pair => Console.WriteLine($"{pair.Key}");
            }
            else if (format == "age")
            {
                return pair => Console.WriteLine($"{pair.Value}");
            }
            else
            {
                return null;
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
