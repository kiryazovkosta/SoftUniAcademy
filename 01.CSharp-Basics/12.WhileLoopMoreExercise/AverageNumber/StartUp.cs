namespace AverageNumber
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            double sum = 0;
            for (int i = 0; i < size; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number;
            }

            Console.WriteLine($"{sum/size:F2}");
        }
    }
}
