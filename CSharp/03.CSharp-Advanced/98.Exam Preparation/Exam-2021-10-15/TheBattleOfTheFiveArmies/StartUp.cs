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
            var battleGroud = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                battleGroud[i] = rowData;

                for (int j = 0; j < battleGroud[i].Length; j++)
                {
                    if (rowData[j] == 'A')
                    {
                        armyRow = i;
                        armyCol = j;
                    }
                }
            }

            while (true)
            {
                string[] commandData = Console.ReadLine().Split(" ");
                string command = commandData[0];
                int orcRow = int.Parse(commandData[1]);
                int orcCol = int.Parse(commandData[2]);

                armor--;
                battleGroud[orcRow][orcCol] = 'O';
                battleGroud[armyRow][armyCol] = '-';

                if (command == "up" && armyRow - 1 >= 0)
                {
                    armyRow--;
                }
                else if (command == "down" && armyRow + 1 < rows)
                {
                    armyRow++;
                }
                else if (command == "left" && armyCol - 1 >= 0)
                {
                    armyCol--;
                }
                else if (command == "right" && armyCol + 1 < battleGroud[armyRow].Length)
                {
                    armyCol++;
                }

                if (battleGroud[armyRow][armyCol] == 'O')
                {
                    armor -= 2;
                }

                if (battleGroud[armyRow][armyCol] == 'M')
                {
                    battleGroud[armyRow][armyCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    break;
                }

                if (armor <= 0)
                {
                    battleGroud[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    break;
                }

                battleGroud[armyRow][armyCol] = 'A';
            }

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(new string(battleGroud[i]));
            }
        }
    }
}
