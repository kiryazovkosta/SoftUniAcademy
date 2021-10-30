namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const decimal CoffeePrice = 3.50m;
        private const double CoffeeMilliliters = 50;

        public Coffee(string name, decimal price, double milliliters, double caffeine) 
            : base(name, price, milliliters)
        {
            this.Caffeine = caffeine;
        }

        public Coffee(string name, double caffeine)
            : this(name, CoffeePrice, CoffeeMilliliters, caffeine)
        {
        }

        public double Caffeine { get; set; }
    }
}