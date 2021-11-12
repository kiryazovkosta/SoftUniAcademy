namespace WildFarm.Models.Animals.Mammals
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Mouse : Mammal
    {
        private const double MouseWeightPerPiece = 0.10;

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightPerPiece => MouseWeightPerPiece;

        protected override List<Type> EatenFood => new List<Type>() { typeof(Fruit), typeof(Vegetable) };

        public override string AskForFood()
        {
            return "Squeak";
        }
    }
}
