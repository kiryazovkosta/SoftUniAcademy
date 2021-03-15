using System;

namespace FuelTankPartTwo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double gasPrice = 0.93;
            double gasolinePrice = 2.22;
            double dieselPrice = 2.33;

            string fuel = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            string hasDiscount = Console.ReadLine();

            if (hasDiscount == "Yes")
            {
                gasPrice -= 0.08;
                gasolinePrice -= 0.18;
                dieselPrice -= 0.12;
            }

            double totalPrice = 0;
            switch (fuel)
            {
                case "Gas":
                    totalPrice = quantity * gasPrice;
                    break;

                case "Gasoline":
                    totalPrice = quantity * gasolinePrice;
                    break;

                case "Diesel":
                    totalPrice = quantity * dieselPrice;
                    break;

                default:
                    break;
            }

            if (quantity > 25)
            {
                totalPrice = totalPrice - (totalPrice * 0.1);
            }
            else if (quantity >= 20 && quantity <= 25)
            {
                totalPrice = totalPrice - (totalPrice * 0.08);
            }

            Console.WriteLine($"{totalPrice:F2} lv.");
        }
    }
}
