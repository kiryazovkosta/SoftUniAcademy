namespace PassedOrFailed
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine() 
                ?? throw new ArgumentException(nameof(grade)));
            if (grade >= 3.0)
            {
                Console.WriteLine("Passed!");
            }
            else
            {
                Console.WriteLine("Failed!");
            }
        }
    }
}
