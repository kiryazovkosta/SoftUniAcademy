namespace FloatingEquality
{
    using System;
    public class FloatingEqualityMain
    {
        public static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine() ?? throw new ArgumentException());
            double b = double.Parse(Console.ReadLine() ?? throw new ArgumentException());
            if (Math.Abs(a - b) > 0.000001)
            {
                Console.WriteLine("False");
            }
            else
            {
                Console.WriteLine("True");
            }
        }
    }
}
