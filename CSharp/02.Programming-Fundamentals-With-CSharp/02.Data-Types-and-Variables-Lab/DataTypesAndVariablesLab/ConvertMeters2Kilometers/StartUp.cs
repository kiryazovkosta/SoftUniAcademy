namespace ConvertMeters2Kilometers
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            long meters = long.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(meters)));
            decimal kilometers = meters / 1000.00m;
            Console.WriteLine($"{kilometers:F2}");

        }
    }
}
