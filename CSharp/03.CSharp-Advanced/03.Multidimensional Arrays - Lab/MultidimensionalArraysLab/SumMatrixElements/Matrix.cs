namespace SumMatrixElements
{
    using System;
    using System.Linq;

    public class Matrix
    {
        public static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rowsNumber = dimensions[0];
            int colsNumber = dimensions[1];

            int[,] matrix = new int[rowsNumber, colsNumber];
            for (int rows = 0; rows < rowsNumber; rows++)
            {
                int[] values = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int cols = 0; cols < colsNumber; cols++)
                {
                    matrix[rows, cols] = values[cols];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            long sum = 0;
            foreach (int number in matrix)
            {
                sum += number;
            }
            Console.WriteLine(sum);
        }
    }
}
