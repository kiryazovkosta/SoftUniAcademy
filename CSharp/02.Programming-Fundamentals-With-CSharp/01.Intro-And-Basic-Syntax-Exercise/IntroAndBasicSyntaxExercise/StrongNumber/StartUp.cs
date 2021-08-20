namespace StrongNumber
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int totalSum = 0;
            for (int i = 0; i < number.Length; i++)
            {
                int digit = int.Parse(number[i].ToString());
                if (digit > 0)
                {
                    int currentSum = 1;
                    for (int j = 1; j <= digit; j++)
                    {
                        currentSum *= j;
                    }

                    totalSum += currentSum;
                }
            }

            if (int.Parse(number) == totalSum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
