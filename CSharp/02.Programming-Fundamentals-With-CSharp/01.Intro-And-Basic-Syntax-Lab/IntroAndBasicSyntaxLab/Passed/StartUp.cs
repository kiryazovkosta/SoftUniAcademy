namespace Passed
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine() 
                ?? throw new InvalidCastException(nameof(grade)));
            if (grade >= 3.00)
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}