namespace AsciiSumator
{
    #region Using

    using System;

    #endregion

    internal class Sumator
    {
        private static void Main(string[] args)
        {
            char begin = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            string line = Console.ReadLine();

            if (begin > end)
            {
                char temp = begin;
                begin = end;
                end = temp;
            }

            long sum = 0;
            for (int i = 0; i < line.Length; i++)
            {
                char current = line[i];
                if (begin < current && end > current)
                {
                    sum += current;
                }
            }

            Console.WriteLine(sum);
        }
    }
}