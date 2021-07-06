// ------------------------------------------------------------------------------------------------
//  <copyright file="Target.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace MovingTarget
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class Target
    {
        private static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList() ?? new List<int>() { };

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] command = input?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? new string[] { };
                string operation = command[0];
                int index = int.Parse(command[1]);
                int value = int.Parse(command[2]);
                switch (operation)
                {
                    case "Shoot":
                        Shoot(targets, index, value);
                        break;

                    case "Add":
                        Add(targets, index, value);
                        break;

                    case "Strike":
                        Strike(targets, index, value);
                        break;

                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join("|", targets));
        }

        private static void Strike(List<int> targets, int index, int radius)
        {
            int beginIndex = index - radius;
            int endIndex = index + radius;

            if (beginIndex < 0 || endIndex >= targets.Count )
            {
                Console.WriteLine("Strike missed!");
                return;
            }

            targets.RemoveRange(beginIndex, radius * 2 + 1);
        }

        private static void Add(List<int> targets, int index, int value)
        {
            if (IndexIsValid(targets, index))
            {
                targets.Insert(index, value);
            }
            else
            {
                Console.WriteLine("Invalid placement!");
            }
        }

        private static void Shoot(List<int> targets, int index, int power)
        {
            if (IndexIsValid(targets, index))
            {
                targets[index] -= power;
                if (targets[index] <= 0)
                {
                    targets.RemoveAt(index);
                }
            }
        }

        private static bool IndexIsValid(List<int> targets, int index)
        {
            return index >= 0 && index < targets.Count;
        }
    }
}