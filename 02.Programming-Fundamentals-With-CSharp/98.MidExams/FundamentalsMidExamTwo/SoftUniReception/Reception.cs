// ------------------------------------------------------------------------------------------------
//  <copyright file="Reception.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace SoftUniReception
{
    #region Using

    using System;

    #endregion

    public class Reception
    {
        private static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(a)));
            int b = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(b)));
            int c = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(c)));

            int s = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(s)));

            int f = a + b + c;
            int h = 0;
            while (s > 0)
            {
                h++;
                if (h % 4 == 0)
                {
                    continue;
                }

                s -= f;
            }

            Console.WriteLine($"Time needed: {h}h.");
        }
    }
}