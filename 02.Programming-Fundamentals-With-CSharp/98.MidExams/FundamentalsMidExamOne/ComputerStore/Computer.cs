namespace ComputerStore
{
    #region Using

    using System;

    #endregion

    public class Computer
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var totalPrice = 0.0;

            while (input != "special" && input != "regular")
            {
                var price = double.Parse(input);
                if (price <= 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else
                {
                    totalPrice += price;
                }

                input = Console.ReadLine();
            }

            if (totalPrice > 0)
            {
                var taxes = totalPrice * 0.2;
                var total = totalPrice + taxes;
                if (input == "special")
                {
                    total -= (total * 0.1);
                }

                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPrice:F2}$");
                Console.WriteLine($"Taxes: {taxes:F2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {total:F2}$");
            }
            else
            {
                Console.WriteLine("Invalid order!");
            }
        }
    }
}