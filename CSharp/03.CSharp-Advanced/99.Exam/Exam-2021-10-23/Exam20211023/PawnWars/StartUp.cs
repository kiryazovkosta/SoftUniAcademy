namespace PawnWars
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int whitePawnRow = 0;
            int whitePawnCol = 0;
            int blackPawnRow = 0;
            int blackPawnCol = 0;

            char[,] matrix = new char[8, 8];
            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
                {
                    matrix[rowIndex, colIndex] = row[colIndex];
                    if (row[colIndex] == 'w')
                    {
                        whitePawnRow = rowIndex;
                        whitePawnCol = colIndex;
                    }
                    else if (row[colIndex] == 'b')
                    {
                        blackPawnRow = rowIndex;
                        blackPawnCol = colIndex;
                    }
                }
            }

            bool whiteCapture = false;
            bool blackCapture = false;
            int winRow = -1;
            int winCol = -1;

            bool whiteWin = false;
            bool blackWin = false;

            while (true)
            {
                // move white
                matrix[whitePawnRow, whitePawnCol] = '-';
                if (whitePawnRow == 0)
                {
                    whiteWin = true;
                    break;
                }
                else
                {
                    if (whitePawnCol == 0)
                    {
                        if (matrix[whitePawnRow - 1, whitePawnCol + 1] == 'b')
                        {
                            whiteCapture = true;
                            winRow = whitePawnRow - 1;
                            winCol = whitePawnCol + 1;
                            break;
                        }
                    }
                    else if (whitePawnCol == matrix.GetLength(1) - 1)
                    {
                        if (matrix[whitePawnRow - 1, whitePawnCol - 1] == 'b')
                        {
                            whiteCapture = true;
                            winRow = whitePawnRow - 1;
                            winCol = whitePawnCol - 1;
                            break;
                        }
                    }
                    else
                    {
                        if (matrix[whitePawnRow - 1, whitePawnCol + 1] == 'b')
                        {
                            whiteCapture = true;
                            winRow = whitePawnRow - 1;
                            winCol = whitePawnCol + 1;
                            break;
                        }
                        else if (matrix[whitePawnRow - 1, whitePawnCol - 1] == 'b')
                        {
                            whiteCapture = true;
                            winRow = whitePawnRow - 1;
                            winCol = whitePawnCol - 1;
                            break;
                        }
                    }

                    whitePawnRow--;
                    matrix[whitePawnRow, whitePawnCol] = 'w';
                }


                // move black
                matrix[blackPawnRow, blackPawnCol] = '-';
                if (blackPawnRow == matrix.GetLength(1) - 1)
                {
                    blackWin = true;
                    break;
                }
                else
                {
                    if (blackPawnCol == 0)
                    {
                        if (matrix[blackPawnRow + 1, blackPawnCol + 1] == 'w')
                        {
                            blackCapture = true;
                            winRow = blackPawnRow + 1;
                            winCol = blackPawnCol + 1;
                            break;
                        }
                    }
                    else if (blackPawnCol == matrix.GetLength(1) - 1)
                    {
                        if (matrix[blackPawnRow + 1, blackPawnCol - 1] == 'w')
                        {
                            blackCapture = true;
                            winRow = blackPawnRow + 1;
                            winCol = blackPawnCol - 1;
                            break;
                        }
                    }
                    else
                    {
                        if (matrix[blackPawnRow + 1, blackPawnCol + 1] == 'w')
                        {
                            blackCapture = true;
                            winRow = blackPawnRow - 1;
                            winCol = blackPawnCol + 1;
                            break;
                        }
                        else if (matrix[blackPawnRow + 1, blackPawnCol - 1] == 'w')
                        {
                            blackCapture = true;
                            winRow = blackPawnRow + 1;
                            winCol = blackPawnCol - 1;
                            break;
                        }
                    }

                    blackPawnRow++;
                    matrix[blackPawnRow, blackPawnCol] = 'b';
                }
            }

            if (whiteWin)
            {
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(97 + whitePawnCol)}8.");
            }
            else if (blackWin)
            {
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(97 + blackPawnCol)}1.");
            }
            if (whiteCapture)
            {
                Console.WriteLine($"Game over! White capture on {(char)(97 + winCol)}{8 - winRow}.");
            }
            else if (blackCapture)
            {
                Console.WriteLine($"Game over! Black capture on {(char)(97 + winCol)}{8 -winRow}.");
            }
        }
    }
}
