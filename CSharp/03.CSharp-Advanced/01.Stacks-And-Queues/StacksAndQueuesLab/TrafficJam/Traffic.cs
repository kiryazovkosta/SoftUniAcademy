namespace TrafficJam
{
    using System;
    using System.Collections.Generic;

    public class Traffic
    {
        static void Main(string[] args)
        {
            int passedCarsCount = 0;
            Queue<string> cars = new Queue<string>();
            int passedCarsNumber = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            while (input != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < passedCarsNumber; i++)
                    {
                        if (cars.Count <= 0)
                        {
                            break;
                        }

                        string car = cars.Dequeue();
                        Console.WriteLine($"{car} passed!");
                        passedCarsCount++;
                    }
                }
                else
                {
                    string car = input;
                    cars.Enqueue(car);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{passedCarsCount} cars passed the crossroads.");
        }
    }
}
