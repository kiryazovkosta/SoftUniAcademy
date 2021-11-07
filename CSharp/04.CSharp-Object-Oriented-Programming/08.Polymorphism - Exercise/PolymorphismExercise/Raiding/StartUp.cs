namespace Raiding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Factory;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var heroFactory = new HeroCreatorFactory();

            int count = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();
            while (count > 0)
            {
                try
                {
                    string name = Console.ReadLine();
                    string type = Console.ReadLine();
                    BaseHero hero = heroFactory.CreateBaseHero(name, type);
                    heroes.Add(hero);
                    count--;
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            long bossPower = long.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            long heroesPower = heroes.Sum(h => h.Power);
            if (heroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
