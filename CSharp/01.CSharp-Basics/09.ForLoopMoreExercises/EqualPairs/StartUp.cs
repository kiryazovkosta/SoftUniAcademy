namespace EqualPairs
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int prevDiff = 0;
            int maxDiff = 0;
            int firstSum = 0;
            int size = int.Parse(Console.ReadLine());
            for (int i = 0; i < size; i++)
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                int sum = a + b;

                if (i == 0)
                {
                    firstSum = sum;
                    prevDiff = sum;
                    maxDiff = sum;
                }
                else
                {
                    if (sum != prevDiff)
                    {
                        maxDiff = Math.Abs(sum - prevDiff);
                    }

                    prevDiff = sum;
                }

            }

            if (maxDiff == firstSum)
            {
                Console.WriteLine($"Yes, value={maxDiff}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={maxDiff}");
            }
        }
    }
}
