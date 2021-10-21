using System;

namespace ReVolt
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int playerRow = 0;
            int playerCol = 0;

            int n = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());

            char[,] board = new char[n, n];
            for (int rowIndex = 0; rowIndex < n; rowIndex++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int colIndex = 0; colIndex < currentRow.Length; colIndex++)
                {
                    board[rowIndex, colIndex] = currentRow[colIndex];
                    if (currentRow[colIndex] == 'f')
                    {
                        playerRow = rowIndex;
                        playerCol = colIndex;
                    }
                }
            }

            bool isWinner = false;

            for (int commandIndex = 0; commandIndex < commandsCount; commandIndex++)
            {
                string command = Console.ReadLine();

                board[playerRow, playerCol] = '-';

                MovePlayer(command, ref playerRow, board, ref playerCol);

                if (board[playerRow, playerCol] == 'B')
                {
                    MovePlayer(command, ref playerRow, board, ref playerCol);
                }
                else if (board[playerRow, playerCol] == 'T')
                {
                    if (command == "up")
                    {
                        command = "down";
                    }
                    else if (command == "down")
                    {
                        command = "up";
                    }
                    else if (command == "left")
                    {
                        command = "right";
                    }
                    else if (command == "right")
                    {
                        command = "left";
                    }

                    MovePlayer(command, ref playerRow, board, ref playerCol);
                }

                if (board[playerRow, playerCol] == 'F')
                {
                    isWinner = true;
                    board[playerRow, playerCol] = 'f';
                    break;
                }

                board[playerRow, playerCol] = 'f';
            }

            if (isWinner)
            {
                Console.WriteLine($"Player won!");
            }
            else
            {
                Console.WriteLine($"Player lost!");
            }

            Print(board);
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

        private static void MovePlayer(string command, ref int playerRow, char[,] board, ref int playerCol)
        {
            if (command == "up")
            {
                if (playerRow - 1 < 0)
                {
                    playerRow = board.GetLength(0) - 1;
                }
                else
                {
                    playerRow--;
                }
            }
            else if (command == "down")
            {
                if (playerRow + 1 >= board.GetLength(0))
                {
                    playerRow = 0;
                }
                else
                {
                    playerRow++;
                }
            }
            else if (command == "left")
            {
                if (playerCol - 1 < 0)
                {
                    playerCol = board.GetLength(1) - 1;
                }
                else
                {
                    playerCol--;
                }
            }
            else if (command == "right")
            {
                if (playerCol + 1 >= board.GetLength(1))
                {
                    playerCol = 0;
                }
                else
                {
                    playerCol++;
                }
            }
        }
    }
}
