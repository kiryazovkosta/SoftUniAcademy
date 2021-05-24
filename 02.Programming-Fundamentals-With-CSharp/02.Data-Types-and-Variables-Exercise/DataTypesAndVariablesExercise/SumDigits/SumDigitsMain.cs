namespace SumDigits
{
    using System;
    class SumDigitsMain
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            long sum = 0;
            while (number > 0)
            {
                int digit = (int)(number % 10);
                sum += digit;
                number /= 10;
            }

            Console.WriteLine(sum);
        }
    }
}
