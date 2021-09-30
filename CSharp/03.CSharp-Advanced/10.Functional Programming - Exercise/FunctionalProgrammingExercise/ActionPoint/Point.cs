namespace ActionPoint
{
    using System;
    using System.Linq;

    public class Point
    {
        static void Main(string[] args)
        {
            Action<string> print = Console.WriteLine;
            Console.ReadLine()?.Split(" ").ToList().ForEach(print);
        }
    }
}