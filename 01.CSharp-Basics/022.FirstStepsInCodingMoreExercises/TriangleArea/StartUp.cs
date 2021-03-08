namespace TriangleArea
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double area = (side * height) / 2;
            Console.WriteLine($"{area:F2}");
        }
    }
}
