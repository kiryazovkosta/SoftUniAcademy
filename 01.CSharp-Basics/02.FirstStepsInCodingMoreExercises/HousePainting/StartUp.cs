namespace HousePainting
{
    using System;
    using System.Xml.Schema;

    public class StartUp
    {
        const double greenPaintPerLitter = 3.4;
        const double redPaintPerLitter = 4.3;

        private const double frontWindowX = 1.2;
        private const double frontWindowH = 2;

        private const double sideWindowX = 1.5;

        public static void Main()
        {
            double x = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double y = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double h = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            double backWall = x * x;
            double frontWall = backWall - (frontWindowX * frontWindowH);
            double sideWalls = ((x * y) - (sideWindowX * sideWindowX)) * 2;
            double greenArea = frontWall + backWall + sideWalls;
            double allGreenPaint = greenArea / greenPaintPerLitter;
            Console.WriteLine($"{allGreenPaint:F2}");

            double sideRoofs = x * y * 2;
            double frontRoof = (x * h) / 2;
            double backRoof = frontRoof;
            double redArea = sideRoofs + frontRoof + backRoof;
            double allRedPaint = redArea / redPaintPerLitter;
            Console.WriteLine($"{allRedPaint:F2}");
        }
    }
}
