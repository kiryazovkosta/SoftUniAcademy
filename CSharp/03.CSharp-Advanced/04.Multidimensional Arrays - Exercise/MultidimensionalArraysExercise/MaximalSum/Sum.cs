namespace MaximalSum
{
    using System;
    using System.Linq;

    class Sum
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            long maxSum = long.MinValue;
            int maxRow = 0;
            int maxCol = 0;
            int square = 3;
            GetMaxSquare(matrix, ref maxSum, ref maxRow, ref maxCol, square);
            Console.WriteLine($"Sum = {maxSum}");
            PrintMatrix(matrix, square, maxRow, maxCol);
        }

        private static void PrintMatrix(int[,] matrix, int square, int maxRow, int maxCol)
        {
            for (int row = maxRow; row < maxRow + square; row++)
            {
                for (int col = maxCol; col < maxCol + square; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        private static void GetMaxSquare(int[,] matrix, ref long maxSum, ref int maxRow, ref int maxCol, int square)
        {
            for (int row = 0; row < matrix.GetLength(0) - square + 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - square + 1; col++)
                {
                    long sum = 0;
                    for (int squareRow = row; squareRow < row + square; squareRow++)
                    {
                        for (int squareCol = col; squareCol < col + square; squareCol++)
                        {
                            sum += matrix[squareRow, squareCol];
                        }
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
        }
    }
}