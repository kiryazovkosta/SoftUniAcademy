namespace OrderByAge
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class Ordered
    {
        private static void Main(string[] args)
        {
            var persons = new List<Person>();
            while (true)
            {
                var input = Console.ReadLine() ?? string.Empty;
                if (input == "End")
                {
                    break;
                }

                var personData = input.Split(" ");
                if (personData.Length == 3)
                {
                    var name = personData[0];
                    var id = personData[1];
                    var age = int.Parse(personData[2]);
                    persons.Add(new Person(name, id, age));
                }
            }

            persons = persons.OrderBy(p => p.Age).ToList();
            foreach (var person in persons)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }

    public class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.";
        }
    }
}