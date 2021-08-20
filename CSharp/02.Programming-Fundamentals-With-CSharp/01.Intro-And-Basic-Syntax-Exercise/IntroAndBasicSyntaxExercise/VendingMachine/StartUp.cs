namespace VendingMachine
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double amount = 0.0;
            string input = Console.ReadLine();
            while (input != "Start")
            {
                double coin = double.Parse(input ?? throw new ArgumentException(nameof(coin)));
                switch (coin)
                {
                    case 0.1:
                    case 0.2:
                    case 0.5:
                    case 1:
                    case 2:
                        amount += coin;
                        break;

                    default:
                        Console.WriteLine($"Cannot accept {coin}");
                        break;
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                string product = input;
                double productPrice = 0.0;
                switch (product)
                {
                    case "Nuts":
                        productPrice = 2.0;
                        break;
                    case "Water":
                        productPrice = 0.7;
                        break;
                    case "Crisps":
                        productPrice = 1.5;
                        break;
                    case "Soda":
                        productPrice = 0.8;
                        break;
                    case "Coke":
                        productPrice = 1.0;
                        break;
                    default:
                        break;
                }

                if (productPrice > 0)
                {
                    if (amount >= productPrice)
                    {
                        Console.WriteLine($"Purchased {product.ToLower()}");
                        amount -= productPrice;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Change: {amount:F2}");
        }
    }
}
