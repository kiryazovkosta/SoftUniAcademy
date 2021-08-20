namespace EvenNumber
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(number)));
            while (number % 2 != 0)
            {
                Console.WriteLine("Please write an even number.");
                number = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(number)));
            }

            Console.WriteLine($"The number is: {Math.Abs(number)}");
        }
    }
}
