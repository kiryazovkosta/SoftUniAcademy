// ------------------------------------------------------------------------------------------------
//  <copyright file="Army.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace DragonArmy
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class Army
    {
        private static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<double>>> dragons =
                new Dictionary<string, Dictionary<string, List<double>>>();


            int dragonsNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < dragonsNumber; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = data[0];
                string name = data[1];
                double damage = data[2].Trim() != "null" ? double.Parse(data[2]) : 45;
                double health = data[3].Trim() != "null" ? double.Parse(data[3]) : 250;
                double armor = data[4].Trim() != "null" ? double.Parse(data[4]) : 10;

                if (dragons.ContainsKey(type) == false)
                {
                    dragons.Add(type, new Dictionary<string, List<double>>());
                }

                if (dragons[type].ContainsKey(name) == false)
                {
                    dragons[type].Add(name, new List<double>() {damage, health, armor});
                }
                else
                {
                    dragons[type][name].Clear();
                    dragons[type][name].AddRange(new List<double>() {damage, health, armor});
                }
            }

            foreach (var dragon in dragons)
            {
                var type = dragon.Key;
                var data = dragon.Value;

                double averageDamage = data.Values.Average(x => x[0]);
                double averageHealth = data.Values.Average(x => x[1]);
                double averageArmor = data.Values.Average(x => x[2]);

                Console.WriteLine($"{type}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");
                foreach (var dragonData in data.OrderBy(d => d.Key))
                {
                    string dragonName = dragonData.Key;
                    List<double> dragonStats = dragonData.Value;
                    double damage = dragonStats[0];
                    double health = dragonStats[1];
                    double armor = dragonStats[2];
                    Console.WriteLine($"-{dragonName} -> damage: {damage:F0}, health: {health:F0}, armor: {armor:F0}");
                }
            }
        }
    }
}