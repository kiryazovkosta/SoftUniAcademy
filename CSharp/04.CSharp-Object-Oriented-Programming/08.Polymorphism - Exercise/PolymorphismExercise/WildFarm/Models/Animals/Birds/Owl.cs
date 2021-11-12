namespace WildFarm.Models.Animals.Birds
{
    using System;
    using System.Collections.Generic;
    using Foods;

    public class Owl : Bird
    {
        private const double OwlWeightPerPiece = 0.25;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightPerPiece => OwlWeightPerPiece;

        protected override List<Type> EatenFood => new List<Type>() { typeof(Meat) };

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }
    }
}
