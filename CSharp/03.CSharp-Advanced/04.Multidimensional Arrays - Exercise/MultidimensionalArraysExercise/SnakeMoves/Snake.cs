namespace SnakeMoves
{
    using System;
    using System.Linq;

    public class Snake
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            char[,] matrix = new char[rows, cols];

            string text = Console.ReadLine();
            int index = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2  == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        index = FillCell(matrix, text, index, row, col);
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        index = FillCell(matrix, text, index, row, col);
                    }
                }
            }

            Print(matrix);
        }

        private static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }

                Console.WriteLine();
            }
        }

        private static int FillCell(char[,] matrix, string text, int index, int row, int col)
        {
            matrix[row, col] = text[index];
            index++;
            if (index >= text.Length)
            {
                index = 0;
            }

            return index;
        }
    }
}
