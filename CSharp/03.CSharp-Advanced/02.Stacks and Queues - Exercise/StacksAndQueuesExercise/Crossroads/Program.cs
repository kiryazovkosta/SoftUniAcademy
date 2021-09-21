using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightInSeconds = int.Parse(Console.ReadLine());
            int freeWindowInSeconds = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int carCounter = 0;
            bool isHitted = false;

            string command = Console.ReadLine();
            while (command != "END")
            {
                if (command != "green")
                {
                    string car = command;
                    cars.Enqueue(car);
                }
                else
                {
                    int currentGreenLightInSeconds = greenLightInSeconds;
                    while (currentGreenLightInSeconds > 0 && cars.Count > 0)
                    {
                        string car = cars.Dequeue();
                        if (car.Length <= currentGreenLightInSeconds)
                        {
                            currentGreenLightInSeconds -= car.Length;
                            carCounter++;
                            continue;
                        }

                        if (car.Length <= currentGreenLightInSeconds + freeWindowInSeconds)
                        {
                            currentGreenLightInSeconds -= (car.Length + freeWindowInSeconds);
                            carCounter++;
                            continue;
                        }

                        char hitChar = car[currentGreenLightInSeconds + freeWindowInSeconds];
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{car} was hit at {hitChar}.");
                        isHitted = true;
                        break;
                    }
                }

                if (isHitted)
                {
                    break;
                }

                command = Console.ReadLine();
            }

            if (!isHitted)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carCounter} total cars passed the crossroads.");
            }
        }
    }
}
