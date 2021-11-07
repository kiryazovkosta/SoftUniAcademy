namespace Vehicles
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(" ");
            Vehicle car = new Car(double.Parse(data[1]), double.Parse(data[2]));
            data = Console.ReadLine().Split(" ");
            Vehicle truck = new Truck(double.Parse(data[1]), double.Parse(data[2]));

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                data = Console.ReadLine().Split(" ");
                string operation = data[0] + data[1];
                double value = double.Parse(data[2]);
                switch (operation)
                {
                    case "DriveCar":
                        Console.WriteLine(car.Drive(value));
                        break;

                    case "DriveTruck":
                        Console.WriteLine(truck.Drive(value));
                        break;

                    case "RefuelCar":
                        car.Refuel(value);
                        break;

                    case "RefuelTruck":
                        truck.Refuel(value);
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
    }
}
