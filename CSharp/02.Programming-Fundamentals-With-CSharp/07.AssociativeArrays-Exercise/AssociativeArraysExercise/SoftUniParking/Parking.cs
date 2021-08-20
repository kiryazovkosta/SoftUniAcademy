namespace SoftUniParking
{
    #region Using

    using System;
    using System.Collections.Generic;

    #endregion

    internal class Parking
    {
        private static void Main(string[] args)
        {
            int commandsNumber = int.Parse(Console.ReadLine());

            Dictionary<string, string> users = new Dictionary<string, string>();
            for (int i = 0; i < commandsNumber; i++)
            {
                string[] operation = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = operation[0];
                string user = operation[1];

                switch (command)
                {
                    case "register":
                        string number = operation[2];
                        if (users.ContainsKey(user))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {users[user]}");
                        }
                        else
                        {
                            users.Add(user, number);
                            Console.WriteLine($"{user} registered {number} successfully");
                        }
                        break;

                    case "unregister":
                        if (users.ContainsKey(user))
                        {
                            Console.WriteLine($"{user} unregistered successfully");
                            users.Remove(user);
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: user {user} not found");
                        }
                        break;
                }
            }

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}