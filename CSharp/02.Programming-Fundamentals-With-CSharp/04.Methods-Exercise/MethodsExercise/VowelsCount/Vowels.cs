// ------------------------------------------------------------------------------------------------
//  <copyright file="Vowels.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace VowelsCount
{
    #region Using

    using System;

    #endregion

    public class Vowels
    {
        private static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int count = CountVowels(text);
            Console.WriteLine(count);
        }

        private static int CountVowels(string text)
        {
            int counter = 0;
            foreach (var symbol in text)
            {
                if (IsVowel(symbol))
                {
                    counter++;
                }
            }

            return counter;
        }

        private static bool IsVowel(char symbol)
        {
            if (symbol == 'a' || symbol == 'e' || symbol == 'i' || symbol == 'o' || symbol == 'u'
                || symbol == 'A' || symbol == 'E' || symbol == 'I' || symbol == 'O' || symbol == 'U')
            {
                return true;
            }

            return false;
        }
    }
}