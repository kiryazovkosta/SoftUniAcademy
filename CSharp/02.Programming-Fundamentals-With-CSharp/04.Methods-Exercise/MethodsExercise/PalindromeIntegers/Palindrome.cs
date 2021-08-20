// ------------------------------------------------------------------------------------------------
//  <copyright file="Program.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace PalindromeIntegers
{
    #region Using

    using System;

    #endregion

    public class Palindrome
    {
        private static void Main(string[] args)
        {
            string input = Console.ReadLine() ?? throw new ArgumentException(nameof(input));
            while (input != "END")
            {
                int number = int.Parse(input ?? throw new ArgumentException(nameof(number)));
                var isPalindrome = IsPalindrome(number).ToString().ToLower();
                Console.WriteLine(isPalindrome);
                input = Console.ReadLine() ?? throw new ArgumentException(nameof(input));
            }
        }

        public static bool IsPalindrome(int n)
        {
            var isPalindrome = true;
            var number = n.ToString();
            for (int i = 0, j = number.Length - 1; i < number.Length / 2; i++, j--)
            {
                if (number[i] != number[j])
                {
                    isPalindrome = false;
                    break;
                }
            }

            return isPalindrome;
        }
    }
}