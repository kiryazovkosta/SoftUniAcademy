using System;

namespace TheBattleOfTheFiveArmies
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            int armyRow = 0;
            int armyCol = 0;

            char[][] board = new char[rows][];
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                var line = Console.ReadLine();
                board[rowIndex] = line.ToCharArray();
                var colIndex = line.IndexOf('A');
                if (colIndex >= 0)
                {
                    armyRow = rowIndex;
                    armyCol = colIndex;
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split(' ');
                string dirrection = command[0];
                int orcRow = int.Parse(command[1]);
                int orcCol = int.Parse(command[2]);

                board[orcRow][orcCol] = 'O';
                armor--;
                board[armyRow][armyCol] = '-';
                if (dirrection == "up" && armyRow - 1 >= 0)
                {
                    armyRow--;
                }
                else if (dirrection == "down" && armyRow + 1 < rows)
                {
                    armyRow++;
                }
                else if (dirrection == "left" && armyCol - 1 >= 0)
                {
                    armyCol--;
                }
                else if (dirrection == "right" && armyCol + 1 < board[armyRow].Length)
                {
                    armyCol++;
                }

                if (board[armyRow][armyCol] == 'O')
                {
                    armor -= 2;
                }

                if (board[armyRow][armyCol] == 'M')
                {
                    board[armyRow][armyCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    break;
                }

                if (armor <= 0)
                {
                    board[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    break;
                }

                board[armyRow][armyCol] = 'A';
            }

            for (int rowIndex = 0; rowIndex < board.GetLength(0); rowIndex++)
            {
                Console.WriteLine(string.Join(string.Empty, board[rowIndex]));
            }

        }
    }
}
