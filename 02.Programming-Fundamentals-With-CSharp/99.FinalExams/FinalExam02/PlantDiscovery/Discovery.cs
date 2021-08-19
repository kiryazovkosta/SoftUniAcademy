namespace PlantDiscovery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Discovery
    {
        private static void Main(string[] args)
        {
            Dictionary<string, Plant> plants = new Dictionary<string, Plant>();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] data = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                int rarity = int.Parse(data[1]);
                if (plants.ContainsKey(data[0]) == false)
                {
                    plants.Add(name, new Plant() { Ratings = new List<double>()} );
                }

                plants[name].Rarity = rarity;
            }

            string input = Console.ReadLine();
            while (input != "Exhibition")
            {
                string[] data = input.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string command = data[0].Trim();
                string[] arguments = data[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string name = arguments[0];
                switch (command)
                {
                    case "Rate":
                        double rating = double.Parse(arguments[1]);
                        plants[name].Ratings.Add(rating);
                        break;

                    case "Update":
                        int rarity = int.Parse(arguments[1]);
                        plants[name].Rarity = rarity;
                        break;

                    case "Reset":
                        plants[name].Ratings.Clear();
                        break;

                    default:
                        Console.WriteLine("error");
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Plants for the exhibition:");
            foreach (var plant in plants.OrderByDescending(p => p.Value.Rarity).ThenByDescending(p => p.Value.Ratings.Count > 0 ? p.Value.Ratings.Average() : 0.0))
            {
                double averageRating = plant.Value.Ratings.Count > 0 ? plant.Value.Ratings.Average() : 0.0;
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {averageRating:F2}");
            }
        }
    }

    public class Plant
    {
        public int Rarity { get; set; }
        public List<double> Ratings { get; set; }
    }
}