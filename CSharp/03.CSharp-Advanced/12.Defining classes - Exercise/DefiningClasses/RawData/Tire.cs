namespace DefiningClasses
{
    public class Tire
    {
        private int age;
        private double pressure;

        public Tire(int age, double pressure)
        {
            this.Age = age;
            this.Pressure = pressure;
        }

        public int Age
        {
            get => this.age;
            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentException(nameof(this.Age));
                }

                this.age = value;
            }
        }

        public double Pressure
        {
            get => this.pressure;
            set => this.pressure = value;
        }
    }
}
