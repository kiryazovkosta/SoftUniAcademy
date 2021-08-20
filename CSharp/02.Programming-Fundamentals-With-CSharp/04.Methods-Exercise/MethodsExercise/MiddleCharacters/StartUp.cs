// ------------------------------------------------------------------------------------------------
//  <copyright file="Program.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace MiddleCharacters
{
    #region Using

    using System;

    #endregion

    public class StartUp
    {
        private static void Main(string[] args)
        {
            string text = Console.ReadLine();
            GetMiddleCharacters(text);
        }

        private static void GetMiddleCharacters(string text)
        {
            if (text.Length % 2 == 0)
            {
                Console.Write(text[(text.Length - 1) / 2]);
                
            }
            Console.Write(text[text.Length / 2]);
        }
    }
}