// ------------------------------------------------------------------------------------------------
//  <copyright file="Strike.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace CounterStrike
{
    #region Using

    using System;

    #endregion

    public class Strike
    {
        private static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(energy)));
            string input = Console.ReadLine();
            int count = 0;
            bool failed = false;
            while (input != "End of battle")
            {
                int distance = int.Parse(input);
                if (distance > energy)
                {
                    failed = true;
                    break;
                }

                energy -= distance;
                count++;
                if (count % 3 == 0)
                {
                    energy += count;
                }

                input = Console.ReadLine();
            }

            if (failed)
            {
                Console.WriteLine($"Not enough energy! Game ends with {count} won battles and {energy} energy");
            }
            else
            {
                Console.WriteLine($"Won battles: {count}. Energy left: {energy}");
            }
        }
    }
}