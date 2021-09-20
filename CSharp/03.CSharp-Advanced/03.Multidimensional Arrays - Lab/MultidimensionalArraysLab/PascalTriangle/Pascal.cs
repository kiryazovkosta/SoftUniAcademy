namespace PascalTriangle
{
    using System;
    public class Pascal
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] triangle = new long[rows][];
            for (int row = 0; row < triangle.Length; row++)
            {
                triangle[row] = new long[row + 1];
            }

            for (int row = 0; row < triangle.Length; row++)
            {
                if (row == 0)
                {
                    triangle[row][0] = 1;
                }
                else
                {
                    triangle[row][0] = 1;
                    triangle[row][triangle[row].Length - 1] = 1;
                    for (int col = 1; col < triangle[row].Length - 1; col++)
                    {
                        long a = triangle[row - 1][col - 1];
                        long b = triangle[row - 1][col];
                        triangle[row][col] = a + b;
                    }
                }
            }

            for (int row = 0; row < triangle.Length; row++)
            {
                Console.WriteLine(string.Join(" ", triangle[row]));
            }
        }
    }
}