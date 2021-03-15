namespace TrapezoidArea
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            double b1 = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double b2 = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double h = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            double area = ((b1 + b2) / 2) * h;
            Console.WriteLine($"{area:F2}");
        }
    }
}