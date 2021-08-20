namespace HalfSumElement
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int max = int.MinValue;
            int sum = 0;

            for (int i = 0; i < size; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number;
                if (number > max)
                {
                    max = number;
                }
            }

            int sumWithoutMax = sum - max;
            if (sumWithoutMax == max)
            {
                Console.WriteLine($"Yes{Environment.NewLine}Sum = {max}");
            }
            else
            {
                Console.WriteLine($"No{Environment.NewLine}Diff = {Math.Abs(sumWithoutMax-max)}");
            }
        }
    }
}
