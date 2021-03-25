namespace PointOnRectangleBorder
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            bool isX = (x == x1 || x == x2) && (y >= y1 && y <= y2);
            bool isY = (y == y1 || y == y2) && (x >= x1 && x <= x2);
            if (isX || isY)
            {
                Console.WriteLine("Border");
            }
            else
            {
                Console.WriteLine("Inside / Outside");
            }
        }
    }
}
