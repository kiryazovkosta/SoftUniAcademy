namespace Supermarket
{
    using System;
    using System.Collections.Generic;

    public class Remaining
    {
        public static void Main(string[] args)
        {
            Queue<string> users = new Queue<string>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                if (input == "Paid")
                {
                    while (users.Count > 0)
                    {
                        string user = users.Dequeue();
                        Console.WriteLine(user);
                    }
                }
                else
                {
                    string user = input;
                    users.Enqueue(user);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{users.Count} people remaining.");
        }
    }
}