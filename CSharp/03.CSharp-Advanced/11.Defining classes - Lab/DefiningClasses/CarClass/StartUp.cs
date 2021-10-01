namespace CarManufacturer
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "Toyota";
            car.Model = "Corolla";
            car.Year = 2014;

            Console.WriteLine($"Make {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
        }
    }
}
