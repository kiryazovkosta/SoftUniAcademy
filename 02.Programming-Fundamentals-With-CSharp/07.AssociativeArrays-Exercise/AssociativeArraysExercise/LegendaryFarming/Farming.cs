using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Farming
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> keys = new Dictionary<string, long>()
            {
                { "shards", 0 },
                { "fragments", 0 },
                { "motes", 0 }
            };
            Dictionary<string, long> junks = new Dictionary<string, long>();

            bool found = false;

            while (true)
            {
                if (found)
                {
                    break;
                }

                string[] line = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? new string[]{ };

                for (int i = 0; i < line.Length; i+=2)
                {
                    int quantity = int.Parse(line[i]);
                    string material = line[i + 1].ToLower();

                    if (IsKeyMaterial(material))
                    {
                        keys[material] += quantity;
                        if (IsLegendaryItemIsReaches(keys, material))
                        {
                            string name = GetLegendaryItemName(material);
                            Console.WriteLine($"{name} obtained!");
                            keys[material] -= 250;
                            found = true;
                            break;
                        }
                    }
                    else
                    {
                        if (junks.ContainsKey(material) == false)
                        {
                            junks.Add(material, 0);
                        }

                        junks[material] += quantity;
                    }
                }
            }

            foreach (var material in keys.OrderByDescending(key => key.Value).ThenBy(key => key.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }

            foreach (var material in junks.OrderBy(key => key.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }

        private static string GetLegendaryItemName(string material)
        {
            switch (material)
            {
                case "shards":
                    return "Shadowmourne";
                    break;

                case "fragments":
                    return "Valanyr";
                    break;

                case "motes":
                    return "Dragonwrath";
                    break;

                default:
                    throw new ArgumentException(nameof(material));
                    break;
            }
        }

        private static bool IsLegendaryItemIsReaches(Dictionary<string, long> keys, string material)
        {
            return keys[material] >= 250;
        }

        private static bool IsKeyMaterial(string material)
        {
            return material == "shards" || material == "fragments" || material == "motes";
        }

    }
}
