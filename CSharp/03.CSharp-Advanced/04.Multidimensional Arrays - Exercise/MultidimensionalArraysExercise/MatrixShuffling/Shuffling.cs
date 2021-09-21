namespace MatrixShuffling
{
    using System;
    using System.Linq;

    public class Shuffling
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

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] command = input.Split(" ");
                if (IsValid(command, rows, cols))
                {
                    int r1 = int.Parse(command[1]);
                    int c1 = int.Parse(command[2]);
                    int r2 = int.Parse(command[3]);
                    int c2 = int.Parse(command[4]);

                    int temp = matrix[r1, c1];
                    matrix[r1, c1] = matrix[r2, c2];
                    matrix[r2, c2] = temp;
                    Print(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                input = Console.ReadLine();
            }
        }

        private static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsValid(string[] command, int rows, int cols)
        {
            bool isValid = true;
            if (command.Length != 5)
            {
                return false;
            }

            if (command[0] != "swap")
            {
                return false;
            }

            int r1 = int.Parse(command[1]);
            int c1 = int.Parse(command[2]);
            int r2 = int.Parse(command[3]);
            int c2 = int.Parse(command[4]);

            if (r1 < 0 || r1 >= rows || c1 < 0 || c1 >= cols
                || r2 < 0 || r2 >= rows || c2 < 0 || c2 >= cols
                )
            {
                return false;
            }

            return isValid;
        }
    }
}
