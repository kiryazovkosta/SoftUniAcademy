namespace CalculateRectangleArea
{
    #region Using

    using System;

    #endregion

    public class Calculate
    {
        private static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(width)));
            double height = double.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(height)));

            double area = CalculateRectangleArea(width, height);
            Console.WriteLine(area);
        }

        private static double CalculateRectangleArea(double width, double height)
        {
            return width * height;
        }
    }
}