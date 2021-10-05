namespace DefiningClasses
{
    public class Cargo
    {
        private CargoType type;
        private int weight;

        public Cargo(CargoType type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public CargoType Type
        {
            get => this.type;
            set => this.type = value;
        }

        public int Weight
        {
            get => this.weight;
            set => this.weight = value;
        }
    }
}
