namespace SquareArea
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            int side = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int area = side * side;
            Console.WriteLine(area);
        }
    }
}