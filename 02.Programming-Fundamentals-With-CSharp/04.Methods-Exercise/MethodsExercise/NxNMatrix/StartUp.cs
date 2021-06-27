// ------------------------------------------------------------------------------------------------
//  <copyright file="StartUp.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace NxNMatrix
{
    #region Using

    using System;

    #endregion

    public class StartUp
    {
        private static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(number)));
            PrintMatrix(number);
        }

        private static void PrintMatrix(int number)
        {
            for (int row = 0; row < number; row++)
            {
                for (int col = 0; col < number; col++)
                {
                    Console.Write($"{number} ");
                }

                Console.WriteLine();
            }
        }
    }
}