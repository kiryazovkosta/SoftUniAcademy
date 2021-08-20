namespace TribonacciSequence
{
    #region Using

    using System;

    #endregion

    public class Tribonacci
    {
        private static readonly long[] records = new long[10000];

        private static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(number)));
            for (var i = 1; i <= number; i++)
            {
                var result = CalcTribonachi(i);
                Console.Write($"{result} ");
            }
        }

        private static long CalcTribonachi(int number)
        {
            if (records[number] != 0)
            {
                return records[number];
            }

            if (number == 1 || number == 2)
            {
                records[number] = 1;
                return 1;
            }

            if (number == 3)
            {
                records[number] = 2;
                return 2;
            }

            var result = CalcTribonachi(number - 3) + CalcTribonachi(number - 2) + CalcTribonachi(number - 1);
            records[number] = result;
            return result;
        }
    }
}