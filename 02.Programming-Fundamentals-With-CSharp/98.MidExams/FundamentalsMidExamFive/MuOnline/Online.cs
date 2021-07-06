// ------------------------------------------------------------------------------------------------
//  <copyright file="Online.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace MuOnline
{
    #region Using

    using System;

    #endregion

    public class Online
    {
        private static void Main(string[] args)
        {
            int health = 100;
            int bitcoins = 0;

            string[] rooms = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < rooms.Length; i++)
            {
                string[] operation = rooms[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = operation[0];
                int value = int.Parse(operation[1]);
                switch (command)
                {
                    case "potion":
                        if (health + value <= 100)
                        {
                            Console.WriteLine($"You healed for {value} hp.");
                        }
                        else
                        {
                            Console.WriteLine($"You healed for {100- health} hp.");
                        }


                        
                        health += value;
                        if (health > 100)
                        {
                            health = 100;
                        }

                        Console.WriteLine($"Current health: {health} hp.");
                        break;

                    case "chest":
                        bitcoins += value;
                        Console.WriteLine($"You found {value} bitcoins.");
                        break;

                    default:
                        health -= value;
                        if (health > 0)
                        {
                            Console.WriteLine($"You slayed {command}.");
                        }
                        else
                        {
                            Console.WriteLine($"You died! Killed by {command}.");
                            Console.WriteLine($"Best room: {i + 1}");
                        }
                        break;
                }

                if (health <= 0)
                {
                    break;
                }
            }

            if (health > 0)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}