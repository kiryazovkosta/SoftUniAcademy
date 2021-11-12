using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double HenWeightPerPiece = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightPerPiece => HenWeightPerPiece;

        protected override List<Type> EatenFood => new List<Type>() { typeof(Fruit), typeof(Meat), typeof(Seeds), typeof(Vegetable) };

        public override string AskForFood()
        {
            return "Cluck";
        }
    }
}
