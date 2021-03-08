namespace CircleAreaAndPerimeter
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());
            double area = Math.PI * Math.Pow(radius, 2);
            double perimeter = 2 * Math.PI * radius;
            Console.WriteLine($"{area:F2}");
            Console.WriteLine($"{perimeter:F2}");
        }
    }
}
