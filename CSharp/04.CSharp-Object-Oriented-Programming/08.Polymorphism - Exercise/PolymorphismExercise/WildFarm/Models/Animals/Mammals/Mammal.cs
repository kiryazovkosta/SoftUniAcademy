namespace WildFarm.Models.Animals.Mammals
{
    public abstract class Mammal : Animal
    {
        private string livingRegion;

        protected Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        protected string LivingRegion
        {
            get => this.livingRegion;
            private set => this.livingRegion = value;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{base.Name}, {base.Weight}, {this.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
