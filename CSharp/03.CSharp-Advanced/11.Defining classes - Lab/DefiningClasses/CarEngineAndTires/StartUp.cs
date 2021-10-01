namespace CarManufacturer
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var tires = new Tire[4]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(2, 0.5),
                new Tire(2, 2.3)
            };

            var engine = new Engine(560, 6300);
            var car = new Car("test", "User", 2020, 260, 8, engine, tires);
            var car1 = new Car();
            var car2 = new Car("test", "User", 2020);
            var car3 = new Car("test", "User", 2020, 260, 8);
            Console.WriteLine(car.WhoAmI());
            Console.WriteLine(car1.WhoAmI());
            Console.WriteLine(car2.WhoAmI());
            Console.WriteLine(car3.WhoAmI());
        }
    }
}
