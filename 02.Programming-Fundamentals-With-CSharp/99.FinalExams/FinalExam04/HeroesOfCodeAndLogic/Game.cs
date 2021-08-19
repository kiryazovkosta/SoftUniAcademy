namespace HeroesOfCodeAndLogic
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    internal class Game
    {
        private static void Main(string[] args)
        {
            Dictionary<string, HeroData> heroes = new Dictionary<string, HeroData>();

            int heroesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < heroesCount; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                int hitPoints = int.Parse(data[1]);
                int manaPoints = int.Parse(data[2]);
                heroes.Add(name, new HeroData() { HitPoints = hitPoints, ManaPoints = manaPoints });
            }

            string line = string.Empty;
            while ((line = Console.ReadLine()) != "End")
            {
                string[] data = line.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                switch (data[0])
                {
                    case "CastSpell":
                        string name = data[1].Trim();
                        int mana = int.Parse(data[2].Trim());
                        string spell = data[3].Trim();
                        if (heroes[name].ManaPoints >= mana)
                        {
                            heroes[name].ManaPoints -= mana;
                            Console.WriteLine($"{name} has successfully cast {spell} and now has {heroes[name].ManaPoints} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{name} does not have enough MP to cast {spell}!");
                        }
                        break;

                    case "TakeDamage":
                        name = data[1].Trim();
                        int damage = int.Parse(data[2].Trim());
                        string attacker = data[3].Trim();
                        heroes[name].HitPoints -= damage;
                        if (heroes[name].HitPoints > 0)
                        {
                            Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroes[name].HitPoints} HP left!");
                        }
                        else
                        {
                            heroes.Remove(name);
                            Console.WriteLine($"{name} has been killed by {attacker}!");
                        }
                        break;

                    case "Recharge":
                        name = data[1].Trim();
                        int amount = int.Parse(data[2].Trim());
                        if (heroes[name].ManaPoints + amount > 200)
                        {
                            amount = 200 - heroes[name].ManaPoints;
                            heroes[name].ManaPoints = 200;
                        }
                        else
                        {
                            heroes[name].ManaPoints += amount;
                        }

                        Console.WriteLine($"{name} recharged for {amount} MP!");
                        break;

                    case "Heal":
                        name = data[1].Trim();
                        amount = int.Parse(data[2].Trim());
                        if (heroes[name].HitPoints + amount > 100)
                        {
                            amount = 100 - heroes[name].HitPoints;
                        }

                        heroes[name].HitPoints += amount;
                        Console.WriteLine($"{name} healed for {amount} HP!");
                        break;

                    default:
                        break;
                }
            }

            foreach (var hero in heroes.OrderByDescending(h => h.Value.HitPoints).ThenBy(h => h.Key))
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($"  HP: {hero.Value.HitPoints}");
                Console.WriteLine($"  MP: {hero.Value.ManaPoints}");
            }

            

        }
    }

    public class HeroData
    {
        public int HitPoints { get; set; }
        public int ManaPoints { get; set; }
    }
}