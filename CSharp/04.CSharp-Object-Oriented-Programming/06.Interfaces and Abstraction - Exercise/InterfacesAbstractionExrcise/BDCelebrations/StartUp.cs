namespace BDCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var celebrants = new List<IBirthable>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] data = input.Split(" ");
                string type = data[0];
                if (type == "Citizen")
                {
                    celebrants.Add(new Citizen(data[1], int.Parse(data[2]), data[3], data[4]));
                }
                else if (type == "Pet")
                {
                    celebrants.Add(new Pet(data[1], data[2]));
                }

                input = Console.ReadLine();
            }

            string year = Console.ReadLine();
            foreach (var celebrant in celebrants.Where(c => c.Birthdate.EndsWith(year)))
            {
                Console.WriteLine(celebrant.Birthdate);
            }
        }
    }
}