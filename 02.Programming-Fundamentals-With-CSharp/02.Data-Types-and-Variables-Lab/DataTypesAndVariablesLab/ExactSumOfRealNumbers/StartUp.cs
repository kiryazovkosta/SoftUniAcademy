namespace ExactSumOfRealNumbers
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine() 
                                 ?? throw new ArgumentException(nameof(size)));
            decimal total = 0.0m;
            for (int i = 0; i < size; i++)
            {
                decimal number = decimal.Parse(Console.ReadLine() 
                                               ?? throw new ArgumentException(nameof(number)));
                total += number;
            }

            Console.WriteLine(total);
        }
    }
}
