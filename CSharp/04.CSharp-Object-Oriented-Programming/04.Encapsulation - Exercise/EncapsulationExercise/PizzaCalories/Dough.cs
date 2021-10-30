namespace PizzaCalories
{
    using System;

    public class Dough
    {
        private const int CaloriesPerGram = 2;

        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType 
        { 
            get => flourType;
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }
        public string BakingTechnique 
        { 
            get => bakingTechnique;
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }
        public int Weight 
        { 
            get => weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public double Calories()
        {
            double flourTypeModifier = 1.0;
            if (this.FlourType.ToLower() == "white")
            {
                flourTypeModifier = 1.5;
            }

            double bakingTechniqueModifier = 1.0;
            if (this.BakingTechnique.ToLower() == "crispy")
            {
                bakingTechniqueModifier = 0.9;
            }
            else if (this.BakingTechnique.ToLower() == "chewy")
            {
                bakingTechniqueModifier = 1.1;
            }

            return (this.Weight * CaloriesPerGram) * flourTypeModifier * bakingTechniqueModifier;
        }
    }
}
