namespace FoldAndSum
{
    #region Using

    using System;
    using System.Linq;

    #endregion

    internal class FoldAndSumMain
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            var size = input.Length / 4;
            var first = new int[size * 2];
            var i = 0;
            for (var n = size - 1; i < size; i++, n--)
            {
                first[n] = input[i];
            }

            for (int k = input.Length - size, l = first.Length - 1; k < input.Length; k++, l--)
            {
                first[l] = input[k];
            }

            var second = new int[size * 2];
            for (var m = 0; i < input.Length - size; m++, i++)
            {
                second[m] = input[i];
            }

            for (var j = 0; j < size * 2; j++)
            {
                Console.Write($"{first[j] + second[j]} ");
            }
        }
    }
}