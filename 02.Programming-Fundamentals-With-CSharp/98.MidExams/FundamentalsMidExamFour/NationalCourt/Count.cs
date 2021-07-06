// ------------------------------------------------------------------------------------------------
//  <copyright file="Count.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace NationalCourt
{
    #region Using

    using System;

    #endregion

    public class Count
    {
        private static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            int h = 0;
            int t = a + b + c;
            while (p > 0)
            {
                h++;
                if (h % 4 == 0)
                {
                    continue;
                }

                p -= t;
            }

            Console.WriteLine($"Time needed: {h}h.");
        }
    }
}