﻿namespace Raiding.Factory
{
    using System;

    public class HeroCreatorFactory : HeroCreator
    {
        public override BaseHero CreateBaseHero(string name, string type)
        {
            BaseHero hero = null;
            switch (type)
            {
                case "Druid":
                    hero = new Druid(name);
                    break;

                case "Paladin":
                    hero = new Paladin(name);
                    break;

                case "Rogue":
                    hero = new Rogue(name);
                    break;

                case "Warrior":
                    hero = new Warrior(name);
                    break;

                default:
                    throw new ArgumentException("Invalid hero!");
            }

            return hero;
        }
    }
}
