namespace PascalTriangle
{
    using System;
    public class PascalTriangleMain
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(size)));
            int value = 1;
            for (int i = 0; i < size; i++)
            {
                string row = string.Empty;
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                    {
                        value = 1;
                    }
                    else
                    {
                        value = value * (i - j + 1) / j;
                    }

                    row += $"{value} ";
                }

                Console.WriteLine(string.Join("", row));
            }
        }
    }
}