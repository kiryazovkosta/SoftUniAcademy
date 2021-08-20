// ------------------------------------------------------------------------------------------------
//  <copyright file="Lift.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace TheLift
{
    #region Using

    using System;
    using System.Linq;

    #endregion

    public class Lift
    {
        private static void Main(string[] args)
        {
            int capacity = 4;
            int peoples = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(peoples)));
            int[] wagons = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            bool noMorePeoples = false;

            for (int i = 0; i < wagons.Length; i++)
            {
                int current = wagons[i];
                int diff = peoples - (capacity - current);
                if (diff == 0)
                {
                    wagons[i] = capacity;
                    noMorePeoples = true;
                    peoples -= (capacity - current);
                    break;
                }
                else if (diff < 0)
                {
                    wagons[i] = peoples;
                    noMorePeoples = true;
                    peoples = 0;
                    break;
                }
                else
                {
                    wagons[i] = capacity;
                    peoples -= (capacity - current);
                }
            }

            bool isEmpty = wagons.Any(x => x != capacity);

            if (noMorePeoples && isEmpty)
            {
                Console.WriteLine($"The lift has empty spots!");
                Console.WriteLine(string.Join(" ", wagons));
            }
            else if (peoples > 0 && !isEmpty)
            {
                Console.WriteLine($"There isn't enough space! {peoples} people in a queue!");
                Console.WriteLine(string.Join(" ", wagons));
            }
            else if (peoples == 0 && !isEmpty)
            {
                Console.WriteLine(string.Join(" ", wagons));
            }
        }
    }
}