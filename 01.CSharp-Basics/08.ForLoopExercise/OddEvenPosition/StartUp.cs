using System;

namespace OddEvenPosition
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double oddSum = 0.0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenSum = 0.0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            int size = int.Parse(Console.ReadLine());
            for (int i = 1; i <= size; i++)
            {
                double number = double.Parse(Console.ReadLine());
                if (i % 2 != 0)
                {
                    oddSum += number;
                    if (oddMin > number)
                    {
                        oddMin = number;
                    }
                    if (oddMax < number)
                    {
                        oddMax = number;
                    }
                }
                else
                {
                    evenSum += number;
                    if (evenMin > number)
                    {
                        evenMin = number;
                    }
                    if (evenMax < number)
                    {
                        evenMax = number;
                    }
                }
            }

            Console.WriteLine($"OddSum={oddSum:F2},");
            if (size == 0)
            {
                Console.WriteLine($"OddMin=No,");
                Console.WriteLine($"OddMax=No,");
            }
            else
            {
                Console.WriteLine($"OddMin={oddMin:F2},");
                Console.WriteLine($"OddMax={oddMax:F2},");
            }

            Console.WriteLine($"EvenSum={evenSum:F2},");
            if (size <= 1)
            {
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No");
            }                       
            else                    
            {                       
                Console.WriteLine($"EvenMin={evenMin:F2},");
                Console.WriteLine($"EvenMax={evenMax:F2}");
            }
        }
    }
}
