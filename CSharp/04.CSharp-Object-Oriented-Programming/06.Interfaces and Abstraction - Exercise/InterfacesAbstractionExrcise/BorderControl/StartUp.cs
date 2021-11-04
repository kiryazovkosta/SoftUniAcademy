namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var persons = new List<IHaveId>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] data = input?.Split(" ");
                if (data.Length == 2)
                {
                    var robot = new Robot(data[0], data[1]);
                    persons.Add(robot);
                }
                else
                {
                    var citizen = new Citizen(data[0], int.Parse(data[1]), data[2]);
                    persons.Add(citizen);
                }

                input = Console.ReadLine();
            }

            string fakeLastDigits = Console.ReadLine();

            foreach (var person in persons.Where(person => person.Id.EndsWith(fakeLastDigits)))
            {
                Console.WriteLine(person.Id);
            }

        }
    }
}
