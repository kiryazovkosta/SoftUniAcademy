// ------------------------------------------------------------------------------------------------
//  <copyright file="Words.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace RandomizeWords
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    internal class Words
    {
        private static void Main(string[] args)
        {
            var words = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList() ??
                        new List<string>();

            var rnd = new Random();
            while (words.Count > 0)
            {
                var index = rnd.Next(0, words.Count);
                var item = words[index];
                Console.WriteLine(item);
                words.RemoveAt(index);
            }
        }
    }
}