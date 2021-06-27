// ------------------------------------------------------------------------------------------------
//  <copyright file="Point.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace CenterPoint
{
    #region Using

    using System;

    #endregion

    public class Point
    {
        private static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(x1)));
            double y1 = double.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(x1)));
            double x2 = double.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(x1)));
            double y2 = double.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(x1)));

            double[] point = ClosestPointToTheCenter(x1, y1, x2, y2);
            PrintPoint(point);
        }

        private static void PrintPoint(double[] point)
        {
            Console.WriteLine($"({point[0]}, {point[1]})");
        }

        private static double[] ClosestPointToTheCenter(double x1, double y1, double x2, double y2)
        {
            double[] coordinates = new double[2];
            double firstDistance = CalculateDistance(x1, y1);
            double secondDistance = CalculateDistance(x2, y2);
            if (firstDistance <= secondDistance)
            {
                coordinates[0] = x1;
                coordinates[1] = y1;
            }
            else
            {
                coordinates[0] = x2;
                coordinates[1] = y2;
            }

            return coordinates;
        }

        private static double CalculateDistance(double x1, double y1)
        {
            double a = Math.Abs(x1) - 0;
            double b = Math.Abs(y1) - 0;

            double c = Math.Sqrt(a * a + b * b);
            return c;
        }
    }
}