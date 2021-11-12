using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double DogWeightPerPiece = 0.40;

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightPerPiece => DogWeightPerPiece;

        protected override List<Type> EatenFood => new List<Type>() { typeof(Meat) };

        public override string AskForFood()
        {
            return "Woof!";
        }
    }
}
