namespace RefactorSpecialNumbers
{
    using System;
    public class RefactorSpecialNumbersMain
    {
        public static void Main(string[] args)
        {
            int maxNumber = int.Parse(Console.ReadLine());
            for (int number = 1; number <= maxNumber; number++)
            {
                int current = number;
                int digitsSum = 0;

                while (current > 0)
                {
                    digitsSum += current % 10;
                    current /= 10;
                }

                bool isSpecial = (digitsSum == 5) || (digitsSum == 7) || (digitsSum == 11);
                Console.WriteLine("{0} -> {1}", number, isSpecial);
            }
        }
    }
}
