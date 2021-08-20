namespace EqualSumsEvenOddPosition
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            for (int i = first; i <= second; i++)
            {
                string number = i.ToString();
                int oddSum = 0;
                int evenSum = 0;
                for (int j = 1; j <= number.Length; j++)
                {
                    int n = int.Parse(number[j - 1].ToString());
                    if (j % 2 == 0)
                    {
                        evenSum += n;
                    }
                    else
                    {
                        oddSum += n;
                    }
                }

                if (oddSum == evenSum)
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}
