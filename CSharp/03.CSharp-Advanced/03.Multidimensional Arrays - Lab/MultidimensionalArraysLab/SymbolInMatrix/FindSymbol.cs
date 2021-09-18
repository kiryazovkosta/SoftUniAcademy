namespace SymbolInMatrix
{
    using System;

    public class FindSymbol
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            
            bool notFound = true;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        notFound = false;
                        break;
                    }
                }

                if (notFound == false)
                {
                    break;
                }
            }

            if (notFound)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}