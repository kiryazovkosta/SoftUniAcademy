
namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Lot
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] data = input.Split(", ");
                string direction = data[0];
                string car = data[1];
                if (direction == "IN")
                {
                    parking.Add(car);
                }
                else
                {
                    parking.Remove(car);
                }

                input = Console.ReadLine();
            }

            if (parking.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, parking));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}