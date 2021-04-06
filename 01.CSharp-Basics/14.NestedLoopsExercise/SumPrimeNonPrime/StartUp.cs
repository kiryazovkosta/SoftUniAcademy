namespace SumPrimeNonPrime
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = string.Empty;
            int primeSum = 0;
            int nonPrimeSum = 0;
            while ((input = Console.ReadLine()) != "stop")
            {
                int number = int.Parse(input);
                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else if (number > 0)
                {
                    bool isPrime = true;
                    for (int i = 2; i < number; i++)
                    {
                        if (number % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    if (isPrime)
                    {
                        primeSum += number;
                    }
                    else
                    {
                        nonPrimeSum += number;
                    }
                }
            }

            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}
