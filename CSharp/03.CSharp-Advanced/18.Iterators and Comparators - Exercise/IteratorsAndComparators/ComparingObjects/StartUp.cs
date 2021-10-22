using System;

namespace ComparingObjects
{
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] data = input.Split(" ");
                string name = data[0];
                int age = int.Parse(data[1]);
                string town = data[2];
                persons.Add(new Person(name, age, town));

                input = Console.ReadLine();
            }

            int position = int.Parse(Console.ReadLine());
            if (position < persons.Count)
            {
                int matches = 0;
                int notMatches = 0;

                Person person = persons[position];

                for (int i = 0; i < persons.Count; i++)
                {
                    if (person.CompareTo(persons[i]) == 0)
                    {
                        matches++;
                    }
                    else
                    {
                        notMatches++;
                    }
                }

                Console.WriteLine($"{matches} {notMatches} {persons.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
