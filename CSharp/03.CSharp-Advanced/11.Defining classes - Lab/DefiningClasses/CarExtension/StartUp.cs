namespace CarManufacturer
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car
            {
                Make = "Toyota",
                Model = "Corolla",
                Year = 2014,
                FuelConsumption = 200,
                FuelQuantity = 200
            };
            car.Drive(2000);
            Console.WriteLine(car.WhoAmI());
        }
    }
}
