// ------------------------------------------------------------------------------------------------
//  <copyright file="Program.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace Demos
{
    #region Using

    using System;
    using System.Collections.Generic;

    #endregion

    internal class Program
    {
        private static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>();
            dict.Add("a", 1);
            dict.Add("c", 2);
            dict.Add("b", 3);
            dict.Add("f", 4);
            dict.Add("d", 5);

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}->{item.Value}");
            }

            var sorted = new SortedDictionary<string, int>();
            sorted.Add("a", 1);
            sorted.Add("c", 2);
            sorted.Add("b", 3);
            sorted.Add("f", 4);
            sorted.Add("d", 5);

            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.Key}->{item.Value}");
            }
        }
    }
}