namespace WildFarm.Models.Animals.Mammals.Felines
{
    public abstract class Feline : Mammal
    {
        private string breed;

        protected Feline(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        private string Breed
        {
            get => this.breed;
            set => this.breed = value;
        }

        public override string ToString()
        {
            return
                $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
