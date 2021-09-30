namespace CustomMinFunction
{
    using System;
    using System.Linq;

    public class Min
    {
        static void Main(string[] args)
        {
            Func<int[], int> customMin = CustomMin;
            int[] numbers = Console.ReadLine()?.Split(" ").Select(int.Parse).ToArray();
            int min = customMin(numbers);
            Console.WriteLine(min);
        }

        public static int CustomMin(int[] numbers)
        {
            int min = int.MaxValue;
            foreach (var number in numbers)
            {
                if (number < min)
                {
                    min = number;
                }
            }

            return min;
        }
    }
}