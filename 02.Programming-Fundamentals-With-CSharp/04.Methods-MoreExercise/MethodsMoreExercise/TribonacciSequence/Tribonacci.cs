using System;

namespace TribonacciSequence
{
    public class Program
    {
        static long[] records = new long[10000];

        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(number)));
            for (int i = 1; i <= number; i++)
            {
                long result = CalcTribonachi(i);
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
            else if (number == 3)
            {
                records[number] = 2;
                return 2;
            }
            else
            {
                long result =  CalcTribonachi(number - 3) + CalcTribonachi(number - 2) + CalcTribonachi(number - 1);
                records[number] = result;
                return result;
            }
        }
    }
}
