// ------------------------------------------------------------------------------------------------
//  <copyright file="Big.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace BigFactorial
{
    #region Using

    using System;
    using System.Numerics;

    #endregion

    internal class Big
    {
        private static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(number)));

            BigInteger result = 1;
            for (var i = 2; i <= number; i++)
            {
                result *= i;
            }

            Console.WriteLine(result);
        }
    }
}