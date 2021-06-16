namespace MultiplyEvensByOdds
{
    #region Using

    using System;

    #endregion

    public class Multiply
    {
        private static void Main(string[] args)
        {
            int number = Math.Abs(
                int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(number))));

            int sum = GetMultipleOfEvenAndOdds(number);
            Console.WriteLine(sum);
        }

        private static int GetMultipleOfEvenAndOdds(int number)
        {
            int evenSum = GetSumOfEvenDigits(number);
            int oddSum = GetSumOfOddDigits(number);

            return evenSum * oddSum;
        }

        private static int GetSumOfOddDigits(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                int digit = number % 10;
                number /= 10;
                if (digit % 2 == 0)
                {
                    sum += digit;
                }
            }

            return sum;
        }

        private static int GetSumOfEvenDigits(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                int digit = number % 10;
                number /= 10;
                if (digit % 2 != 0)
                {
                    sum += digit;
                }
            }

            return sum;
        }
    }
}