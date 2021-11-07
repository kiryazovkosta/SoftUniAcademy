namespace Raiding.Factory
{
    using System;

    public abstract class HeroCreator
    {
        public abstract BaseHero CreateBaseHero(string name, string type);
    }
}
