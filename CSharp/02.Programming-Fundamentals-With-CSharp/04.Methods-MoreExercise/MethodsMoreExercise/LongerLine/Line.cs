using System;

namespace LongerLine
{
    class Line
    {
        static void Main(string[] args)
        {
            double pX1 = double.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(pX1)));
            double pY1 = double.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(pY1)));
            double pX2 = double.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(pX2)));
            double pY2 = double.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(pY2)));

            double sX1 = double.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(sX1)));
            double sY1 = double.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(sY1)));
            double sX2 = double.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(sX2)));
            double sY2 = double.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(sY2)));

            double[] lineCoordinates = GetLongestLineCoordinates(pX1, pY1, pX2, pY2, sX1, sY1, sX2, sY2);
            PrintLine(lineCoordinates);
        }

        private static double[] GetLongestLineCoordinates(double pX1, double pY1, double pX2, double pY2, double sX1, double sY1, double sX2, double sY2)
        {
            double[] coordinates = new double[4];
            double pLength = CalculateLength(pX1, pY1);
            double sLength = CalculateLength(sX1, sY1);
            if (pLength >= sLength)
            {
                coordinates[0] = pX1;
                coordinates[1] = pY1;
                coordinates[2] = pX2;
                coordinates[3] = pY2;
            }
            else
            {
                coordinates[0] = sX1;
                coordinates[1] = sY1;
                coordinates[2] = sX2;
                coordinates[3] = sY2;
            }

            return coordinates;
        }

        private static double CalculateLength(double x, double y)
        {
            double a = Math.Abs(x) - 0;
            double b = Math.Abs(y) - 0;

            double c = Math.Sqrt(a * a + b * b);
            return c;
        }

        private static void PrintLine(double[] point)
        {
            double p1Length = CalculateLength(point[0], point[1]);
            double p2Length = CalculateLength(point[2], point[3]);
            if (p1Length < p2Length)
            {
                Console.WriteLine($"({point[0]}, {point[1]})({point[2]}, {point[3]})");
            }
            else
            {
                Console.WriteLine($"({point[2]}, {point[3]})({point[0]}, {point[1]})");
            }
        }
    }
}
