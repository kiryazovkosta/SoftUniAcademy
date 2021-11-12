namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WildFarm.Models.Foods;

    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        protected string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        protected double Weight
        {
            get => this.weight;
            private set => this.weight = value;
        }

        protected int FoodEaten
        {
            get => this.foodEaten; 
            private set  => this.foodEaten = value;
        }

        protected abstract double WeightPerPiece { get; }

        public abstract string AskForFood();

        public void IncreaseWeight(int pieces)
        {
            this.Weight += (pieces * this.WeightPerPiece);
            this.FoodEaten += pieces;
        }

        protected abstract List<Type> EatenFood { get; }

        public bool CanEat(Food food)
        {
            return this.EatenFood.Contains(food.GetType());
        }
    }
}
