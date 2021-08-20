// ------------------------------------------------------------------------------------------------
//  <copyright file="Program.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace TopNumber
{
    #region Using

    using System;

    #endregion

    public class Top
    {
        private static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(size)));
            for (int i = 1; i <= size; i++)
            {
                int number = i;
                if (IsTopNumber(number))
                {
                    Console.WriteLine(number);
                }
            }
        }

        private static bool IsTopNumber(int number)
        {
            bool isTop = false;
            if (IsDigitsSumDivideByEight(number))
            {
                if (IsHoldLeastOneOddDigit(number))
                {
                    isTop = true;
                }
            }

            return isTop;
        }

        private static bool IsHoldLeastOneOddDigit(int number)
        {
            bool hasOddDigit = false;
            while (number > 0)
            {
                int digit = number % 10;
                if (digit % 2 != 0)
                {
                    hasOddDigit = true;
                    break;
                }

                number /= 10;
            }

            return hasOddDigit;
        }

        private static bool IsDigitsSumDivideByEight(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                int digit = number % 10;
                sum += digit;
                number /= 10;
            }

            return sum % 8 == 0;
        }
    }
}