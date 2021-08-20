// ------------------------------------------------------------------------------------------------
//  <copyright file="Delivery.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace HeartDelivery
{
    #region Using

    using System;
    using System.Linq;

    #endregion

    public class Delivery
    {
        private static void Main(string[] args)
        {
            int[] houses = Console.ReadLine().Split("@", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int houseIndex = 0;
            int houseCount = 0;

            string operation = Console.ReadLine();
            while (operation != "Love!")
            {
                string[] command = operation?.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int steps = int.Parse(command[1] ?? throw new NullReferenceException(nameof(steps)));

                houseIndex += steps;
                if (houseIndex < 0 || houseIndex >= houses.Length)
                {
                    houseIndex = 0;
                }

                if (houses[houseIndex] > 0)
                {
                    houses[houseIndex] -= 2;
                    if (houses[houseIndex] == 0)
                    {
                        Console.WriteLine($"Place {houseIndex} has Valentine's day.");
                        houseCount++;
                    }
                }
                else
                {
                    Console.WriteLine($"Place {houseIndex} already had Valentine's day.");
                }


                operation = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {houseIndex}.");
            Console.WriteLine(houses.All(h => h == 0)
                ? "Mission was successful."
                : $"Cupid has failed {houses.Count(h => h != 0)} places.");
        }
    }
}