// ------------------------------------------------------------------------------------------------
//  <copyright file="Win.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace ShootForTheWin
{
    #region Using

    using System;
    using System.Linq;

    #endregion

    public class Win
    {
        private static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray() ?? new int[] { };

            string input = Console.ReadLine();
            int counter = 0;
            while (input != "End")
            {
                int index = int.Parse(input);
                if (index >= 0 && index < numbers.Length && numbers[index] != -1)
                {
                    counter++;
                    int value = numbers[index];
                    numbers[index] = -1;
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (numbers[i] == -1)
                        {
                            continue;
                        }

                        if (numbers[i] <= value)
                        {
                            numbers[i] += value;
                        }
                        else
                        {
                            numbers[i] -= value;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {counter} -> {string.Join(" ", numbers)}");
        }
    }
}