namespace PrimaryDiagonal
{
    using System;
    using System.Linq;

    public class Diagonal
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];
            for (int row = 0; row < size; row++)
            {
                int[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            int diagonalSum = 0;
            int index = 0;
            while (index < matrix.GetLength(0))
            {
                int value = matrix[index, index];
                diagonalSum += value;
                index++;
            }

            Console.WriteLine(diagonalSum);
        }
    }
}