namespace Vacation
{
    using System;
    public class VacationMain
    {
        public static void Main(string[] args)
        {
            int days = 0;
            bool isSpend = false;
            int daysSpend = 0;
            double tripPrice = double.Parse(Console.ReadLine());
            double money = double.Parse(Console.ReadLine());
            while (money < tripPrice)
            {
                String operation = Console.ReadLine();
                double price = double.Parse(Console.ReadLine());
                days++;
                if (operation == "spend")
                {
                    daysSpend++;
                    money -= price;
                    if (money < 0)
                    {
                        money = 0;
                    }

                    if (daysSpend == 5)
                    {
                        isSpend = true;
                        break;
                    }

                }
                else
                {
                    daysSpend = 0;
                    money += price;
                }
            }

            if (isSpend)
            {
                Console.WriteLine($"You can't save the money.{Environment.NewLine}{days}");
            }
            else
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }
        }
    }
}
