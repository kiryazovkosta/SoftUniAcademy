using System;
using System.Linq;

namespace Warships
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] board = new string[size, size];

            int playerOneShips = 0;
            int playerTwoShips = 0;

            int playerOneHits = 0;
            int playerTwoHits = 0;

            string[] commands = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < board.GetLength(1); i++)
            {
                string[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < rowData.GetLength(0); j++)
                {
                    board[i, j] = rowData[j];
                    if (rowData[j] == "<")
                    {
                        playerOneShips++;
                    }
                    else if (rowData[j] == ">")
                    {
                        playerTwoShips++;
                    }
                }
            }

            for (int i = 0; i < commands.Length; i++)
            {
                int[] coordinates = commands[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int row = coordinates[0];
                int col = coordinates[1];

                if (row < 0 || row >= board.GetLength(0) || col < 0 || col >= board.GetLength(1))
                {
                    continue;
                }

                string position = board[row, col];
                if (position == "*" || position == "X")
                {
                    continue;
                }

                if (position == "#")
                {
                    board[row, col] = "X";
                    for (int j = row - 1; j <= row + 1; j++)
                    {
                        for (int k = col - 1; k <= col + 1; k++)
                        {
                            if (j < 0 || j >= board.GetLength(0) || k < 0 || k >= board.GetLength(1))
                            {
                                continue;
                            }

                            string location = board[j, k];
                            if (location == ">")
                            {
                                playerTwoHits++;
                                board[j, k] = "X";
                            }
                            else if (location == "<")
                            {
                                playerOneHits++;
                                board[j, k] = "X";
                            }
                        }
                    }
                }
                else if (position == ">")
                {
                    playerTwoHits++;
                    board[row, col] = "X";
                }
                else if (position == "<")
                {
                    playerOneHits++;
                    board[row, col] = "X";
                }

                if (playerOneShips == playerOneHits || playerTwoShips == playerTwoHits)
                {
                    break;
                }

            }

            if (playerOneShips > playerOneHits && playerTwoShips == playerTwoHits)
            {
                Console.WriteLine($"Player One has won the game! {playerOneHits + playerTwoHits} ships have been sunk in the battle.");
            }
            else if (playerTwoShips > playerTwoHits && playerOneShips == playerOneHits)
            {
                Console.WriteLine($"Player Two has won the game! {playerOneHits + playerTwoHits} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShips - playerOneHits} ships left. Player Two has {playerTwoShips - playerTwoHits} ships left.");
            }
        }
    }
}
