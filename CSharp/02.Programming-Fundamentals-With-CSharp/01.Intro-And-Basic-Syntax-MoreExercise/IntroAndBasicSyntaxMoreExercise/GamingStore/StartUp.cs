using System;

namespace GamingStore
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(balance)));
            string input = Console.ReadLine();
            bool hasBalance = true;
            double totalSpent = 0;
            while (input != "Game Time")
            {
                string game = input;
                double price = 0;
                switch (game)
                {
                    case "OutFall 4":
                    case "RoverWatch Origins Edition":
                        price = 39.99;
                        break;
                    case "CS: OG":
                        price = 15.99;
                        break;
                    case "Zplinter Zell":
                        price = 19.99;
                        break;
                    case "Honored 2":
                        price = 59.99;
                        break;
                    case "RoverWatch":
                        price = 29.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                }

                if (price > 0)
                {
                    if (balance >= price)
                    {
                        Console.WriteLine($"Bought {game}");
                        balance -= price;
                        totalSpent += price;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }

                if (balance <= 0)
                {
                    Console.WriteLine("Out of money!");
                    hasBalance = false;
                    break;
                }

                input = Console.ReadLine();
            }

            if (hasBalance)
            {
                Console.WriteLine($"Total spent: ${totalSpent:F2}. Remaining: ${balance:F2}");
            }
        }
    }
}
