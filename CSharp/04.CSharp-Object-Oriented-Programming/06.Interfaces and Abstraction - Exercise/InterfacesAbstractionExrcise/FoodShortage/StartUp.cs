namespace FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var peoples = ReadBuyers();

            string name = Console.ReadLine();
            while (name != "End")
            {
                IBuyer buyer = peoples.FirstOrDefault(n => n.Name == name);
                buyer?.BuyFood();
                name = Console.ReadLine();
            }

            Console.WriteLine(peoples.Sum(p => p.Food));
        }

        private static List<IBuyer> ReadBuyers()
        {
            var peoples = new List<IBuyer>();
            int peopleNumber = int.Parse(Console.ReadLine());
            for (int i = 1; i <= peopleNumber; i++)
            {
                string[] peopleData = Console.ReadLine().Split(" ");
                if (peopleData.Length == 3)
                {
                    var people = new Rebel(peopleData[0], int.Parse(peopleData[1]), peopleData[2]);
                    peoples.Add(people);
                }
                else
                {
                    var people = new Citizen(peopleData[0], int.Parse(peopleData[1]), peopleData[2], peopleData[3]);
                    peoples.Add(people);
                }
            }

            return peoples;
        }
    }
}