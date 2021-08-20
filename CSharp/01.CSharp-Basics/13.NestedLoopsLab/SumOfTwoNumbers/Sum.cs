namespace SumOfTwoNumbers
{
    using System;
    public class Sum
    {
        public static void Main(string[] args)
        {
            int counter = 0;
            bool isFound = false;
            int begin = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());

            int i = 0;
            int j = 0;
            for (i = begin; i <= end; i++)
            {
                for (j = begin; j <= end; j++)
                {
                    counter++;
                    if (i + j == number)
                    {
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    break;
                }
            }

            if (isFound)
            {
                Console.WriteLine($"Combination N:{counter} ({i} + {j} = {number})");
            }
            else
            {
                Console.WriteLine($"{counter} combinations - neither equals {number}");
            }
        }
    }
}
