namespace WildFarm.Models.Animals.Mammals.Felines
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Tiger : Feline
    {
        private const double TigerWeightPerPiece = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightPerPiece => TigerWeightPerPiece;

        protected override List<Type> EatenFood => new List<Type>() { typeof(Meat) };

        public override string AskForFood()
        {
            return "ROAR!!!";
        }
    }
}
