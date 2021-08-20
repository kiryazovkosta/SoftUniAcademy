// ------------------------------------------------------------------------------------------------
//  <copyright file="Modifier.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace ArrayModifier
{
    #region Using

    using System;
    using System.Linq;

    #endregion

    public class Modifier
    {
        private static void Main(string[] args)
        {
            long[] numbers = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray() ?? new long[] { };
            string input = Console.ReadLine() ?? string.Empty;
            while (input != "end")
            {
                string[] command = input?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? new string[] { };
                string operation = command[0];
                switch (operation)
                {
                    case "swap":
                        int index1 = int.Parse(command[1]);
                        int index2 = int.Parse(command[2]);
                        Swap(numbers, index1, index2);
                        break;

                    case "multiply":
                        index1 = int.Parse(command[1]);
                        index2 = int.Parse(command[2]);
                        Multiply(numbers, index1, index2);
                        break;

                    case "decrease":
                        Decrease(numbers);
                        break;

                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void Swap(long[] numbers, int index1, int index2)
        {
            long temp = numbers[index1];
            numbers[index1] = numbers[index2];
            numbers[index2] = temp;
        }

        private static void Multiply(long[] numbers, int index1, int index2)
        {
            long result = numbers[index1] * numbers[index2];
            numbers[index1] = result;
        }

        private static void Decrease(long[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i]--;
            }
        }
    }
}