// ------------------------------------------------------------------------------------------------
//  <copyright file="Repeater.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace RepeatString
{
    #region Using

    using System;
    using System.Text;

    #endregion

    public class Repeater
    {
        private static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int number = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(number)));

            string repeated = Repeat(text, number);
            Console.WriteLine(repeated);
        }

        private static string Repeat(string text, int number)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < number; i++)
            {
                builder.Append(text);
            }

            return builder.ToString();
        }
    }
}