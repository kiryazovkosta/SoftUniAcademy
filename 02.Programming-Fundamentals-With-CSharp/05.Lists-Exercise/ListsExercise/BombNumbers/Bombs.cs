namespace BombNumbers
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class Bombs
    {
        private static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList() 
                                ?? new List<int>();

            int[] bombData = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()
                ?? new int[] { };

            int number = bombData[0];
            int range = bombData[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == number)
                {
                    for (int j = i - range; j <= i + range; j++)
                    {
                        if (j < 0 || j > numbers.Count - 1)
                        {
                            continue;
                        }

                        numbers[j] = 0;
                    }
                }
            }

            Console.WriteLine(numbers.Sum());
        }
    }
}