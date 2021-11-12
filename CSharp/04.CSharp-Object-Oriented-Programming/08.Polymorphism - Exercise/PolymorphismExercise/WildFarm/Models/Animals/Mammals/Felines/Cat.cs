using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double CarWeightPerPiece = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightPerPiece => CarWeightPerPiece;

        protected override List<Type> EatenFood => new List<Type>() { typeof(Meat), typeof(Vegetable) };

        public override string AskForFood()
        {
            return "Meow";
        }
    }
}
