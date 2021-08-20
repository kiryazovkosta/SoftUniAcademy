namespace LeftAndRightSum
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int leftSum = 0;
            for (int i = 0; i < number; i++)
            {
                int a = int.Parse(Console.ReadLine());
                leftSum += a;
            }

            int rightSum = 0;
            for (int i = 0; i < number; i++)
            {
                int a = int.Parse(Console.ReadLine());
                rightSum += a;
            }

            if (leftSum == rightSum)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(leftSum-rightSum)}");
            }
        }
    }
}
