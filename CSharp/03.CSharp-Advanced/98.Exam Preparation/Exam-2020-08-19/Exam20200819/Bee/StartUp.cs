namespace Bee
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int beeRow = 0;
            int beeCol = 0;
            int flowers = 0;
            bool isLost = false;

            var board = ReadBoardFromConsole(n, ref beeRow, ref beeCol);

            string command = Console.ReadLine();
            while (command != "End" /*&& flowers < 5*/)
            {
                board[beeRow, beeCol] = '.';

                isLost = ValidateDirection(command, board, ref beeRow, ref beeCol);
                if (isLost)
                {
                    break;
                }

                if (board[beeRow, beeCol] == 'f')
                {
                    flowers++;
                }
                else if (board[beeRow, beeCol] == 'O')
                {
                    board[beeRow, beeCol] = '.';
                    isLost = ValidateDirection(command, board, ref beeRow, ref beeCol);
                    if (isLost)
                    {
                        break;
                    }

                    if (board[beeRow, beeCol] == 'f')
                    {
                        flowers++;
                    }
                }

                board[beeRow, beeCol] = 'B';
                command = Console.ReadLine();
            }

            if (isLost)
            {
                Console.WriteLine($"The bee got lost!");
            }

            Console.WriteLine(flowers >= 5
                ? $"Great job, the bee managed to pollinate {flowers} flowers!"
                : $"The bee couldn't pollinate the flowers, she needed {5 - flowers} flowers more");

            Print(board);

        }

        private static bool ValidateDirection(string command, char[,] board, ref int beeRow, ref int beeCol)
        {
            bool isLost = false;
            if (command == "up")
            {
                if (beeRow - 1 < 0)
                {
                    isLost = true;
                }

                beeRow--;
            }
            else if (command == "down")
            {
                if (beeRow + 1 >= board.GetLength(0))
                {
                    isLost = true;
                }

                beeRow++;
            }
            else if (command == "right")
            {
                if (beeCol + 1 >= board.GetLength(1))
                {
                    isLost = true;
                }

                beeCol++;
            }
            else if (command == "left")
            {
                if (beeCol - 1 < 0)
                {
                    isLost = true;
                }

                beeCol--;
            }

            return isLost;
        }

        private static void Print(char[,] board)
        {
            for (int rowIndex = 0; rowIndex < board.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < board.GetLength(1); colIndex++)
                {
                    Console.Write(board[rowIndex, colIndex]);
                }

                Console.WriteLine();
            }
        }

        private static char[,] ReadBoardFromConsole(int n, ref int beeRow, ref int beeCol)
        {
            char[,] board = new char[n, n];
            for (int rowIndex = 0; rowIndex < board.GetLength(0); rowIndex++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int colIndex = 0; colIndex < board.GetLength(1); colIndex++)
                {
                    board[rowIndex, colIndex] = row[colIndex];
                    if (row[colIndex] == 'B')
                    {
                        beeRow = rowIndex;
                        beeCol = colIndex;
                    }
                }
            }

            return board;
        }
    }
}
