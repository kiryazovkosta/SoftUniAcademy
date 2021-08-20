namespace InchesToCentimeters
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            double centimeters = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double inches = centimeters * 2.54;
            Console.WriteLine(inches);
        }
    }
}
