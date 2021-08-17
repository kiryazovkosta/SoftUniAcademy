namespace Pirates
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion
    internal class Yohoho
    {
        private static void Main(string[] args)
        {
            var cities = new Dictionary<string, CityData>();

            var input = Console.ReadLine();
            while (input != "Sail")
            {
                var data = input.Split("||", StringSplitOptions.RemoveEmptyEntries);
                var name = data[0];
                var population = int.Parse(data[1]);
                var gold = int.Parse(data[2]);

                if (cities.ContainsKey(name) == false)
                {
                    cities.Add(
                        name,
                        new CityData()
                        {
                            Population = population,
                            Gold = gold
                        });
                }
                else
                {
                    cities[name].Population += population;
                    cities[name].Gold += gold;
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                string[] data = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                string name = data[1];
                if (command == "Plunder")
                {
                    int people = int.Parse(data[2]);
                    int gold = int.Parse(data[3]);
                    cities[name].Population -= people;
                    cities[name].Gold -= gold;
                    Console.WriteLine($"{name} plundered! {gold} gold stolen, {people} citizens killed.");
                    if (cities[name].Population <= 0 || cities[name].Gold <= 0)
                    {
                        Console.WriteLine($"{name} has been wiped off the map!");
                        cities.Remove(name);
                    }

                }
                else if (command == "Prosper")
                {
                    int gold = int.Parse(data[2]);
                    if (gold >= 0)
                    {
                        cities[name].Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {name} now has {cities[name].Gold} gold.");
                    }
                    else
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                    }

                }

                input = Console.ReadLine();
            }

            if (cities.Count == 0)
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                cities = cities.OrderByDescending(c => c.Value.Gold).ThenBy(c => c.Key).ToDictionary(k => k.Key, v => v.Value);
                foreach (var city in cities)
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value.Population} citizens, Gold: {city.Value.Gold} kg");
                }
            }
        }
    }

    public class CityData
    {
        public int Population { get; set; }
        public int Gold { get; set; }
    }
}