// ------------------------------------------------------------------------------------------------
//  <copyright file="Program.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace SmallestOfThreeNumbers
{
    #region Using

    using System;

    #endregion
    public class MIn
    {
        private static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(a)));
            int b = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(b)));
            int c = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(c)));

            int min = GetMin(GetMin(a, b), c);
            Console.WriteLine(min);
        }

        private static int GetMin(int a, int b)
        {
            if (a <= b)
            {
                return a;
            }

            return b;
        }
    }
}