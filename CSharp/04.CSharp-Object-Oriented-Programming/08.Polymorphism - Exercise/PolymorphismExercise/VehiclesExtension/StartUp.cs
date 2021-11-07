namespace VehiclesExtension
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(" ");
            Vehicle car = new Car(double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3]));
            data = Console.ReadLine().Split(" ");
            Vehicle truck = new Truck(double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3]));
            data = Console.ReadLine().Split(" ");
            Vehicle bus = new Bus(double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3]));

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                data = Console.ReadLine().Split(" ");
                string operation = data[0] + data[1];
                double value = double.Parse(data[2]);
                try
                {
                    switch (operation)
                    {
                        case "DriveCar":
                            Console.WriteLine(car.Drive(value));
                            break;

                        case "DriveTruck":
                            Console.WriteLine(truck.Drive(value));
                            break;

                        case "DriveBus":
                            Console.WriteLine(bus.Drive(value));
                            break;

                        case "DriveEmptyBus":
                            var b = (Bus)bus;
                            b.TurnOffAirConditioner();
                            Console.WriteLine(b.Drive(value));
                            b.TurnOnAirConditioner();
                            break;

                        case "RefuelCar":
                            car.Refuel(value);
                            break;

                        case "RefuelTruck":
                            truck.Refuel(value);
                            break;

                        case "RefuelBus":
                            bus.Refuel(value);
                            break;

                        default:
                            break;
                    }
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
