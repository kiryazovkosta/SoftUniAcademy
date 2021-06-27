// ------------------------------------------------------------------------------------------------
//  <copyright file="StartUp.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace FactorialDivision
{
    #region Using

    using System;

    #endregion

    public class StartUp
    {
        private static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(a)));
            int b = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(b)));

            var fA = CalcFactorial(a);
            var fB = CalcFactorial(b);

            Console.WriteLine($"{fA / fB:F2}");
        }

        private static double CalcFactorial(int a)
        {
            double result = 1;
            for (var i = 2; i <= a; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}