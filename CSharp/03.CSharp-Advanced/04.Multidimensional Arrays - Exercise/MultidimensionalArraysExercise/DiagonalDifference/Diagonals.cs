namespace DiagonalDifference
{
    using System;
    public class Diagonals
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = int.Parse(elements[col]);
                }
            }

            long diagonal = CalculateDiagonalSum(matrix);
            long antidiagonal = CalculateAntidiagonalSum(matrix);

            Console.WriteLine(Math.Abs(diagonal - antidiagonal));
        }

        private static long CalculateDiagonalSum(int[,] matrix)
        {
            long sum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = row; col <= row; col++)
                {
                    sum += matrix[row, col];
                }
            }

            return sum;
        }

        private static long CalculateAntidiagonalSum(int[,] matrix)
        {
            long sum = 0;
            for (int row = 0, col = matrix.GetLength(1) - 1; row < matrix.GetLength(0); row++, col--)
            {
                sum += matrix[row, col];
            }

            return sum;
        }
    }
}