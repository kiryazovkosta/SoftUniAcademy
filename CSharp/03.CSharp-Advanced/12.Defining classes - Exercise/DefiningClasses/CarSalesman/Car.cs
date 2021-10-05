namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = int.MinValue;
            this.Color = "n/a";
        }

        public string Model
        {
            get => this.model;
            private set => this.model = value;
        }

        public Engine Engine

        {
            get => this.engine;
            private set => this.engine = value;
        }

        public int Weight
        {
            get => this.weight;
            set => this.weight = value;
        }

        public string Color
        {
            get => this.color;
            set => this.color = value;
        }

        public override string ToString()
        {
            return $"{this.Model}:\n"
                   + $"  {this.Engine.ToString()}\n"
                   + $"  Weight: {this.GetWeightAsString()}\n"
                   + $"  Color: {this.GetColorAsString()}";
        }

        private string GetWeightAsString()
        {
            return this.Weight >= 0 ? this.Weight.ToString() : "n/a";
        }

        private string GetColorAsString()
        {
            return string.IsNullOrWhiteSpace(this.Color) ? "n/a" : this.Color;
        }
    }
}
