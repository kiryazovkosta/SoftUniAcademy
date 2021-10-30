
namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name 
        { 
            get => name;
            private set
            {
                if (value == string.Empty || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public int Count => this.toppings.Count;

        public Dough Dough { private get => dough; set => dough = value; }

        public double Calories()
        {
            double totalCalories = 0;
            totalCalories += this.Dough.Calories();
            foreach (var topping in this.toppings)
            {
                totalCalories += topping.Calories();
            }

            return totalCalories;
        }

        public void AddTopping(Topping topping)
        {
            if (this.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }
    }
}