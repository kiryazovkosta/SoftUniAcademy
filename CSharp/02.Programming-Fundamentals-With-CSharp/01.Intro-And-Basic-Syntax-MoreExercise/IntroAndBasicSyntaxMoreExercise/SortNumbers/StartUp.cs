namespace SortNumbers
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int a = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(a)));
            int b = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(b)));
            int c = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(c)));

            if (a >= b && a >= c)
            {
                if (b >= c)
                {
                    Console.WriteLine($"{a}{Environment.NewLine}{b}{Environment.NewLine}{c}");
                }
                else
                {
                    Console.WriteLine($"{a}{Environment.NewLine}{c}{Environment.NewLine}{b}");
                }
            }
            else if (b >= a && b >= c)
            {
                if (a >= c)
                {
                    Console.WriteLine($"{b}{Environment.NewLine}{a}{Environment.NewLine}{c}");
                }
                else
                {
                    Console.WriteLine($"{b}{Environment.NewLine}{c}{Environment.NewLine}{a}");
                }
            }
            else if (c >= a && c >= b)
            {
                if (a >= b)
                {
                    Console.WriteLine($"{c}{Environment.NewLine}{a}{Environment.NewLine}{b}");
                }
                else
                {
                    Console.WriteLine($"{c}{Environment.NewLine}{b}{Environment.NewLine}{a}");
                }
            }
        }
    }
}
