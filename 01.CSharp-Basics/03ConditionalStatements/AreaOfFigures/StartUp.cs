namespace AreaOfFigures
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            string figureType = Console.ReadLine();
            double area = 0;
            switch (figureType)
            {
                case "square":
                    double aquareLength = double.Parse(Console.ReadLine());
                    area = aquareLength * aquareLength;
                    break;

                case "rectangle":
                    double rectangleLength = double.Parse(Console.ReadLine());
                    double rectangleWidth = double.Parse(Console.ReadLine());
                    area = rectangleLength * rectangleWidth;
                    break;

                case "circle":
                    double circleRadius = double.Parse(Console.ReadLine());
                    area = Math.PI * Math.Pow(circleRadius, 2);
                    break;

                case "triangle":
                    double triangleSideLength = double.Parse(Console.ReadLine());
                    double triangleSideHeight = double.Parse(Console.ReadLine());
                    area = (triangleSideLength * triangleSideHeight) / 2;
                    break;

                default:
                    break;
            }

            Console.WriteLine($"{area:F3}");
        }
    }
}
