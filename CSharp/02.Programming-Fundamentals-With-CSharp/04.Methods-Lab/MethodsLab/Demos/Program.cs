using System;

namespace Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CalculatePagesNumber(10, 10));
            Console.WriteLine(CalculatePagesNumber(15, 10));
            Console.WriteLine(CalculatePagesNumber(8, 10));
            Console.WriteLine(CalculatePagesNumber(0, 10));
        }

        private static int CalculatePagesNumber(int total, int page)
        {
            int pages = (int)Math.Ceiling(total * 1.0 / page);
            return pages;
        }
    }


}
