using System;

namespace UniquePinCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstLimit = int.Parse(Console.ReadLine());
            int secondLimit = int.Parse(Console.ReadLine());
            int thirdLimit = int.Parse(Console.ReadLine());
            for (int i = 2; i <= firstLimit; i++)
            {
                if (i % 2 != 0)
                {
                    continue;
                }

                for (int j = 2; j <= secondLimit; j++)
                {
                    bool isPrime = true;
                    for (int p = 2; p < j && p <= 7; p++)
                    {
                        if (j % p == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    if (!isPrime)
                    {
                        continue;
                    }

                    for (int k = 2; k <= thirdLimit; k++)
                    {
                        if (k % 2 != 0)
                        {
                            continue;
                        }

                        Console.WriteLine($"{i} {j} {k}");
                    }
                }
            }
        }
    }
}
