﻿namespace Raiding
{
    using System;
    public class Rogue : BaseHero
    {
        private const int RoguePower = 80;

        public Rogue(string name) 
            : base(name, RoguePower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
